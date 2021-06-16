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

            if (Cb_idEnvio.SelectedIndex <= -1)
            {
                SqlCommand cmd;

                string sql = "select SalesTripulacion.idEmpleado,Empleados.nombre,SalesTripulacion.idEnvio,SalesEnvios.idUnidadTransporte,SalesUnidadesTransporte.placas,SalesEnvios.fechaInicio,SalesEnvios.fechaFin,SalesTripulacion.rol, SalesTripulacion.estatus from SalesTripulacion JOIN Empleados ON Empleados.idEmpleado = SalesTripulacion.idEmpleado JOIN SalesEnvios ON SalesEnvios.idEnvio = SalesTripulacion.idEnvio JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesEnvios.idUnidadTransporte";

                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, 100, "SalesTripulacion");
                //DGVIEW
                dataGridView1.DataSource = ds.Tables[0];
                //habilita Boton 
                btn_atras.Enabled = false;
            }
        }



        public void Cargar_Datos_EmpleadoNombre()
        {
            con.Open();
            string q = "SELECT s.* FROM Empleados s WHERE NOT EXISTS (SELECT * FROM SalesTripulacion a WHERE s.idEmpleado = a.idEmpleado and a.idEnvio = '" + Cb_idEnvio.SelectedItem + "')";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                Cb_idEmpleado.Items.Add(dr[1].ToString());
                Cb_idEmpleado.DisplayMember = (dr[1].ToString());
                Cb_idEmpleado.ValueMember = (dr[1].ToString());

            }

            con.Close();
        }

        public void Cargar_Datos_EnviosId()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select idEnvio from SalesEnvios where estatus = 'A' ";
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
            con1.Open();
            string q = "select idEmpleado from Empleados where nombre ='" + Cb_idEmpleado.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idEmpleado.Text = dr[0].ToString();
            }

            con1.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Cb_idEnvio.SelectedIndex = -1;
            Cb_idEmpleado.SelectedIndex = -1;
            txt_idEmpleado.Text = "";
            txt_conductor.Text = "";
            Cb_RolTripulacion.SelectedIndex = -1;



        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Cb_idEnvio.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Envio !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if  (Cb_idEmpleado.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Empleado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           else if (Cb_RolTripulacion.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta agregar el Rol !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Cb_idEnvio.SelectedIndex >= 0 && Cb_idEmpleado.SelectedIndex >= 0)
            {
                String Estatus = "A";
                cn.InsertarSalesTripulacionDT(txt_idEmpleado.Text, Cb_idEnvio.Text, Cb_RolTripulacion.Text, Estatus);


                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

                Cb_idEnvio.SelectedIndex = -1;
                Cb_idEmpleado.SelectedIndex = -1;
                txt_idEmpleado.Text = "";
                Cb_RolTripulacion.SelectedIndex = -1;
                txt_conductor.Text = "";
                Cb_RolTripulacion.SelectedIndex = -1;

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
            else if (Cb_RolTripulacion.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta agregar el Rol !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Cb_idEnvio.SelectedIndex >= 0 || Cb_idEmpleado.SelectedIndex >= 0)
            {
                String Estatus = "A";
                cn.ModificarSalesTripulacionDT(txt_idEmpleado.Text, Cb_idEnvio.Text, Cb_RolTripulacion.Text, Estatus);


                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

                Cb_idEnvio.SelectedIndex = -1;
                Cb_idEmpleado.SelectedIndex = -1;
                txt_idEmpleado.Text = "";
                Cb_RolTripulacion.SelectedIndex = -1;
                txt_conductor.Text = "";
                Cb_RolTripulacion.SelectedIndex = -1;

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
            else if (Cb_RolTripulacion.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta agregar el Rol !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Cb_idEnvio.SelectedIndex >= 0 || Cb_idEmpleado.SelectedIndex >= 0)
            {
                String Estatus = "I";
                cn.ModificarSalesTripulacionDT(txt_idEmpleado.Text, Cb_idEnvio.Text, Cb_RolTripulacion.Text, Estatus);


                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

                Cb_idEnvio.SelectedIndex = -1;
                Cb_idEmpleado.SelectedIndex = -1;
                txt_idEmpleado.Text = "";
                Cb_RolTripulacion.SelectedIndex = -1;
                txt_conductor.Text = "";
                Cb_RolTripulacion.SelectedIndex = -1;

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
            Cb_idEmpleado.SelectedItem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Cb_idEnvio.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Cb_RolTripulacion.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            btnGuardar.Enabled = false;
           
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void Cb_idEnvio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cb_idEnvio.SelectedIndex <= -1)
            {
                ds.Clear();
                loadData();

                btnGuardar.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else
            {

                // string conexionstring = "server = DESKTOP-IP4QBPJ\\SQLEXPRESS; database = ERP;" +
                // "integrated security = true";
                SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);

                SqlDataAdapter datos = new SqlDataAdapter("select SalesTripulacion.idEmpleado,Empleados.nombre,SalesTripulacion.idEnvio,SalesEnvios.idUnidadTransporte,SalesUnidadesTransporte.placas,SalesEnvios.fechaInicio,SalesEnvios.fechaFin,SalesTripulacion.rol, SalesTripulacion.estatus from SalesTripulacion JOIN Empleados ON Empleados.idEmpleado = SalesTripulacion.idEmpleado JOIN SalesEnvios ON SalesEnvios.idEnvio = SalesTripulacion.idEnvio JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesEnvios.idUnidadTransporte where SalesEnvios.idEnvio = '" + Cb_idEnvio.SelectedItem + "'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesDetallesEnvio");
                this.dataGridView1.DataSource = ds.Tables[0];

                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                txt_conductor.Text = "";
                txt_idempleadoTripulacio.Text = "";
                Cb_idEmpleado.SelectedItem = -1;
                Cb_RolTripulacion.SelectedItem = -1;

            }

            con.Open();
            string q = "SELECT s.* FROM Empleados s WHERE NOT EXISTS (SELECT * FROM SalesTripulacion a WHERE s.idEmpleado = a.idEmpleado and a.idEnvio = '" + Cb_idEnvio.SelectedItem + "')";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                Cb_idEmpleado.Items.Add(dr[1].ToString());
                Cb_idEmpleado.DisplayMember = (dr[1].ToString());
                Cb_idEmpleado.ValueMember = (dr[1].ToString());

            }

            con.Close();

            con.Open();//con para ver que no se agrege otra vez el conductor
            string qx = "select SalesTripulacion.rol,SalesTripulacion.idEmpleado from SalesTripulacion where SalesTripulacion.rol = 'CONDUCTOR' and SalesTripulacion.idEnvio = '" + Cb_idEnvio.SelectedItem + "'";
            SqlCommand cmdx = new SqlCommand(qx, con);
            SqlDataReader drx = cmdx.ExecuteReader();
            while (drx.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_conductor.Text = drx[0].ToString();
                txt_idempleadoTripulacio.Text = drx[1].ToString();

                if (string.IsNullOrEmpty(txt_conductor.Text))
                {
                    txt_conductor.Text = "";
                    txt_idempleadoTripulacio.Text = "";
                }
              
            }

            con.Close();












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

        private void Cb_idEmpleado_MouseClick(object sender, MouseEventArgs e)
        {
            Cb_idEmpleado.Items.Clear();
            Cargar_Datos_EmpleadoNombre();

        }

        private void Cb_RolTripulacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_conductor.Text))
            {

            }
            else if (txt_conductor.Text.Length > 0)//se que ya hay un conductor en el Envio 
            {
                Cb_RolTripulacion.Text = "PASAJERO";
                MessageBox.Show("Ya existe un CONDUCTOR registrado en este envio !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
