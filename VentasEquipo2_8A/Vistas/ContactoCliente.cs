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
using System.Text.RegularExpressions;

namespace Vistas
{
    public partial class ContactoCliente : Form
    {
        

        ConexionSQLN cn = new ConexionSQLN();//negocios
        Class_Entidad obje = new Class_Entidad();//entidad
        DataSet dsTabla;

        int VarPagInicio = 1;
        //int VarPagIndice = 0;
        int TotalFilasAMostrar = 2;
        int VarPagFinal;

        //conexio a mi base de datos
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);//-------
        /// </summary>
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int start;

        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_listar_CONTACTOCLIENTE(obje);

            //dataGridView_UnidadesT.DataSource = dsTabla.Tables[1];
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
            string sql = "select SalesContactosCliente.idContacto, SalesClientes.nombre, SalesContactosCliente.telefono, SalesContactosCliente.email, SalesContactosCliente.idCliente, SalesContactosCliente.estatus from SalesContactosCliente JOIN SalesClientes ON SalesContactosCliente.idCliente = SalesClientes.idCliente ";

            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            //fill dataser
            adapter.Fill(ds, start, 2, "SalesContactosCliente");
            //DGVIEW
            dataGridView_UnidadesT.DataSource = ds.Tables[0];
            //habilita Boton 
            btn_atras.Enabled = false;


        }
        public void Cargar_Datos_clienteNombre()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);//----------
            con.Open();
            string q = "select nombre from SalesClientes";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb_Nombre_Cliente.Items.Add(dr["nombre"].ToString());
                cb_Nombre_Cliente.DisplayMember = (dr["nombre"].ToString());
                cb_Nombre_Cliente.ValueMember = (dr["nombre"].ToString());
            }

        }

        public ContactoCliente()
        {
            InitializeComponent();
            dataGridView_UnidadesT.DataSource = cn.ConsultarJoinContactoClienteDT();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            start = 0;
            loadData();
            Cargar_Datos_clienteNombre();
        }

        private void dataGridView_UnidadesT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idContacto.Text = dataGridView_UnidadesT.CurrentRow.Cells[0].Value.ToString();
            //txt_nombre.Text = dataGridView_UnidadesT.CurrentRow.Cells[1].Value.ToString();
            txt_telefono.Text = dataGridView_UnidadesT.CurrentRow.Cells[2].Value.ToString();
            txt_email.Text = dataGridView_UnidadesT.CurrentRow.Cells[3].Value.ToString();
            txt_idCliente.Text = dataGridView_UnidadesT.CurrentRow.Cells[4].Value.ToString();
            Cb_Estatus.Text = dataGridView_UnidadesT.CurrentRow.Cells[5].Value.ToString();
            cb_Nombre_Cliente.Text = dataGridView_UnidadesT.CurrentRow.Cells[1].Value.ToString();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
           
            txt_idContacto.Text = "";
            txt_nombre.Text = "";
            txt_telefono.Text = "";
            txt_email.Text = "";
            txt_idCliente.Text = "";
            Cb_Estatus.SelectedIndex = -1;
            cb_Nombre_Cliente.SelectedIndex = -1;

            ds.Clear();
            loadData();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string pattern = "([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if ( string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_telefono.Text) || string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_idCliente.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
            if (!Regex.IsMatch(txt_email.Text, pattern))
            {
                MessageBox.Show("Email incorecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_telefono.Text.Length > 10 || txt_telefono.Text.Length < 10)
            {
                MessageBox.Show("Numero debe tener 10 digitos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (Cb_Estatus.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Estatus !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cb_Nombre_Cliente.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Nombre del cliente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0 || cb_Nombre_Cliente.SelectedIndex > 0 || cb_Nombre_Cliente.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                cn.InsertarContactoClienteDT(txt_nombre.Text, txt_telefono.Text, txt_email.Text, txt_idCliente.Text, Estatus);
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

                // txt_idContacto.Text = "";
                txt_nombre.Text = "";
                txt_telefono.Text = "";
                txt_email.Text = "";
                txt_idCliente.Text = "";
                Cb_Estatus.SelectedIndex = -1;
                cb_Nombre_Cliente.SelectedIndex = -1;


                MessageBox.Show("Agregado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Error al Guardar los datos!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string pattern = "([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_telefono.Text) || string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_idCliente.Text))
            {
                MessageBox.Show("Debe seleccionar de la tabla el dato!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (!Regex.IsMatch(txt_email.Text, pattern))
            {
                MessageBox.Show("Email incorecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Estatus !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cb_Nombre_Cliente.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Nombre del cliente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0 || cb_Nombre_Cliente.SelectedIndex > 0 || cb_Nombre_Cliente.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                cn.ModificarContactoClienteDT(txt_idContacto.Text, txt_nombre.Text, txt_telefono.Text, txt_email.Text, txt_idCliente.Text, Estatus);
                ds.Clear();
                loadData();

                txt_idContacto.Text = "";
                txt_nombre.Text = "";
                txt_telefono.Text = "";
                txt_email.Text = "";//
                txt_idCliente.Text = "";
                Cb_Estatus.SelectedIndex = -1;
                cb_Nombre_Cliente.SelectedIndex = -1;


                MessageBox.Show("Actualizado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Error al Editar los datos!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string pattern = "([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_telefono.Text) || string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_idCliente.Text))
            {
                MessageBox.Show("Debe seleccionar de la tabla el dato!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (!Regex.IsMatch(txt_email.Text, pattern))
            {
                MessageBox.Show("Email incorecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Estatus !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cb_Nombre_Cliente.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Nombre del cliente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0 || cb_Nombre_Cliente.SelectedIndex > 0 || cb_Nombre_Cliente.SelectedIndex == 0)
            {
                Cb_Estatus.Text = "I";
                cn.ModificarContactoClienteDT(txt_idContacto.Text, txt_nombre.Text, txt_telefono.Text, txt_email.Text, txt_idCliente.Text, Cb_Estatus.Text);
                ds.Clear();
                loadData();

                txt_idContacto.Text = "";
                txt_nombre.Text = "";
                txt_telefono.Text = "";
                txt_email.Text = "";
                txt_idCliente.Text = "";
                Cb_Estatus.SelectedIndex = -1;
                cb_Nombre_Cliente.SelectedIndex = -1;


                MessageBox.Show("Eliminado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Error al Eliminar los datos!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txt_idContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txt_idCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        //VALIDAR SOLO LETRAS INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO LETRAS!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);//-------
                con.Open();
                SqlDataAdapter datos = new SqlDataAdapter(" select SalesContactosCliente.idContacto, SalesClientes.nombre, SalesContactosCliente.telefono, SalesContactosCliente.email, SalesContactosCliente.idCliente, SalesContactosCliente.estatus from SalesContactosCliente JOIN SalesClientes ON SalesContactosCliente.idCliente = SalesClientes.idCliente where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesContactosCliente");
                this.dataGridView_UnidadesT.DataSource = ds.Tables[0];
            }

        }

        private void ContactoCliente_MouseMove(object sender, MouseEventArgs e)
        {
           
            
        }

        private void ContactoCliente_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void cb_Nombre_Cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select idCliente, telefono, email from SalesClientes where nombre ='" + cb_Nombre_Cliente.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idCliente.Text = dr[0].ToString();
                txt_telefono.Text = dr[1].ToString();
                txt_email.Text = dr[2].ToString();
                txt_nombre.Text = cb_Nombre_Cliente.Text;
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
                string sql = "select SalesContactosCliente.idContacto, SalesClientes.nombre, SalesContactosCliente.telefono, SalesContactosCliente.email, SalesContactosCliente.idCliente, SalesContactosCliente.estatus from SalesContactosCliente JOIN SalesClientes ON SalesContactosCliente.idCliente = SalesClientes.idCliente ";

                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, numMostar, "SalesContactosCliente");
                //DGVIEW
                dataGridView_UnidadesT.DataSource = ds.Tables[0];
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
                adapter.Fill(ds, start, 2, "SalesContactosCliente");
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
                adapter.Fill(ds, start, numMostar, "SalesContactosCliente");
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
                adapter.Fill(ds, start, 2, "SalesContactosCliente");
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
                adapter.Fill(ds, start, numMostar, "SalesContactosCliente");
            }
        }

        private void txt_email_Validating(object sender, CancelEventArgs e)
        {
           // System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
           // if (txt_email.Text.Length > 0)
          //  {
           //     if (!rEmail.IsMatch(txt_email.Text))
             //   {
           //         MessageBox.Show("Email incorecto","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           //     }



          //  }


        }

        private void txt_email_Leave(object sender, EventArgs e)
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
    }
}
