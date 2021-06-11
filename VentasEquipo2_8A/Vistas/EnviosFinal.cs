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
    public partial class EnviosFinal : Form
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

        DateTime fecha = DateTime.Today;
        DateTime fechaN = new DateTime();
        DateTime fechas = new DateTime();
        string mesFechaini;
        string mesFechaFin;
 


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
            string sql = "select SalesEnvios.idEnvio, SalesEnvios.fechaInicio,SalesEnvios.fechaFin,SalesEnvios.idUnidadTransporte,SalesUnidadesTransporte.placas,SalesUnidadesTransporte.modelo,SalesUnidadesTransporte.capacidad,SalesEnvios.pesoTotalVenta,SalesEnvios.estatus from SalesEnvios JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesEnvios.idUnidadTransporte";

            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            //fill dataser
            adapter.Fill(ds, start, 100, "SalesEnvios");
            //DGVIEW
            dataGridView1.DataSource = ds.Tables[0];
            //habilita Boton 
            //  btn_atras.Enabled = false;

        }

        public void Cargar_Datos_idUnidadTransporte()
        {
            

        }

        public EnviosFinal()
        {
            InitializeComponent();
            loadData();
            Mostrar_datos();
            start = 0;
     
           
            
            


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
        }

        private void Cb_unidadTransporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Envios_y_EnviosDetalle vf = new Envios_y_EnviosDetalle();
            vf.Show();
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            ds.Clear();
            loadData();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
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
                string sql = "select SalesEnvios.idEnvio, SalesEnvios.fechaInicio,SalesEnvios.fechaFin,SalesEnvios.idUnidadTransporte,SalesUnidadesTransporte.placas,SalesUnidadesTransporte.modelo,SalesUnidadesTransporte.capacidad,SalesEnvios.pesoTotalVenta,SalesEnvios.estatus from SalesEnvios JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesEnvios.idUnidadTransporte";


                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, numMostar, "SalesEnvios");
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
                adapter.Fill(ds, start, 2, "SalesEnvios");
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
                adapter.Fill(ds, start, numMostar, "SalesEnvios");
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
                adapter.Fill(ds, start, 2, "SalesEnvios");
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
                adapter.Fill(ds, start, numMostar, "SalesEnvios");
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

                SqlDataAdapter datos = new SqlDataAdapter("select SalesEnvios.idEnvio, SalesEnvios.fechaInicio,SalesEnvios.fechaFin,SalesEnvios.idUnidadTransporte,SalesUnidadesTransporte.placas,SalesUnidadesTransporte.modelo,SalesUnidadesTransporte.capacidad,SalesEnvios.pesoTotalVenta,SalesEnvios.estatus from SalesEnvios JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesEnvios.idUnidadTransporte  where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesEnvios");
                this.dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
