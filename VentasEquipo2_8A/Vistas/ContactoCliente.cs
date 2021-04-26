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
    public partial class ContactoCliente : Form
    {
        

        ConexionSQLN cn = new ConexionSQLN();//negocios
        Class_Entidad obje = new Class_Entidad();//entidad
        DataSet dsTabla;

        int VarPagInicio = 1;
        int VarPagIndice = 0;
        int TotalFilasAMostrar = 2;
        int VarPagFinal;


        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_listar_CONTACTOCLIENTE(obje);

            dataGridView_UnidadesT.DataSource = dsTabla.Tables[1];
            txtCantidadTotal.Text = dsTabla.Tables[0].Rows[0][0].ToString();

            int cantidad = Convert.ToInt32(dsTabla.Tables[0].Rows[0][0].ToString()) / TotalFilasAMostrar;
            comboBox2.Items.Clear();

            if (Convert.ToInt32(dsTabla.Tables[0].Rows[0][0].ToString()) % TotalFilasAMostrar > 0)
            {
                cantidad += 1;
            }

            textBox3.Text = cantidad.ToString();
            comboBox2.Items.Clear();

            for (int x = 1; x <= cantidad; x++)
            {
                comboBox2.Items.Add(x.ToString());
            }

            comboBox2.SelectedIndex = VarPagIndice;
        }









        public ContactoCliente()
        {
            InitializeComponent();
            //dataGridView_UnidadesT.DataSource = cn.ConsultaContactoClienteDT();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            dataGridView2.DataSource = cn.ConsultaCliente();
        }

        private void dataGridView_UnidadesT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idContacto.Text = dataGridView_UnidadesT.CurrentRow.Cells[0].Value.ToString();
            txt_nombre.Text = dataGridView_UnidadesT.CurrentRow.Cells[1].Value.ToString();
            txt_telefono.Text = dataGridView_UnidadesT.CurrentRow.Cells[2].Value.ToString();
            txt_email.Text = dataGridView_UnidadesT.CurrentRow.Cells[3].Value.ToString();
            txt_idCliente.Text = dataGridView_UnidadesT.CurrentRow.Cells[4].Value.ToString();
            Cb_Estatus.Text = dataGridView_UnidadesT.CurrentRow.Cells[5].Value.ToString();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //dataGridView_UnidadesT.DataSource = cn.ConsultaContactoClienteDT();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            dataGridView2.DataSource = cn.ConsultaCliente();

            txt_idContacto.Text = "";
            txt_nombre.Text = "";
            txt_telefono.Text = "";
            txt_email.Text = "";
            txt_idCliente.Text = "";
            Cb_Estatus.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_idContacto.Text) || string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_telefono.Text) || string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_idCliente.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                cn.InsertarContactoClienteDT(txt_idContacto.Text, txt_nombre.Text, txt_telefono.Text, txt_email.Text, txt_idCliente.Text, Estatus);
                //dataGridView_UnidadesT.DataSource = cn.ConsultaContactoClienteDT();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();
                dataGridView2.DataSource = cn.ConsultaCliente();

                txt_idContacto.Text = "";
                txt_nombre.Text = "";
                txt_telefono.Text = "";
                txt_email.Text = "";//
                txt_idCliente.Text = "";
                Cb_Estatus.Text = "";


                MessageBox.Show("Agregado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_idContacto.Text) || string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_telefono.Text) || string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_idCliente.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                cn.ModificarContactoClienteDT(txt_idContacto.Text, txt_nombre.Text, txt_telefono.Text, txt_email.Text, txt_idCliente.Text, Estatus);
                //dataGridView_UnidadesT.DataSource = cn.ConsultaContactoClienteDT();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();
                dataGridView2.DataSource = cn.ConsultaCliente();

                txt_idContacto.Text = "";
                txt_nombre.Text = "";
                txt_telefono.Text = "";
                txt_email.Text = "";//
                txt_idCliente.Text = "";
                Cb_Estatus.Text = "";


                MessageBox.Show("Actualizado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_idContacto.Text) || string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_telefono.Text) || string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_idCliente.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                Cb_Estatus.Text = "I";
                cn.ModificarContactoClienteDT(txt_idContacto.Text, txt_nombre.Text, txt_telefono.Text, txt_email.Text, txt_idCliente.Text, Cb_Estatus.Text);
                //dataGridView_UnidadesT.DataSource = cn.ConsultaContactoClienteDT();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();
                dataGridView2.DataSource = cn.ConsultaCliente();


                txt_idContacto.Text = "";
                txt_nombre.Text = "";
                txt_telefono.Text = "";
                txt_email.Text = "";//
                txt_idCliente.Text = "";
                Cb_Estatus.Text = "";


                MessageBox.Show("Eliminado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPConexion);
            con.Open();
            SqlDataAdapter datos = new SqlDataAdapter("Select idContacto,nombre,telefono,email,idCliente from SalesContactosCliente where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
            DataSet ds = new DataSet();
            datos.Fill(ds, "SalesContactosCliente");
            this.dataGridView_UnidadesT.DataSource = ds.Tables[0];
        }

        private void ContactoCliente_MouseMove(object sender, MouseEventArgs e)
        {
           
            dataGridView2.DataSource = cn.ConsultaCliente();
        }

        private void ContactoCliente_MouseClick(object sender, MouseEventArgs e)
        {
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            dataGridView2.DataSource = cn.ConsultaCliente();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pagina = Convert.ToInt32(comboBox2.Text);
            VarPagIndice = pagina - 1;
            VarPagInicio = (pagina - 1) * TotalFilasAMostrar + 1;
            VarPagFinal = pagina * TotalFilasAMostrar;
            Mostrar_datos();
        }
    }
}
