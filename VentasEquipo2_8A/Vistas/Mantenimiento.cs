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
    public partial class Mantenimiento : Form
    {
        ConexionSQLN cn = new ConexionSQLN();
        public Mantenimiento()
        {
            InitializeComponent();
            dataGridView1.DataSource = cn.ConsultaMantenimientoDT();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cn.ConsultaMantenimientoDT();
            txt_idMantenimiento.Text = "";
            txt_fechaInicio.Text = " ";
            txt_fechaFin.Text = "";
            txt_taller.Text = "";
            txt_costo.Text = "";
            txt_comentarios.Text = "";
            txt_tipo.Text = "";
            txt_idUnidadTransporte.Text = "";
            txt_Estatus.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int num;


            if (string.IsNullOrEmpty(txt_idMantenimiento.Text) || string.IsNullOrEmpty(txt_fechaInicio.Text) || string.IsNullOrEmpty(txt_fechaFin.Text) || string.IsNullOrEmpty(txt_taller.Text) || string.IsNullOrEmpty(txt_costo.Text) || string.IsNullOrEmpty(txt_comentarios.Text) || string.IsNullOrEmpty(txt_tipo.Text) || string.IsNullOrEmpty(txt_idUnidadTransporte.Text) || string.IsNullOrEmpty(txt_Estatus.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(txt_idMantenimiento.Text, out num) || !int.TryParse(txt_idUnidadTransporte.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de idMantenimiento y idUnidadTransporte!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

            else
            {


                cn.InsertarMantenimientoDT(txt_idMantenimiento.Text, txt_fechaInicio.Text, txt_fechaFin.Text, txt_taller.Text, txt_costo.Text, txt_comentarios.Text, txt_tipo.Text, txt_idUnidadTransporte.Text, txt_Estatus.Text);
                dataGridView1.DataSource = cn.ConsultaMantenimientoDT();

                txt_idMantenimiento.Text = "";
                txt_fechaInicio.Text = " ";
                txt_fechaFin.Text = "";
                txt_taller.Text = "";
                txt_costo.Text = "";
                txt_comentarios.Text = "";
                txt_tipo.Text = "";
                txt_idUnidadTransporte.Text = "";
                txt_Estatus.Text = "";


                MessageBox.Show("Agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            int num;


            if (string.IsNullOrEmpty(txt_idMantenimiento.Text) || string.IsNullOrEmpty(txt_fechaInicio.Text) || string.IsNullOrEmpty(txt_fechaFin.Text) || string.IsNullOrEmpty(txt_taller.Text) || string.IsNullOrEmpty(txt_costo.Text) || string.IsNullOrEmpty(txt_comentarios.Text) || string.IsNullOrEmpty(txt_tipo.Text) || string.IsNullOrEmpty(txt_idUnidadTransporte.Text) || string.IsNullOrEmpty(txt_Estatus.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(txt_idMantenimiento.Text, out num) || !int.TryParse(txt_idUnidadTransporte.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de idMantenimiento y idUnidadTransporte!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {


                cn.ModificarMantenimientoDT(txt_idMantenimiento.Text, txt_fechaInicio.Text, txt_fechaFin.Text, txt_taller.Text, txt_costo.Text, txt_comentarios.Text, txt_tipo.Text, txt_idUnidadTransporte.Text, txt_Estatus.Text);
                dataGridView1.DataSource = cn.ConsultaMantenimientoDT();

                txt_idMantenimiento.Text = "";
                txt_fechaInicio.Text = " ";
                txt_fechaFin.Text = "";
                txt_taller.Text = "";
                txt_costo.Text = "";
                txt_comentarios.Text = "";
                txt_tipo.Text = "";
                txt_idUnidadTransporte.Text = "";
                txt_Estatus.Text = "";


                MessageBox.Show("Modificado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int num;


            if (string.IsNullOrEmpty(txt_idMantenimiento.Text) || string.IsNullOrEmpty(txt_fechaInicio.Text) || string.IsNullOrEmpty(txt_fechaFin.Text) || string.IsNullOrEmpty(txt_taller.Text) || string.IsNullOrEmpty(txt_costo.Text) || string.IsNullOrEmpty(txt_comentarios.Text) || string.IsNullOrEmpty(txt_tipo.Text) || string.IsNullOrEmpty(txt_idUnidadTransporte.Text) || string.IsNullOrEmpty(txt_Estatus.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(txt_idMantenimiento.Text, out num) || !int.TryParse(txt_idUnidadTransporte.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de idMantenimiento y idUnidadTransporte!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {

                txt_Estatus.Text = "I";
                cn.ModificarMantenimientoDT(txt_idMantenimiento.Text, txt_fechaInicio.Text, txt_fechaFin.Text, txt_taller.Text, txt_costo.Text, txt_comentarios.Text, txt_tipo.Text, txt_idUnidadTransporte.Text, txt_Estatus.Text);
                dataGridView1.DataSource = cn.ConsultaMantenimientoDT();

                txt_idMantenimiento.Text = "";
                txt_fechaInicio.Text = " ";
                txt_fechaFin.Text = "";
                txt_taller.Text = "";
                txt_costo.Text = "";
                txt_comentarios.Text = "";
                txt_tipo.Text = "";
                txt_idUnidadTransporte.Text = "";
                txt_Estatus.Text = "";


                MessageBox.Show("Eliminado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idMantenimiento.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_fechaInicio.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_fechaFin.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_taller.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_costo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_comentarios.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_tipo.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txt_idUnidadTransporte.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txt_Estatus.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }
    }
}
