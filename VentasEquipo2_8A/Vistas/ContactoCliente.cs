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
namespace Vistas
{
    public partial class ContactoCliente : Form
    {
        ConexionSQLN cn = new ConexionSQLN();
        public ContactoCliente()
        {
            InitializeComponent();
            dataGridView_UnidadesT.DataSource = cn.ConsultaContactoClienteDT();
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
            dataGridView_UnidadesT.DataSource = cn.ConsultaContactoClienteDT();
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
                dataGridView_UnidadesT.DataSource = cn.ConsultaContactoClienteDT();
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
                dataGridView_UnidadesT.DataSource = cn.ConsultaContactoClienteDT();
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
                dataGridView_UnidadesT.DataSource = cn.ConsultaContactoClienteDT();
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
    }
}
