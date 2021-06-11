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
    public partial class Envios : Form
    {
        ConexionSQLN cn = new ConexionSQLN();//negocios
        Class_Entidad obje = new Class_Entidad();//entidad
        DataSet dsTabla;

        int VarPagInicio = 1;
        // int VarPagIndice = 0;
        int TotalFilasAMostrar = 2;
        int VarPagFinal;

        //conexio a mi base de datos
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int start;

        int pesoTotalVentaFinal;
        int cantVenta;
        int pesoVenta;



        int CapacidadUnidad;

        int idEnvio;
        int idVenta;

        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_Lista_SalesEnvios(obje);

            //dataGridView1.DataSource = dsTabla.Tables[1];
            txtCantidadTotal.Text = dsTabla.Tables[0].Rows[0][0].ToString();

            int cantidad = Convert.ToInt32(dsTabla.Tables[0].Rows[0][0].ToString()) / TotalFilasAMostrar;
            //comboBox2.Items.Clear();

            if (Convert.ToInt32(dsTabla.Tables[0].Rows[0][0].ToString()) % TotalFilasAMostrar > 0)
            {
                cantidad += 1;
            }

            textBox3.Text = cantidad.ToString();

        }

        private void loadData()
        {
            //Variable de Cantiada a mostrar
            // int numMostra = (int.Parse(txt_DatosaMostar.Text));


            SqlCommand cmd;
            string sql = "select SalesEnvios.idEnvio, SalesEnvios.fechaInicio,SalesEnvios.fechaFin,SalesEnvios.idUnidadTransporte,SalesUnidadesTransporte.placas,SalesUnidadesTransporte.modelo,SalesUnidadesTransporte.capacidad,SalesEnvios.pesoTotalVenta,SalesEnvios.estatus from SalesEnvios JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesEnvios.idUnidadTransporte";

            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            //fill dataser
            adapter.Fill(ds, start, 2, "SalesEnvios");
            //DGVIEW
            dataGridView1.DataSource = ds.Tables[0];
            //habilita Boton 
            //  btn_atras.Enabled = false;

        }

        public void Cargar_Datos_ventas_idventa()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select idVenta from SalesVentas";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_idVenta.Items.Add(dr["idVenta"].ToString());
                Cb_idVenta.DisplayMember = (dr["idVenta"].ToString());
                Cb_idVenta.ValueMember = (dr["idVenta"].ToString());

            }

        }



        public void Cargar_Datos_UnidadesTransporte()//no estan en mantenimiento
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "SELECT s.idUnidadTransporte,s.placas,s.capacidad FROM SalesUnidadesTransporte s WHERE NOT EXISTS (SELECT * FROM SalesMantenimiento a WHERE s.idUnidadTransporte = a.idUnidadTransporte );";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_unidadTransporte.Items.Add(dr["placas"].ToString());
                Cb_unidadTransporte.DisplayMember = (dr["placas"].ToString());
                Cb_unidadTransporte.ValueMember = (dr["placas"].ToString());
            }

        }



        public Envios()
        {
            InitializeComponent();
            loadData();

            Mostrar_datos();
            start = 0;
            pesoTotalVentaFinal = 0;
            cantVenta = 0;
            pesoVenta = 0;

            CapacidadUnidad = 0;
            idEnvio = 0;
            idVenta = 0;
            Cargar_Datos_UnidadesTransporte();
            Cargar_Datos_ventas_idventa();
        }

        private void Cb_idVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select SalesVentas.idVenta,SalesVentas.idCliente,SalesClientes.nombre,SalesVentas.idEmpaque,SalesVentas.fecha, SalesVentas.cantidad,Empaques.capacidad,SalesEnvios.idEnvio from SalesVentas JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Empaques ON Empaques.idEmpaque = SalesVentas.idEmpaque left JOIN SalesEnvios ON SalesEnvios.idEnvio = SalesVentas.idVenta where SalesVentas.idVenta = '" + Cb_idVenta.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_clienteNombre.Text = dr[2].ToString();
                txt_FechaIni.Text = dr[4].ToString();
                txt_cantVenta.Text = dr[5].ToString();//cant de idventa
                txt_pesoVenta.Text = dr[6].ToString();//peso de idventa
                txt_idEnvios.Text = dr[7].ToString();





                if (string.IsNullOrEmpty(txt_idEnvios.Text))
                {

                    txt_idEnvios.Text = "";

                    string idventa = this.Cb_idVenta.Text;
                    idVenta = Int32.Parse(idventa);//cant de venta


                    string cant = this.txt_cantVenta.Text;
                    cantVenta = Int32.Parse(cant);//cant de venta

                    string peso = this.txt_pesoVenta.Text;
                    pesoVenta = Int32.Parse(peso);//cant de venta

                    int operacion = (cantVenta * pesoVenta);

                    pesoTotalVentaFinal = operacion;


                    //txt_pesoTotal.Text = pesoTotalVentaFinal.ToString();

                }
                else
                {

                    string iden = this.txt_idEnvios.Text;
                    idEnvio = Int32.Parse(iden);//IdEnvio para comprobar que no se agregue 

                    string idventa = this.Cb_idVenta.Text;
                    idVenta = Int32.Parse(idventa);//cant de venta

                    string cant = this.txt_cantVenta.Text;
                    cantVenta = Int32.Parse(cant);//cant de venta

                    string peso = this.txt_pesoVenta.Text;
                    pesoVenta = Int32.Parse(peso);//cant de venta

                    int operacion = (cantVenta * pesoVenta);

                    pesoTotalVentaFinal = operacion;


                   // txt_pesoTotal.Text = pesoTotalVentaFinal.ToString();

                }
            }

            con.Close();
        }

        private void Cb_unidadTransporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select idUnidadTransporte,capacidad from SalesUnidadesTransporte where placas = '" + Cb_unidadTransporte.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                txt_idunidadTransporte.Text = dr[0].ToString();
                txt_capacidadTransporte.Text = dr[1].ToString();




                if (string.IsNullOrEmpty(txt_capacidadTransporte.Text))
                {

                    txt_capacidadTransporte.Text = "";

                }
                else
                {

                    string cad = this.txt_capacidadTransporte.Text;
                    CapacidadUnidad = Int32.Parse(cad);//capacidad de Unidad


                }
            }

            con.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txt_idunidadTransporte.Text = "";
            Cb_idVenta.SelectedIndex = -1;
            txt_FechaIni.Text = "";
            txt_FechaFin.Text = "";
            Cb_unidadTransporte.SelectedIndex = -1;
          //  txt_pesoTotal.Text = "";
            txt_capacidadTransporte.Text = "";
            Cb_Estatus.SelectedIndex = -1;
            Cb_idVenta.SelectedIndex = -1;
            txt_clienteNombre.Text = "";
            txt_pesoVenta.Text = "";
            txt_cantVenta.Text = "";
            txt_idEnvios.Text = "";


            ds.Clear();
            loadData();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Cb_idVenta.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Envio !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_unidadTransporte.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Unidad de Transportes !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (string.IsNullOrEmpty(txt_FechaFin.Text))
            {
                MessageBox.Show("Falta agregar la Fecha Entrega !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_Estatus.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Estatus !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (CapacidadUnidad < pesoTotalVentaFinal)
            {
                MessageBox.Show("Error el Peso Total rebasa la capacidad maxima de la unidad!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txt_idunidadTransporte.Text = "";
                Cb_idVenta.SelectedIndex = -1;
                txt_FechaIni.Text = "";
                txt_FechaFin.Text = "";
                Cb_unidadTransporte.SelectedIndex = -1;
                //txt_pesoTotal.Text = "";
                txt_capacidadTransporte.Text = "";
                Cb_Estatus.SelectedIndex = -1;
                Cb_idVenta.SelectedIndex = -1;
                txt_clienteNombre.Text = "";
                txt_pesoVenta.Text = "";
                txt_cantVenta.Text = "";
                txt_idEnvios.Text = "";
            }
            else if (idEnvio == idVenta)
            {
                MessageBox.Show("Error Ya Existe esa Venta en la Tabla!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txt_idunidadTransporte.Text = "";
                Cb_idVenta.SelectedIndex = -1;
                txt_FechaIni.Text = "";
                txt_FechaFin.Text = "";
                Cb_unidadTransporte.SelectedIndex = -1;
                //txt_pesoTotal.Text = "";
                txt_capacidadTransporte.Text = "";
                Cb_Estatus.SelectedIndex = -1;
                Cb_idVenta.SelectedIndex = -1;
                txt_clienteNombre.Text = "";
                txt_pesoVenta.Text = "";
                txt_cantVenta.Text = "";
                txt_idEnvios.Text = "";
            }
            else if (idEnvio != idVenta || CapacidadUnidad >= pesoTotalVentaFinal)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                string idVenta = Cb_idVenta.SelectedItem.ToString();



                // cn.InsertarSalesEnviosDT(idVenta, txt_FechaIni.Text, txt_FechaFin.Text, txt_idunidadTransporte.Text, txt_capacidadTransporte.Text, Estatus);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();




                txt_idunidadTransporte.Text = "";
                Cb_idVenta.SelectedIndex = -1;
                txt_FechaIni.Text = "";
                txt_FechaFin.Text = "";
                Cb_unidadTransporte.SelectedIndex = -1;
                //txt_pesoTotal.Text = "";
                txt_capacidadTransporte.Text = "";
                Cb_Estatus.SelectedIndex = -1;
                Cb_idVenta.SelectedIndex = -1;
                txt_clienteNombre.Text = "";
                txt_pesoVenta.Text = "";
                txt_cantVenta.Text = "";
                txt_idEnvios.Text = "";
                MessageBox.Show("Agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Guardar los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
    







        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            if (Cb_idVenta.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Envio !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_unidadTransporte.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Unidad de Transportes !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (string.IsNullOrEmpty(txt_FechaFin.Text))
            {
                MessageBox.Show("Falta agregar la Fecha Entrega !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_Estatus.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Estatus !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_Estatus.SelectedIndex > -1)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                string idVenta = Cb_idVenta.SelectedItem.ToString();



               // cn.ModificarSalesEnviosDT(txt_idEnvios.Text,idVenta, txt_FechaIni.Text, txt_FechaFin.Text, txt_idunidadTransporte.Text, txt_capacidadTransporte.Text, txt_pesoTotal.Text, Estatus);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();




                txt_idunidadTransporte.Text = "";
                Cb_idVenta.SelectedIndex = -1;
                txt_FechaIni.Text = "";
                txt_FechaFin.Text = "";
                Cb_unidadTransporte.SelectedIndex = -1;
                //txt_pesoTotal.Text = "";
                txt_capacidadTransporte.Text = "";
                Cb_Estatus.SelectedIndex = -1;
                Cb_idVenta.SelectedIndex = -1;
                txt_clienteNombre.Text = "";
                txt_pesoVenta.Text = "";
                txt_cantVenta.Text = "";
                txt_idEnvios.Text = "";
                MessageBox.Show("Actualizados correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Actualizados los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }         

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Cb_idVenta.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Envio !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_unidadTransporte.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Unidad de Transportes !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (string.IsNullOrEmpty(txt_FechaFin.Text))
            {
                MessageBox.Show("Falta agregar la Fecha Entrega !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_Estatus.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Estatus !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            
            else if (Cb_Estatus.SelectedIndex > -1 )
            {
                //string Estatus = Cb_Estatus.SelectedItem.ToString();
                string idVenta = Cb_idVenta.SelectedItem.ToString();

                Cb_Estatus.Text = "I";

               // cn.ModificarSalesEnviosDT(txt_idEnvios.Text, idVenta, txt_FechaIni.Text, txt_FechaFin.Text, txt_idunidadTransporte.Text, txt_capacidadTransporte.Text, txt_pesoTotal.Text, Cb_Estatus.Text);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();




                txt_idunidadTransporte.Text = "";
                Cb_idVenta.SelectedIndex = -1;
                txt_FechaIni.Text = "";
                txt_FechaFin.Text = "";
                Cb_unidadTransporte.SelectedIndex = -1;
                //txt_pesoTotal.Text = "";
                txt_capacidadTransporte.Text = "";
                Cb_Estatus.SelectedIndex = -1;
                Cb_idVenta.SelectedIndex = -1;
                txt_clienteNombre.Text = "";
                txt_pesoVenta.Text = "";
                txt_cantVenta.Text = "";
                txt_idEnvios.Text = "";
                MessageBox.Show("Eliminado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Eliminado los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void txt_DatosaMostar_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_DatosaMostar.Text))
            {
                ds.Clear();
                loadData();
            }
            else
            {
                string id = txt_DatosaMostar.Text;
                int numMostar = Int32.Parse(id);
                ds.Clear();

                SqlCommand cmd;
                string sql = "select SalesEnvios.idEnvio,SalesVentas.idVenta,SalesVentas.idEmpaque,SalesVentas.cantidad,Empaques.nombre ,SalesEnvios.fechaInicio, SalesEnvios.fechaFin, SalesEnvios.idUnidadTransporte, SalesUnidadesTransporte.placas,SalesUnidadesTransporte.capacidad,SalesUnidadesTransporte.marca,SalesEnvios.pesoTotalVenta, SalesEnvios.estatus from SalesEnvios JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesEnvios.idUnidadTransporte JOIN SalesVentas ON SalesVentas.idVenta = SalesEnvios.idVenta JOIN Empaques ON Empaques.idEmpaque = SalesVentas.idEmpaque";
                    
                    

                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, numMostar, "SalesEnvios");
                //DGVIEW
                dataGridView1.DataSource = ds.Tables[0];
                //habilita Boton 
                btn_atras.Enabled = false;

            }
        }

        private void txt_DatosaMostar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                MessageBox.Show("SOLO NUMERO!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void btn_adelante_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_DatosaMostar.Text))
            {
                int num = (int.Parse(txtCantidadTotal.Text));
                start = start + 2;
                btn_atras.Enabled = true;
                if (start > num)
                {
                    start = 0;
                }

                ds.Clear();
                adapter.Fill(ds, start, 2, "SalesEnvios");
            }
            else
            {

                string id = txt_DatosaMostar.Text;
                int numMostar = Int32.Parse(id);

                int num = (int.Parse(txtCantidadTotal.Text));
                start = start + numMostar;
                btn_atras.Enabled = true;
                if (start > num)
                {
                    start = 0;
                }

                ds.Clear();
                adapter.Fill(ds, start, numMostar, "SalesEnvios");
            }
        }

        private void btn_atras_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_DatosaMostar.Text))
            {
                start = start - 2;
                if (start < 0)
                {
                    start = 0;
                    btn_atras.Enabled = false;
                }
                ds.Clear();
                adapter.Fill(ds, start, 2, "SalesEnvios");
            }
            else
            {
                string id = txt_DatosaMostar.Text;
                int numMostar = Int32.Parse(id);
                start = start - numMostar;
                if (start < 0)
                {
                    start = 0;
                    btn_atras.Enabled = false;
                }
                ds.Clear();
                adapter.Fill(ds, start, numMostar, "SalesEnvios");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                ds.Clear();
                loadData();
            }
            else
            {
                // string conexionstring = "server = DESKTOP-IP4QBPJ\\SQLEXPRESS; database = ERP;" +
                // "integrated security = true";
                SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
                con.Open();

                // SqlDataAdapter datos = new SqlDataAdapter("select SalesParcelas.idParcela, SalesParcelas.extension, SalesParcelas.idCliente, SalesParcelas.idCultivo, SalesParcelas.idDireccion, SalesParcelas.estatus, SalesClientes.nombre, SalesDireccionesCliente.calle, SalesDireccionesCliente.colonia, SalesCultivos.nombre from SalesParcelas  JOIN SalesClientes ON SalesParcelas.idCliente = SalesClientes.idCliente JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idCliente = SalesClientes.idCliente JOIN SalesCultivos ON SalesCultivos.idCultivo = SalesParcelas.idCultivo where " + this.comboBox1.Text+ " like '%" + this.textBox1.Text + "%'", con);

                SqlDataAdapter datos = new SqlDataAdapter("select SalesEnvios.idEnvio,SalesVentas.idVenta,SalesVentas.idEmpaque,SalesVentas.cantidad,Empaques.nombre ,SalesEnvios.fechaInicio, SalesEnvios.fechaFin, SalesEnvios.idUnidadTransporte, SalesUnidadesTransporte.placas,SalesUnidadesTransporte.capacidad,SalesUnidadesTransporte.marca,SalesEnvios.pesoTotalVenta, SalesEnvios.estatus from SalesEnvios JOIN SalesUnidadesTransporte ON SalesUnidadesTransporte.idUnidadTransporte = SalesEnvios.idUnidadTransporte JOIN SalesVentas ON SalesVentas.idVenta = SalesEnvios.idVenta JOIN Empaques ON Empaques.idEmpaque = SalesVentas.idEmpaque  where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesEnvios");
                this.dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txt_idEnvios.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();//-
            Cb_idVenta.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();//-
            txt_idunidadTransporte.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();//-
            txt_FechaIni.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();//-
            txt_FechaFin.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();//-
            Cb_unidadTransporte.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();//text//-
            //txt_pesoTotal.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();//-
            txt_capacidadTransporte.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();//-
            Cb_Estatus.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();//-

            Cb_unidadTransporte.Enabled = false;
            Cb_idVenta.Enabled = false;
        }

        private void Cb_idVenta_MouseClick(object sender, MouseEventArgs e)
        {
            Cb_idVenta.Items.Clear();
            Cargar_Datos_ventas_idventa();
        }
    }
}
