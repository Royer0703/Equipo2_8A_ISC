using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios;
using Entidad;//new 

namespace Vistas
{
    public partial class Miembros : Form
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
            dsTabla = cn.N_listar_Miembros(obje);

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












        public Miembros()
        {
            InitializeComponent();
            //dataGridView1.DataSource = cn.ConsultaMiembrosDT();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            dataGridView2.DataSource = cn.ConsultaCliente();
            dataGridView3.DataSource = cn.ConsultaAsociacion();


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
                //dataGridView1.DataSource = cn.ConsultaMiembrosDT();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

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
                //dataGridView1.DataSource = cn.ConsultaMiembrosDT();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

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
                //dataGridView1.DataSource = cn.ConsultaMiembrosDT();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

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

        private void Miembros_MouseMove(object sender, MouseEventArgs e)
        {
            dataGridView2.DataSource = cn.ConsultaCliente();
            dataGridView3.DataSource = cn.ConsultaAsociacion();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPConexion);
            con.Open();
            SqlDataAdapter datos = new SqlDataAdapter("Select idCliente,idAsosiacion,estatus,fechaIncorporacion from SalesMiembros where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
            DataSet ds = new DataSet();
            datos.Fill(ds, "SalesMiembros");
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void Miembros_MouseClick(object sender, MouseEventArgs e)
        {
            //dataGridView1.DataSource = cn.ConsultaMiembrosDT();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            dataGridView2.DataSource = cn.ConsultaCliente();
            dataGridView3.DataSource = cn.ConsultaAsociacion();
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
