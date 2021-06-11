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
    public partial class Tripulacion : Form
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
            dsTabla = cn.N_Lista_SalesTripulacion(obje);

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

            string sql = "select SalesTripulacion.idEmpleado,Empleados.nombre,SalesTripulacion.idEnvio,SalesEnvios.idUnidadTransporte,SalesUnidadesTransporte.placas,SalesEnvios.fechaInicio,SalesEnvios.fechaFin,SalesTripulacion.rol, SalesTripulacion.estatus from SalesTripulacion JOIN Empleados ON Empleados.idEmpleado = SalesTripulacion.idEmpleado JOIN SalesEnvios ON SalesEnvios.idEnvio = SalesTripulacion.idEnvio JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesEnvios.idUnidadTransporte";

                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, 2, "SalesTripulacion");
                //DGVIEW
                dataGridView1.DataSource = ds.Tables[0];
                //habilita Boton 
                 btn_atras.Enabled = false;
            
        }



        public void Cargar_Datos_EmpleadoNombre()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select nombre from Empleados";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_idEmpleado.Items.Add(dr["nombre"].ToString());
                Cb_idEmpleado.DisplayMember = (dr["nombre"].ToString());
                Cb_idEmpleado.ValueMember = (dr["nombre"].ToString());
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


        public Tripulacion()
        {
            InitializeComponent();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            // dataGridView1.DataSource = cn.ConsultarJoinParcelasDT();
            start = 0;

            Cargar_Datos_EnviosId();
            Cargar_Datos_EmpleadoNombre();
            loadData();
            Mostrar_datos();

            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

        }

        private void Cb_idEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select idEmpleado from Empleados where nombre ='" + Cb_idEmpleado.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idEmpleado.Text = dr[0].ToString();
            }

            con.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Cb_idEnvio.SelectedIndex = -1;
            Cb_idEmpleado.SelectedIndex = -1;
            txt_idEmpleado.Text = "";
            txt_Rol.Text = "";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Cb_idEnvio.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Envio !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (Cb_idEmpleado.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Empleado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (string.IsNullOrEmpty(txt_Rol.Text))
            {
                MessageBox.Show("Falta agregar el Rol !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (Cb_idEnvio.SelectedIndex >= 0 && Cb_idEmpleado.SelectedIndex >= 0)
            {
                String Estatus = "A";
                cn.InsertarSalesTripulacionDT(txt_idEmpleado.Text, Cb_idEnvio.Text, txt_Rol.Text, Estatus);


                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

                Cb_idEnvio.SelectedIndex = -1;
                Cb_idEmpleado.SelectedIndex = -1;
                txt_idEmpleado.Text = "";
                txt_Rol.Text = "";

                MessageBox.Show("Agregado  Correctamente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Cb_idEnvio.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Envio !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Cb_idEmpleado.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Empleado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txt_Rol.Text))
            {
                MessageBox.Show("Falta agregar el Rol !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Cb_idEnvio.SelectedIndex >= 0 || Cb_idEmpleado.SelectedIndex >= 0)
            {
                String Estatus = "A";
                cn.ModificarSalesTripulacionDT(txt_idEmpleado.Text, Cb_idEnvio.Text, txt_Rol.Text, Estatus);


                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

                Cb_idEnvio.SelectedIndex = -1;
                Cb_idEmpleado.SelectedIndex = -1;
                txt_idEmpleado.Text = "";
                txt_Rol.Text = "";

                MessageBox.Show("Actualizado  Correctamente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuardar.Enabled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Cb_idEnvio.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Envio !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Cb_idEmpleado.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Empleado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txt_Rol.Text))
            {
                MessageBox.Show("Falta agregar el Rol !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Cb_idEnvio.SelectedIndex >= 0 || Cb_idEmpleado.SelectedIndex >= 0)
            {
                String Estatus = "I";
                cn.ModificarSalesTripulacionDT(txt_idEmpleado.Text, Cb_idEnvio.Text, txt_Rol.Text, Estatus);


                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

                Cb_idEnvio.SelectedIndex = -1;
                Cb_idEmpleado.SelectedIndex = -1;
                txt_idEmpleado.Text = "";
                txt_Rol.Text = "";

                MessageBox.Show("Eliminado  Correctamente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuardar.Enabled = true;
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
                string sql = "select SalesTripulacion.idEmpleado,Empleados.nombre,SalesTripulacion.idEnvio,SalesEnvios.idUnidadTransporte,SalesUnidadesTransporte.placas,SalesEnvios.fechaInicio,SalesEnvios.fechaFin,SalesTripulacion.rol, SalesTripulacion.estatus from SalesTripulacion JOIN Empleados ON Empleados.idEmpleado = SalesTripulacion.idEmpleado JOIN SalesEnvios ON SalesEnvios.idEnvio = SalesTripulacion.idEnvio JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesEnvios.idUnidadTransporte";
                    
                    
                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, numMostar, "SalesTripulacion");
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
                adapter.Fill(ds, start, 2, "SalesTripulacion");
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

                SqlDataAdapter datos = new SqlDataAdapter("select SalesTripulacion.idEmpleado,Empleados.nombre,SalesTripulacion.idEnvio,SalesEnvios.idUnidadTransporte,SalesUnidadesTransporte.placas,SalesEnvios.fechaInicio,SalesEnvios.fechaFin,SalesTripulacion.rol, SalesTripulacion.estatus from SalesTripulacion JOIN Empleados ON Empleados.idEmpleado = SalesTripulacion.idEmpleado JOIN SalesEnvios ON SalesEnvios.idEnvio = SalesTripulacion.idEnvio JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesEnvios.idUnidadTransporte  where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesTripulacion");
                this.dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idEmpleado.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Cb_idEmpleado.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Cb_idEnvio.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_Rol.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            btnGuardar.Enabled = false;
           
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void Cb_idEnvio_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Cb_idEnvio.SelectedIndex <= -1)
            {
                btnGuardar.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else if (Cb_idEnvio.SelectedIndex > 0)
            {
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
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

        private void txt_Rol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO LETRAS!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }
    }
}
