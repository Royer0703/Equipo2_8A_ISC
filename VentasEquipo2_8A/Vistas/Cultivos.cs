﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios;
using System.Data.SqlClient;
using Entidad;//new 


namespace Vistas
{
    public partial class Cultivos : Form
    {

        ConexionSQLN cn = new ConexionSQLN();//negocios
        Class_Entidad obje = new Class_Entidad();//entidad
        DataSet dsTabla;

        int VarPagInicio = 1;
        int VarPagIndice = 0;
        int TotalFilasAMostrar = 10;
        int VarPagFinal;


        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_listar_Cultivos(obje);

            dataGridView1.DataSource = dsTabla.Tables[1];
            txtCantidadTotal.Text = dsTabla.Tables[0].Rows[0][0].ToString();

            int cantidad = Convert.ToInt32(dsTabla.Tables[0].Rows[0][0].ToString()) / TotalFilasAMostrar;
            comboBox2.Items.Clear();

            if (Convert.ToInt32(dsTabla.Tables[0].Rows[0][0].ToString()) % TotalFilasAMostrar > 0)
            {
                cantidad += 1;
            }

            textBox3.Text = cantidad.ToString();
            comboBox2.Items.Clear();

            for (int x = 1; x <= cantidad; x++)
            {
                comboBox2.Items.Add(x.ToString());
            }

            comboBox2.SelectedIndex = VarPagIndice;
        }












        public Cultivos()
        {
            InitializeComponent();
            //dataGridView1.DataSource = cn.ConsultaCultivosDT();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();


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
            //dataGridView1.DataSource = cn.ConsultaCultivosDT();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();


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
                //dataGridView1.DataSource = cn.ConsultaCultivosDT();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

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

                // dataGridView1.DataSource = cn.ConsultaCultivosDT();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

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

                //dataGridView1.DataSource = cn.ConsultaCultivosDT();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // "integrated security = true";
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPConexion);
            con.Open();
            SqlDataAdapter datos = new SqlDataAdapter("Select idCultivo,nombre,costoAsesoria,estatus from SalesCultivos where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
            DataSet ds = new DataSet();
            datos.Fill(ds, "SalesCultivos");
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void Cultivos_MouseClick(object sender, MouseEventArgs e)
        {
            //dataGridView1.DataSource = cn.ConsultaCultivosDT();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pagina = Convert.ToInt32(comboBox2.Text);
            VarPagIndice = pagina - 1;
            VarPagInicio = (pagina - 1) * TotalFilasAMostrar + 1;
            VarPagFinal = pagina * TotalFilasAMostrar;
            Mostrar_datos();
        }
    }
}
