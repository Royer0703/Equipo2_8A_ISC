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
    public partial class Asesorias : Form
    {


        ConexionSQLN cn = new ConexionSQLN();//negocios
        Class_Entidad obje = new Class_Entidad();//entidad
        DataSet dsTabla;

        int VarPagInicio = 1;
        //int VarPagIndice = 0;
        int TotalFilasAMostrar = 2;
        int VarPagFinal;

        SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int start;

        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_listar_SalesAsesorias(obje);

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

            string sql = "select SalesAsesorias.idAsesoria, SalesAsesorias.fecha, SalesAsesorias.comentarios, SalesAsesorias.estatus,SalesAsesorias.costo,SalesAsesorias.idParcela,SalesAsesorias.idEmpleado, SalesAsesorias.idUnidadTransporte, SalesParcelas.extension, SalesCultivos.nombre, Empleados.nombre, SalesUnidadesTransporte.placas , SalesUnidadesTransporte.marca,SalesUnidadesTransporte.modelo  from SalesAsesorias JOIN SalesParcelas ON SalesParcelas.idParcela = SalesAsesorias.idParcela JOIN SalesCultivos ON SalesCultivos.idCultivo = SalesParcelas.idCultivo JOIN Empleados ON Empleados.idEmpleado = SalesAsesorias.idEmpleado JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesAsesorias.idUnidadTransporte";
            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            //fill dataser
            adapter.Fill(ds, start, 2, "SalesAsesorias");
            //DGVIEW
            dataGridView1.DataSource = ds.Tables[0];
            //habilita Boton 
            btn_atras.Enabled = false;


        }

        public void Cargar_Datos_Placas_unidadTransporte()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select placas from SalesUnidadesTransporte";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb_Placas_unidadTransporte.Items.Add(dr["placas"].ToString());
                cb_Placas_unidadTransporte.DisplayMember = (dr["placas"].ToString());
                cb_Placas_unidadTransporte.ValueMember = (dr["placas"].ToString());
            }

        }

        public void Cargar_Datos_nombre_Empleados()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select nombre from Empleados";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb_nombre_Empleados.Items.Add(dr["nombre"].ToString());
                cb_nombre_Empleados.DisplayMember = (dr["nombre"].ToString());
                cb_nombre_Empleados.ValueMember = (dr["nombre"].ToString());
            }

        }

        public void Cargar_Datos_extencion_Parcelas()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select extension from SalesParcelas";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb_extension_Parcelas.Items.Add(dr["extension"].ToString());
                cb_extension_Parcelas.DisplayMember = (dr["extension"].ToString());
                cb_extension_Parcelas.ValueMember = (dr["extension"].ToString());
            }

        }




        public Asesorias()
        {
            InitializeComponent();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            dataGridView1.DataSource = cn.ConsultarJoinAsesoriaDT();
            start = 0;
            loadData();
            Cargar_Datos_Placas_unidadTransporte();
            Cargar_Datos_extencion_Parcelas();
            Cargar_Datos_nombre_Empleados();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            ds.Clear();
            loadData();

            txt_idAsesoria.Text = "";
            txt_fecha.Text = "";
            txt_comentarios.Text = "";
            Cb_Estatus.SelectedIndex = -1;
            txt_costo.Text = "";
            txt_idParcela.Text = "";
            txt_idEmpleado.Text = "";
            txt_idUnidadTransporte.Text = "";
            cb_extension_Parcelas.SelectedIndex = -1;
            cb_nombre_Empleados.SelectedIndex = -1;
            cb_Placas_unidadTransporte.SelectedIndex = -1;



        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_fecha.Text) || string.IsNullOrEmpty(txt_comentarios.Text) || string.IsNullOrEmpty(txt_costo.Text) || string.IsNullOrEmpty(txt_idParcela.Text) || string.IsNullOrEmpty(txt_idEmpleado.Text) || string.IsNullOrEmpty(txt_idUnidadTransporte.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cb_extension_Parcelas.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Parcela !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cb_nombre_Empleados.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Nombre del Empleado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cb_Placas_unidadTransporte.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar las Placas de Unidad de Transporte !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0 || cb_extension_Parcelas.SelectedIndex > 0 || cb_extension_Parcelas.SelectedIndex == 0|| cb_nombre_Empleados.SelectedIndex > 0 || cb_nombre_Empleados.SelectedIndex == 0|| cb_Placas_unidadTransporte.SelectedIndex > 0 || cb_Placas_unidadTransporte.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();


                cn.InsertarSalesAsesoriasDT(txt_fecha.Text, txt_comentarios.Text, Estatus, txt_costo.Text, txt_idParcela.Text, txt_idEmpleado.Text, txt_idUnidadTransporte.Text);

                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();
                ds.Clear();
                loadData();

                //txt_idAsesoria.Text = "";
                txt_fecha.Text = "";
                txt_comentarios.Text = "";
                Cb_Estatus.SelectedIndex = -1;
                txt_costo.Text = "";
                txt_idParcela.Text = "";
                txt_idEmpleado.Text = "";
                txt_idUnidadTransporte.Text = "";
                cb_extension_Parcelas.SelectedIndex = -1;
                cb_nombre_Empleados.SelectedIndex = -1;
                cb_Placas_unidadTransporte.SelectedIndex = -1;

                MessageBox.Show("Agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

             }
            else
            {

                MessageBox.Show("Error al Guardar los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_fecha.Text) || string.IsNullOrEmpty(txt_comentarios.Text) || string.IsNullOrEmpty(txt_costo.Text) || string.IsNullOrEmpty(txt_idParcela.Text) || string.IsNullOrEmpty(txt_idEmpleado.Text) || string.IsNullOrEmpty(txt_idUnidadTransporte.Text))
            {
                MessageBox.Show("Debe seleccionar de la tabla el dato!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cb_extension_Parcelas.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Parcela !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cb_nombre_Empleados.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Nombre del Empleado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cb_Placas_unidadTransporte.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar las Placas de Unidad de Transporte !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0 || cb_extension_Parcelas.SelectedIndex > 0 || cb_extension_Parcelas.SelectedIndex == 0 || cb_nombre_Empleados.SelectedIndex > 0 || cb_nombre_Empleados.SelectedIndex == 0 || cb_Placas_unidadTransporte.SelectedIndex > 0 || cb_Placas_unidadTransporte.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();


                cn.ModificarSalesAsesoriasDT(txt_idAsesoria.Text, txt_fecha.Text, txt_comentarios.Text, Estatus, txt_costo.Text, txt_idParcela.Text, txt_idEmpleado.Text, txt_idUnidadTransporte.Text);

                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();
                ds.Clear();
                loadData();

                txt_idAsesoria.Text = "";
                txt_fecha.Text = "";
                txt_comentarios.Text = "";
                Cb_Estatus.SelectedIndex = -1;
                txt_costo.Text = "";
                txt_idParcela.Text = "";
                txt_idEmpleado.Text = "";
                txt_idUnidadTransporte.Text = "";
                cb_extension_Parcelas.SelectedIndex = -1;
                cb_nombre_Empleados.SelectedIndex = -1;
                cb_Placas_unidadTransporte.SelectedIndex = -1;

                MessageBox.Show("Modificado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {



                MessageBox.Show("Error al Editar los datos!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_fecha.Text) || string.IsNullOrEmpty(txt_comentarios.Text) || string.IsNullOrEmpty(txt_costo.Text) || string.IsNullOrEmpty(txt_idParcela.Text) || string.IsNullOrEmpty(txt_idEmpleado.Text) || string.IsNullOrEmpty(txt_idUnidadTransporte.Text))
            {
                MessageBox.Show("Debe seleccionar de la tabla el dato!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cb_extension_Parcelas.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Parcela !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cb_nombre_Empleados.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Nombre del Empleado !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cb_Placas_unidadTransporte.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar las Placas de Unidad de Transporte !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0 || cb_extension_Parcelas.SelectedIndex > 0 || cb_extension_Parcelas.SelectedIndex == 0 || cb_nombre_Empleados.SelectedIndex > 0 || cb_nombre_Empleados.SelectedIndex == 0 || cb_Placas_unidadTransporte.SelectedIndex > 0 || cb_Placas_unidadTransporte.SelectedIndex == 0)
            {
                Cb_Estatus.Text = "I";
                cn.ModificarSalesAsesoriasDT(txt_idAsesoria.Text, txt_fecha.Text, txt_comentarios.Text, Cb_Estatus.Text, txt_costo.Text, txt_idParcela.Text, txt_idEmpleado.Text, txt_idUnidadTransporte.Text);

                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();
                ds.Clear();
                loadData();

                txt_idAsesoria.Text = "";
                txt_fecha.Text = "";
                txt_comentarios.Text = "";
                Cb_Estatus.SelectedIndex = -1;
                txt_costo.Text = "";
                txt_idParcela.Text = "";
                txt_idEmpleado.Text = "";
                txt_idUnidadTransporte.Text = "";
                cb_extension_Parcelas.SelectedIndex = -1;
                cb_nombre_Empleados.SelectedIndex = -1;
                cb_Placas_unidadTransporte.SelectedIndex = -1;

                MessageBox.Show("Eliminado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {


                MessageBox.Show("Error al Eliminar los datos!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }




        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            SqlDataAdapter datos = new SqlDataAdapter("select SalesAsesorias.idAsesoria, SalesAsesorias.fecha, SalesAsesorias.comentarios, SalesAsesorias.estatus,SalesAsesorias.costo,SalesAsesorias.idParcela,SalesAsesorias.idEmpleado,SalesAsesorias.idUnidadTransporte,SalesParcelas.extension,SalesCultivos.nombre,Empleados.nombre,SalesUnidadesTransporte.placas,SalesUnidadesTransporte.marca,SalesUnidadesTransporte.modelo  from SalesAsesorias JOIN SalesParcelas ON SalesParcelas.idParcela = SalesAsesorias.idParcela JOIN SalesCultivos ON SalesCultivos.idCultivo = SalesParcelas.idCultivo JOIN Empleados ON Empleados.idEmpleado = SalesAsesorias.idEmpleado JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesAsesorias.idUnidadTransporte where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
            DataSet ds = new DataSet();
            datos.Fill(ds, "SalesAsesorias");
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

   


            txt_idAsesoria.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_fecha.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_comentarios.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Cb_Estatus.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_costo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //txt_idParcela.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            //txt_idEmpleado.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            //txt_idUnidadTransporte.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            cb_extension_Parcelas.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            cb_nombre_Empleados.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            cb_Placas_unidadTransporte.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();


        }

        private void Asesorias_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void Asesorias_MouseMove(object sender, MouseEventArgs e)
        {
            
           
        }

        private void txt_idAsesoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txt_costo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txt_idParcela_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txt_idEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txt_idUnidadTransporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txt_comentarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO LETRAS!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void cb_extension_Parcelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select idParcela from SalesParcelas where extension ='" + cb_extension_Parcelas.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idParcela.Text = dr[0].ToString();
            }

            con.Close();
        }

        private void cb_nombre_Empleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select idEmpleado from Empleados where nombre ='" + cb_nombre_Empleados.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idEmpleado.Text = dr[0].ToString();
            }

            con.Close();
        }

        private void cb_Placas_unidadTransporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select idUnidadTransporte from SalesUnidadesTransporte where placas ='" + cb_Placas_unidadTransporte.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idUnidadTransporte.Text = dr[0].ToString();
            }

            con.Close();
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
                string sql = "select SalesAsesorias.idAsesoria, SalesAsesorias.fecha, SalesAsesorias.comentarios, SalesAsesorias.estatus,SalesAsesorias.costo,SalesAsesorias.idParcela,SalesAsesorias.idEmpleado, SalesAsesorias.idUnidadTransporte, SalesParcelas.extension, SalesCultivos.nombre, Empleados.nombre, SalesUnidadesTransporte.placas , SalesUnidadesTransporte.marca,SalesUnidadesTransporte.modelo  from SalesAsesorias JOIN SalesParcelas ON SalesParcelas.idParcela = SalesAsesorias.idParcela JOIN SalesCultivos ON SalesCultivos.idCultivo = SalesParcelas.idCultivo JOIN Empleados ON Empleados.idEmpleado = SalesAsesorias.idEmpleado JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesAsesorias.idUnidadTransporte";
                   
                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, numMostar, "SalesAsesorias");
                //DGVIEW
                dataGridView1.DataSource = ds.Tables[0];
                //habilita Boton 
                btn_atras.Enabled = false;

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
                adapter.Fill(ds, start, 2, "SalesAsesorias");
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
                adapter.Fill(ds, start, numMostar, "SalesAsesorias");
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
                adapter.Fill(ds, start, 2, "SalesAsesorias");
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
                adapter.Fill(ds, start, numMostar, "SalesAsesorias");
            }
        }
    }
}
