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
    public partial class ventasDetalle : Form
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

        int Cantida;
        int Precio;







        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_listar_SalesVentaDetalle(obje);

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
            string sql = "select SalesVentaDetalle.idVentaDetalle,SalesVentaDetalle.precioVenta,SalesVentaDetalle.cantidad,SalesVentaDetalle.subtotal,SalesVentaDetalle.idVenta,SalesVentas.idCliente,SalesClientes.nombre,SalesVentaDetalle.idPresentacion,PresentacionesProducto.precioCompra,Productos.idProducto,Productos.nombre,SalesVentaDetalle.estatus from SalesVentaDetalle JOIN SalesVentas ON SalesVentas.idVenta = SalesVentaDetalle.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN PresentacionesProducto on PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Productos ON Productos.idProducto = PresentacionesProducto.idProducto";

            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            //fill dataser
            adapter.Fill(ds, start, 2, "SalesVentaDetalle");
            //DGVIEW
            dataGridView1.DataSource = ds.Tables[0];
            //habilita Boton 
            btn_atras.Enabled = false;

        }

        public void Cargar_Datos_VentasID()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select idVenta from SalesVentas";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_idVenta.Items.Add(dr["idVenta"].ToString());
                Cb_idVenta.DisplayMember = (dr["idVenta"].ToString());
                Cb_idVenta.ValueMember = (dr["idVenta"].ToString());
            }

        }




        public ventasDetalle()
        {
            InitializeComponent();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            //dataGridView1.DataSource = cn.ConsultarJoinParcelasDT();
            start = 0;
            loadData();
            Mostrar_datos();
            Cargar_Datos_VentasID();
            Cantida = 0;
            Precio = 0;

        }

        private void ventasDetalle_Load(object sender, EventArgs e)
        {

        }

        private void Cb_idVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select SalesVentas.idCliente,SalesClientes.nombre,SalesVentas.cantPagada,SalesVentas.subtotal,SalesVentas.idProducto,PresentacionesProducto.idPresentacion,PresentacionesProducto.precioVenta,SalesVentaDetalle.idVentaDetalle from SalesVentas JOIN SalesClientes on SalesClientes.idCliente = SalesVentas.idCliente JOIN PresentacionesProducto on PresentacionesProducto.idProducto = SalesVentas.idProducto left JOIN  SalesVentaDetalle on SalesVentaDetalle.idVenta = SalesVentas.idVenta where SalesVentas.idVenta = '" + Cb_idVenta.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();
                txt_cliente.Text = dr[1].ToString();
                txt_precioVenta.Text = dr[6].ToString();
                txt_cantidad.Text = dr[2].ToString();
                txt_subTotal.Text = dr[3].ToString();
                txt_Presentacion.Text = dr[5].ToString();
                txt_idventaPrueba.Text = dr[7].ToString();





                if (string.IsNullOrEmpty(txt_idventaPrueba.Text))
                {
                    txt_idventaPrueba.Text = "";

                    string id = this.Cb_idVenta.Text;
                    Cantida = Int32.Parse(id);//textbox de Cb_idVenta
                }
                else
                {
                    string id = this.Cb_idVenta.Text;
                    Cantida = Int32.Parse(id);//textbox de Cb_idVenta

                    string ids = this.txt_idventaPrueba.Text;
                    Precio = Int32.Parse(ids);//textbox de txt_idventaPrueba
                }

            }

            con.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txt_idventaDetalle.Text = " ";
            txt_cliente.Text = " ";
            txt_precioVenta.Text = " ";
            txt_cantidad.Text = " ";
            txt_subTotal.Text = " ";
            txt_Presentacion.Text = " ";
            Cb_idVenta.SelectedIndex = -1;
            Cb_Estatus.SelectedIndex = -1;
            txt_idventaPrueba.Text = "";


            ds.Clear();
            loadData();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {


            if (Cb_idVenta.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Venta !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_idVenta.SelectedIndex > 0 || Cb_idVenta.SelectedIndex == 0)
            {


                if (Cantida == Precio)
                {
                    MessageBox.Show("Error Ya Existe esa Venta en la Tabla!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (string.IsNullOrEmpty(txt_idventaPrueba.Text))
                {


                    string Estatus = Cb_Estatus.SelectedItem.ToString();
                    string idVenta = Cb_idVenta.SelectedItem.ToString();

                    cn.InsertarSalesVentasDetalleDT(txt_precioVenta.Text, txt_cantidad.Text, txt_subTotal.Text, idVenta, txt_Presentacion.Text, Estatus);
                    //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                    ds.Clear();
                    loadData();
                    VarPagFinal = TotalFilasAMostrar;
                    Mostrar_datos();




                    //txt_idventaDetalle.Text = " ";
                    txt_cliente.Text = " ";
                    txt_precioVenta.Text = " ";
                    txt_cantidad.Text = " ";
                    txt_subTotal.Text = " ";
                    txt_Presentacion.Text = " ";
                    Cb_idVenta.SelectedIndex = -1;
                    Cb_Estatus.SelectedIndex = -1;
                    txt_idventaPrueba.Text = "";
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
            if (Cb_idVenta.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Venta que va Modificar !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_idVenta.SelectedIndex > 0 || Cb_idVenta.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                string idVenta = Cb_idVenta.SelectedItem.ToString();

                cn.ModificarSalesVentasDetalleDT(txt_idventaDetalle.Text, txt_precioVenta.Text, txt_cantidad.Text, txt_subTotal.Text, idVenta, txt_Presentacion.Text, Estatus);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();




                txt_idventaDetalle.Text = " ";
                txt_cliente.Text = " ";
                txt_precioVenta.Text = " ";
                txt_cantidad.Text = " ";
                txt_subTotal.Text = " ";
                txt_Presentacion.Text = " ";
                Cb_idVenta.SelectedIndex = -1;
                Cb_Estatus.SelectedIndex = -1;
                txt_idventaPrueba.Text = "";

                MessageBox.Show("Actualizados correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Actualizados los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Cb_idVenta.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Venta que va Modificar !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_idVenta.SelectedIndex > 0 || Cb_idVenta.SelectedIndex == 0)
            {
                //string Estatus = Cb_Estatus.SelectedItem.ToString();
                string idVenta = Cb_idVenta.SelectedItem.ToString();
                Cb_Estatus.Text = "I";
                cn.ModificarSalesVentasDetalleDT(txt_idventaDetalle.Text, txt_precioVenta.Text, txt_cantidad.Text, txt_subTotal.Text, idVenta, txt_Presentacion.Text, Cb_Estatus.Text);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();




                txt_idventaDetalle.Text = " ";
                txt_cliente.Text = " ";
                txt_precioVenta.Text = " ";
                txt_cantidad.Text = " ";
                txt_subTotal.Text = " ";
                txt_Presentacion.Text = " ";
                Cb_idVenta.SelectedIndex = -1;
                Cb_Estatus.SelectedIndex = -1;
                txt_idventaPrueba.Text = "";

                MessageBox.Show("Eliminado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Eliminar los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idventaDetalle.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_precioVenta.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_cantidad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_subTotal.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Cb_idVenta.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_cliente.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txt_Presentacion.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            Cb_Estatus.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();

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

                SqlDataAdapter datos = new SqlDataAdapter("select SalesVentaDetalle.idVentaDetalle,SalesVentaDetalle.precioVenta,SalesVentaDetalle.cantidad,SalesVentaDetalle.subtotal,SalesVentaDetalle.idVenta,SalesVentas.idCliente,SalesClientes.nombre,SalesVentaDetalle.idPresentacion,PresentacionesProducto.precioCompra,Productos.idProducto,Productos.nombre,SalesVentaDetalle.estatus from SalesVentaDetalle JOIN SalesVentas ON SalesVentas.idVenta = SalesVentaDetalle.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN PresentacionesProducto on PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Productos ON Productos.idProducto = PresentacionesProducto.idProducto  where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesVentaDetalle");
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
                string sql = "select SalesVentaDetalle.idVentaDetalle,SalesVentaDetalle.precioVenta,SalesVentaDetalle.cantidad,SalesVentaDetalle.subtotal,SalesVentaDetalle.idVenta,SalesVentas.idCliente,SalesClientes.nombre,SalesVentaDetalle.idPresentacion,PresentacionesProducto.precioCompra,Productos.idProducto,Productos.nombre,SalesVentaDetalle.estatus from SalesVentaDetalle JOIN SalesVentas ON SalesVentas.idVenta = SalesVentaDetalle.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN PresentacionesProducto on PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Productos ON Productos.idProducto = PresentacionesProducto.idProducto";
                   
                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, numMostar, "SalesVentaDetalle");
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
                adapter.Fill(ds, start, 2, "SalesVentaDetalle");
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
                adapter.Fill(ds, start, numMostar, "SalesVentaDetalle");
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
                adapter.Fill(ds, start, 2, "SalesVentaDetalle");
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
                adapter.Fill(ds, start, numMostar, "SalesVentaDetalle");
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
