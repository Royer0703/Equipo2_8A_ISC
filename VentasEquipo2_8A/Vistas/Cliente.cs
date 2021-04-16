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
    public partial class Clientes : Form
    {
        ConexionSQLN cn = new ConexionSQLN();
        public Clientes()
        {
            InitializeComponent();
            dataGridView_UnidadesT.DataSource = cn.ConsultaCliente();
        }

        private void Asociaciones_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtidClientes.Text) || string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtrazonSocial.Text) || string.IsNullOrEmpty(txtLm.Text) || string.IsNullOrEmpty(txtRfc.Text) || string.IsNullOrEmpty(txtTel.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          

            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                cn.InsertarCliente(txtidClientes.Text, txtnombre.Text, txtrazonSocial.Text, txtLm.Text, txtRfc.Text, txtTel.Text, txtEmail.Text, Estatus);
                dataGridView_UnidadesT.DataSource = cn.ConsultaCliente();

                txtidClientes.Text = "";
                txtnombre.Text = "";
                txtrazonSocial.Text = "";
                txtLm.Text = "";
                txtRfc.Text = "";
                txtTel.Text = "";
                txtEmail.Text = "";
               
                Cb_Estatus.Text = "";


                MessageBox.Show("Cliente agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

           

            if (string.IsNullOrEmpty(txtidClientes.Text) || string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtrazonSocial.Text) || string.IsNullOrEmpty(txtLm.Text) || string.IsNullOrEmpty(txtRfc.Text) || string.IsNullOrEmpty(txtTel.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();

                cn.ModificarClientes(txtidClientes.Text, txtnombre.Text, txtrazonSocial.Text, txtLm.Text, txtRfc.Text, txtTel.Text, txtEmail.Text, Estatus);

                dataGridView_UnidadesT.DataSource = cn.ConsultaCliente();

                txtidClientes.Text = "";
                txtnombre.Text = "";
                txtrazonSocial.Text = "";
                txtLm.Text = "";
                txtRfc.Text = "";
                txtTel.Text = "";
                txtEmail.Text = "";
         
                Cb_Estatus.Text = "";


                MessageBox.Show("Cliente modificado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtidClientes.Text) || string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtrazonSocial.Text) || string.IsNullOrEmpty(txtLm.Text) || string.IsNullOrEmpty(txtRfc.Text) || string.IsNullOrEmpty(txtTel.Text) || string.IsNullOrEmpty(txtEmail.Text) )
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                //string Estatus = Cb_Estatus.SelectedItem.ToString();
                Cb_Estatus.Text = "I";

                cn.ModificarClientes(txtidClientes.Text, txtnombre.Text, txtrazonSocial.Text, txtLm.Text, txtRfc.Text, txtTel.Text, txtEmail.Text,  Cb_Estatus.Text);

                dataGridView_UnidadesT.DataSource = cn.ConsultaCliente();

                txtidClientes.Text = "";
                txtnombre.Text = "";
                txtrazonSocial.Text = "";
                txtLm.Text = "";
                txtRfc.Text = "";
                txtTel.Text = "";
                txtEmail.Text = "";
                
                Cb_Estatus.Text = "";

                MessageBox.Show("Cliente eliminado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dataGridView_UnidadesT.DataSource = cn.ConsultaCliente();

            txtidClientes.Text = "";
            txtnombre.Text = "";
            txtrazonSocial.Text = "";
            txtLm.Text = "";
            txtRfc.Text = "";
            txtTel.Text = "";
            txtEmail.Text = "";
       
            Cb_Estatus.Text = "";
        }

        private void dataGridView_UnidadesT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidClientes.Text = dataGridView_UnidadesT.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = dataGridView_UnidadesT.CurrentRow.Cells[1].Value.ToString();
            txtrazonSocial.Text = dataGridView_UnidadesT.CurrentRow.Cells[2].Value.ToString();
            txtLm.Text = dataGridView_UnidadesT.CurrentRow.Cells[3].Value.ToString();
            txtRfc.Text = dataGridView_UnidadesT.CurrentRow.Cells[4].Value.ToString();
            txtTel.Text = dataGridView_UnidadesT.CurrentRow.Cells[5].Value.ToString();
            txtEmail.Text = dataGridView_UnidadesT.CurrentRow.Cells[6].Value.ToString();
            Cb_Estatus.Text = dataGridView_UnidadesT.CurrentRow.Cells[7].Value.ToString();
            
        }
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txtidClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txtLm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        //VALIDAR SOLO LETRAS INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO LETRAS!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }
        //VALIDAR SOLO LETRAS INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txtrazonSocial_KeyPress(object sender, KeyPressEventArgs e)
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