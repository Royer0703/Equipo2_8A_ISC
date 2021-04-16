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
    public partial class Asociaciones : Form
    {
        ConexionSQLN cn = new ConexionSQLN();
        public Asociaciones()
        {
            InitializeComponent();
            dataGridView_UnidadesT.DataSource = cn.ConsultaAsociacion();
        }

        private void Asociaciones_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int num;
            if (string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txtnombre.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!int.TryParse(txtplacas.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de IDASOCIACION!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                cn.insertarAsociacion(txtplacas.Text, txtnombre.Text, Estatus);
                dataGridView_UnidadesT.DataSource = cn.ConsultaAsociacion();

                txtplacas.Text = "";
                txtnombre.Text = "";
                Cb_Estatus.Text = "";


                MessageBox.Show("Asociado Agregado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int num;
            if (string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txtnombre.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!int.TryParse(txtplacas.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de IDASOCIACION!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                cn.modificarAsociacion(txtplacas.Text, txtnombre.Text, Estatus);

                dataGridView_UnidadesT.DataSource = cn.ConsultaAsociacion();


                txtplacas.Text = "";
                txtnombre.Text = "";
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
            int num;
            if (string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txtnombre.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!int.TryParse(txtplacas.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de IDASOCIACION!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                Cb_Estatus.Text = "I";
                cn.modificarAsociacion(txtplacas.Text, txtnombre.Text, Cb_Estatus.Text);
                txtplacas.Text = "";
                txtnombre.Text = "";
                Cb_Estatus.Text = "";

                MessageBox.Show("Asociado Eliminado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtmarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dataGridView_UnidadesT.DataSource = cn.ConsultaAsociacion();
            txtplacas.Text = "";
            txtnombre.Text = "";
            Cb_Estatus.Text = "";

        }

        private void dataGridView_UnidadesT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtplacas.Text = dataGridView_UnidadesT.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = dataGridView_UnidadesT.CurrentRow.Cells[1].Value.ToString();
            Cb_Estatus.Text = dataGridView_UnidadesT.CurrentRow.Cells[2].Value.ToString();
 
        }

        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txtplacas_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
