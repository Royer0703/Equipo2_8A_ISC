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
    public partial class DetallesEnvio : Form
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

        int Peso;
        int Cantida;

        int idventas;
        int idVentaDetalle;


        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_Lista_SalesDetallesEnvio(obje);

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
            string sql = "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto";
                

            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            //fill dataser
            adapter.Fill(ds, start, 2, "SalesDetallesEnvio");
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
                Cb_idventa.Items.Add(dr["idVenta"].ToString());
                Cb_idventa.DisplayMember = (dr["idVenta"].ToString());
                Cb_idventa.ValueMember = (dr["idVenta"].ToString());
            }

        }



        public DetallesEnvio()
        {
            InitializeComponent();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            //dataGridView1.DataSource = cn.ConsultarJoinParcelasDT();
            start = 0;
            loadData();
            Mostrar_datos();
            Cargar_Datos_VentasID();
            Peso = 0;
            Cantida = 0;

            idventas = 0;
            idVentaDetalle = 0;
        }

        private void Cb_idventa_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "Select SalesVentas.idVenta,SalesVentas.cantPagada,SalesVentas.idCliente,SalesClientes.nombre,Productos.idProducto,SalesVentaDetalle.idVenta,PresentacionesProducto.idPresentacion,Empaques.idEmpaque, Empaques.capacidad,SalesDireccionesCliente.idDireccion,SalesDetallesEnvio.idEnvio,SalesContactosCliente.idContacto,SalesVentas.fecha from SalesVentas JOIN SalesClientes on SalesClientes.idCliente = SalesVentas.idCliente JOIN Productos ON Productos.idProducto = SalesVentas.idProducto JOIN SalesVentaDetalle ON SalesVentaDetalle.idVenta = SalesVentas.idVenta JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idCliente = SalesClientes.idCliente LEFT JOIN SalesDetallesEnvio ON SalesDetallesEnvio.idVenta = SalesVentas.idVenta JOIN SalesContactosCliente ON SalesContactosCliente.idCliente = SalesVentas.idCliente where SalesVentas.idVenta = '" + Cb_idventa.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                txt_CantidaTotalVenta.Text = dr[1].ToString();
                txt_PesoEmpaque.Text = dr[8].ToString();
                txt_nombreClient.Text = dr[3].ToString();
                txt_Direccion_cliente.Text = dr[9].ToString();
                txt_ContactoCliente.Text = dr[11].ToString();
                txt_fechaEntrega.Text = dr[12].ToString();
                txt_idEnviosDetalle.Text = dr[10].ToString();


                

                if (string.IsNullOrEmpty(txt_idEnviosDetalle.Text))
                {

                    txt_idEnviosDetalle.Text = "";

                    string idventa = this.Cb_idventa.Text;
                    idventas = Int32.Parse(idventa);//combo de idventa



                 //------------------------------------------------------//Calculo
                    string id = this.txt_CantidaTotalVenta.Text;
                    Cantida = Int32.Parse(id);//textbox de cantidad de ventas

                    string ids = this.txt_PesoEmpaque.Text;
                    Peso = Int32.Parse(ids);//textbox de Precio
                    int Calculo = (Cantida * Peso);

                    txt_peso.Text = Calculo.ToString();


                }
                else
                {

                    string idventa = this.Cb_idventa.Text;
                     idventas = Int32.Parse(idventa);//combo de idventa

                    string idventadeta = this.txt_idEnviosDetalle.Text;
                    idVentaDetalle = Int32.Parse(idventadeta);//textbox de idventadetale


                    //--------------------------------------------------------------//
                    string id = this.txt_CantidaTotalVenta.Text;
                     Cantida = Int32.Parse(id);//textbox de cantidad de ventas

                    string ids = this.txt_PesoEmpaque.Text;
                     Peso = Int32.Parse(ids);//textbox de Precio

                    int Calculo = (Cantida * Peso);

                    txt_peso.Text = Calculo.ToString();


                }







            }

            con.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txt_idEnviosDetalle.Text = "";
            Cb_idventa.SelectedIndex = -1;
            Cb_Estatus.SelectedIndex = -1;
            txt_CantidaTotalVenta.Text = "";
            txt_PesoEmpaque.Text = "";
            txt_nombreClient.Text = "";
            txt_Direccion_cliente.Text = "";
            txt_fechaEntrega.Text = "";
            txt_peso.Text = "";
            txt_ContactoCliente.Text = "";

            ds.Clear();
            loadData();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Cb_idventa.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Venta !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (Cb_Estatus.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Estatus !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (string.IsNullOrEmpty(txt_fechaEntrega.Text))
            {
                MessageBox.Show("Falta Agrega la Fecha de Entrega!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_idventa.SelectedIndex > 0 || Cb_idventa.SelectedIndex == 0)
            {


                if (idventas == idVentaDetalle)
                {
                    MessageBox.Show("Error Ya Existe esa Venta en la Tabla!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_idEnviosDetalle.Text = "";
                    Cb_idventa.SelectedIndex = -1;
                    Cb_Estatus.SelectedIndex = -1;
                    txt_CantidaTotalVenta.Text = "";
                    txt_PesoEmpaque.Text = "";
                    txt_nombreClient.Text = "";
                    txt_Direccion_cliente.Text = "";
                    txt_fechaEntrega.Text = "";
                    txt_peso.Text = "";
                    txt_ContactoCliente.Text = "";

                }
                else if (string.IsNullOrEmpty(txt_idEnviosDetalle.Text))
                {


                    string Estatus = Cb_Estatus.SelectedItem.ToString();
                    string idVenta = Cb_idventa.SelectedItem.ToString();
                    

                    cn.InsertarSalesDetallesEnvioDT(idVenta,txt_Direccion_cliente.Text,txt_fechaEntrega.Text,txt_peso.Text, Estatus,txt_ContactoCliente.Text);
                    //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                    ds.Clear();
                    loadData();
                    VarPagFinal = TotalFilasAMostrar;
                    Mostrar_datos();




                    //txt_idEnviosDetalle.Text = "";
                    Cb_idventa.SelectedIndex = -1;
                    Cb_Estatus.SelectedIndex = -1;
                    txt_CantidaTotalVenta.Text = "";
                    txt_PesoEmpaque.Text = "";
                    txt_nombreClient.Text = "";
                    txt_Direccion_cliente.Text = "";
                    txt_fechaEntrega.Text = "";
                    txt_peso.Text = "";
                    txt_ContactoCliente.Text = "";
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
            if (Cb_idventa.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Venta a Actualizar !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (Cb_Estatus.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Estatus !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (string.IsNullOrEmpty(txt_fechaEntrega.Text))
            {
                MessageBox.Show("Falta Agrega la Fecha de Entrega!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_idventa.SelectedIndex > 0 || Cb_idventa.SelectedIndex == 0)
            {

                string Estatus = Cb_Estatus.SelectedItem.ToString();
                string idVenta = Cb_idventa.SelectedItem.ToString();


                cn.ModificarSalesDetallesEnvioDT(txt_idEnviosDetalle.Text, idVenta, txt_Direccion_cliente.Text, txt_fechaEntrega.Text, txt_peso.Text, Estatus, txt_ContactoCliente.Text);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();




                txt_idEnviosDetalle.Text = "";
                Cb_idventa.SelectedIndex = -1;
                Cb_Estatus.SelectedIndex = -1;
                txt_CantidaTotalVenta.Text = "";
                txt_PesoEmpaque.Text = "";
                txt_nombreClient.Text = "";
                txt_Direccion_cliente.Text = "";
                txt_fechaEntrega.Text = "";
                txt_peso.Text = "";
                txt_ContactoCliente.Text = "";
                MessageBox.Show("Actualizados correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Actualizados los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Cb_idventa.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Venta a Eliminar!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (Cb_Estatus.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Estatus !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (string.IsNullOrEmpty(txt_fechaEntrega.Text))
            {
                MessageBox.Show("Falta Agrega la Fecha de Entrega!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_idventa.SelectedIndex > 0 || Cb_idventa.SelectedIndex == 0)
            {

                //string Estatus = Cb_Estatus.SelectedItem.ToString();
                string idVenta = Cb_idventa.SelectedItem.ToString();
                Cb_Estatus.Text = "I";

                cn.ModificarSalesDetallesEnvioDT(txt_idEnviosDetalle.Text, idVenta, txt_Direccion_cliente.Text, txt_fechaEntrega.Text, txt_peso.Text, Cb_Estatus.Text, txt_ContactoCliente.Text);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();




                txt_idEnviosDetalle.Text = "";
                Cb_idventa.SelectedIndex = -1;
                Cb_Estatus.SelectedIndex = -1;
                txt_CantidaTotalVenta.Text = "";
                txt_PesoEmpaque.Text = "";
                txt_nombreClient.Text = "";
                txt_Direccion_cliente.Text = "";
                txt_fechaEntrega.Text = "";
                txt_peso.Text = "";
                txt_ContactoCliente.Text = "";
                MessageBox.Show("Actualizados correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Actualizados los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                string sql = "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto";
                    
                    
                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, numMostar, "SalesDetallesEnvio");
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
                adapter.Fill(ds, start, 2, "SalesDetallesEnvio");
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
                adapter.Fill(ds, start, numMostar, "SalesDetallesEnvio");
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
                adapter.Fill(ds, start, 2, "SalesDetallesEnvio");
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
                adapter.Fill(ds, start, numMostar, "SalesDetallesEnvio");
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

                SqlDataAdapter datos = new SqlDataAdapter("select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesDetallesEnvio");
                this.dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void txt_DatosaMostar_KeyDown(object sender, KeyEventArgs e)
        {

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txt_idEnviosDetalle.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Cb_idventa.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Cb_Estatus.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_nombreClient.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txt_fechaEntrega.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_peso.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_ContactoCliente.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();


        }
    }
}
