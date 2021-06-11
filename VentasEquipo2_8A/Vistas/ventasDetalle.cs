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
    public partial class ventasDetalle : Form
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

        int Cantida;
        int Precio;

        int subTotalFinalVenta;









        void Mostrar_datos()
        {
            obje.varDatoInicio = VarPagInicio;
            obje.varDatoFinal = VarPagFinal;
            dsTabla = cn.N_listar_SalesVentaDetalle(obje);

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
            string sql = "select SalesVentaDetalle.idVentaDetalle, SalesVentaDetalle.precioVenta, SalesVentaDetalle.cantidad,SalesVentaDetalle.subtotal,SalesVentaDetalle.idVenta,SalesVentaDetalle.idPresentacion,PresentacionesProducto.idEmpaque,Empaques.nombre,SalesVentaDetalle.estatus,SalesVentas.idVenta,SalesVentas.idCliente,SalesClientes.nombre  from SalesVentaDetalle JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque JOIN SalesVentas ON SalesVentas.idVenta = SalesVentaDetalle.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente";

            cmd = new SqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            //fill dataser
            adapter.Fill(ds, start, 2, "SalesVentaDetalle");
            //DGVIEW
            dataGridView1.DataSource = ds.Tables[0];
            //habilita Boton 
            btn_atras.Enabled = false;

        }

        public void Cargar_Datos_VentasID()
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
        public void Cargar_Datos_nombreEmpaquesProductosPresentacion()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
            con.Open();
            string q = "select nombre from Empaques";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cb_idPresentacion.Items.Add(dr["nombre"].ToString());
                Cb_idPresentacion.DisplayMember = (dr["nombre"].ToString());
                Cb_idPresentacion.ValueMember = (dr["nombre"].ToString());
            }

        }








        public ventasDetalle()
        {
            InitializeComponent();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            //dataGridView1.DataSource = cn.ConsultarJoinParcelasDT();
            start = 0;
            loadData();
            Mostrar_datos();
            Cargar_Datos_VentasID();
            Cargar_Datos_nombreEmpaquesProductosPresentacion();
            Cantida = 0;
            Precio = 0;

            subTotalFinalVenta = 0;

        }

        private void ventasDetalle_Load(object sender, EventArgs e)
        {
            

        }

        private void Cb_idVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string q = "select SalesVentas.fecha, SalesVentas.estatus,SalesVentas.idCliente,SalesClientes.nombre from SalesVentas JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente where SalesVentas.idVenta = '" + Cb_idVenta.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();
                txt_fechaVenta.Text = dr[0].ToString();
                txt_estatusVenta.Text = dr[1].ToString();
                txt_clienteVenta.Text = dr[3].ToString();


                String EstatusActual = "A";
                string estatusSalesVenta = txt_estatusVenta.Text;

                if (estatusSalesVenta == EstatusActual)//si la Venta fue pagada validar 
                {
                    MessageBox.Show("La Venta ya fue Pagada no se puede agregar nada mas !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardar.Enabled = false;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;

                }
                else
                {
                    btnGuardar.Enabled = true;
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                }

            }

            con.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txt_idventaDetalle.Text = " ";
            
            txt_precioVenta.Text = " ";
            txt_cantidad.Text = " ";
            txt_subTotal.Text = " ";
            txt_idPresentacion.Text = " ";
            Cb_idVenta.SelectedIndex = -1;
            Cb_Estatus.SelectedIndex = -1;
           

            
            Cb_idVenta.Items.Clear();
            Cargar_Datos_VentasID();


            ds.Clear();
            loadData();
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Cb_idVenta.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Venta !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_idPresentacion.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Presentacion !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if(Cb_Estatus.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Estatus !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_Estatus.SelectedIndex > -1)
            {

                ///SALESVENTAS MODIFICADO LOS SUB,IVA,TOTAL
               // cn.ModificarSalesVentasDT(Cb_idVenta.Text, txt_fechaVenta.Text, txt_cantPagadaVenta.Text, txt_subTotalVenta.Text, txt_ivaVenta.Text, txt_totalVenta.Text, txt_comentarisVenta.Text, txt_estatusVenta.Text, txt_clienteVenta.Text, txt_sucursalVenta.Text, txt_empleadoVenta.Text, txt_tipoVenta.Text);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();

                string Estatus = Cb_Estatus.SelectedItem.ToString();
                string idVenta = Cb_idVenta.SelectedItem.ToString();

                cn.InsertarSalesVentasDetalleDT(txt_precioVenta.Text, txt_cantidad.Text, txt_subTotal.Text, idVenta, txt_idPresentacion.Text, Estatus);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                //modificar EN salesVentas
               
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();


                txt_idventaDetalle.Text = " ";
                txt_precioVenta.Text = " ";
                txt_cantidad.Text = " ";
                txt_subTotal.Text = " ";
                txt_idPresentacion.Text = " ";
               // Cb_idVenta.SelectedIndex = -1;
                Cb_Estatus.SelectedIndex = -1;

                MessageBox.Show("Agregado correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


                con.Open();
                string q = "SELECT SUM(subtotal) Total FROM SalesVentaDetalle where idVenta = '" + Cb_idVenta.SelectedItem + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //string idCliente = (string)dr["idCliente"].ToString();
                    // txt_idCliente.Text = dr[0].ToString();
                    txt_subTotalVenta.Text = dr[0].ToString();
                    string Sub = this.txt_subTotalVenta.Text;
                    subTotalFinalVenta = Int32.Parse(Sub);//textbox de Precio

                }
              

                    int subTotal = (subTotalFinalVenta);//calculo de subtotal

                    int Iva = (int)(subTotal * 0.16);//calculo de IVA

                    int Total = (subTotal + Iva);//calculo de Total

                    txt_subTotalVenta.Text = subTotal.ToString();

                    txt_ivaVenta.Text = Iva.ToString();
                    txt_totalVenta.Text = Total.ToString();

                    

                    cn.ModificarSalesVentasDT(idVenta, txt_subTotalVenta.Text, txt_ivaVenta.Text, txt_totalVenta.Text);
                    //dataGridView1.DataSource = cn.ConsultaParcelasDT();


                
                
                con.Close();

            }
         




        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Cb_idVenta.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar la Venta que va Modificar !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (Cb_Estatus.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Estatus !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_idVenta.SelectedIndex > 0 || Cb_idVenta.SelectedIndex == 0)
            {
                string Estatus = Cb_Estatus.SelectedItem.ToString();
                string idVenta = Cb_idVenta.SelectedItem.ToString();
                

                cn.ModificarSalesVentasDetalleDT(txt_idventaDetalle.Text, txt_precioVenta.Text, txt_cantidad.Text, txt_subTotal.Text, idVenta, txt_idPresentacion.Text, Estatus);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();




                txt_idventaDetalle.Text = " ";
               
                txt_precioVenta.Text = " ";
                txt_cantidad.Text = " ";
                txt_subTotal.Text = " ";
                txt_idPresentacion.Text = " ";
              //  Cb_idVenta.SelectedIndex = -1;
                Cb_Estatus.SelectedIndex = -1;
               

                MessageBox.Show("Actualizados correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Open();
                string q = "SELECT SUM(subtotal) Total FROM SalesVentaDetalle where idVenta = '" + Cb_idVenta.SelectedItem + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //string idCliente = (string)dr["idCliente"].ToString();
                    // txt_idCliente.Text = dr[0].ToString();
                    txt_subTotalVenta.Text = dr[0].ToString();
                    string Sub = this.txt_subTotalVenta.Text;
                    subTotalFinalVenta = Int32.Parse(Sub);//textbox de Precio

                }


                int subTotal = (subTotalFinalVenta);//calculo de subtotal

                int Iva = (int)(subTotal * 0.16);//calculo de IVA

                int Total = (subTotal + Iva);//calculo de Total

                txt_subTotalVenta.Text = subTotal.ToString();

                txt_ivaVenta.Text = Iva.ToString();
                txt_totalVenta.Text = Total.ToString();



                cn.ModificarSalesVentasDT(idVenta, txt_subTotalVenta.Text, txt_ivaVenta.Text, txt_totalVenta.Text);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();




                con.Close();
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
                MessageBox.Show("Falta seleccionar la Venta que va Modificar !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
           else  if (Cb_Estatus.SelectedIndex <= -1)
            {
                MessageBox.Show("Falta seleccionar el Estatus !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (Cb_idVenta.SelectedIndex > 0 || Cb_idVenta.SelectedIndex == 0)
            {
                //string Estatus = Cb_Estatus.SelectedItem.ToString();
                string idVenta = Cb_idVenta.SelectedItem.ToString();
                Cb_Estatus.Text = "I";
                cn.ModificarSalesVentasDetalleDT(txt_idventaDetalle.Text, txt_precioVenta.Text, txt_cantidad.Text, txt_subTotal.Text, idVenta, txt_idPresentacion.Text, Cb_Estatus.Text);
                //dataGridView1.DataSource = cn.ConsultaParcelasDT();
                ds.Clear();
                loadData();
                VarPagFinal = TotalFilasAMostrar;
                Mostrar_datos();




                txt_idventaDetalle.Text = " ";
               
                txt_precioVenta.Text = " ";
                txt_cantidad.Text = " ";
                txt_subTotal.Text = " ";
                txt_idPresentacion.Text = " ";
                Cb_idVenta.SelectedIndex = -1;
                Cb_Estatus.SelectedIndex = -1;
              

                MessageBox.Show("Eliminado Correctamente!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error al Eliminar los datos !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idventaDetalle.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_precioVenta.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_cantidad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_subTotal.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Cb_idVenta.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Cb_idPresentacion.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            //txt_idPresentacion.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            Cb_Estatus.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

            Cb_idVenta.Enabled = false;



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
                
                SqlDataAdapter datos = new SqlDataAdapter("select SalesVentaDetalle.idVentaDetalle, SalesVentaDetalle.precioVenta, SalesVentaDetalle.cantidad,SalesVentaDetalle.subtotal,SalesVentaDetalle.idVenta,SalesVentaDetalle.idPresentacion,PresentacionesProducto.idEmpaque,Empaques.nombre,SalesVentaDetalle.estatus,SalesVentas.idVenta,SalesVentas.idCliente,SalesClientes.nombre  from SalesVentaDetalle JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque JOIN SalesVentas ON SalesVentas.idVenta = SalesVentaDetalle.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente  where " + this.comboBox1.Text + " like '%" + this.textBox1.Text + "%'", con);
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesVentaDetalle");
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
                string sql = "select SalesVentaDetalle.idVentaDetalle, SalesVentaDetalle.precioVenta, SalesVentaDetalle.cantidad,SalesVentaDetalle.subtotal,SalesVentaDetalle.idVenta,SalesVentaDetalle.idPresentacion,PresentacionesProducto.idEmpaque,Empaques.nombre,SalesVentaDetalle.estatus,SalesVentas.idVenta,SalesVentas.idCliente,SalesClientes.nombre  from SalesVentaDetalle JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque JOIN SalesVentas ON SalesVentas.idVenta = SalesVentaDetalle.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente";

                cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;

                //fill dataser
                adapter.Fill(ds, start, numMostar, "SalesVentaDetalle");
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
                adapter.Fill(ds, start, 2, "SalesVentaDetalle");
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
                adapter.Fill(ds, start, numMostar, "SalesVentaDetalle");
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
                adapter.Fill(ds, start, 2, "SalesVentaDetalle");
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
                adapter.Fill(ds, start, numMostar, "SalesVentaDetalle");
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

        private void ventasDetalle_MouseMove(object sender, MouseEventArgs e)
        {
           

        }

        private void ventasDetalle_Leave(object sender, EventArgs e)
        {
            VarPagFinal = TotalFilasAMostrar;
            Mostrar_datos();
            //dataGridView1.DataSource = cn.ConsultarJoinParcelasDT();
            start = 0;
            loadData();
            Mostrar_datos();
            Cargar_Datos_VentasID();
            Cantida = 0;
            Precio = 0;
        }

        private void Cb_idVenta_MouseClick(object sender, MouseEventArgs e)
        {
            Cb_idVenta.Items.Clear();
            Cargar_Datos_VentasID();
        }

        private void txt_Presentacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Cb_idPresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            Cantida = 0;
            string q = "select PresentacionesProducto.idPresentacion,PresentacionesProducto.precioVenta,PresentacionesProducto.idEmpaque,Empaques.nombre from PresentacionesProducto JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque WHERE Empaques.nombre = '" + Cb_idPresentacion.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //string idCliente = (string)dr["idCliente"].ToString();
                // txt_idCliente.Text = dr[0].ToString();
          
                txt_idPresentacion.Text = dr[0].ToString();
                txt_precioVenta.Text = dr[1].ToString();


            }
            if (string.IsNullOrEmpty(txt_cantidad.Text))
            {
                MessageBox.Show("Falta Agregar la Cantidad !!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_cantidad.Text = "";
            }
            else
            {


                string ids = this.txt_precioVenta.Text;
                int Precio = Int32.Parse(ids);//textbox de Precio

                string cant = this.txt_cantidad.Text;
                int Cantida = Int32.Parse(cant);//textbox de Precio

                int subTotal = (Precio * Cantida);//calculo de subtotal

                txt_subTotal.Text = subTotal.ToString();



            }

            con.Close();
        }

        private void btnGuardar_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnGuardar_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void Cb_Estatus_MouseClick(object sender, MouseEventArgs e)
        {
           


        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
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
