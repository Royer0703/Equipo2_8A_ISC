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
            if (string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtestatus.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                string id = txtplacas.Text;
                int idr = Int32.Parse(id);
                string nombre = txtnombre.Text;
                string estatus = txtestatus.Text;

                cn.insertarAsociacion(txtplacas.Text, txtnombre.Text, txtestatus.Text);
                dataGridView_UnidadesT.DataSource = cn.ConsultaAsociacion();

                txtplacas.Text = "";
                txtnombre.Text = "";
                txtestatus.Text = "";


                MessageBox.Show("Asociado agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtestatus.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cn.modificarAsociacion(txtplacas.Text, txtnombre.Text, txtestatus.Text);

                dataGridView_UnidadesT.DataSource = cn.ConsultaAsociacion();


                txtplacas.Text = "";
                txtnombre.Text = "";
                 
                txtestatus.Text = "";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtplacas.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cn.eliminarAsociacion(txtplacas.Text);
                dataGridView_UnidadesT.DataSource = cn.ConsultaAsociacion();


                txtplacas.Text = "";
                txtnombre.Text = "";
                txtestatus.Text = "";
                MessageBox.Show("Asociado eliminado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void txtmarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
