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
    public partial class UnidadesTransporte : Form
    {
        ConexionSQLN cn = new ConexionSQLN();
        public UnidadesTransporte()
        {
            InitializeComponent();
            dataGridView_UnidadesT.DataSource = cn.ConsultaDt();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtanio.Enabled = true;
            txtcapacidad.Enabled = true;
            txtmarca.Enabled = true;
            txtmodelo.Enabled = true;
            txtplacas.Enabled = true;
            txttipo.Enabled = true;
            txtidunidadest.Enabled = true;
            dataGridView_UnidadesT.DataSource = cn.ConsultaDt();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtanio.Text) || string.IsNullOrEmpty(txtcapacidad.Text) || string.IsNullOrEmpty(txtidunidadest.Text) || string.IsNullOrEmpty(txtmarca.Text) || string.IsNullOrEmpty(txtmodelo.Text) || string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txttipo.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string id = txtidunidadest.Text;
                int idr = Int32.Parse(id);
                string anio = txtanio.Text;
                int anior = Int32.Parse(anio);
                string capacidad = txtcapacidad.Text;
                int capacidadr = Int32.Parse(capacidad);

                cn.insertarUnidad(idr, txtplacas.Text, txtmarca.Text, txtmodelo.Text, anior, capacidadr, txttipo.Text, txtestatus.Text);
                dataGridView_UnidadesT.DataSource = cn.ConsultaDt();

                MessageBox.Show("Unidad de Transporte agregada correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtanio.Text = "";
                txtcapacidad.Text = "";
                txtidunidadest.Text = "";
                txtmarca.Text = "";
                txtmodelo.Text = "";
                txtplacas.Text = "";
                txttipo.Text = "";
                txtestatus.Text = "";
            }

            dataGridView_UnidadesT.DataSource = cn.ConsultaDt();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtanio.Text) || string.IsNullOrEmpty(txtcapacidad.Text) || string.IsNullOrEmpty(txtidunidadest.Text) || string.IsNullOrEmpty(txtmarca.Text) || string.IsNullOrEmpty(txtmodelo.Text) || string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txttipo.Text))
            {
                MessageBox.Show("Seleccione una Unidad de transporte!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string id = txtidunidadest.Text;
                int idr = Int32.Parse(id);
                string anio = txtanio.Text;
                int anior = Int32.Parse(anio);
                string capacidad = txtcapacidad.Text;
                int capacidadr = Int32.Parse(capacidad);
                txtestatus.Text = "I";

                cn.modificarUnidadTransporte(idr, txtplacas.Text, txtmarca.Text, txtmodelo.Text, anior, capacidadr, txttipo.Text, txtestatus.Text);
                dataGridView_UnidadesT.DataSource = cn.ConsultaDt();

                MessageBox.Show("Unidad de Transporte Eliminada correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtanio.Text = "";
                txtcapacidad.Text = "";
                txtidunidadest.Text = "";
                txtmarca.Text = "";
                txtmodelo.Text = "";
                txtplacas.Text = "";
                txttipo.Text = "";
                txtestatus.Text = "";
            }
            dataGridView_UnidadesT.DataSource = cn.ConsultaDt();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtanio.Text) || string.IsNullOrEmpty(txtcapacidad.Text) || string.IsNullOrEmpty(txtidunidadest.Text) || string.IsNullOrEmpty(txtmarca.Text) || string.IsNullOrEmpty(txtmodelo.Text) || string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txttipo.Text))
            {
                MessageBox.Show("Seleccione una Unidad de transporte!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string id = txtidunidadest.Text;
                int idr = Int32.Parse(id);
                string anio = txtanio.Text;
                int anior = Int32.Parse(anio);
                string capacidad = txtcapacidad.Text;
                int capacidadr = Int32.Parse(capacidad);

                cn.modificarUnidadTransporte(idr, txtplacas.Text, txtmarca.Text, txtmodelo.Text, anior, capacidadr, txttipo.Text, txtestatus.Text);
                dataGridView_UnidadesT.DataSource = cn.ConsultaDt();

                MessageBox.Show("Unidad de Transporte modificado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtanio.Text = "";
                txtcapacidad.Text = "";
                txtidunidadest.Text = "";
                txtmarca.Text = "";
                txtmodelo.Text = "";
                txtplacas.Text = "";
                txttipo.Text = "";
                txtestatus.Text = "";
            }
            dataGridView_UnidadesT.DataSource = cn.ConsultaDt();
        }

        private void UnidadesTransporte_Load(object sender, EventArgs e)
        {

            dataGridView_UnidadesT.DataSource = cn.ConsultaDt();
        }

        private void dataGridView_UnidadesT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidunidadest.Text = dataGridView_UnidadesT.CurrentRow.Cells[0].Value.ToString();
            txtplacas.Text = dataGridView_UnidadesT.CurrentRow.Cells[1].Value.ToString();
            txtmarca.Text = dataGridView_UnidadesT.CurrentRow.Cells[2].Value.ToString();
            txtmodelo.Text = dataGridView_UnidadesT.CurrentRow.Cells[3].Value.ToString();
            txtanio.Text = dataGridView_UnidadesT.CurrentRow.Cells[4].Value.ToString();
            txtcapacidad.Text = dataGridView_UnidadesT.CurrentRow.Cells[5].Value.ToString();
            txttipo.Text = dataGridView_UnidadesT.CurrentRow.Cells[6].Value.ToString();
            txtestatus.Text = dataGridView_UnidadesT.CurrentRow.Cells[7].Value.ToString();
        }
    }
}
