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
            txtanio.Text = "";
            txtcapacidad.Text = "";
            txtidunidadest.Text = "";
            txtmarca.Text = "";
            txtmodelo.Text = "";
            txtplacas.Text = "";
            txttipo.Text = "";
            Cb_Estatus.Text = "";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtanio.Text) || string.IsNullOrEmpty(txtcapacidad.Text) || string.IsNullOrEmpty(txtidunidadest.Text) || string.IsNullOrEmpty(txtmarca.Text) || string.IsNullOrEmpty(txtmodelo.Text) || string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txttipo.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                string id = txtidunidadest.Text;
                int idr = Int32.Parse(id);
                string anio = txtanio.Text;
                int anior = Int32.Parse(anio);
                string capacidad = txtcapacidad.Text;
                int capacidadr = Int32.Parse(capacidad);

                cn.insertarUnidad(idr, txtplacas.Text, txtmarca.Text, txtmodelo.Text, anior, capacidadr, txttipo.Text, Estatus);
                dataGridView_UnidadesT.DataSource = cn.ConsultaDt();

                MessageBox.Show("Unidad de Transporte agregada correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtanio.Text = "";
                txtcapacidad.Text = "";
                txtidunidadest.Text = "";
                txtmarca.Text = "";
                txtmodelo.Text = "";
                txtplacas.Text = "";
                txttipo.Text = "";
                Cb_Estatus.Text = "";

            }
            else
            {
                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtanio.Text) || string.IsNullOrEmpty(txtcapacidad.Text) || string.IsNullOrEmpty(txtidunidadest.Text) || string.IsNullOrEmpty(txtmarca.Text) || string.IsNullOrEmpty(txtmodelo.Text) || string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txttipo.Text))
            {
                MessageBox.Show("Seleccione una Unidad de transporte!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                
                string id = txtidunidadest.Text;
                int idr = Int32.Parse(id);
                string anio = txtanio.Text;
                int anior = Int32.Parse(anio);
                string capacidad = txtcapacidad.Text;
                int capacidadr = Int32.Parse(capacidad);
                Cb_Estatus.Text = "I";

                cn.modificarUnidadTransporte(idr, txtplacas.Text, txtmarca.Text, txtmodelo.Text, anior, capacidadr, txttipo.Text, Cb_Estatus.Text);
                dataGridView_UnidadesT.DataSource = cn.ConsultaDt();

                MessageBox.Show("Unidad de Transporte Eliminada correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtanio.Text = "";
                txtcapacidad.Text = "";
                txtidunidadest.Text = "";
                txtmarca.Text = "";
                txtmodelo.Text = "";
                txtplacas.Text = "";
                txttipo.Text = "";
                Cb_Estatus.Text = "";


            }


            else
            {
                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtanio.Text) || string.IsNullOrEmpty(txtcapacidad.Text) || string.IsNullOrEmpty(txtidunidadest.Text) || string.IsNullOrEmpty(txtmarca.Text) || string.IsNullOrEmpty(txtmodelo.Text) || string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txttipo.Text))
            {
                MessageBox.Show("Seleccione una Unidad de transporte!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();

                string id = txtidunidadest.Text;
                int idr = Int32.Parse(id);
                string anio = txtanio.Text;
                int anior = Int32.Parse(anio);
                string capacidad = txtcapacidad.Text;
                int capacidadr = Int32.Parse(capacidad);

                cn.modificarUnidadTransporte(idr, txtplacas.Text, txtmarca.Text, txtmodelo.Text, anior, capacidadr, txttipo.Text, Estatus);
                dataGridView_UnidadesT.DataSource = cn.ConsultaDt();

                MessageBox.Show("Unidad de Transporte modificado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtanio.Text = "";
                txtcapacidad.Text = "";
                txtidunidadest.Text = "";
                txtmarca.Text = "";
                txtmodelo.Text = "";
                txtplacas.Text = "";
                txttipo.Text = "";
                Cb_Estatus.Text = "";
            }

            else
            {
                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
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
            Cb_Estatus.Text = dataGridView_UnidadesT.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            txtanio.Text = "";
            txtcapacidad.Text = "";
            txtidunidadest.Text = "";
            txtmarca.Text = "";
            txtmodelo.Text = "";
            txtplacas.Text = "";
            txttipo.Text = "";
            Cb_Estatus.Text = "";
            dataGridView_UnidadesT.DataSource = cn.ConsultaDt();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txtidunidadest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txtanio_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txtcapacidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtanio_KeyPress(object sender, KeyPressEventArgs e)
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
