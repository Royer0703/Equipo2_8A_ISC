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
            Cb_Estatus.Text = "";
            txt_fechaIncorporacion.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int num;



            if (string.IsNullOrEmpty(txt_idCliente.Text) || string.IsNullOrEmpty(txt_idAsosiacion.Text) || string.IsNullOrEmpty(txt_fechaIncorporacion.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(txt_idCliente.Text, out num) || !int.TryParse(txt_idAsosiacion.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de idCultivo!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0){
                string Estatus = Cb_Estatus.SelectedItem.ToString();

                cn.insertarMiembrosDT(txt_idCliente.Text, txt_idAsosiacion.Text, Estatus, txt_fechaIncorporacion.Text);
                dataGridView1.DataSource = cn.ConsultaMiembrosDT();

                txt_idCliente.Text = "";
                txt_idAsosiacion.Text = "";
                Cb_Estatus.Text = "";
                txt_fechaIncorporacion.Text = "";


                MessageBox.Show("Agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else
            {

                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int num;



            if (string.IsNullOrEmpty(txt_idCliente.Text) || string.IsNullOrEmpty(txt_idAsosiacion.Text) || string.IsNullOrEmpty(txt_fechaIncorporacion.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(txt_idCliente.Text, out num) || !int.TryParse(txt_idAsosiacion.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de idCultivo!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();

                cn.modificarMiembrosDT(txt_idCliente.Text, txt_idAsosiacion.Text, Estatus, txt_fechaIncorporacion.Text);
                dataGridView1.DataSource = cn.ConsultaMiembrosDT();

                txt_idCliente.Text = "";
                txt_idAsosiacion.Text = "";
                Cb_Estatus.Text = "";
                txt_fechaIncorporacion.Text = "";


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



            if (string.IsNullOrEmpty(txt_idCliente.Text) || string.IsNullOrEmpty(txt_idAsosiacion.Text) || string.IsNullOrEmpty(txt_fechaIncorporacion.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(txt_idCliente.Text, out num) || !int.TryParse(txt_idAsosiacion.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de idCultivo!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {

                Cb_Estatus.Text = "I";
                cn.modificarMiembrosDT(txt_idCliente.Text, txt_idAsosiacion.Text, Cb_Estatus.Text, txt_fechaIncorporacion.Text);
                dataGridView1.DataSource = cn.ConsultaMiembrosDT();

                txt_idCliente.Text = "";
                txt_idAsosiacion.Text = "";
                Cb_Estatus.Text = "";
                txt_fechaIncorporacion.Text = "";


                MessageBox.Show("Eliminado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }



            else
            {

                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idCliente.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_idAsosiacion.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Cb_Estatus.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_fechaIncorporacion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
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
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txt_idAsosiacion_KeyPress(object sender, KeyPressEventArgs e)
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
