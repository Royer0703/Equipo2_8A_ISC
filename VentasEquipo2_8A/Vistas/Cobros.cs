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
    public partial class Cobros : Form
    {
        ConexionSQLN cn = new ConexionSQLN();//negocios
        Class_Entidad obje = new Class_Entidad();//entidad
        DataSet dsTabla;

        int VarPagInicio = 1;
        // int VarPagIndice = 0;
        int TotalFilasAMostrar = 2;
        int VarPagFinal;

        int totalVentaFinal;
        int importeCobro;
        int importesalesCobros;

        //conexio a mi base de datos
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int start;

        int idVenta;
        int idCobros;


        int creditoPagado;


        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_listar_Salescobros(obje);

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
            // "Select SalesCobros.idCobro, SalesCobros.fecha, SalesCobros.importe, SalesCobros.idVenta,SalesVentas.idCliente,SalesClientes.nombre,SalesClientes.telefono ,SalesCobros.estatus from SalesCobros JOIN SalesVentas ON SalesVentas.idVenta = SalesCobros.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);

            if (Cb_idVenta.SelectedIndex <= -1)
            {
                SqlCommand cmd;


                string sql = "Select SalesCobros.idCobro, SalesCobros.fecha, SalesCobros.importe, SalesCobros.idVenta,SalesVentas.idCliente,SalesClientes.nombre,SalesClientes.telefono ,SalesCobros.estatus,SalesCobros.idformaPago,formasPago.nombre from SalesCobros JOIN SalesVentas ON SalesVentas.idVenta = SalesCobros.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente  JOIN formasPago ON formasPago.idformaPago = SalesCobros.idformaPago";


                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, 2, "SalesCobros");
                //DGVIEW
                dataGridView1.DataSource = ds.Tables[0];
                //habilita Boton 
                //  btn_atras.Enabled = false;
            }
            



        }

        public void Cargar_Datos_idVentas()
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

        public void Cargar_Datos_idFormaPagos()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select nombre from formasPago";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_FormasPago.Items.Add(dr["nombre"].ToString());
                Cb_FormasPago.DisplayMember = (dr["nombre"].ToString());
                Cb_FormasPago.ValueMember = (dr["nombre"].ToString());
            }

        }




        public Cobros()
        {
            InitializeComponent();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
           // dataGridView1.DataSource = cn.ConsultarJoinParcelasDT();
            start = 0;
            idVenta = 0;
            idCobros = 0;
            loadData();
            Cargar_Datos_idVentas();
            Cargar_Datos_idFormaPagos();


            totalVentaFinal = 0;
            importeCobro = 0;

            importesalesCobros = 0;


            creditoPagado = 0;

        }

      

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ds.Clear();
            loadData();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();

            txt_idCobros.Text = "";
            
            txt_fecha.Text = "";
            txt_Importe.Text = "";
            txt_nombreCliente.Text = "";
            Cb_idVenta.SelectedIndex = -1;
            Cb_FormasPago.SelectedIndex = -1;
            Cb_FormasPago.Enabled = true;
            btnGuardar.Enabled = true;
            txt_TotalVenta.Text = "0";




        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Contado = "CONTADO";
            String Credito = "CREDITO";
            String ContadoVenta = txt_TipoVenta.Text.ToString();

           

            if (Cb_idVenta.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la venta!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (string.IsNullOrEmpty(txt_Importe.Text))
            {
                MessageBox.Show("Falta agregar el importe!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_FormasPago.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Forma de Pago!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
           else if (ContadoVenta == Credito)//Normal se agregan si es credito 
            {
                string Totalimpor = this.txt_Importe.Text;
                importeCobro = Int32.Parse(Totalimpor);//textbox importe

                String Estatus = "A";
                
                    cn.InsertarSalesCobrosDT(txt_fecha.Text, txt_Importe.Text, Cb_idVenta.Text, txt_idformasPago.Text, Estatus);


                    ds.Clear();
                    loadData();
                    VarPagFinal = TotalFilasAMostrar;
                    Mostrar_datos();


                    txt_fecha.Text = "";
                    txt_Importe.Text = "";
                    txt_nombreCliente.Text = "";
                    Cb_idVenta.SelectedIndex = -1;
                    Cb_FormasPago.SelectedIndex = -1;
                    MessageBox.Show("Pago Aceptado a Credito !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if (importesalesCobros == totalVentaFinal)//validar que ya pago todo selecionando Importe.salesCobros = Total.saleVentas
                {
                  MessageBox.Show("Pago Completado Exitosamente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.ModificarSalesCobrosTextoSalesventasEstatusDT(Cb_idVenta.Text, txt_Importe.Text, Estatus);
                    txt_fecha.Text = "";
                    txt_Importe.Text = "";
                    txt_nombreCliente.Text = "";
                    Cb_idVenta.SelectedIndex = -1;
                    Cb_FormasPago.SelectedIndex = -1;
                }
            }
            
            else  if (ContadoVenta == Contado )//SalesVentas.total == SalesCobros.importe
            {
                string Totalimpor = this.txt_Importe.Text;
                importeCobro = Int32.Parse(Totalimpor);//textbox importe

                if (idVenta == importeCobro)
                {
                    String Estatus = "A";
                    cn.InsertarSalesCobrosDT(txt_fecha.Text, txt_Importe.Text, Cb_idVenta.Text, txt_idformasPago.Text, Estatus);
                    cn.ModificarSalesCobrosTextoSalesventasEstatusDT(Cb_idVenta.Text, txt_Importe.Text, Estatus);
                    //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                    ds.Clear();
                    loadData();
                    VarPagFinal = TotalFilasAMostrar;
                    Mostrar_datos();


                    txt_fecha.Text = "";
                    txt_Importe.Text = "";
                    txt_nombreCliente.Text = "";
                    Cb_idVenta.SelectedIndex = -1;
                    Cb_FormasPago.SelectedIndex = -1;
                    MessageBox.Show("Pago Completado Exitosamente !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if(totalVentaFinal > importeCobro)
                {
                    MessageBox.Show("Error el importe es menor al total de la venta a contado!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (totalVentaFinal < importeCobro)
                {
                    MessageBox.Show("Error el importe es mayor al total de la venta a contado!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            


            }
           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           
        }
        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idCobros.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_fecha.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_Importe.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Cb_idVenta.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Cb_FormasPago.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();


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

                SqlDataAdapter datos = new SqlDataAdapter("Select SalesCobros.idCobro, SalesCobros.fecha, SalesCobros.importe, SalesCobros.idVenta,SalesVentas.idCliente,SalesClientes.nombre,SalesClientes.telefono ,SalesCobros.estatus from SalesCobros JOIN SalesVentas ON SalesVentas.idVenta = SalesCobros.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesCobros");
                this.dataGridView1.DataSource = ds.Tables[0];
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
                string sql = "Select SalesCobros.idCobro, SalesCobros.fecha, SalesCobros.importe, SalesCobros.idVenta,SalesVentas.idCliente,SalesClientes.nombre,SalesClientes.telefono ,SalesCobros.estatus from SalesCobros JOIN SalesVentas ON SalesVentas.idVenta = SalesCobros.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente";
                    
                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, numMostar, "SalesCobros");
                //DGVIEW
                dataGridView1.DataSource = ds.Tables[0];
                //habilita Boton 
                btn_atras.Enabled = false;

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
                adapter.Fill(ds, start, 2, "SalesCobros");
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
                adapter.Fill(ds, start, numMostar, "SalesCobros");
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
                adapter.Fill(ds, start, 2, "SalesCobros");
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
                adapter.Fill(ds, start, numMostar, "SalesCobros");
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

        private void Cb_idVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///Filta los cobros guardados en SalesCobros por (filtro de salesVentas.idVenta) ///llena la tabla principal 
            if (Cb_idVenta.SelectedIndex <= -1)
            {
                ds.Clear();
                loadData();
            }
            else
            {

                SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
                con.Open();

                SqlDataAdapter datos = new SqlDataAdapter("Select SalesCobros.idCobro, SalesCobros.fecha, SalesCobros.importe, SalesCobros.idVenta,SalesVentas.idCliente,SalesClientes.nombre,SalesClientes.telefono ,SalesCobros.estatus,SalesCobros.idformaPago,formasPago.nombre from SalesCobros JOIN SalesVentas ON SalesVentas.idVenta = SalesCobros.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente  JOIN formasPago ON formasPago.idformaPago = SalesCobros.idformaPago where SalesCobros.idVenta = '" + Cb_idVenta.SelectedItem + "'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesCobros");
                this.dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }


            //SUMA LOS DATOS (IMPORTES) de Salescobros ya guadados en la tabla SalesCobros
            con.Open();
            string q = "SELECT SUM(importe) TOTAL  FROM SalesCobros where idVenta = '" + Cb_idVenta.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                txt_importesalesCobros.Text = dr[0].ToString();//SalesCobros

                if (string.IsNullOrEmpty(txt_importesalesCobros.Text))
                {

                    txt_importesalesCobros.Text = "";

                }
                else
                {
                    string importeCo = this.txt_importesalesCobros.Text;
                    importesalesCobros = Int32.Parse(importeCo);//Variable de la suma total de importes 


                }

            }

            con.Close();

            //LLENAR LOS TEXTBOX CON EL (IDVENTA COMBOBOX)
            con.Open();
            string qx = "select SalesVentas.idVenta, SalesVentas.fecha,SalesVentas.total,SalesVentas.idCliente,SalesClientes.nombre,SalesVentas.tipo,SalesVentas.estatus from SalesVentas JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente  where SalesVentas.idVenta = '" + Cb_idVenta.SelectedItem + "'";
            SqlCommand cmdx = new SqlCommand(qx, con);
            SqlDataReader drx = cmdx.ExecuteReader();
            while (drx.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();

                txt_fecha.Text = drx[1].ToString();//-
                txt_nombreCliente.Text = drx[4].ToString();//-
                txt_TipoVenta.Text = drx[5].ToString();//-
                txt_TotalVenta.Text = drx[2].ToString();//-
                txt_EstatusVenta.Text = drx[6].ToString();//-
                                                          // txt_idCobros.Text = drx[8].ToString();//SalesCobros
                                                          //  txt_salesCobrosIdVenta.Text = drx[9].ToString();//SalesCobros

                //Cb_FormasPago.Text = dr[13].ToString();//SalesCobros

                string totalv = this.txt_TotalVenta.Text;
                idVenta = Int32.Parse(totalv);//Total de la venta


            }

            con.Close();



            string CONTADO = "CONTADO";
            string CREDITO = "CREDITO";
            String TipoventaSalesVentas = txt_TipoVenta.Text;////si es CONTADO O CREDITO 
            if (importesalesCobros == idVenta)//si el idventa es tipo contado
            {

                if (TipoventaSalesVentas == CONTADO) // si la SUM (IMPORTES) = TOTAL DE LA VENTA YA FUE PAGADA
                {
                    txt_Importe.Text = importesalesCobros.ToString();
                    txt_Importe.Enabled = false;
                    Cb_FormasPago.Enabled = false;
                    String Estatus = "A";
                    cn.ModificarSalesCobrosTextoSalesventasEstatusDT(Cb_idVenta.Text, txt_importesalesCobros.Text, Estatus);
                    MessageBox.Show("Pago Completado Exitosamente ya existe en la tabla !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardar.Enabled = false;

                    txt_creditoPagado.Text = "0";
                    txt_creditoporPagar.Text = "0";
                    // txt_Importe.Text = "0";

                }
                else if (TipoventaSalesVentas == CREDITO)
                {
                    txt_Importe.Text = importesalesCobros.ToString();
                    txt_Importe.Enabled = false;
                    Cb_FormasPago.Enabled = false;
                    txt_fecha.Enabled = false;
                    String Estatus = "A";
                    cn.ModificarSalesCobrosTextoSalesventasEstatusDT(Cb_idVenta.Text, txt_importesalesCobros.Text, Estatus);
                    MessageBox.Show("Pago Completado Exitosamente ya existe en la tabla !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardar.Enabled = false;

                    txt_creditoPagado.Text = "0";
                    txt_creditoporPagar.Text = "0";


                }
              

            }
            else if (txt_importesalesCobros != txt_TotalVenta)
            {
                btnGuardar.Enabled = true;
                txt_Importe.Enabled = true;
                txt_fecha.Enabled = true;

                if (TipoventaSalesVentas == CREDITO)
                {

                    if (string.IsNullOrEmpty(txt_importesalesCobros.Text))
                    {
                        txt_importesalesCobros.Text = "";
                        txt_creditoPagado.Text = "0";
                        txt_creditoporPagar.Text = "0";

                    }
                    if (importesalesCobros > 0)
                    {
                        
                        txt_creditoPagado.Text = this.txt_importesalesCobros.Text;//lo que ya se pago

                        int resta = (idVenta - importesalesCobros);
                        txt_creditoporPagar.Text = resta.ToString();

                      

                    }

                }



            }


        }

        private void Cb_idVenta_MouseClick(object sender, MouseEventArgs e)
        {
            Cb_idVenta.Items.Clear();
            Cargar_Datos_idVentas();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Cb_FormasPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            con.Open();
            string q = "Select idformaPago from formasPago where nombre = '" + Cb_FormasPago.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();

                txt_idformasPago.Text = dr[0].ToString();


            }

            con.Close();
        }

        private void Cb_idVenta_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_Importe_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
