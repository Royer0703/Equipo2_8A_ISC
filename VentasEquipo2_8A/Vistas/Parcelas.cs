using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios;
using Entidad;//new 
using System.Data.SqlClient;//new 

namespace Vistas
{
    public partial class Parcelas : Form
    {
        ConexionSQLN cn = new ConexionSQLN();//negocios
        Class_Entidad obje = new Class_Entidad();//entidad
        DataSet dsTabla;

        int VarPagInicio = 1;
       // int VarPagIndice = 0;
        int TotalFilasAMostrar = 2;
        int VarPagFinal;

        //conexio a mi base de datos
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPConexion);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int start;
        

        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_listar_Parcelas(obje);
           
            //dataGridView1.DataSource = dsTabla.Tables[1];
            txtCantidadTotal.Text = dsTabla.Tables[0].Rows[0][0].ToString();

            int cantidad = Convert.ToInt32(dsTabla.Tables[0].Rows[0][0].ToString()) /TotalFilasAMostrar;
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
            string sql = "select SalesParcelas.idParcela, SalesParcelas.extension, SalesParcelas.idCliente, SalesParcelas.idCultivo, SalesParcelas.idDireccion, SalesParcelas.estatus, SalesClientes.nombre, SalesDireccionesCliente.calle, SalesDireccionesCliente.colonia, SalesCultivos.nombre from SalesParcelas JOIN SalesClientes ON SalesParcelas.idCliente = SalesClientes.idCliente  JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idDireccion = SalesParcelas.idDireccion JOIN SalesCultivos ON SalesCultivos.idCultivo = SalesParcelas.idCultivo";

            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            //fill dataser
            adapter.Fill(ds, start, 2, "SalesParcelas");
            //DGVIEW
            dataGridView1.DataSource = ds.Tables[0];
            //habilita Boton 
            btn_atras.Enabled = false;


        }

        public void Cargar_Datos_clienteNombre()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPConexion);
            con.Open();
            string q = "select nombre from SalesClientes";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb_Cliente_Nombre.Items.Add(dr["nombre"].ToString());
                cb_Cliente_Nombre.DisplayMember = (dr["nombre"].ToString());
                cb_Cliente_Nombre.ValueMember = (dr["nombre"].ToString());
            }

        }


        public void Cargar_Datos_cultivosNombre()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPConexion);
            con.Open();
            string q = "select nombre from SalesCultivos";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb_cultivos_Nombre.Items.Add(dr["nombre"].ToString());
                cb_cultivos_Nombre.DisplayMember = (dr["nombre"].ToString());
                cb_cultivos_Nombre.ValueMember = (dr["nombre"].ToString());
            }

        }

        public void Cargar_Datos_direccionNombre()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPConexion);
            con.Open();
            string q = "select calle from SalesDireccionesCliente";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb_direccion_Nombre.Items.Add(dr["calle"].ToString());
                cb_direccion_Nombre.DisplayMember = (dr["calle"].ToString());
                cb_direccion_Nombre.ValueMember = (dr["calle"].ToString());
            }

        }



        public Parcelas()
        {
            InitializeComponent();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            dataGridView1.DataSource = cn.ConsultarJoinParcelasDT();
            start = 0;
            loadData();
            Cargar_Datos_clienteNombre();
            Cargar_Datos_cultivosNombre();
            Cargar_Datos_direccionNombre();
        }
       







        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            txt_idParcelas.Text = " ";
            txt_Extension.Text = " ";
            txt_idCliente.Text = " ";
            txt_idCultivo.Text = " ";
            txt_idDireccion.Text = " ";
            Cb_Estatus.SelectedIndex = -1;
            cb_Cliente_Nombre.SelectedIndex = -1;
            cb_cultivos_Nombre.SelectedIndex = -1;
            cb_direccion_Nombre.SelectedIndex = -1;
            //dataGridView1.DataSource = cn.ConsultaParcelasDT();
            ds.Clear();
            loadData();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
          
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_idParcelas.Text) || string.IsNullOrEmpty(txt_Extension.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Estatus !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if(cb_Cliente_Nombre.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Nombre del Cliente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cb_cultivos_Nombre.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Nombre de Cultivo !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cb_direccion_Nombre.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Direccion !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0 || cb_Cliente_Nombre.SelectedIndex > 0 || cb_Cliente_Nombre.SelectedIndex == 0 || cb_cultivos_Nombre.SelectedIndex > 0 || cb_cultivos_Nombre.SelectedIndex == 0 || cb_direccion_Nombre.SelectedIndex > 0 || cb_direccion_Nombre.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();

                cn.InsertarParcelas(txt_idParcelas.Text, txt_Extension.Text, txt_idCliente.Text, txt_idCultivo.Text, txt_idDireccion.Text, Estatus);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                


                txt_idParcelas.Text = " ";
                txt_Extension.Text = " ";
                txt_idCliente.Text = " ";
                txt_idCultivo.Text = " ";
                txt_idDireccion.Text = " ";
                Cb_Estatus.SelectedIndex = -1;
                cb_Cliente_Nombre.SelectedIndex = -1;
                cb_cultivos_Nombre.SelectedIndex = -1;
                cb_direccion_Nombre.SelectedIndex = -1;
                MessageBox.Show("Agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Falta seleccionar el Estatus o Cliente o Cultivo o Direccion !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }




        }

        private void btnEditar_Click(object sender, EventArgs e)
        {



            if (string.IsNullOrEmpty(txt_idParcelas.Text) || string.IsNullOrEmpty(txt_Extension.Text) || string.IsNullOrEmpty(txt_idCliente.Text) || string.IsNullOrEmpty(txt_idCultivo.Text) || string.IsNullOrEmpty(txt_idDireccion.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0 || cb_Cliente_Nombre.SelectedIndex > 0 || cb_Cliente_Nombre.SelectedIndex == 0 || cb_cultivos_Nombre.SelectedIndex > 0 || cb_cultivos_Nombre.SelectedIndex == 0 || cb_direccion_Nombre.SelectedIndex > 0 || cb_direccion_Nombre.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();

                cn.ModificarParcelas(txt_idParcelas.Text, txt_Extension.Text, txt_idCliente.Text, txt_idCultivo.Text, txt_idDireccion.Text, Estatus);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();


                txt_idParcelas.Text = " ";
                txt_Extension.Text = " ";
                txt_idCliente.Text = " ";
                txt_idCultivo.Text = " ";
                txt_idDireccion.Text = " ";
                Cb_Estatus.SelectedIndex = -1;
                cb_Cliente_Nombre.SelectedIndex = -1;
                cb_cultivos_Nombre.SelectedIndex = -1;
                cb_direccion_Nombre.SelectedIndex = -1;
                MessageBox.Show("Actualizados Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_idParcelas.Text) || string.IsNullOrEmpty(txt_Extension.Text) || string.IsNullOrEmpty(txt_idCliente.Text) || string.IsNullOrEmpty(txt_idCultivo.Text) || string.IsNullOrEmpty(txt_idDireccion.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                Cb_Estatus.Text = "I";
                cn.ModificarParcelas(txt_idParcelas.Text, txt_Extension.Text, txt_idCliente.Text, txt_idCultivo.Text, txt_idDireccion.Text, Cb_Estatus.Text);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();


                txt_idParcelas.Text = " ";
                txt_Extension.Text = " ";
                txt_idCliente.Text = " ";
                txt_idCultivo.Text = " ";
                txt_idDireccion.Text = " ";
                Cb_Estatus.SelectedIndex = -1;
                cb_Cliente_Nombre.SelectedIndex = -1;
                cb_cultivos_Nombre.SelectedIndex = -1;
                cb_direccion_Nombre.SelectedIndex = -1;
                MessageBox.Show("Eliminado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

        }


        //modificar esto 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            txt_idParcelas.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_Extension.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //txt_idCliente.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cb_Cliente_Nombre.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            // txt_idCultivo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cb_cultivos_Nombre.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            //txt_idDireccion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cb_direccion_Nombre.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            Cb_Estatus.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO TODOS LOS CAMPOS
        private void txt_idParcelas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txt_Extension_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txt_idCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txt_idCultivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txt_idDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }


        
        private void Parcelas_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           // string conexionstring = "server = DESKTOP-IP4QBPJ\\SQLEXPRESS; database = ERP;" +
               // "integrated security = true";
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPConexion);
            con.Open();

           // SqlDataAdapter datos = new SqlDataAdapter("select SalesParcelas.idParcela, SalesParcelas.extension, SalesParcelas.idCliente, SalesParcelas.idCultivo, SalesParcelas.idDireccion, SalesParcelas.estatus, SalesClientes.nombre, SalesDireccionesCliente.calle, SalesDireccionesCliente.colonia, SalesCultivos.nombre from SalesParcelas  JOIN SalesClientes ON SalesParcelas.idCliente = SalesClientes.idCliente JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idCliente = SalesClientes.idCliente JOIN SalesCultivos ON SalesCultivos.idCultivo = SalesParcelas.idCultivo where " + this.comboBox1.Text+ " like '%" + this.textBox1.Text + "%'", con);
            SqlDataAdapter datos = new SqlDataAdapter ("select SalesParcelas.idParcela, SalesParcelas.extension, SalesParcelas.idCliente, SalesParcelas.idCultivo, SalesParcelas.idDireccion, SalesParcelas.estatus, SalesClientes.nombre, SalesDireccionesCliente.calle, SalesDireccionesCliente.colonia, SalesCultivos.nombre from SalesParcelas JOIN SalesClientes ON SalesParcelas.idCliente = SalesClientes.idCliente  JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idDireccion = SalesParcelas.idDireccion JOIN SalesCultivos ON SalesCultivos.idCultivo = SalesParcelas.idCultivo where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
            DataSet ds = new DataSet();
            datos.Fill(ds, "SalesParcelas");
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void Parcelas_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void Parcelas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void Parcelas_MouseClick(object sender, MouseEventArgs e)
        {
            //dataGridView1.DataSource = cn.ConsultaParcelasDT();
           // VarPagFinal = TotalFilasAMostrar;
           // Mostrar_datos();
           
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
                adapter.Fill(ds, start, 2, "SalesParcelas");
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
                adapter.Fill(ds, start, numMostar, "SalesParcelas");
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
                adapter.Fill(ds, start, 2, "SalesParcelas");
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
                adapter.Fill(ds, start, numMostar, "SalesParcelas");
            }
           
        }

        private void txt_DatosaMostar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txt_DatosaMostar_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void txt_DatosaMostar_TextChanged_1(object sender, EventArgs e)
        {
            

            if (string.IsNullOrEmpty(txt_DatosaMostar.Text))
            {
                ds.Clear();
                loadData();
            }
            else{
                string id = txt_DatosaMostar.Text;
                int numMostar = Int32.Parse(id);
                ds.Clear();

                SqlCommand cmd;
                string sql = "select SalesParcelas.idParcela, SalesParcelas.extension, SalesParcelas.idCliente, SalesParcelas.idCultivo, SalesParcelas.idDireccion, SalesParcelas.estatus, SalesClientes.nombre, SalesDireccionesCliente.calle, SalesDireccionesCliente.colonia, SalesCultivos.nombre from SalesParcelas JOIN SalesClientes ON SalesParcelas.idCliente = SalesClientes.idCliente  JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idDireccion = SalesParcelas.idDireccion JOIN SalesCultivos ON SalesCultivos.idCultivo = SalesParcelas.idCultivo";

                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, numMostar, "SalesParcelas");
                //DGVIEW
                dataGridView1.DataSource = ds.Tables[0];
                //habilita Boton 
                btn_atras.Enabled = false;

            }

        }

        private void cb_Cliente_Nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select idCliente from SalesClientes where nombre ='"+ cb_Cliente_Nombre.SelectedItem+"'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idCliente.Text = dr[0].ToString();
            }

            con.Close();

        }

        private void cb_cultivos_Nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select idCultivo from SalesCultivos where nombre ='" + cb_cultivos_Nombre.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idCultivo.Text = dr[0].ToString();
            }

            con.Close();
        }

        private void cb_direccion_Nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select idDireccion from SalesDireccionesCliente where calle ='" + cb_direccion_Nombre.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idDireccion.Text = dr[0].ToString();
            }

            con.Close();
        }
    }
}
