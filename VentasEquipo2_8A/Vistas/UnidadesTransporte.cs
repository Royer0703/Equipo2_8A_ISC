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
    public partial class UnidadesTransporte : Form
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
            dsTabla = cn.N_listar_SalesUnidadesTransporte(obje);

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
        public UnidadesTransporte()
        {
            InitializeComponent();
            // dataGridView_UnidadesT.DataSource = cn.ConsultaDt();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            txtanio.Text = "";
            txtcapacidad.Text = "";
            txtidunidadest.Text = "";
            txtmarca.Text = "";
            txtmodelo.Text = "";
            txtplacas.Text = "";
            txttipo.Text = "";
            Cb_Estatus.Text = "";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtanio.Text) || string.IsNullOrEmpty(txtcapacidad.Text) || string.IsNullOrEmpty(txtidunidadest.Text) || string.IsNullOrEmpty(txtmarca.Text) || string.IsNullOrEmpty(txtmodelo.Text) || string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txttipo.Text))
            {
                MessageBox.Show("Debe llenar todos los campos!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                string id = txtidunidadest.Text;
                int idr = Int32.Parse(id);
                string anio = txtanio.Text;
                int anior = Int32.Parse(anio);
                string capacidad = txtcapacidad.Text;
                int capacidadr = Int32.Parse(capacidad);

                cn.insertarUnidad(idr, txtplacas.Text, txtmarca.Text, txtmodelo.Text, anior, capacidadr, txttipo.Text, Estatus);
                // dataGridView_UnidadesT.DataSource = cn.ConsultaDt();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();
                MessageBox.Show("Unidad de Transporte agregada correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtanio.Text = "";
                txtcapacidad.Text = "";
                txtidunidadest.Text = "";
                txtmarca.Text = "";
                txtmodelo.Text = "";
                txtplacas.Text = "";
                txttipo.Text = "";
                Cb_Estatus.Text = "";

            }
            else
            {
                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtanio.Text) || string.IsNullOrEmpty(txtcapacidad.Text) || string.IsNullOrEmpty(txtidunidadest.Text) || string.IsNullOrEmpty(txtmarca.Text) || string.IsNullOrEmpty(txtmodelo.Text) || string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txttipo.Text))
            {
                MessageBox.Show("Seleccione una Unidad de transporte!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                
                string id = txtidunidadest.Text;
                int idr = Int32.Parse(id);
                string anio = txtanio.Text;
                int anior = Int32.Parse(anio);
                string capacidad = txtcapacidad.Text;
                int capacidadr = Int32.Parse(capacidad);
                Cb_Estatus.Text = "I";

                cn.modificarUnidadTransporte(idr, txtplacas.Text, txtmarca.Text, txtmodelo.Text, anior, capacidadr, txttipo.Text, Cb_Estatus.Text);
                // dataGridView_UnidadesT.DataSource = cn.ConsultaDt();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();
                MessageBox.Show("Unidad de Transporte Eliminada correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtanio.Text = "";
                txtcapacidad.Text = "";
                txtidunidadest.Text = "";
                txtmarca.Text = "";
                txtmodelo.Text = "";
                txtplacas.Text = "";
                txttipo.Text = "";
                Cb_Estatus.Text = "";


            }


            else
            {
                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtanio.Text) || string.IsNullOrEmpty(txtcapacidad.Text) || string.IsNullOrEmpty(txtidunidadest.Text) || string.IsNullOrEmpty(txtmarca.Text) || string.IsNullOrEmpty(txtmodelo.Text) || string.IsNullOrEmpty(txtplacas.Text) || string.IsNullOrEmpty(txttipo.Text))
            {
                MessageBox.Show("Seleccione una Unidad de transporte!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Cb_Estatus.SelectedIndex > 0 || Cb_Estatus.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();

                string id = txtidunidadest.Text;
                int idr = Int32.Parse(id);
                string anio = txtanio.Text;
                int anior = Int32.Parse(anio);
                string capacidad = txtcapacidad.Text;
                int capacidadr = Int32.Parse(capacidad);

                cn.modificarUnidadTransporte(idr, txtplacas.Text, txtmarca.Text, txtmodelo.Text, anior, capacidadr, txttipo.Text, Estatus);
                //dataGridView_UnidadesT.DataSource = cn.ConsultaDt();

                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();

                MessageBox.Show("Unidad de Transporte modificado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtanio.Text = "";
                txtcapacidad.Text = "";
                txtidunidadest.Text = "";
                txtmarca.Text = "";
                txtmodelo.Text = "";
                txtplacas.Text = "";
                txttipo.Text = "";
                Cb_Estatus.Text = "";
            }

            else
            {
                MessageBox.Show("Debe seleccionar el estatus!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void UnidadesTransporte_Load(object sender, EventArgs e)
        {

            dataGridView_UnidadesT.DataSource = cn.ConsultaDt();
        }

        private void dataGridView_UnidadesT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidunidadest.Text = dataGridView_UnidadesT.CurrentRow.Cells[0].Value.ToString();
            txtplacas.Text = dataGridView_UnidadesT.CurrentRow.Cells[1].Value.ToString();
            txtmarca.Text = dataGridView_UnidadesT.CurrentRow.Cells[2].Value.ToString();
            txtmodelo.Text = dataGridView_UnidadesT.CurrentRow.Cells[3].Value.ToString();
            txtanio.Text = dataGridView_UnidadesT.CurrentRow.Cells[4].Value.ToString();
            txtcapacidad.Text = dataGridView_UnidadesT.CurrentRow.Cells[5].Value.ToString();
            txttipo.Text = dataGridView_UnidadesT.CurrentRow.Cells[6].Value.ToString();
            Cb_Estatus.Text = dataGridView_UnidadesT.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            txtanio.Text = "";
            txtcapacidad.Text = "";
            txtidunidadest.Text = "";
            txtmarca.Text = "";
            txtmodelo.Text = "";
            txtplacas.Text = "";
            txttipo.Text = "";
            Cb_Estatus.Text = "";
            //dataGridView_UnidadesT.DataSource = cn.ConsultaDt();

            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txtidunidadest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txtanio_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        //VALIDAR SOLO NUMERO INGRESADAS EN LOS CAMPOS DE TEXTO
        private void txtcapacidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtanio_KeyPress(object sender, KeyPressEventArgs e)
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
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPConexion);
            con.Open();
            SqlDataAdapter datos = new SqlDataAdapter("Select idUnidadTransporte,placas,marca,modelo,anio,capacidad,tipo,estatus from SalesUnidadesTransporte where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
            DataSet ds = new DataSet();
            datos.Fill(ds, "SalesUnidadesTransporte");
            this.dataGridView_UnidadesT.DataSource = ds.Tables[0];
        }

        private void UnidadesTransporte_MouseClick(object sender, MouseEventArgs e)
        {
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

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
