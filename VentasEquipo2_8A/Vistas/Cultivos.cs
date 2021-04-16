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
    public partial class Cultivos : Form
    {
        ConexionSQLN cn = new ConexionSQLN();
        public Cultivos()
        {
            InitializeComponent();
            dataGridView1.DataSource = cn.ConsultaCultivosDT();
           

        }

        private void label1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cn.ConsultaCultivosDT();

        }
        //METODO PARA AGREGAR NUEVO CULTIVO
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            txt_idCultivo.Text = "";
            txt_Nombre.Text = "";
            txt_costoAsesoria.Text = "";
            Cb_Estatus.Text = "";
            dataGridView1.DataSource = cn.ConsultaCultivosDT();


        }
        //METODO PARA GUARDAR NUEVO CULTIVO
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            int num;

            if (string.IsNullOrEmpty(txt_idCultivo.Text) || string.IsNullOrEmpty(txt_Nombre.Text) || string.IsNullOrEmpty(txt_costoAsesoria.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(txt_idCultivo.Text, out num) || !int.TryParse(txt_costoAsesoria.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de idCultivo y Costo Asesoria!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();

                cn.insertarCultivos(txt_idCultivo.Text, txt_Nombre.Text, txt_costoAsesoria.Text, Estatus);
                dataGridView1.DataSource = cn.ConsultaCultivosDT();

                txt_idCultivo.Text = "";
                txt_Nombre.Text = "";
                txt_costoAsesoria.Text = "";
                
                Cb_Estatus.Text = "";


                MessageBox.Show("Cultivo agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }
        //METODO PARA EDITAR NUEVO CULTIVO
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int num;

            if (string.IsNullOrEmpty(txt_idCultivo.Text) || string.IsNullOrEmpty(txt_Nombre.Text) || string.IsNullOrEmpty(txt_costoAsesoria.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(txt_idCultivo.Text, out num) || !int.TryParse(txt_costoAsesoria.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de idCultivo y Costo Asesoria!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                cn.modificarCultivos(txt_idCultivo.Text, txt_Nombre.Text, txt_costoAsesoria.Text, Estatus);

                dataGridView1.DataSource = cn.ConsultaCultivosDT();

                txt_idCultivo.Text = "";
                txt_Nombre.Text = "";
                txt_costoAsesoria.Text = "";
                Cb_Estatus.Text = "";


                MessageBox.Show("Cultivo modificado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //METODO PARA ELIMINAR NUEVO CULTIVO
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_idCultivo.Text) || string.IsNullOrEmpty(txt_Nombre.Text) || string.IsNullOrEmpty(txt_costoAsesoria.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                Cb_Estatus.Text = "I";
                // string Estatus = Cb_Estatus.SelectedItem.ToString();

                cn.modificarCultivos(txt_idCultivo.Text, txt_Nombre.Text, txt_costoAsesoria.Text, Cb_Estatus.Text);

                dataGridView1.DataSource = cn.ConsultaCultivosDT();

                txt_idCultivo.Text = "";
                txt_Nombre.Text = "";
                txt_costoAsesoria.Text = "";
                Cb_Estatus.Text = "";


                MessageBox.Show("Cultivo eliminado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idCultivo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_Nombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_costoAsesoria.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Cb_Estatus.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        //VALIDAR SOLO LETRAS INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txt_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <=64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO LETRAS!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        
        }

        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txt_idCultivo_KeyPress(object sender, KeyPressEventArgs e)
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
