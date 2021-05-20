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
    public partial class Envios : Form
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

        int pesoTotal;
        int CapacidadUnidad;

        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_Lista_SalesEnvios(obje);

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
            string sql = "select SalesEnvios.idEnvio, SalesEnvios.fechaInicio, SalesEnvios.fechaFin, SalesEnvios.idUnidadTransporte, SalesUnidadesTransporte.placas,SalesUnidadesTransporte.marca,SalesEnvios.pesoTotal, SalesEnvios.estatus from SalesEnvios JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesEnvios.idUnidadTransporte";
                
               
            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            //fill dataser
            adapter.Fill(ds, start, 2, "SalesEnvios");
            //DGVIEW
            dataGridView1.DataSource = ds.Tables[0];
            //habilita Boton 
            btn_atras.Enabled = false;


        }

        public void Cargar_Datos_ventas_idventa()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select idEnvio,fechaEntregaPlaneada from SalesDetallesEnvio";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_idEnvios.Items.Add(dr["idEnvio"].ToString());
                Cb_idEnvios.DisplayMember = (dr["idEnvio"].ToString());
                Cb_idEnvios.ValueMember = (dr["idEnvio"].ToString());

            }

        }



        public void Cargar_Datos_UnidadesTransporte()//no estan en mantenimiento
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "SELECT s.idUnidadTransporte,s.placas,s.capacidad FROM SalesUnidadesTransporte s WHERE NOT EXISTS (SELECT * FROM SalesMantenimiento a WHERE s.idUnidadTransporte = a.idUnidadTransporte );";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_unidadTransporte.Items.Add(dr["placas"].ToString());
                Cb_unidadTransporte.DisplayMember = (dr["placas"].ToString());
                Cb_unidadTransporte.ValueMember = (dr["placas"].ToString());
            }

        }



        public Envios()
        {
            InitializeComponent();
            loadData();

            Mostrar_datos();
            start = 0;
            pesoTotal = 0;
            CapacidadUnidad = 0;
            Cargar_Datos_UnidadesTransporte();
            Cargar_Datos_ventas_idventa();
        }

        private void Cb_idEnvios_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select SalesDetallesEnvio.fechaEntregaPlaneada,SalesDetallesEnvio.peso from SalesDetallesEnvio where SalesDetallesEnvio.idEnvio = '" + Cb_idEnvios.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_FechaIni.Text = dr[0].ToString();
                txt_FechaFin.Text = dr[0].ToString();
                txt_pesoTotal.Text = dr[1].ToString();


                if (string.IsNullOrEmpty(txt_pesoTotal.Text))
                {

                    txt_pesoTotal.Text = "";

                }
                else
                {

                    string peso = this.txt_pesoTotal.Text;
                    pesoTotal = Int32.Parse(peso);//peso de la venta hecha

                }
            }

            con.Close();
        }

        private void Cb_unidadTransporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select idUnidadTransporte,capacidad from SalesUnidadesTransporte where placas = '" + Cb_unidadTransporte.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idunidadTransporte.Text = dr[0].ToString();
                txt_capacidadTransporte.Text = dr[1].ToString();




                if (string.IsNullOrEmpty(txt_capacidadTransporte.Text))
                {

                    txt_capacidadTransporte.Text = "";

                }
                else
                {

                    string cad = this.txt_capacidadTransporte.Text;
                    CapacidadUnidad = Int32.Parse(cad);//capacidad de Unidad

                    
                }
            }

            con.Close();
        }
    }
}
