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
    public partial class Parcelas : Form
    {
        ConexionSQLN cn = new ConexionSQLN();
        public Parcelas()
        {
            InitializeComponent();
            dataGridView1.DataSource = cn.ConsultaParcelasDT();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txt_idParcelas.Text = " ";
            txt_Extension.Text = " ";
            txt_idCliente.Text = " ";
            txt_idCultivo.Text = " ";
            txt_idDireccion.Text = " ";
            txt_Estatus.Text = " ";
            dataGridView1.DataSource = cn.ConsultaParcelasDT();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int num;


            if (string.IsNullOrEmpty(txt_idParcelas.Text) || string.IsNullOrEmpty(txt_Extension.Text) || string.IsNullOrEmpty(txt_idCliente.Text) || string.IsNullOrEmpty(txt_idCultivo.Text) || string.IsNullOrEmpty(txt_idDireccion.Text) || string.IsNullOrEmpty(txt_Estatus.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(txt_idParcelas.Text, out num) || !int.TryParse(txt_Extension.Text, out num) || !int.TryParse(txt_idCliente.Text, out num) || !int.TryParse(txt_idCultivo.Text, out num) || !int.TryParse(txt_idDireccion.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                cn.InsertarParcelas(txt_idParcelas.Text, txt_Extension.Text, txt_idCliente.Text, txt_idCultivo.Text, txt_idDireccion.Text, txt_Estatus.Text);
                dataGridView1.DataSource = cn.ConsultaParcelasDT();

                txt_idParcelas.Text = " ";
                txt_Extension.Text = " ";
                txt_idCliente.Text = " ";
                txt_idCultivo.Text = " ";
                txt_idDireccion.Text = " ";
                txt_Estatus.Text = " ";


                MessageBox.Show("Agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }




        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int num;


            if (string.IsNullOrEmpty(txt_idParcelas.Text) || string.IsNullOrEmpty(txt_Extension.Text) || string.IsNullOrEmpty(txt_idCliente.Text) || string.IsNullOrEmpty(txt_idCultivo.Text) || string.IsNullOrEmpty(txt_idDireccion.Text) || string.IsNullOrEmpty(txt_Estatus.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(txt_idParcelas.Text, out num) || !int.TryParse(txt_Extension.Text, out num) || !int.TryParse(txt_idCliente.Text, out num) || !int.TryParse(txt_idCultivo.Text, out num) || !int.TryParse(txt_idDireccion.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                cn.ModificarParcelas(txt_idParcelas.Text, txt_Extension.Text, txt_idCliente.Text, txt_idCultivo.Text, txt_idDireccion.Text, txt_Estatus.Text);
                dataGridView1.DataSource = cn.ConsultaParcelasDT();

                txt_idParcelas.Text = " ";
                txt_Extension.Text = " ";
                txt_idCliente.Text = " ";
                txt_idCultivo.Text = " ";
                txt_idDireccion.Text = " ";
                txt_Estatus.Text = " ";


                MessageBox.Show("Actualizados Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_idParcelas.Text) || string.IsNullOrEmpty(txt_Extension.Text) || string.IsNullOrEmpty(txt_idCliente.Text) || string.IsNullOrEmpty(txt_idCultivo.Text) || string.IsNullOrEmpty(txt_idDireccion.Text) || string.IsNullOrEmpty(txt_Estatus.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                txt_Estatus.Text = "I";
                cn.ModificarParcelas(txt_idParcelas.Text, txt_Extension.Text, txt_idCliente.Text, txt_idCultivo.Text, txt_idDireccion.Text, txt_Estatus.Text);
                dataGridView1.DataSource = cn.ConsultaParcelasDT();

                txt_idParcelas.Text = " ";
                txt_Extension.Text = " ";
                txt_idCliente.Text = " ";
                txt_idCultivo.Text = " ";
                txt_idDireccion.Text = " ";
                txt_Estatus.Text = " ";


                MessageBox.Show("Eliminado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idParcelas.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_Extension.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_idCliente.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_idCultivo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_idDireccion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_Estatus.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }



    }
}
