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
    public partial class OfertaAsociacion : Form
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
        SqlConnection con1 = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int start;

        


        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_Lista_SalesOfertasAsociacion(obje);

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

            SqlCommand cmd;

            string sql = "select SalesOfertasAsociacion.idAsosiacion,SalesMiembros.idCliente,SalesClientes.nombre,SalesAsociaciones.nombre,SalesOfertasAsociacion.idOferta,Ofertas.nombre,Productos.idProducto,Productos.nombre,PresentacionesProducto.idPresentacion,Empaques.nombre,Ofertas.canMinProductos,Ofertas.porDescuento,Ofertas.fechaInicio,Ofertas.fechaFin,SalesOfertasAsociacion.estatus from SalesOfertasAsociacion JOIN  SalesAsociaciones ON SalesAsociaciones.idAsosiacion = SalesOfertasAsociacion.idAsosiacion JOIN Ofertas ON Ofertas.idOferta = SalesOfertasAsociacion.idOferta JOIN SalesMiembros ON SalesMiembros.idAsosiacion = SalesOfertasAsociacion.idAsosiacion JOIN SalesClientes ON SalesClientes.idCliente = SalesMiembros.idCliente JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = Ofertas.idPresentacion JOIN Productos ON Productos.idProducto = PresentacionesProducto.idProducto JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque ";

            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            //fill dataser
            adapter.Fill(ds, start, 2, "SalesOfertasAsociacion");
            //DGVIEW
            dataGridView1.DataSource = ds.Tables[0];
            //habilita Boton 
            btn_atras.Enabled = false;

        }

        public void Cargar_Datos_nombreAsociacion()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select nombre from SalesAsociaciones";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_nombreAsociacion.Items.Add(dr["nombre"].ToString());
                Cb_nombreAsociacion.DisplayMember = (dr["nombre"].ToString());
                Cb_nombreAsociacion.ValueMember = (dr["nombre"].ToString());
            }
            con.Close();
        }

        public void Cargar_Datos_nombreOferta()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select nombre from Ofertas";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_nombreOferta.Items.Add(dr["nombre"].ToString());
                Cb_nombreOferta.DisplayMember = (dr["nombre"].ToString());
                Cb_nombreOferta.ValueMember = (dr["nombre"].ToString());
            }
            con.Close();
        }









        public OfertaAsociacion()
        {
            InitializeComponent();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            // dataGridView1.DataSource = cn.ConsultarJoinParcelasDT();
            start = 0;
            Cargar_Datos_nombreAsociacion();
            Cargar_Datos_nombreOferta();
            loadData();
            Mostrar_datos();

            

        }

        private void Cb_nombreAsociacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select idAsosiacion from SalesAsociaciones where nombre = '" + Cb_nombreAsociacion.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idAsociacion.Text = dr[0].ToString();

            }

            con.Close();
        }

        private void Cb_nombreOferta_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select idOferta from Ofertas  where nombre =  '" + Cb_nombreOferta.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idOferta.Text = dr[0].ToString();

               

               
            }

            con.Close();


            con.Open();///select de la tabla 
            string qx = "select SalesOfertasAsociacion.idAsosiacion,SalesOfertasAsociacion.idOferta from SalesOfertasAsociacion where SalesOfertasAsociacion.idAsosiacion =  '" + txt_idAsociacion.Text + "'";
            SqlCommand cmdx = new SqlCommand(qx, con);
            SqlDataReader drx = cmdx.ExecuteReader();
            while (drx.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                idAsosiacionEnTabla.Text = drx[0].ToString();
                idOfertaEnTabla.Text = drx[0].ToString();

            }

            con.Close();


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Cb_nombreAsociacion.SelectedIndex = -1;
            Cb_nombreOferta.SelectedIndex = -1;
            txt_idAsociacion.Text = "";
            txt_idOferta.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Cb_nombreAsociacion.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar nombre de Asociacion!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Cb_nombreOferta.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar nombre de oferta!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (idAsosiacionEnTabla.Text == txt_idAsociacion.Text && idOfertaEnTabla.Text == txt_idOferta.Text)
            {
                MessageBox.Show("Error ya existe en la tabla !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Cb_nombreAsociacion.SelectedIndex >= 0 && Cb_nombreOferta.SelectedIndex >= 0)
            {
                String Estatus = "A";
                cn.InsertarSalesOfertAsocoacionDT(txt_idAsociacion.Text, txt_idOferta.Text, Estatus);


                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

                Cb_nombreAsociacion.SelectedIndex = -1;
                Cb_nombreOferta.SelectedIndex = -1;
                txt_idAsociacion.Text = "";
                txt_idOferta.Text = "";

                MessageBox.Show("Agregado  Correctamente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Cb_nombreAsociacion.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar nombre de Asociacion!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Cb_nombreOferta.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar nombre de oferta!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
            else if (Cb_nombreAsociacion.SelectedIndex >= 0 && Cb_nombreOferta.SelectedIndex >= 0)
            {
                String Estatus = "A";
                cn.ModificarSalesOfertAsocoacionDT(txt_idAsociacion.Text, txt_idOferta.Text, Estatus);


                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

                Cb_nombreAsociacion.SelectedIndex = -1;
                Cb_nombreOferta.SelectedIndex = -1;
                txt_idAsociacion.Text = "";
                txt_idOferta.Text = "";

                Cb_nombreAsociacion.Enabled = true;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                MessageBox.Show("Actualizado Correctamente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Cb_nombreAsociacion.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar nombre de Asociacion!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Cb_nombreOferta.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar nombre de oferta!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            else if (Cb_nombreAsociacion.SelectedIndex >= 0 && Cb_nombreOferta.SelectedIndex >= 0)
            {
                String Estatus = "I";
                cn.ModificarSalesOfertAsocoacionDT(txt_idAsociacion.Text, txt_idOferta.Text, Estatus);


                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

                Cb_nombreAsociacion.SelectedIndex = -1;
                Cb_nombreOferta.SelectedIndex = -1;
                txt_idAsociacion.Text = "";
                txt_idOferta.Text = "";

                Cb_nombreAsociacion.Enabled = true;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                MessageBox.Show("Eliminado Correctamente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                adapter.Fill(ds, start, 2, "SalesOfertasAsociacion");
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
                adapter.Fill(ds, start, numMostar, "SalesOfertasAsociacion");
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
                adapter.Fill(ds, start, 2, "SalesOfertasAsociacion");
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
                adapter.Fill(ds, start, numMostar, "SalesOfertasAsociacion");
            }
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
                string sql = "select SalesOfertasAsociacion.idAsosiacion,SalesMiembros.idCliente,SalesClientes.nombre,SalesAsociaciones.nombre,SalesOfertasAsociacion.idOferta,Ofertas.nombre,Productos.idProducto,Productos.nombre,PresentacionesProducto.idPresentacion,Empaques.nombre,Ofertas.canMinProductos,Ofertas.porDescuento,Ofertas.fechaInicio,Ofertas.fechaFin,SalesOfertasAsociacion.estatus from SalesOfertasAsociacion JOIN  SalesAsociaciones ON SalesAsociaciones.idAsosiacion = SalesOfertasAsociacion.idAsosiacion JOIN Ofertas ON Ofertas.idOferta = SalesOfertasAsociacion.idOferta JOIN SalesMiembros ON SalesMiembros.idAsosiacion = SalesOfertasAsociacion.idAsosiacion JOIN SalesClientes ON SalesClientes.idCliente = SalesMiembros.idCliente JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = Ofertas.idPresentacion JOIN Productos ON Productos.idProducto = PresentacionesProducto.idProducto JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque ";


                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, numMostar, "SalesOfertasAsociacion");
                //DGVIEW
                dataGridView1.DataSource = ds.Tables[0];
                //habilita Boton 
                btn_atras.Enabled = false;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Cb_nombreAsociacion.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Cb_nombreOferta.SelectedItem = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            Cb_nombreAsociacion.Enabled = false;
            btnGuardar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
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

                SqlDataAdapter datos = new SqlDataAdapter("select SalesOfertasAsociacion.idAsosiacion,SalesMiembros.idCliente,SalesClientes.nombre,SalesAsociaciones.nombre,SalesOfertasAsociacion.idOferta,Ofertas.nombre,Productos.idProducto,Productos.nombre,PresentacionesProducto.idPresentacion,Empaques.nombre,Ofertas.canMinProductos,Ofertas.porDescuento,Ofertas.fechaInicio,Ofertas.fechaFin,SalesOfertasAsociacion.estatus from SalesOfertasAsociacion JOIN  SalesAsociaciones ON SalesAsociaciones.idAsosiacion = SalesOfertasAsociacion.idAsosiacion JOIN Ofertas ON Ofertas.idOferta = SalesOfertasAsociacion.idOferta JOIN SalesMiembros ON SalesMiembros.idAsosiacion = SalesOfertasAsociacion.idAsosiacion JOIN SalesClientes ON SalesClientes.idCliente = SalesMiembros.idCliente JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = Ofertas.idPresentacion JOIN Productos ON Productos.idProducto = PresentacionesProducto.idProducto JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesOfertasAsociacion");
                this.dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
