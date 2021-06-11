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
        SqlConnection con1 = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int start;

        int Peso;
        int Cantida;


        int CantidaPre2;
        int CantidaPre1;

        int pesoId1;
        int pesoId2;

        int SumPesoEnvios;
        int capacidaUnidadTrans;

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

            if (Cb_idEnvio.SelectedIndex <= -1)
            {
                SqlCommand cmd;
                string sql = "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,SalesDetallesEnvio.idDireccion,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.fechaRecepcion,SalesDetallesEnvio.pesoTotal,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto from SalesDetallesEnvio";

                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, 2, "SalesDetallesEnvio");
                //DGVIEW
                dataGridView1.DataSource = ds.Tables[0];
                //habilita Boton 
                btn_atras.Enabled = false;
            }
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

        public void Cargar_Datos_EnviosId()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select idEnvio from SalesEnvios";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_idEnvio.Items.Add(dr["idEnvio"].ToString());
                Cb_idEnvio.DisplayMember = (dr["idEnvio"].ToString());
                Cb_idEnvio.ValueMember = (dr["idEnvio"].ToString());
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
            Cargar_Datos_EnviosId();
            Peso = 0;
            Cantida = 0;


            CantidaPre1 = 0;
            CantidaPre2 = 0;

            pesoId1 = 0;
            pesoId2 = 0;

            SumPesoEnvios = 0;
            capacidaUnidadTrans = 0;

        }

        private void Cb_idventa_SelectedIndexChanged(object sender, EventArgs e)
        {

            con.Open();
            string qq = " select SalesVentas.idCliente,SalesDireccionesCliente.idCliente,SalesDireccionesCliente.idDireccion,SalesContactosCliente.idCliente from SalesVentas JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idCliente = SalesVentas.idCliente JOIN SalesContactosCliente ON SalesContactosCliente.idCliente = SalesVentas.idCliente where SalesVentas.idVenta ='" + Cb_idventa.SelectedItem + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmdq = new SqlCommand(qq, con);
            SqlDataReader drq = cmdq.ExecuteReader();
            while (drq.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                txt_Direccion_cliente.Text = drq[2].ToString();
                txt_ContactoCliente.Text = drq[3].ToString();

            }

            con.Close();

            con.Open();
            string q = "SELECT SUM( cantidad) AS CANT FROM SalesVentaDetalle where idPresentacion = 1 and  idVenta = '" + Cb_idventa.SelectedItem + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                txt_cantidpresenta1.Text = dr[0].ToString();


                if (string.IsNullOrEmpty(txt_cantidpresenta1.Text))
                {
                    
                    txt_cantidpresenta1.Text = "";
                    pesoIdpre1.Text = "";
                   


                }
                else
                {
                    string cantId1 = this.txt_cantidpresenta1.Text;
                    CantidaPre1 = Int32.Parse(cantId1);


                }
            
        

            }

            con.Close();

            con.Open();
            string qr = "SELECT SUM( cantidad) AS CANT FROM SalesVentaDetalle where idPresentacion = 2 and  idVenta = '" + Cb_idventa.SelectedItem + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmdr = new SqlCommand(qr, con);
            SqlDataReader drr = cmdr.ExecuteReader();
            while (drr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                txt_cantidpresenta2.Text = drr[0].ToString();

                
                    if (string.IsNullOrEmpty(txt_cantidpresenta2.Text))
                    {
                   
                    txt_cantidpresenta2.Text = "";
                         pesoIdpre2.Text = "";

              

                }
                    else
                    {
                        string cantId2 = this.txt_cantidpresenta2.Text;
                        CantidaPre2 = Int32.Parse(cantId2);


                    }
                


            }

            con.Close();

            con.Open();
            string qrr = "select PresentacionesProducto.idPresentacion,PresentacionesProducto.idEmpaque,Empaques.capacidad from PresentacionesProducto JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque where PresentacionesProducto.idPresentacion = '" + txt_idPresenta1.Text.ToString() + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmdrr = new SqlCommand(qrr, con);
            SqlDataReader drrr = cmdrr.ExecuteReader();
            while (drrr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                pesoIdpre1.Text = drrr[2].ToString();


                if (string.IsNullOrEmpty(txt_cantidpresenta1.Text))
                {
                    
                    pesoIdpre1.Text = "";


                }
                else
                {
                    string peso1 = this.pesoIdpre1.Text;
                    pesoId1 = Int32.Parse(peso1);

                }


            }

            con.Close();
         

            con.Open();
            string qrrr = "select PresentacionesProducto.idPresentacion,PresentacionesProducto.idEmpaque,Empaques.capacidad from PresentacionesProducto JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque where PresentacionesProducto.idPresentacion = '" + txt_idPresenta2.Text.ToString() + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmdrrr = new SqlCommand(qrrr, con);
            SqlDataReader drrrr = cmdrrr.ExecuteReader();
            while (drrrr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                pesoIdpre2.Text = drrrr[2].ToString();

                if (string.IsNullOrEmpty(txt_cantidpresenta2.Text))
                {
                    
                    pesoIdpre2.Text = "";//si no hay nada en cant 2

                }
                else
                {
                  
                    string peso2 = this.pesoIdpre2.Text;
                    pesoId2 = Int32.Parse(peso2);

 
                }


            }

            con.Close();

            con.Open();
            string qrrrx = "select SalesVentas.idVenta,SalesDetallesEnvio.idVenta from SalesDetallesEnvio left JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta where SalesDetallesEnvio.idVenta = '" + Cb_idventa.SelectedItem + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmdrrrx = new SqlCommand(qrrrx, con);
            SqlDataReader drrrrx = cmdrrrx.ExecuteReader();
            while (drrrrx.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                txt_idventaEnvio.Text = drrrrx[1].ToString();

                string idventaEnvio = txt_idventaEnvio.Text.ToString();
                string idventa = Cb_idventa.Text.ToString();
                if (idventaEnvio != idventa)
                {
                    
                    btnNuevo.Enabled = true;
                    txt_idventaEnvio.Text = "";

                }
                else
                {
                    MessageBox.Show("Esas venta ya fue agregada a envios", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnNuevo.Enabled = false;
                    txt_idventaEnvio.Text = "";

                }


            }

            con.Close();




            if (string.IsNullOrEmpty(txt_cantidpresenta1.Text) && string.IsNullOrEmpty(pesoIdpre1.Text))
            {
                int pesoFinal = 0;
                int pesoFinalCant2 = (CantidaPre2 * pesoId2);
                pesoFinal = pesoFinalCant2;
                 txt_peso.Text = pesoFinal.ToString();

            }
           else if (string.IsNullOrEmpty(txt_cantidpresenta2.Text) && string.IsNullOrEmpty(pesoIdpre2.Text))
            {
                int pesoFinal = 0;
                int pesoFinalCant1 = (CantidaPre1 * pesoId1);
                pesoFinal = pesoFinalCant1;
                txt_peso.Text = pesoFinal.ToString();
            }
            else
            {
                int pesoFinal = 0;
                int pesoFinalCant2 = (CantidaPre2 * pesoId2);
                int pesoFinalCant1 = (CantidaPre1 * pesoId1);
                pesoFinal = (pesoFinalCant2 + pesoFinalCant1);

                txt_peso.Text = pesoFinal.ToString();
            }


        }//ultimo

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string Estatus1 = "A";
            if (Cb_idventa.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Venta !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (Cb_idEnvio.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el envio !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (capacidaUnidadTrans < SumPesoEnvios)
            {
                MessageBox.Show("Error el Peso total de las ventas sobre paso la capacidad de la unidad !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (txt_EstatusEnvio.Text == Estatus1)
            {

                MessageBox.Show("Error ya no puedes agregar mas datos en este envio !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (capacidaUnidadTrans >= SumPesoEnvios && txt_EstatusEnvio.Text != Estatus1)
            {
                string Estatus = "A";
                string idVenta = Cb_idventa.SelectedItem.ToString();
                string idEnvio = Cb_idEnvio.SelectedItem.ToString();



                cn.InsertarSalesDetallesEnvioDT(idEnvio, idVenta, txt_Direccion_cliente.Text, txt_fechaEntrega.Text, txt_fechaRecepcion.Text, txt_peso.Text, Estatus, txt_ContactoCliente.Text);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();




                //txt_idEnviosDetalle.Text = "";
                Cb_idEnvio.SelectedIndex = -1;
                Cb_idventa.SelectedIndex = -1;

                
                txt_PesoEmpaque.Text = "";

                txt_Direccion_cliente.Text = "";
                txt_fechaEntrega.Text = "";
                txt_fechaRecepcion.Text = "";
                txt_peso.Text = "";
                txt_ContactoCliente.Text = "";
                MessageBox.Show("Agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Estatus1 = "A";
            if (Cb_idEnvio.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el envio !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (txt_EstatusEnvio.Text == Estatus1)
            {

                MessageBox.Show("Ya se guardo este envio revisa Envios Aprobados !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (capacidaUnidadTrans >= SumPesoEnvios && txt_EstatusEnvio.Text != Estatus1)
            {
                String EstatusEnvio = "A";
                cn.ModificarSalesEnviosTablasEnvioUpdateDT(Cb_idEnvio.Text, txt_totalEnvioSum.Text, EstatusEnvio);
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();




                //txt_idEnviosDetalle.Text = "";
                Cb_idEnvio.SelectedIndex = -1;
                Cb_idventa.SelectedIndex = -1;

                
                txt_PesoEmpaque.Text = "";

                txt_Direccion_cliente.Text = "";
                txt_fechaEntrega.Text = "";
                txt_fechaRecepcion.Text = "";
                txt_peso.Text = "";
                txt_ContactoCliente.Text = "";
                MessageBox.Show("Envios Guardados Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);



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
                string sql = "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,SalesDetallesEnvio.idDireccion,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.fechaRecepcion,SalesDetallesEnvio.pesoTotal,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto from SalesDetallesEnvio";


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

               
                SqlDataAdapter datos = new SqlDataAdapter("select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,SalesDetallesEnvio.idDireccion,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.fechaRecepcion,SalesDetallesEnvio.pesoTotal,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto from SalesDetallesEnvio  where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
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

           
            Cb_idventa.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            
           
            txt_fechaEntrega.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_peso.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_ContactoCliente.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();


        }

        private void txt_idPresenta1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cb_idEnvio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cb_idEnvio.SelectedIndex <= -1)
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

                SqlDataAdapter datos = new SqlDataAdapter("select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,SalesVentaDetalle.idPresentacion,SalesVentaDetalle.cantidad,PresentacionesProducto.idEmpaque,Empaques.nombre,SalesDetallesEnvio.idDireccion,SalesDireccionesCliente.calle,SalesDireccionesCliente.colonia,SalesDireccionesCliente.idCiudad,Ciudades.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.fechaRecepcion,SalesDetallesEnvio.pesoTotal,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idDireccion = SalesDetallesEnvio.idDireccion JOIN Ciudades ON Ciudades.idCiudad = SalesDireccionesCliente.idCiudad JOIN SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentaDetalle ON SalesVentaDetalle.idVenta = SalesDetallesEnvio.idVenta JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque where SalesDetallesEnvio.idEnvio = '" + Cb_idEnvio.SelectedItem + "'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesDetallesEnvio");
                this.dataGridView1.DataSource = ds.Tables[0];
                
            }











            con.Open();
            string q = "select SalesEnvios.fechaInicio, SalesEnvios.fechaFin,SalesEnvios.estatus from SalesEnvios where SalesEnvios.idEnvio = '" + Cb_idEnvio.SelectedItem + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                txt_fechaEntrega.Text = dr[0].ToString();
                txt_fechaRecepcion.Text = dr[1].ToString();
                txt_EstatusEnvio.Text = dr[2].ToString();

                string EstatusEnvio = txt_EstatusEnvio.Text;
                String estatus = "A";
                if (EstatusEnvio == estatus)
                {
                    btnNuevo.Enabled = false;
                    btnGuardar.Enabled = false;
                    MessageBox.Show("Envios ya fue Aprobado elige otro!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }


            }

            con.Close();
            //suma de pesototal de 
            con.Open();
            string qs = "SELECT SUM(pesoTotal) AS Peso FROM SalesDetallesEnvio WHERE idEnvio = '" + Cb_idEnvio.SelectedItem + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmds = new SqlCommand(qs, con);
            SqlDataReader drs = cmds.ExecuteReader();
            while (drs.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                txt_totalEnvioSum.Text = drs[0].ToString();

                if (string.IsNullOrEmpty(txt_totalEnvioSum.Text))
                {
                    txt_totalEnvioSum.Text = "";
                }
                else
                {
                    string cant = this.txt_totalEnvioSum.Text;
                    SumPesoEnvios = Int32.Parse(cant);
                }
            }

            con.Close();

            con.Open();
            string qss = "select SalesEnvios.idEnvio,SalesEnvios.idUnidadTransporte,SalesUnidadesTransporte.capacidad from SalesEnvios JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesEnvios.idUnidadTransporte Where SalesEnvios.idEnvio = '" + Cb_idEnvio.SelectedItem + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmdss = new SqlCommand(qss, con);
            SqlDataReader drss = cmdss.ExecuteReader();
            while (drss.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                txt_capacidaUnidad.Text = drss[2].ToString();

                if (string.IsNullOrEmpty(txt_capacidaUnidad.Text))
                {
                    txt_capacidaUnidad.Text = "";
                }
                else
                {
                    string capacida = this.txt_capacidaUnidad.Text;
                    capacidaUnidadTrans = Int32.Parse(capacida);
                }
            }

            con.Close();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            Cb_idEnvio.SelectedIndex = -1;
            Cb_idventa.SelectedIndex = -1;

          
            txt_PesoEmpaque.Text = "";

            txt_Direccion_cliente.Text = "";
            txt_fechaEntrega.Text = "";
            txt_fechaRecepcion.Text = "";
            txt_peso.Text = "";
            txt_ContactoCliente.Text = "";
            btnNuevo.Enabled = true;
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = true;
        }
    }
}
