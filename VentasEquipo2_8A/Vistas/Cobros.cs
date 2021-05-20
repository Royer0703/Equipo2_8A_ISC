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
    public partial class Cobros : Form
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

        int idVenta;
        int idCobros;

        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_listar_Salescobros(obje);

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
            string sql = "Select SalesCobros.idCobro, SalesCobros.fecha, SalesCobros.importe, SalesCobros.idVenta,Productos.nombre,SalesVentas.idCliente,SalesClientes.nombre,SalesClientes.telefono ,SalesCobros.estatus from SalesCobros JOIN SalesVentas ON SalesVentas.idVenta = SalesCobros.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente";

            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            //fill dataser
            adapter.Fill(ds, start, 2, "SalesCobros");
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
                Cb_nombre_Clientes.Items.Add(dr["nombre"].ToString());
                Cb_nombre_Clientes.DisplayMember = (dr["nombre"].ToString());
                Cb_nombre_Clientes.ValueMember = (dr["nombre"].ToString());
            }

        }






        public Cobros()
        {
            InitializeComponent();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
           // dataGridView1.DataSource = cn.ConsultarJoinParcelasDT();
            start = 0;
            idVenta = 0;
            idCobros = 0;
            loadData();
            Cargar_Datos_clienteNombre();

        }

        private void Cb_nombre_Clientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select SalesVentas.idVenta, SalesVentas.fecha,SalesVentas.total,SalesVentas.idCliente,SalesClientes.nombre,SalesCobros.idCobro from SalesVentas JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente LEFT JOIN SalesCobros ON SalesCobros.idVenta = SalesVentas.idVenta where SalesClientes.nombre = '" + Cb_nombre_Clientes.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                //txt_idCliente.Text = dr[0].ToString();
                txt_idVenta.Text = dr[0].ToString();
                txt_fecha.Text = dr[1].ToString();
                txt_Importe.Text = dr[2].ToString();
                txt_idCobros.Text = dr[5].ToString();

                if (string.IsNullOrEmpty(txt_idCobros.Text))
                {
                    txt_idCobros.Text = "";

                    string id = this.txt_idVenta.Text;
                    idVenta = Int32.Parse(id);//textbox de 

                }
                else
                {
                    string id = this.txt_idVenta.Text;
                    idVenta = Int32.Parse(id);//textbox de 

                    string ids = this.txt_idCobros.Text;
                    idCobros = Int32.Parse(ids);//textbox de txt_idCobros


                }


            }

            con.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ds.Clear();
            loadData();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();

            txt_idCobros.Text = "";
            txt_idVenta.Text = "";
            txt_fecha.Text = "";
            txt_Importe.Text = "";
            Cb_nombre_Clientes.SelectedIndex = -1;
            Cb_Estatus.SelectedIndex = -1;





        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Cb_nombre_Clientes.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Cliente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_nombre_Clientes.SelectedIndex > 0 || Cb_nombre_Clientes.SelectedIndex == 0)
            {


                if (idVenta == idCobros)
                {
                    MessageBox.Show("Error Ya Existe es Cobro en la Tabla!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (string.IsNullOrEmpty(txt_idCobros.Text))
                {


                    string Estatus = Cb_Estatus.SelectedItem.ToString();
                    

                    cn.InsertarSalesCobrosDT(txt_fecha.Text, txt_Importe.Text, txt_idVenta.Text, Estatus);
                    //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                    ds.Clear();
                    loadData();
                    VarPagFinal = TotalFilasAMostrar;
                    Mostrar_datos();




                   // txt_idCobros.Text = "";
                    txt_idVenta.Text = "";
                    txt_fecha.Text = "";
                    txt_Importe.Text = "";
                    Cb_nombre_Clientes.SelectedIndex = -1;
                    Cb_Estatus.SelectedIndex = -1;
                    MessageBox.Show("Agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show("Error al Guardar los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Cb_nombre_Clientes.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Cliente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_nombre_Clientes.SelectedIndex > 0 || Cb_nombre_Clientes.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();


                cn.ModificarSalesCobrosDT(txt_idCobros.Text, txt_fecha.Text, txt_Importe.Text, txt_idVenta.Text, Estatus);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();




                txt_idCobros.Text = "";
                txt_idVenta.Text = "";
                txt_fecha.Text = "";
                txt_Importe.Text = "";
                Cb_nombre_Clientes.SelectedIndex = -1;
                Cb_Estatus.SelectedIndex = -1;
                MessageBox.Show("Actualizado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Actualizado los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Cb_nombre_Clientes.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Cliente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_nombre_Clientes.SelectedIndex > 0 || Cb_nombre_Clientes.SelectedIndex == 0)
            {
                //string Estatus = Cb_Estatus.SelectedItem.ToString();

                Cb_Estatus.Text = "I";
                cn.ModificarSalesCobrosDT(txt_idCobros.Text, txt_fecha.Text, txt_Importe.Text, txt_idVenta.Text, Cb_Estatus.Text);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();




                txt_idCobros.Text = "";
                txt_idVenta.Text = "";
                txt_fecha.Text = "";
                txt_Importe.Text = "";
                Cb_nombre_Clientes.SelectedIndex = -1;
                Cb_Estatus.SelectedIndex = -1;
                MessageBox.Show("Eliminado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Eliminado los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idCobros.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_fecha.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_Importe.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Cb_nombre_Clientes.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            Cb_Estatus.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();


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

                SqlDataAdapter datos = new SqlDataAdapter("Select SalesCobros.idCobro, SalesCobros.fecha, SalesCobros.importe, SalesCobros.idVenta,Productos.nombre,SalesVentas.idCliente,SalesClientes.nombre,SalesClientes.telefono ,SalesCobros.estatus from SalesCobros JOIN SalesVentas ON SalesVentas.idVenta = SalesCobros.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesCobros");
                this.dataGridView1.DataSource = ds.Tables[0];
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
                string sql = "Select SalesCobros.idCobro, SalesCobros.fecha, SalesCobros.importe, SalesCobros.idVenta,Productos.nombre,SalesVentas.idCliente,SalesClientes.nombre,SalesClientes.telefono ,SalesCobros.estatus from SalesCobros JOIN SalesVentas ON SalesVentas.idVenta = SalesCobros.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente";
                   
                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, numMostar, "SalesCobros");
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
                adapter.Fill(ds, start, 2, "SalesCobros");
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
                adapter.Fill(ds, start, numMostar, "SalesCobros");
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
                adapter.Fill(ds, start, 2, "SalesCobros");
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
                adapter.Fill(ds, start, numMostar, "SalesCobros");
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
    }
}
