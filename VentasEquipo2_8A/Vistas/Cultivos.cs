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

            txt_idCultivo.Enabled = true;
            txt_Nombre.Enabled = true;
            txt_costoAsesoria.Enabled = true;
            txt_Estatus.Enabled = true;
            dataGridView1.DataSource = cn.ConsultaCultivosDT();


        }
        //METODO PARA GUARDAR NUEVO CULTIVO
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_idCultivo.Text) || string.IsNullOrEmpty(txt_Nombre.Text) || string.IsNullOrEmpty(txt_costoAsesoria.Text) || string.IsNullOrEmpty(txt_Estatus.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cn.insertarCultivos(txt_idCultivo.Text, txt_Nombre.Text, txt_costoAsesoria.Text, txt_Estatus.Text);
                dataGridView1.DataSource = cn.ConsultaCultivosDT();

                txt_idCultivo.Text = "";
                txt_Nombre.Text = "";
                txt_costoAsesoria.Text = "";
                txt_Estatus.Text = "";


                MessageBox.Show("Cultivo agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        //METODO PARA EDITAR NUEVO CULTIVO
        private void btnEditar_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrEmpty(txt_idCultivo.Text) || string.IsNullOrEmpty(txt_Nombre.Text) || string.IsNullOrEmpty(txt_costoAsesoria.Text) || string.IsNullOrEmpty(txt_Estatus.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cn.modificarCultivos(txt_idCultivo.Text, txt_Nombre.Text, txt_costoAsesoria.Text, txt_Estatus.Text);

                dataGridView1.DataSource = cn.ConsultaCultivosDT();

                txt_idCultivo.Text = "";
                txt_Nombre.Text = "";
                txt_costoAsesoria.Text = "";
                txt_Estatus.Text = "";


                MessageBox.Show("Cultivo modificado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        //METODO PARA ELIMINAR NUEVO CULTIVO
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cn.ConsultaCultivosDT();
            if (string.IsNullOrEmpty(txt_idCultivo.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cn.eliminarCultivos(txt_idCultivo.Text);
                dataGridView1.DataSource = cn.ConsultaCultivosDT();


                txt_idCultivo.Text = "";
                txt_Nombre.Text = "";
                txt_costoAsesoria.Text = "";
                txt_Estatus.Text = "";


                MessageBox.Show("Cultivo eliminado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }







        }
    }
}
