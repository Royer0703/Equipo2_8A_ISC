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

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtidClientes.Text) || string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtrazonSocial.Text) || string.IsNullOrEmpty(txtLm.Text) || string.IsNullOrEmpty(txtRfc.Text) || string.IsNullOrEmpty(txtTel.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cn.InsertarCliente(txtidClientes.Text, txtnombre.Text, txtrazonSocial.Text, txtLm.Text, txtRfc.Text, txtTel.Text, txtEmail.Text,txttipo.Text);
                dataGridView_UnidadesT.DataSource = cn.ConsultaCliente();

                txtidClientes.Text = "";
                txtnombre.Text = "";
                txtrazonSocial.Text = "";
                txtLm.Text = "";
                txtRfc.Text = "";
                txtTel.Text = "";
                txtEmail.Text = "";


                MessageBox.Show("Cliente agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtidClientes.Text) || string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtrazonSocial.Text) || string.IsNullOrEmpty(txtLm.Text) || string.IsNullOrEmpty(txtRfc.Text) || string.IsNullOrEmpty(txtTel.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cn.ModificarClientes(txtidClientes.Text, txtnombre.Text, txtrazonSocial.Text, txtLm.Text, txtRfc.Text, txtTel.Text, txtEmail.Text,txttipo.Text);

                dataGridView_UnidadesT.DataSource = cn.ConsultaCliente();

                txtidClientes.Text = "";
                txtnombre.Text = "";
                txtrazonSocial.Text = "";
                txtLm.Text = "";
                txtRfc.Text = "";
                txtTel.Text = "";
                txtEmail.Text = "";


                MessageBox.Show("Cliente modificado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            dataGridView_UnidadesT.DataSource = cn.ConsultaCliente();
            if (string.IsNullOrEmpty(txtidClientes.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cn.EliminarCliente(txtidClientes.Text);
                dataGridView_UnidadesT.DataSource = cn.ConsultaCliente();


                txtidClientes.Text = "";
                txtnombre.Text = "";
                txtrazonSocial.Text = "";
                txtLm.Text = "";
                txtRfc.Text = "";
                txtTel.Text = "";
                txtEmail.Text = "";

                MessageBox.Show("Cultivo eliminado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }




        }
        }
}