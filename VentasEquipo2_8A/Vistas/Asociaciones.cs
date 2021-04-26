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
using Entidad;//new 
using System.Data.SqlClient;//new 


namespace Vistas
{
    public partial class Asociaciones : Form
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
            dsTabla = cn.N_listar_SalesAsociaciones(obje);

            dataGridView_UnidadesT.DataSource = dsTabla.Tables[1];
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









        public Asociaciones()
        {
            InitializeComponent();
            //dataGridView_UnidadesT.DataSource = cn.ConsultaAsociacion();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
        }

        private void Asociaciones_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int num;
            if (string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txtnombre.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!int.TryParse(txtplacas.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de IDASOCIACION!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                cn.insertarAsociacion(txtplacas.Text, txtnombre.Text, Estatus);
                // dataGridView_UnidadesT.DataSource = cn.ConsultaAsociacion();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

                txtplacas.Text = "";
                txtnombre.Text = "";
                Cb_Estatus.Text = "";


                MessageBox.Show("Asociado Agregado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int num;
            if (string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txtnombre.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!int.TryParse(txtplacas.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de IDASOCIACION!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                cn.modificarAsociacion(txtplacas.Text, txtnombre.Text, Estatus);

                //dataGridView_UnidadesT.DataSource = cn.ConsultaAsociacion();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

                txtplacas.Text = "";
                txtnombre.Text = "";
                Cb_Estatus.Text = "";

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
            if (string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txtnombre.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!int.TryParse(txtplacas.Text, out num))
            {
                MessageBox.Show("Debe ser NUMERO el campo de IDASOCIACION!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                Cb_Estatus.Text = "I";
                cn.modificarAsociacion(txtplacas.Text, txtnombre.Text, Cb_Estatus.Text);

                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

                txtplacas.Text = "";
                txtnombre.Text = "";
                Cb_Estatus.Text = "";

                MessageBox.Show("Asociado Eliminado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtmarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //dataGridView_UnidadesT.DataSource = cn.ConsultaAsociacion();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            txtplacas.Text = "";
            txtnombre.Text = "";
            Cb_Estatus.Text = "";

        }

        private void dataGridView_UnidadesT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtplacas.Text = dataGridView_UnidadesT.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = dataGridView_UnidadesT.CurrentRow.Cells[1].Value.ToString();
            Cb_Estatus.Text = dataGridView_UnidadesT.CurrentRow.Cells[2].Value.ToString();
 
        }

        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txtplacas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        //VALIDAR SOLO LETRAS INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO LETRAS!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPConexion);
            con.Open();
            SqlDataAdapter datos = new SqlDataAdapter("Select idAsosiacion,nombre,estatus from SalesAsociaciones where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
            DataSet ds = new DataSet();
            datos.Fill(ds, "SalesAsociaciones");
            this.dataGridView_UnidadesT.DataSource = ds.Tables[0];
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pagina = Convert.ToInt32(comboBox2.Text);
            VarPagIndice = pagina - 1;
            VarPagInicio = (pagina - 1) * TotalFilasAMostrar + 1;
            VarPagFinal = pagina * TotalFilasAMostrar;
            Mostrar_datos();
        }

        private void Asociaciones_MouseClick(object sender, MouseEventArgs e)
        {
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
        }
    }
}
