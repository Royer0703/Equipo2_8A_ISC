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
    public partial class Envios_y_EnviosDetalle : Form
    {
        ConexionSQLN cn = new ConexionSQLN();//negocios
        Class_Entidad obje = new Class_Entidad();//entidad
        DataSet dsTabla;

        int VarPagInicio = 1;
        // int VarPagIndice = 0;
        int TotalFilasAMostrar = 2;
        int VarPagFinal;

        DateTime fecha = DateTime.Today;
       
        




        //conexio a mi base de datos
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
        SqlConnection con1 = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int start;



        int CantidaPre1;
        int CantidaPre2;
        int CantidaPre3;
        int CantidaPre4;
        int pesoId1;
        int pesoId2;
        int pesoId3;
        int pesoId4;

        int capacidaUnidadTrans;
        int SumPesoEnvios;
        int SumPesoEnviosNoIngresados;
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
                adapter.Fill(ds, start, 100, "SalesDetallesEnvio");
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
            string q = "select idVenta from SalesVentas where SalesVentas.estatus = 'A' ";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_idventa.Items.Add(dr["idVenta"].ToString());
                Cb_idventa.DisplayMember = (dr["idVenta"].ToString());
                Cb_idventa.ValueMember = (dr["idVenta"].ToString());
            }
            con.Close();
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
            con.Close();
        }

        public void Cargar_Datos_idUnidadTransporte()
        {

            con.Open();
            string q = "SELECT s.* FROM SalesUnidadesTransporte s WHERE NOT EXISTS (SELECT * FROM SalesMantenimiento a WHERE s.idUnidadTransporte = a.idUnidadTransporte ) and NOT EXISTS (SELECT * FROM SalesEnvios a WHERE s.idUnidadTransporte = a.idUnidadTransporte and a.fechaInicio  = '" + txt_FechaIni.Text + "')";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                Cb_unidadTransporte.Items.Add(dr[1].ToString());
                Cb_unidadTransporte.DisplayMember = (dr[1].ToString());
                Cb_unidadTransporte.ValueMember = (dr[1].ToString());

            }

            con.Close();



        }




        public Envios_y_EnviosDetalle()
        {
            InitializeComponent();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            //dataGridView1.DataSource = cn.ConsultarJoinParcelasDT();
            start = 0;
            loadData();
            Mostrar_datos();

            // txt_FechaIni.Text = fecha.ToShortDateString().ToString();
            txt_FechaIni.Text = fecha.ToString();

            Cargar_Datos_VentasID();
            Cargar_Datos_EnviosId();
            Cargar_Datos_idUnidadTransporte();

            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;

            btn_AgregarEnvioDetalle.Enabled = false;
            btn_GuardarrEnvioDetalle.Enabled = false;
            btn_BorrarrEnvioDetalle.Enabled = false;

            //salesEnviodetalle
            CantidaPre1 = 0;
            CantidaPre2 = 0;
            CantidaPre3 = 0;
            CantidaPre4 = 0;
            pesoId1 = 0;
            pesoId2 = 0;
            pesoId3 = 0;
            pesoId4 = 0;

            capacidaUnidadTrans = 0;
            SumPesoEnvios = 0;

            SumPesoEnviosNoIngresados = 0;

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

                SqlDataAdapter datos = new SqlDataAdapter("select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,SalesVentaDetalle.idPresentacion,SalesVentaDetalle.cantidad,PresentacionesProducto.idEmpaque,Empaques.nombre,SalesDetallesEnvio.idDireccion,SalesDireccionesCliente.calle,SalesDireccionesCliente.colonia,SalesDireccionesCliente.idCiudad,Ciudades.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.fechaRecepcion,SalesDetallesEnvio.pesoTotal,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idDireccion = SalesDetallesEnvio.idDireccion JOIN Ciudades ON Ciudades.idCiudad = SalesDireccionesCliente.idCiudad JOIN SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentaDetalle ON SalesVentaDetalle.idVenta = SalesDetallesEnvio.idVenta JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque where SalesDetallesEnvio.idEnvio = '" + Cb_idEnvio.SelectedItem + "'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesDetallesEnvio");
                this.dataGridView1.DataSource = ds.Tables[0];

            }
            con.Open();
            string q = "select SalesEnvios.fechaInicio,SalesEnvios.fechaFin,SalesEnvios.idUnidadTransporte,SalesEnvios.pesoTotalVenta,SalesEnvios.estatus,SalesUnidadesTransporte.placas,SalesUnidadesTransporte.idUnidadTransporte,SalesUnidadesTransporte.capacidad from SalesEnvios JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesEnvios.idUnidadTransporte where SalesEnvios.idEnvio = '" + Cb_idEnvio.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                txt_FechaIni.Text = dr[0].ToString();
                txt_FechaFin.Text = dr[1].ToString();
                Cb_unidadTransporte.Text = dr[5].ToString();
                txt_PesoUnidadTransporte.Text = dr[7].ToString();
                txt_PesoVentaTotal.Text = dr[3].ToString();
                txt_Estatus.Text = dr[4].ToString();

                string capacida = this.txt_PesoUnidadTransporte.Text;///llenado de pesotxt_PesoUnidadTransporte  listo
                capacidaUnidadTrans = Int32.Parse(capacida);

                pesoUnidadTransporet.Text = capacidaUnidadTrans.ToString();//me lo llena



                //Enviosdetalle
                txt_capacidaUnidad.Text = dr[7].ToString();
                txt_fechaEntrega.Text = dr[0].ToString();
                txt_fechaRecepcion.Text = dr[1].ToString();


                String Estatus = "A";
                if (txt_Estatus.Text == Estatus)
                {

                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btn_AgregarEnvioDetalle.Enabled = false;
                    btn_GuardarrEnvioDetalle.Enabled = false;
                    btn_BorrarrEnvioDetalle.Enabled = false;
                    Cb_idventa.Enabled = false;
                    MessageBox.Show("Envio  fue Aprovado No se puede modificar !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else if (txt_Estatus.Text != Estatus)
                {
                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = true;
                    btn_AgregarEnvioDetalle.Enabled = false;
                    btn_GuardarrEnvioDetalle.Enabled = false;
                    btn_BorrarrEnvioDetalle.Enabled = false;
                    Cb_idventa.Enabled = true;
                    btnNuevo.Enabled = true;



                }




            }

            con.Close();



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




        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Cb_unidadTransporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            con1.Open();
            string q = "SELECT SalesUnidadesTransporte.idUnidadTransporte,SalesUnidadesTransporte.capacidad from SalesUnidadesTransporte  where SalesUnidadesTransporte.placas =  '" + Cb_unidadTransporte.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idUnidadTransporte.Text = dr[0].ToString();
                txt_PesoUnidadTransporte.Text = dr[1].ToString();


            }

            con1.Close();

           
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            Cb_idEnvio.SelectedIndex = -1;
            Cb_idEnvio.Enabled = false;
            //salesEnvioDetalle
            Cb_idventa.Enabled = false;
            btn_AgregarEnvioDetalle.Enabled = false;
            btn_GuardarrEnvioDetalle.Enabled = false;
            btn_BorrarrEnvioDetalle.Enabled = false;
            //
            


            Cb_unidadTransporte.SelectedIndex = -1;
            Cb_unidadTransporte.Text = "";
            txt_PesoUnidadTransporte.Text = "";
            txt_PesoVentaTotal.Text = "";
            txt_Estatus.Text = "";

            txt_FechaIni.Text = fecha.ToString();
            txt_FechaFin.Text = fecha.ToString();

            txt_idUnidadsalesEnvio.Text = "";
            txt_fechaInicioSalesEnvio.Text = "";
            txt_fechaFinSalesEnvio.Text = "";


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
          //  DateTime fechaN = dateTimePicker1.Value.Date;


            if (Cb_unidadTransporte.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Unidad de Transporte!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (string.IsNullOrEmpty(txt_FechaFin.Text))
            {
                MessageBox.Show("Falta Agregar la Fecha de Regreso!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (txtIdUnidadsalesenvio.Text == txt_idUnidadTransporte.Text)
            {
                MessageBox.Show("Error la unidad de transporte esta en una entrega, revisa los envios Aprobados o en Captura!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (Cb_unidadTransporte.SelectedIndex > -1)
            {
                string Estatus = "C";
                string PesoTotalVenta = "0";

                cn.InsertarSalesEnviosDT(txt_FechaIni.Text, txt_FechaFin.Text, txt_idUnidadTransporte.Text, PesoTotalVenta, Estatus);
                MessageBox.Show("Envia Guardado!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

                MessageBox.Show("Envia Guardado!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_FechaFin.Text = "";
                txt_FechaFin.Text = "";
                Cb_unidadTransporte.SelectedIndex = -1;
                txt_idUnidadTransporte.Text = "";
                txt_idUnidadsalesEnvio.Text = "";

                txt_fechaInicioSalesEnvio.Text = "";
                txt_fechaFinSalesEnvio.Text = "";
                btnGuardar.Enabled = false;
                Cb_idEnvio.Enabled = true;
                Cb_unidadTransporte.Items.Clear();
                Cargar_Datos_idUnidadTransporte();

            }

        }

        private void Cb_idEnvio_MouseClick(object sender, MouseEventArgs e)
        {
            Cb_idEnvio.Items.Clear();
            Cargar_Datos_EnviosId();

        }

        private void txt_FechaIni_TextChanged(object sender, EventArgs e)
        {

        }

        private void Envios_y_EnviosDetalle_DoubleClick(object sender, EventArgs e)
        {
            Cb_idEnvio.Enabled = true;
            btnGuardar.Enabled = false;
        }

        private void Cb_idventa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pesoFinal = 0;
            con.Open(); //llena los campos de idDireccion y idContacto
            string qq = " select SalesVentas.idCliente,SalesDireccionesCliente.idCliente,SalesDireccionesCliente.idDireccion,SalesContactosCliente.idCliente from SalesVentas JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idCliente = SalesVentas.idCliente JOIN SalesContactosCliente ON SalesContactosCliente.idCliente = SalesVentas.idCliente where SalesVentas.idVenta ='" + Cb_idventa.SelectedItem + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmdq = new SqlCommand(qq, con);
            SqlDataReader drq = cmdq.ExecuteReader();
            while (drq.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();
                pesoFinal = 0;
                txt_peso.Text = "";
                txt_Direccion_cliente.Text = drq[2].ToString();
                txt_ContactoCliente.Text = drq[3].ToString();

            }
            con.Close();

            if (Cb_idventa.SelectedIndex > 0)
            {


                // string conexionstring = "server = DESKTOP-IP4QBPJ\\SQLEXPRESS; database = ERP;" +
                // "integrated security = true";
                SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);

                SqlDataAdapter datos = new SqlDataAdapter("select SalesVentaDetalle.idVentaDetalle,SalesVentaDetalle.idVenta,SalesVentaDetalle.cantidad,Productos.nombre,SalesVentaDetalle.idPresentacion,PresentacionesProducto.idEmpaque,Empaques.nombre,Empaques.capacidad,SalesClientes.nombre  from SalesVentaDetalle JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion  JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque  JOIN SalesVentas ON SalesVentas.idVenta = SalesVentaDetalle.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Productos ON Productos.idProducto = PresentacionesProducto.idProducto WHERE NOT EXISTS (SELECT * FROM SalesDetallesEnvio a WHERE SalesVentaDetalle.idVenta = a.idVenta) and SalesVentas.idVenta = '" + Cb_idventa.SelectedItem + "'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesDetallesEnvio");
                this.dataGridView2.DataSource = ds.Tables[0];

            }


            con.Open();///si idPresentacion es  1 EXPRESS
            string q = "SELECT SUM(cantidad) AS CANT FROM SalesVentaDetalle where idPresentacion = 1 and  idVenta = '" + Cb_idventa.SelectedItem + "'";
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
                    //int pesoFinal = 0;
                    txt_cantidpresenta1.Text = "0";
                    pesoIdpre1.Text = "0";

                }
                else
                {
                    // int pesoFinal = 0;
                    string cantId1 = this.txt_cantidpresenta1.Text;
                    CantidaPre1 = Int32.Parse(cantId1);


                }
            }

            con.Close();

            con.Open();///si idPresentacion es  2 VIP 
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
                    //int pesoFinal = 0;
                    txt_cantidpresenta2.Text = "0";
                    pesoIdpre2.Text = "0";



                }
                else
                {
                    // int pesoFinal = 0;
                    string cantId2 = this.txt_cantidpresenta2.Text;
                    CantidaPre2 = Int32.Parse(cantId2);


                }

            }

            con.Close();

            con.Open();///si idPresentacion es  3 
            string qz = "SELECT SUM(cantidad) AS CANT FROM SalesVentaDetalle where idPresentacion = 3 and  idVenta = '" + Cb_idventa.SelectedItem + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmdz = new SqlCommand(qz, con);
            SqlDataReader drz = cmdz.ExecuteReader();
            while (drz.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                txt_cantidpresenta3.Text = drz[0].ToString();


                if (string.IsNullOrEmpty(txt_cantidpresenta3.Text))
                {
                    // int pesoFinal = 0;
                    txt_cantidpresenta3.Text = "0";
                    pesoIdpre3.Text = "0";

                }
                else
                {
                    //int pesoFinal = 0;
                    string cantId3 = this.txt_cantidpresenta3.Text;
                    CantidaPre3 = Int32.Parse(cantId3);


                }
            }

            con.Close();

            con.Open();///si idPresentacion es  4
            string qzs = "SELECT SUM(cantidad) AS CANT FROM SalesVentaDetalle where idPresentacion = 4 and  idVenta = '" + Cb_idventa.SelectedItem + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmdzs = new SqlCommand(qzs, con);
            SqlDataReader drzs = cmdzs.ExecuteReader();
            while (drzs.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                txt_cantidpresenta4.Text = drzs[0].ToString();


                if (string.IsNullOrEmpty(txt_cantidpresenta4.Text))
                {
                    // int pesoFinal = 0;
                    txt_cantidpresenta4.Text = "0";
                    pesoIdpre4.Text = "0";

                }
                else
                {
                    // int pesoFinal = 0;
                    string cantId4 = this.txt_cantidpresenta4.Text;
                    CantidaPre4 = Int32.Parse(cantId4);


                }
            }

            con.Close();





            con.Open();//calcular el peso de idPresentacin 1
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

                    pesoIdpre1.Text = "0";


                }
                else
                {
                    string peso1 = this.pesoIdpre1.Text;
                    pesoId1 = Int32.Parse(peso1);

                }


            }

            con.Close();

            con.Open();//calcular el peso de idPresentacin 2
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

                    pesoIdpre2.Text = "0";//si no hay nada en cant 2

                }
                else
                {

                    string peso2 = this.pesoIdpre2.Text;
                    pesoId2 = Int32.Parse(peso2);


                }
            }

            con.Close();


            con.Open();//calcular el peso de idPresentacin 3
            string qrrz = "select PresentacionesProducto.idPresentacion,PresentacionesProducto.idEmpaque,Empaques.capacidad from PresentacionesProducto JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque where PresentacionesProducto.idPresentacion = '" + txt_idPresenta3.Text.ToString() + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmdrrz = new SqlCommand(qrrz, con);
            SqlDataReader drrrz = cmdrrz.ExecuteReader();
            while (drrrz.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                pesoIdpre3.Text = drrrz[2].ToString();


                if (string.IsNullOrEmpty(txt_cantidpresenta3.Text))
                {

                    pesoIdpre3.Text = "0";


                }
                else
                {
                    string peso3 = this.pesoIdpre3.Text;
                    pesoId3 = Int32.Parse(peso3);

                }


            }

            con.Close();

            con.Open();//calcular el peso de idPresentacin 4
            string qrrzx = "select PresentacionesProducto.idPresentacion,PresentacionesProducto.idEmpaque,Empaques.capacidad from PresentacionesProducto JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque where PresentacionesProducto.idPresentacion = '" + txt_idPresenta4.Text.ToString() + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmdrrzx = new SqlCommand(qrrzx, con);
            SqlDataReader drrrzx = cmdrrzx.ExecuteReader();
            while (drrrzx.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                pesoIdpre4.Text = drrrzx[2].ToString();


                if (string.IsNullOrEmpty(txt_cantidpresenta4.Text))
                {

                    pesoIdpre4.Text = "0";


                }
                else
                {
                    string peso4 = this.pesoIdpre4.Text;
                    pesoId4 = Int32.Parse(peso4);

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




            }

            con.Close();

            con.Open();
            string qrrrxa = "select SalesEnvios.idEnvio,SalesEnvios.estatus,SalesDetallesEnvio.idVenta from SalesEnvios JOIN SalesDetallesEnvio ON SalesDetallesEnvio.idEnvio = SalesEnvios.idEnvio WHERE SalesDetallesEnvio.idVenta = '" + Cb_idventa.SelectedItem + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmdrrrxa = new SqlCommand(qrrrxa, con);
            SqlDataReader drrrrxa = cmdrrrxa.ExecuteReader();
            while (drrrrxa.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                Estatusdeenvio.Text = drrrrxa[1].ToString();


            }

            con.Close();





            string idventaEnvio = txt_idventaEnvio.Text.ToString();
            string idventa = Cb_idventa.Text.ToString();
            string Estatus = "A";
            string EstatusC = "C";
            
            String EstatusEnvio = txt_Estatus.Text.ToString();
            if (idventaEnvio == idventa && Estatusdeenvio.Text == Estatus)//bien
            {
                MessageBox.Show("Esas venta ya fue agregada a un Envio Aprobado No puede modificar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_AgregarEnvioDetalle.Enabled = false;
                btn_GuardarrEnvioDetalle.Enabled = false;
                btn_BorrarrEnvioDetalle.Enabled = false;
                // txt_idventaEnvio.Text = "";


            }
           
            else if (idventaEnvio == idventa && Estatusdeenvio.Text == EstatusC)
            {
                
                btn_AgregarEnvioDetalle.Enabled = false;
                btn_GuardarrEnvioDetalle.Enabled = true;
                btn_BorrarrEnvioDetalle.Enabled = true;
            }
            if (idventaEnvio != idventa)
            {

                btn_AgregarEnvioDetalle.Enabled = true;
                btn_GuardarrEnvioDetalle.Enabled = true;
                btn_BorrarrEnvioDetalle.Enabled = true;
                // txt_idventaEnvio.Text = "";

            }



            if (Cb_idventa.SelectedIndex > 0)
            {
                int pesoFinalCant1 = 0;
                int pesoFinalCant2 = 0;
                int pesoFinalCant3 = 0;
                int pesoFinalCant4 = 0;
                pesoFinal = 0;

                pesoFinalCant1 = (CantidaPre1 * pesoId1);
                pesoFinalCant2 = (CantidaPre2 * pesoId2);
                pesoFinalCant3 = (CantidaPre3 * pesoId3);
                pesoFinalCant4 = (CantidaPre4 * pesoId4);
                pesoFinal = (pesoFinalCant1 + pesoFinalCant2 + pesoFinalCant3 + pesoFinalCant4);

                txt_peso.Text = pesoFinal.ToString();

                string cant1 = this.txt_peso.Text;
                SumPesoEnviosNoIngresados = Int32.Parse(cant1);
                pesoTotalventaNoguarda.Text = SumPesoEnviosNoIngresados.ToString();

                pesoFinal = 0;
                CantidaPre1 = 0;
                CantidaPre2 = 0;
                CantidaPre3 = 0;
                CantidaPre4 = 0;

            }


        }

        private void txt_Direccion_cliente_TextChanged(object sender, EventArgs e)
        {
            con1.Open(); //llena los campos de idDireccion y idContacto
            string qq = "select SalesDireccionesCliente.calle,SalesDireccionesCliente.numero,SalesDireccionesCliente.colonia,SalesDireccionesCliente.codigoPostal,Ciudades.nombre from SalesDireccionesCliente JOIN Ciudades on Ciudades.idCiudad = SalesDireccionesCliente.idCiudad where idDireccion = '" + txt_Direccion_cliente.Text + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmdq = new SqlCommand(qq, con1);
            SqlDataReader drq = cmdq.ExecuteReader();
            while (drq.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                txt_nombreDirreccion.Text = drq[0].ToString();
                txt_numDirre.Text = drq[1].ToString();
                txt_direColonia.Text = drq[2].ToString();
                txt_cdPostal.Text = drq[3].ToString();
                txt_ciudadDire.Text = drq[4].ToString();


            }
            con1.Close();
        }

        private void txt_ContactoCliente_TextChanged(object sender, EventArgs e)
        {
            con1.Open(); //llena los campos de idDireccion y idContacto
            string qq = "select nombre from SalesContactosCliente where idContacto = '" + txt_ContactoCliente.Text + "'";
            // "select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,Productos.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN  SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentas ON SalesVentas.idVenta = SalesDetallesEnvio.idVenta JOIN Productos ON Productos.idProducto = SalesVentas.idProducto  where " + this.comboBox1.Text + "and idPresentacion =" + this.textBox1.Text + "'";
            SqlCommand cmdq = new SqlCommand(qq, con1);
            SqlDataReader drq = cmdq.ExecuteReader();
            while (drq.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();

                txt_ContactoNombre.Text = drq[0].ToString();


            }
            con1.Close();
        }

        private void btn_AgregarEnvioDetalle_Click(object sender, EventArgs e)
        {

            if (Cb_idventa.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Venta !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idEnvio.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el envio !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (SumPesoEnviosNoIngresados > capacidaUnidadTrans)
            {
                MessageBox.Show("Peso sobre pasa la capacidad de la unidad no se pudo agregar !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (SumPesoEnvios > capacidaUnidadTrans)
            {
                MessageBox.Show("Peso sobre pasa la capacidad de la unidad no se pudo agregar !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (SumPesoEnviosNoIngresados < capacidaUnidadTrans && SumPesoEnvios < capacidaUnidadTrans)
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
                //Cb_idEnvio.SelectedIndex = -1;
                Cb_idventa.SelectedIndex = -1;


                txt_PesoEmpaque.Text = "";

                txt_Direccion_cliente.Text = "";
                //txt_fechaEntrega.Text = "";
                //txt_fechaRecepcion.Text = "";
                txt_peso.Text = "";
                txt_ContactoCliente.Text = "";
                MessageBox.Show("Agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
           

            if (Cb_idEnvio.SelectedIndex > 0)
            {


                SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);

                SqlDataAdapter datos = new SqlDataAdapter("select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,SalesVentaDetalle.idPresentacion,SalesVentaDetalle.cantidad,PresentacionesProducto.idEmpaque,Empaques.nombre,SalesDetallesEnvio.idDireccion,SalesDireccionesCliente.calle,SalesDireccionesCliente.colonia,SalesDireccionesCliente.idCiudad,Ciudades.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.fechaRecepcion,SalesDetallesEnvio.pesoTotal,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idDireccion = SalesDetallesEnvio.idDireccion JOIN Ciudades ON Ciudades.idCiudad = SalesDireccionesCliente.idCiudad JOIN SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentaDetalle ON SalesVentaDetalle.idVenta = SalesDetallesEnvio.idVenta JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque where SalesDetallesEnvio.idEnvio = '" + Cb_idEnvio.SelectedItem + "'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesDetallesEnvio");
                this.dataGridView1.DataSource = ds.Tables[0];

            }
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




        }

        private void btn_GuardarrEnvioDetalle_Click(object sender, EventArgs e)
        {
            string Estatus1 = "A";
            if (Cb_idEnvio.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el envio !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (SumPesoEnvios == 0)
            {
                MessageBox.Show("Error No puedes Guardar el Envio sin Ventas Agregadas !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No puedes Guardar si la tabla Detalle Envio Esta Vacia!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (capacidaUnidadTrans >= SumPesoEnvios && txt_Estatus.Text != Estatus1)
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


            //Actualiza los campos
            con.Open();
            string q = "select SalesEnvios.fechaInicio,SalesEnvios.fechaFin,SalesEnvios.idUnidadTransporte,SalesEnvios.pesoTotalVenta,SalesEnvios.estatus,SalesUnidadesTransporte.placas,SalesUnidadesTransporte.idUnidadTransporte,SalesUnidadesTransporte.capacidad from SalesEnvios JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesEnvios.idUnidadTransporte where SalesEnvios.idEnvio = '" + Cb_idEnvio.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                txt_FechaIni.Text = dr[0].ToString();
                txt_FechaFin.Text = dr[1].ToString();
                Cb_unidadTransporte.Text = dr[5].ToString();
                txt_PesoUnidadTransporte.Text = dr[7].ToString();
                txt_PesoVentaTotal.Text = dr[3].ToString();
                txt_Estatus.Text = dr[4].ToString();

                string capacida = this.txt_PesoUnidadTransporte.Text;
                capacidaUnidadTrans = Int32.Parse(capacida);

                //Enviosdetalle
                txt_capacidaUnidad.Text = dr[7].ToString();
                txt_fechaEntrega.Text = dr[0].ToString();
                txt_fechaRecepcion.Text = dr[1].ToString();


            }

            con.Close();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           Cb_idventa.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
          // txt_ContactoCliente.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
          // txt_Direccion_cliente.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string Estatus = "A";
            String EstatusEnvio = txt_Estatus.Text.ToString();
            if (Cb_idEnvio.SelectedIndex <= -1)
            {
                MessageBox.Show("Le falta seleccionar el Envio !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (EstatusEnvio == Estatus)
            {
                MessageBox.Show("Este  Envio no se puede eliminar porque ya fue aprobado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (EstatusEnvio != Estatus)
            {
                cn.EliminacionidEnvioDT(Cb_idEnvio.Text);
                MessageBox.Show("Envio Eliminado!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // dataGridView1.Rows.Clear();
                Cb_idEnvio.Items.Clear();

            }
        }

        private void btn_BorrarrEnvioDetalle_Click(object sender, EventArgs e)
        {
            if (Cb_idventa.SelectedIndex <= -1)
            {
                MessageBox.Show("Le falta seleccionar el idVenta a eliminar !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No puedes Borrar si la tabla Detalle Envio Esta Vacia !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idventa.SelectedIndex > 0) { 
                cn.EliminacionidVentaDT(Cb_idventa.Text);
            MessageBox.Show("Venta Eliminado del Envio Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // dataGridView1.Rows.Clear();
            Cb_idventa.Items.Clear();

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

                SqlDataAdapter datos = new SqlDataAdapter("select SalesDetallesEnvio.idEnvio,SalesDetallesEnvio.idVenta,SalesVentaDetalle.idPresentacion,SalesVentaDetalle.cantidad,PresentacionesProducto.idEmpaque,Empaques.nombre,SalesDetallesEnvio.idDireccion,SalesDireccionesCliente.calle,SalesDireccionesCliente.colonia,SalesDireccionesCliente.idCiudad,Ciudades.nombre,SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.fechaRecepcion,SalesDetallesEnvio.pesoTotal,SalesDetallesEnvio.estatus,SalesDetallesEnvio.idContacto,SalesContactosCliente.nombre from SalesDetallesEnvio JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idDireccion = SalesDetallesEnvio.idDireccion JOIN Ciudades ON Ciudades.idCiudad = SalesDireccionesCliente.idCiudad JOIN SalesContactosCliente ON SalesContactosCliente.idContacto = SalesDetallesEnvio.idContacto JOIN SalesVentaDetalle ON SalesVentaDetalle.idVenta = SalesDetallesEnvio.idVenta JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque where SalesDetallesEnvio.idEnvio = '" + Cb_idEnvio.SelectedItem + "'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesDetallesEnvio");
                this.dataGridView1.DataSource = ds.Tables[0];

            }
            btn_AgregarEnvioDetalle.Enabled = false;
            btn_GuardarrEnvioDetalle.Enabled = false;
            btn_BorrarrEnvioDetalle.Enabled = false;
            txt_idventaEnvio.Text = "";//
        }

        }
            private void Cb_idventa_MouseClick(object sender, MouseEventArgs e)
            {
                Cb_idventa.Items.Clear();
                Cargar_Datos_VentasID();
            }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

