using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;//new 
using System.Data.SqlClient;//new 

namespace Vistas
{
    public partial class DireccionesCliente : Form
    {
        ConexionSQLN cn = new ConexionSQLN();//negocios
        Class_Entidad obje = new Class_Entidad();//entidad
        DataSet dsTabla;

        int VarPagInicio = 1;
        // int VarPagIndice = 0;
        int TotalFilasAMostrar = 2;
        int VarPagFinal;

        //conexio a mi base de datos
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int start;

        int idventas; 
        int idDireccioCliente;

        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_listar_Parcelas(obje);

            //dataGridView1.DataSource = dsTabla.Tables[1];
            txtCantidadTotal.Text = dsTabla.Tables[0].Rows[0][0].ToString();

            int cantidad = Convert.ToInt32(dsTabla.Tables[0].Rows[0][0].ToString()) / TotalFilasAMostrar;
            //comboBox2.Items.Clear();

            if (Convert.ToInt32(dsTabla.Tables[0].Rows[0][0].ToString()) % TotalFilasAMostrar > 0)
            {
                cantidad += 1;
            }

            textBox3.Text = cantidad.ToString();

        }
        private void loadData()
        {
            //Variable de Cantiada a mostrar
            // int numMostra = (int.Parse(txt_DatosaMostar.Text));


            SqlCommand cmd;
            string sql = "select SalesDireccionesCliente.idDireccion, SalesDireccionesCliente.calle,SalesDireccionesCliente.numero,SalesDireccionesCliente.colonia,SalesDireccionesCliente.codigoPostal,SalesDireccionesCliente.tipo,SalesDireccionesCliente.idCliente,SalesClientes.nombre,SalesDireccionesCliente.idCiudad,Ciudades.nombre from SalesDireccionesCliente JOIN SalesClientes ON SalesClientes.idCliente = SalesDireccionesCliente.idCliente JOIN Ciudades ON Ciudades.idCiudad = SalesDireccionesCliente.idCiudad";
                

            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            //fill dataser
            adapter.Fill(ds, start, 2, "SalesDireccionesCliente");
            //DGVIEW
            dataGridView1.DataSource = ds.Tables[0];
            //habilita Boton 
            btn_atras.Enabled = false;


        }

        public void Cargar_Datos_clienteNombre()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select nombre from SalesClientes";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_idcliente.Items.Add(dr["nombre"].ToString());
                Cb_idcliente.DisplayMember = (dr["nombre"].ToString());
                Cb_idcliente.ValueMember = (dr["nombre"].ToString());
            }

        }

        public void Cargar_Datos_Ciudades_Nombre()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select nombre from Ciudades";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_idCiudad.Items.Add(dr["nombre"].ToString());
                Cb_idCiudad.DisplayMember = (dr["nombre"].ToString());
                Cb_idCiudad.ValueMember = (dr["nombre"].ToString());
            }

        }









        public DireccionesCliente()
        {
            InitializeComponent();
            //dataGridViewDireccionesC.DataSource = cn.ConsultaDireccionCliente();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            start = 0;
            loadData();
            Cargar_Datos_clienteNombre();
            Cargar_Datos_Ciudades_Nombre();

            idventas = 0;
            idDireccioCliente = 0;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
           
            txtiddireccion.Text = "";
            txtcalle.Text = "";
            txtnumero.Text = "";
            txtcolonia.Text = "";
            txtcp.Text = "";
            Cb_Estatus.SelectedIndex = -1;
            Cb_idcliente.SelectedIndex = -1;
            Cb_idCiudad.SelectedIndex = -1;

            txt_idCliente.Text = "";
            txt_idCiudad.Text = "";

            ds.Clear();
            loadData();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcalle.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtcolonia.Text) || string.IsNullOrEmpty(txtcp.Text) || string.IsNullOrEmpty(Cb_idcliente.Text) || string.IsNullOrEmpty(Cb_idCiudad.Text))
            {
                MessageBox.Show("Falta seleccionar la direccion para Eliminar!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_idcliente.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Cliente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idCiudad.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Ciudad !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_Estatus.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Estatus !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                //string Estatus = Cb_Estatus.SelectedItem.ToString();
                Cb_Estatus.Text = "I";

                cn.modificarDireccionCliente(txtiddireccion.Text, txtcalle.Text, txtnumero.Text, txtcolonia.Text, txtcp.Text, Cb_Estatus.Text, txt_idCliente.Text, txt_idCiudad.Text);
                //dataGridViewDireccionesC.DataSource = cn.ConsultaDireccionCliente();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();


                txtiddireccion.Text = "";
                txtcalle.Text = "";
                txtnumero.Text = "";
                txtcolonia.Text = "";
                txtcp.Text = "";
                Cb_Estatus.SelectedIndex = -1;
                Cb_idcliente.SelectedIndex = -1;
                Cb_idCiudad.SelectedIndex = -1;

                txt_idCliente.Text = "";
                txt_idCiudad.Text = "";
                MessageBox.Show("Eliminado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Eliminar los datos!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcalle.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtcolonia.Text) || string.IsNullOrEmpty(txtcp.Text) || string.IsNullOrEmpty(Cb_idcliente.Text) || string.IsNullOrEmpty(Cb_idCiudad.Text))
            {
                MessageBox.Show("Falta seleccionar la direccion para Actualizar!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_idcliente.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Cliente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idCiudad.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Ciudad !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_Estatus.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Estatus !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();

                cn.modificarDireccionCliente(txtiddireccion.Text, txtcalle.Text, txtnumero.Text, txtcolonia.Text, txtcp.Text, Estatus, txt_idCliente.Text, txt_idCiudad.Text);
                //dataGridViewDireccionesC.DataSource = cn.ConsultaDireccionCliente();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();


                txtiddireccion.Text = "";
                txtcalle.Text = "";
                txtnumero.Text = "";
                txtcolonia.Text = "";
                txtcp.Text = "";
                Cb_Estatus.SelectedIndex = -1;
                Cb_idcliente.SelectedIndex = -1;
                Cb_idCiudad.SelectedIndex = -1;

                txt_idCliente.Text = "";
                txt_idCiudad.Text = "";
                MessageBox.Show("Actualizados Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Editar los datos!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcalle.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtcolonia.Text) || string.IsNullOrEmpty(txtcp.Text) || string.IsNullOrEmpty(Cb_idcliente.Text) || string.IsNullOrEmpty(Cb_idCiudad.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_idcliente.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Cliente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idCiudad.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Ciudad !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_Estatus.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Estatus !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (txtcp.Text.Length > 5 || txtcp.Text.Length < 5)
            {
                MessageBox.Show("Codigo Postal debe tener 5 digitos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                if (idventas == idDireccioCliente)
                {
                    MessageBox.Show("Error Ya Existe esa Venta en la Tabla!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtiddireccion.Text = "";
                    txtcalle.Text = "";
                    txtnumero.Text = "";
                    txtcolonia.Text = "";
                    txtcp.Text = "";
                    Cb_Estatus.SelectedIndex = -1;
                    Cb_idcliente.SelectedIndex = -1;
                    Cb_idCiudad.SelectedIndex = -1;

                    txt_idCliente.Text = "";
                    txt_idCiudad.Text = "";

                }
                else if (string.IsNullOrEmpty(txtiddireccion.Text))
                {
                    string Estatus = Cb_Estatus.SelectedItem.ToString();

                    cn.insertarDireccionCliente(txtcalle.Text, txtnumero.Text, txtcolonia.Text, txtcp.Text, Estatus, txt_idCliente.Text, txt_idCiudad.Text);
                    //dataGridViewDireccionesC.DataSource = cn.ConsultaDireccionCliente();
                    ds.Clear();
                    loadData();
                    VarPagFinal = TotalFilasAMostrar;
                    Mostrar_datos();


                    //txtiddireccion.Text = "";
                    txtcalle.Text = "";
                    txtnumero.Text = "";
                    txtcolonia.Text = "";
                    txtcp.Text = "";
                    Cb_Estatus.SelectedIndex = -1;
                    Cb_idcliente.SelectedIndex = -1;
                    Cb_idCiudad.SelectedIndex = -1;

                    txt_idCliente.Text = "";
                    txt_idCiudad.Text = "";
                    MessageBox.Show("Direccion del Cliente Agregada Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {

                    MessageBox.Show("Error al Guardar los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }

            }
        }
        

       

        private void txtiddireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcp_TextChanged(object sender, EventArgs e)
        {

        }

        

       

        private void txtiddireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtnumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtcp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtidcliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtidciudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtcalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO LETRAS!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtcolonia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO LETRAS!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                ds.Clear();
                loadData();
            }
            else
            {
                // string conexionstring = "server = DESKTOP-IP4QBPJ\\SQLEXPRESS; database = ERP;" +
                // "integrated security = true";
                SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
                con.Open();

                // SqlDataAdapter datos = new SqlDataAdapter("select SalesParcelas.idParcela, SalesParcelas.extension, SalesParcelas.idCliente, SalesParcelas.idCultivo, SalesParcelas.idDireccion, SalesParcelas.estatus, SalesClientes.nombre, SalesDireccionesCliente.calle, SalesDireccionesCliente.colonia, SalesCultivos.nombre from SalesParcelas  JOIN SalesClientes ON SalesParcelas.idCliente = SalesClientes.idCliente JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idCliente = SalesClientes.idCliente JOIN SalesCultivos ON SalesCultivos.idCultivo = SalesParcelas.idCultivo where " + this.comboBox1.Text+ " like '%" + this.textBox1.Text + "%'", con);

                SqlDataAdapter datos = new SqlDataAdapter("select SalesDireccionesCliente.idDireccion, SalesDireccionesCliente.calle,SalesDireccionesCliente.numero,SalesDireccionesCliente.colonia,SalesDireccionesCliente.codigoPostal,SalesDireccionesCliente.tipo,SalesDireccionesCliente.idCliente,SalesClientes.nombre,SalesDireccionesCliente.idCiudad,Ciudades.nombre from SalesDireccionesCliente JOIN SalesClientes ON SalesClientes.idCliente = SalesDireccionesCliente.idCliente JOIN Ciudades ON Ciudades.idCiudad = SalesDireccionesCliente.idCiudad  where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesDireccionesCliente");
                this.dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void DireccionesCliente_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void DireccionesCliente_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
        
        }

        private void Cb_idcliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select SalesDireccionesCliente.idDireccion,SalesClientes.idCliente from SalesClientes LEFT JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idCliente = SalesClientes.idCliente WHERE SalesClientes.nombre = '" + Cb_idcliente.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();

                txtiddireccion.Text = dr[0].ToString();
                txt_idCliente.Text = dr[1].ToString();


                if (string.IsNullOrEmpty(txtiddireccion.Text))
                {

                    txtiddireccion.Text = "";

                    string idCliente = this.txt_idCliente.Text;
                    idventas = Int32.Parse(idCliente);//combo de idventa

                }
                else
                {

                    string idCliente = this.txt_idCliente.Text;
                    idventas = Int32.Parse(idCliente);//combo de idventa

                    string idDireccio = this.txtiddireccion.Text;
                    idDireccioCliente = Int32.Parse(idDireccio);//textbox de idventadetale


                    

                }

            }

            con.Close();
        }

        private void Cb_idCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select idCiudad from Ciudades where nombre ='" + Cb_idCiudad.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idCiudad.Text = dr[0].ToString();
            }

            con.Close();
        }

        private void txt_DatosaMostar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_DatosaMostar.Text))
            {
                ds.Clear();
                loadData();
            }
            else
            {
                string id = txt_DatosaMostar.Text;
                int numMostar = Int32.Parse(id);
                ds.Clear();

                SqlCommand cmd;
                string sql = "select SalesDireccionesCliente.idDireccion, SalesDireccionesCliente.calle,SalesDireccionesCliente.numero,SalesDireccionesCliente.colonia,SalesDireccionesCliente.codigoPostal,SalesDireccionesCliente.tipo,SalesDireccionesCliente.idCliente,SalesClientes.nombre,SalesDireccionesCliente.idCiudad,Ciudades.nombre from SalesDireccionesCliente JOIN SalesClientes ON SalesClientes.idCliente = SalesDireccionesCliente.idCliente JOIN Ciudades ON Ciudades.idCiudad = SalesDireccionesCliente.idCiudad";
                    
                   

                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, numMostar, "SalesDireccionesCliente");
                //DGVIEW
                dataGridView1.DataSource = ds.Tables[0];
                //habilita Boton 
                btn_atras.Enabled = false;

            }
        }

        private void btn_adelante_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_DatosaMostar.Text))
            {
                int num = (int.Parse(txtCantidadTotal.Text));
                start = start + 2;
                btn_atras.Enabled = true;
                if (start > num)
                {
                    start = 0;
                }

                ds.Clear();
                adapter.Fill(ds, start, 2, "SalesDireccionesCliente");
            }
            else
            {

                string id = txt_DatosaMostar.Text;
                int numMostar = Int32.Parse(id);

                int num = (int.Parse(txtCantidadTotal.Text));
                start = start + numMostar;
                btn_atras.Enabled = true;
                if (start > num)
                {
                    start = 0;
                }

                ds.Clear();
                adapter.Fill(ds, start, numMostar, "SalesDireccionesCliente");
            }
        }

        private void btn_atras_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_DatosaMostar.Text))
            {
                start = start - 2;
                if (start < 0)
                {
                    start = 0;
                    btn_atras.Enabled = false;
                }
                ds.Clear();
                adapter.Fill(ds, start, 2, "SalesDireccionesCliente");
            }
            else
            {
                string id = txt_DatosaMostar.Text;
                int numMostar = Int32.Parse(id);
                start = start - numMostar;
                if (start < 0)
                {
                    start = 0;
                    btn_atras.Enabled = false;
                }
                ds.Clear();
                adapter.Fill(ds, start, numMostar, "SalesDireccionesCliente");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtiddireccion.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtcalle.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtnumero.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtcolonia.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtcp.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Cb_Estatus.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            Cb_idcliente.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            Cb_idCiudad.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }
    }
}
