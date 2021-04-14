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
            dataGridView1.DataSource = cn.ConsultaMiembrosDT();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txt_idCliente.Text = "";
            txt_idAsosiacion.Text = "";
            txt_Estatus.Text = "";
            txt_fechaIncorporacion.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int num;
            


            if (string.IsNullOrEmpty(txt_idCliente.Text) || string.IsNullOrEmpty(txt_idAsosiacion.Text) || string.IsNullOrEmpty(txt_Estatus.Text) || string.IsNullOrEmpty(txt_fechaIncorporacion.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(txt_idCliente.Text, out num) || !int.TryParse(txt_idAsosiacion.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de idCultivo!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {


                cn.insertarMiembrosDT(txt_idCliente.Text, txt_idAsosiacion.Text, txt_Estatus.Text, txt_fechaIncorporacion.Text);
                dataGridView1.DataSource = cn.ConsultaMiembrosDT();

                txt_idCliente.Text = "";
                txt_idAsosiacion.Text = "";
                txt_Estatus.Text = "";
                txt_fechaIncorporacion.Text = "";


                MessageBox.Show("Agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int num;



            if (string.IsNullOrEmpty(txt_idCliente.Text) || string.IsNullOrEmpty(txt_idAsosiacion.Text) || string.IsNullOrEmpty(txt_Estatus.Text) || string.IsNullOrEmpty(txt_fechaIncorporacion.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(txt_idCliente.Text, out num) || !int.TryParse(txt_idAsosiacion.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de idCultivo!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                cn.modificarMiembrosDT(txt_idCliente.Text, txt_idAsosiacion.Text, txt_Estatus.Text, txt_fechaIncorporacion.Text);
                dataGridView1.DataSource = cn.ConsultaMiembrosDT();

                txt_idCliente.Text = "";
                txt_idAsosiacion.Text = "";
                txt_Estatus.Text = "";
                txt_fechaIncorporacion.Text = "";


                MessageBox.Show("Actualizado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int num;



            if (string.IsNullOrEmpty(txt_idCliente.Text) || string.IsNullOrEmpty(txt_idAsosiacion.Text) || string.IsNullOrEmpty(txt_Estatus.Text) || string.IsNullOrEmpty(txt_fechaIncorporacion.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(txt_idCliente.Text, out num) || !int.TryParse(txt_idAsosiacion.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de idCultivo!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                txt_Estatus.Text = "I";
                cn.modificarMiembrosDT(txt_idCliente.Text, txt_idAsosiacion.Text, txt_Estatus.Text, txt_fechaIncorporacion.Text);
                dataGridView1.DataSource = cn.ConsultaMiembrosDT();

                txt_idCliente.Text = "";
                txt_idAsosiacion.Text = "";
                txt_Estatus.Text = "";
                txt_fechaIncorporacion.Text = "";


                MessageBox.Show("Eliminado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idCliente.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_idAsosiacion.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_Estatus.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_fechaIncorporacion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
