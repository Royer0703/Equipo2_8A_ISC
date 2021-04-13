using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vistas
{
    public partial class DireccionesCliente : Form
    {
        ConexionSQLN cn = new ConexionSQLN();
        public DireccionesCliente()
        {
            InitializeComponent();
            dataGridViewDireccionesC.DataSource = cn.ConsultaDireccionCliente();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtcp.Text = "";
            txttipo.Text = "";
            txtiddireccion.Text = "";
            txtnumero.Text = "";
            txtcolonia.Text = "";
            txtcalle.Text = "";
            txtidcliente.Text = "";
            txtidciudad.Text = "";
            txtestatus.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtiddireccion.Text) || string.IsNullOrEmpty(txtcalle.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtcolonia.Text) || string.IsNullOrEmpty(txtcp.Text) || string.IsNullOrEmpty(txttipo.Text) || string.IsNullOrEmpty(txtidcliente.Text) || string.IsNullOrEmpty(txtidciudad.Text) || string.IsNullOrEmpty(txtestatus.Text))
            {
                MessageBox.Show("Seleccione una Unidad de transporte!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtestatus.Text = "I";

                cn.modificarDireccionCliente(txtiddireccion.Text, txtcalle.Text, txtnumero.Text, txtcolonia.Text, txtcp.Text, txttipo.Text, txtidcliente.Text, txtidciudad.Text, txtestatus.Text);
                dataGridViewDireccionesC.DataSource = cn.ConsultaDireccionCliente();

                MessageBox.Show("Direccion del Cliente eliminada correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtcp.Text = "";
                txttipo.Text = "";
                txtiddireccion.Text = "";
                txtnumero.Text = "";
                txtcolonia.Text = "";
                txtcalle.Text = "";
                txtidcliente.Text = "";
                txtidciudad.Text = "";
                txtestatus.Text = "";
            }
            dataGridViewDireccionesC.DataSource = cn.ConsultaDireccionCliente();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtiddireccion.Text) || string.IsNullOrEmpty(txtcalle.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtcolonia.Text) || string.IsNullOrEmpty(txtcp.Text) || string.IsNullOrEmpty(txttipo.Text) || string.IsNullOrEmpty(txtidcliente.Text) || string.IsNullOrEmpty(txtidciudad.Text) || string.IsNullOrEmpty(txtestatus.Text))
            {
                MessageBox.Show("Seleccione una Unidad de transporte!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cn.modificarDireccionCliente(txtiddireccion.Text, txtcalle.Text, txtnumero.Text, txtcolonia.Text, txtcp.Text, txttipo.Text, txtidcliente.Text, txtidciudad.Text, txtestatus.Text);
                dataGridViewDireccionesC.DataSource = cn.ConsultaDireccionCliente();

                MessageBox.Show("Direccion del Cliente modificado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtcp.Text = "";
                txttipo.Text = "";
                txtiddireccion.Text = "";
                txtnumero.Text = "";
                txtcolonia.Text = "";
                txtcalle.Text = "";
                txtidcliente.Text = "";
                txtidciudad.Text = "";
                txtestatus.Text = "";
            }
            dataGridViewDireccionesC.DataSource = cn.ConsultaDireccionCliente();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtiddireccion.Text) || string.IsNullOrEmpty(txtcalle.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtcolonia.Text) || string.IsNullOrEmpty(txtcp.Text) || string.IsNullOrEmpty(txttipo.Text) || string.IsNullOrEmpty(txtidcliente.Text) || string.IsNullOrEmpty(txtidciudad.Text) || string.IsNullOrEmpty(txtestatus.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                cn.insertarDireccionCliente(txtiddireccion.Text, txtcalle.Text, txtnumero.Text, txtcolonia.Text, txtcp.Text, txttipo.Text, txtidcliente.Text, txtidciudad.Text, txtestatus.Text);
                dataGridViewDireccionesC.DataSource = cn.ConsultaDireccionCliente();

                MessageBox.Show("Direccion del Cliente agregada correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtcp.Text = "";
                txttipo.Text = "";
                txtiddireccion.Text = "";
                txtnumero.Text = "";
                txtcolonia.Text = "";
                txtcalle.Text = "";
                txtidcliente.Text = "";
                txtidciudad.Text = "";
                txtestatus.Text = "";
            }

            dataGridViewDireccionesC.DataSource = cn.ConsultaDireccionCliente();
        }

        private void dataGridViewDireccionesC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtiddireccion.Text = dataGridViewDireccionesC.CurrentRow.Cells[0].Value.ToString();
            txtcalle.Text = dataGridViewDireccionesC.CurrentRow.Cells[1].Value.ToString();
            txtnumero.Text = dataGridViewDireccionesC.CurrentRow.Cells[2].Value.ToString();
            txtcolonia.Text = dataGridViewDireccionesC.CurrentRow.Cells[3].Value.ToString();
            txtcp.Text = dataGridViewDireccionesC.CurrentRow.Cells[4].Value.ToString();
            txttipo.Text = dataGridViewDireccionesC.CurrentRow.Cells[5].Value.ToString();
            txtidcliente.Text = dataGridViewDireccionesC.CurrentRow.Cells[6].Value.ToString();
            txtidciudad.Text = dataGridViewDireccionesC.CurrentRow.Cells[7].Value.ToString();
            txtestatus.Text = dataGridViewDireccionesC.CurrentRow.Cells[8].Value.ToString();
        }
    }
}
