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
    public partial class Miembros : Form
    {
        ConexionSQLN cn = new ConexionSQLN();
      
   

        public Miembros()
        {
            InitializeComponent();
            dataGridViewMiembros.DataSource = cn.ConsultaMiembros();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtidAsociacion.Text) || string.IsNullOrEmpty(txtestatus.Text) || string.IsNullOrEmpty(txtIncorporacion.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string id = txtidAsociacion.Text;
                int idr = Int32.Parse(id);
                string estatus = txtestatus.Text;
                string Incorporacion = txtIncorporacion.Text;
                string id1 = txtCliente.Text;
                int id1r = Int32.Parse(id1);


                

                cn.insertarMiembros(txtCliente.Text,txtidAsociacion.Text, txtestatus.Text, txtIncorporacion.Text);
                dataGridViewMiembros.DataSource = cn.ConsultaMiembros();

                txtidAsociacion.Text = "";
                txtestatus.Text = "";
                txtIncorporacion.Text = "";
                

                MessageBox.Show("Miembro agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            dataGridViewMiembros.DataSource = cn.ConsultaDt();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            dataGridViewMiembros.DataSource = cn.ConsultaDt();
        }

        private void Miembros_Load(object sender, EventArgs e)
        {

            dataGridViewMiembros.DataSource = cn.ConsultaDt();
        }
    }
}
