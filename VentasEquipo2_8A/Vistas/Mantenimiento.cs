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
using System.Data.SqlClient;//new 
using Entidad;//new

namespace Vistas
{
    public partial class Mantenimiento : Form
    {
        ConexionSQLN cn = new ConexionSQLN();//negocios
        Class_Entidad obje = new Class_Entidad();//entidad
        DataSet dsTabla;

        int VarPagInicio = 1;
        //int VarPagIndice = 0;
        int TotalFilasAMostrar = 2;
        int VarPagFinal;

        //conexio a mi base de datos
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int start;

        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_listar_Mantenimiento(obje);

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
            string sql = "select SalesMantenimiento.idMantenimiento, SalesMantenimiento.fechaInicio, SalesMantenimiento.fechaFin,SalesMantenimiento.taller, SalesMantenimiento.costo,SalesMantenimiento.comentarios, SalesMantenimiento.tipo, SalesMantenimiento.idUnidadTransporte, SalesMantenimiento.estatus, SalesUnidadesTransporte.placas, SalesUnidadesTransporte.marca,SalesUnidadesTransporte.modelo  from SalesMantenimiento JOIN SalesUnidadesTransporte ON SalesMantenimiento.idUnidadTransporte = SalesUnidadesTransporte.idUnidadTransporte ";
            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            //fill dataser
            adapter.Fill(ds, start, 2, "SalesMantenimiento");
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


        public Mantenimiento()
        {
            InitializeComponent();
            //dataGridView1.DataSource = cn.ConsultaMantenimientoDT();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            dataGridView1.DataSource = cn.ConsultarJoinMiembrosDT();
            start = 0;
            loadData();
            Cargar_Datos_Placas_unidadTransporte();



        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = cn.ConsultaMantenimientoDT();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            txt_idMantenimiento.Text = "";
            txt_fechaInicio.Text = " ";
            txt_fechaFin.Text = "";
            txt_taller.Text = "";
            txt_costo.Text = "";
            txt_comentarios.Text = "";
            txt_tipo.Text = "";
            txt_idUnidadTransporte.Text = "";
            Cb_Estatus.SelectedIndex = -1;
            cb_Placas_unidadTransporte.SelectedIndex = -1;

            ds.Clear();
            loadData();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(txt_fechaInicio.Text) || string.IsNullOrEmpty(txt_fechaFin.Text) || string.IsNullOrEmpty(txt_taller.Text) || string.IsNullOrEmpty(txt_costo.Text) || string.IsNullOrEmpty(txt_comentarios.Text) || string.IsNullOrEmpty(txt_tipo.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cb_Placas_unidadTransporte.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar Unidad De Transporte !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0 || cb_Placas_unidadTransporte.SelectedIndex > 0 || cb_Placas_unidadTransporte.SelectedIndex ==0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                cn.InsertarMantenimientoDT(txt_fechaInicio.Text, txt_fechaFin.Text, txt_taller.Text, txt_costo.Text, txt_comentarios.Text, txt_tipo.Text, txt_idUnidadTransporte.Text, Estatus);
                //dataGridView1.DataSource = cn.ConsultaMantenimientoDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

                //txt_idMantenimiento.Text = "";
                txt_fechaInicio.Text = " ";
                txt_fechaFin.Text = "";
                txt_taller.Text = "";
                txt_costo.Text = "";
                txt_comentarios.Text = "";
                txt_tipo.Text = "";
                txt_idUnidadTransporte.Text = "";
                Cb_Estatus.SelectedIndex = -1;
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
            if (string.IsNullOrEmpty(txt_fechaInicio.Text) || string.IsNullOrEmpty(txt_fechaFin.Text) || string.IsNullOrEmpty(txt_taller.Text) || string.IsNullOrEmpty(txt_costo.Text) || string.IsNullOrEmpty(txt_comentarios.Text) || string.IsNullOrEmpty(txt_tipo.Text) || string.IsNullOrEmpty(txt_idUnidadTransporte.Text))
            {
                MessageBox.Show("Debe seleccionar de la tabla el dato!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cb_Placas_unidadTransporte.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar Unidad De Transporte !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0 || cb_Placas_unidadTransporte.SelectedIndex > 0 || cb_Placas_unidadTransporte.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();

                cn.ModificarMantenimientoDT(txt_idMantenimiento.Text, txt_fechaInicio.Text, txt_fechaFin.Text, txt_taller.Text, txt_costo.Text, txt_comentarios.Text, txt_tipo.Text, txt_idUnidadTransporte.Text, Estatus);
                //dataGridView1.DataSource = cn.ConsultaMantenimientoDT();
                ds.Clear();
                loadData();

                txt_idMantenimiento.Text = "";
                txt_fechaInicio.Text = " ";
                txt_fechaFin.Text = "";
                txt_taller.Text = "";
                txt_costo.Text = "";
                txt_comentarios.Text = "";
                txt_tipo.Text = "";
                txt_idUnidadTransporte.Text = "";
                Cb_Estatus.SelectedIndex = -1;
                cb_Placas_unidadTransporte.SelectedIndex = -1;

                MessageBox.Show("Actualizados Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {


                MessageBox.Show("Error al Editar los datos!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {



            if (string.IsNullOrEmpty(txt_fechaInicio.Text) || string.IsNullOrEmpty(txt_fechaFin.Text) || string.IsNullOrEmpty(txt_taller.Text) || string.IsNullOrEmpty(txt_costo.Text) || string.IsNullOrEmpty(txt_comentarios.Text) || string.IsNullOrEmpty(txt_tipo.Text) || string.IsNullOrEmpty(txt_idUnidadTransporte.Text))
            {
                MessageBox.Show("Debe seleccionar de la tabla el dato!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cb_Placas_unidadTransporte.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar Unidad De Transporte !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0 || cb_Placas_unidadTransporte.SelectedIndex > 0 || cb_Placas_unidadTransporte.SelectedIndex == 0)
            {
                Cb_Estatus.Text = "I";
                cn.ModificarMantenimientoDT(txt_idMantenimiento.Text, txt_fechaInicio.Text, txt_fechaFin.Text, txt_taller.Text, txt_costo.Text, txt_comentarios.Text, txt_tipo.Text, txt_idUnidadTransporte.Text, Cb_Estatus.Text);
                //dataGridView1.DataSource = cn.ConsultaMantenimientoDT();
                ds.Clear();
                loadData();

                txt_idMantenimiento.Text = "";
                txt_fechaInicio.Text = " ";
                txt_fechaFin.Text = "";
                txt_taller.Text = "";
                txt_costo.Text = "";
                txt_comentarios.Text = "";
                txt_tipo.Text = "";
                txt_idUnidadTransporte.Text = "";
                Cb_Estatus.SelectedIndex = -1;
                cb_Placas_unidadTransporte.SelectedIndex = -1;


                MessageBox.Show("Eliminado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Eliminar los datos!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idMantenimiento.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_fechaInicio.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_fechaFin.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_taller.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_costo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_comentarios.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_tipo.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            // txt_idUnidadTransporte.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            cb_Placas_unidadTransporte.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            Cb_Estatus.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txt_idMantenimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txt_costo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        //VALIDAR SOLO LETRAS INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txt_taller_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO LETRAS!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }
        //VALIDAR SOLO LETRAS INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txt_comentarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO LETRAS!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }
        //VALIDAR SOLO LETRAS INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txt_tipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO LETRAS!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txt_idUnidadTransporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
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
                SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
                con.Open();
                SqlDataAdapter datos = new SqlDataAdapter("select SalesMantenimiento.idMantenimiento, SalesMantenimiento.fechaInicio, SalesMantenimiento.fechaFin,SalesMantenimiento.taller, SalesMantenimiento.costo,SalesMantenimiento.comentarios, SalesMantenimiento.tipo, SalesMantenimiento.idUnidadTransporte, SalesMantenimiento.estatus, SalesUnidadesTransporte.placas, SalesUnidadesTransporte.marca,SalesUnidadesTransporte.modelo  from SalesMantenimiento JOIN SalesUnidadesTransporte ON SalesMantenimiento.idUnidadTransporte = SalesUnidadesTransporte.idUnidadTransporte where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesMantenimiento");
                this.dataGridView1.DataSource = ds.Tables[0];
            }
               
        }

        private void Mantenimiento_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void Mantenimiento_MouseClick(object sender, MouseEventArgs e)
        {
           

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
         
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
                string sql = "select SalesMantenimiento.idMantenimiento, SalesMantenimiento.fechaInicio, SalesMantenimiento.fechaFin,SalesMantenimiento.taller, SalesMantenimiento.costo,SalesMantenimiento.comentarios, SalesMantenimiento.tipo, SalesMantenimiento.idUnidadTransporte, SalesMantenimiento.estatus, SalesUnidadesTransporte.placas, SalesUnidadesTransporte.marca,SalesUnidadesTransporte.modelo  from SalesMantenimiento JOIN SalesUnidadesTransporte ON SalesMantenimiento.idUnidadTransporte = SalesUnidadesTransporte.idUnidadTransporte ";

                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, numMostar, "SalesMantenimiento");
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
                adapter.Fill(ds, start, 2, "SalesMantenimiento");
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
                adapter.Fill(ds, start, numMostar, "SalesMantenimiento");
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
                adapter.Fill(ds, start, 2, "SalesMantenimiento");
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
                adapter.Fill(ds, start, numMostar, "SalesMantenimiento");
            }
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
