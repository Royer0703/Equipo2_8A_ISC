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
   

    public partial class Excel : Form
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
        SqlConnection con1 = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
        SqlConnection con2 = new SqlConnection(Properties.Settings.Default.ERPVENTAConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int start;

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
            con.Close();

        }

        public void ExportarDatos(DataGridView dataListado)
        {
            Microsoft.Office.Interop.Excel.Application exportarexcel = new Microsoft.Office.Interop.Excel.Application();

            exportarexcel.Application.Workbooks.Add(true);
            int indececolumna = 0;
            foreach (DataGridViewColumn columna in dataListado.Columns)
            {
                indececolumna++;

                exportarexcel.Cells[1, indececolumna] = columna.Name;
            }

            int indecefila = 0;
            foreach (DataGridViewRow fila in dataListado.Rows)
            {
                indecefila++;
                indececolumna = 0;
                foreach (DataGridViewColumn columna in dataListado.Columns)
                {
                    indececolumna++;
                    exportarexcel.Cells[indecefila + 1, indececolumna] = fila.Cells[columna.Name].Value;
                }                                                                                        


            }
            exportarexcel.Visible = true;


        }


        public Excel()
        {
            InitializeComponent();
           
            VarPagFinal = TotalFilasAMostrar;
            //Mostrar_datos();
            //dataGridView1.DataSource = cn.ConsultarJoinParcelasDT();
            start = 0;
            // loadData();
            Cargar_Datos_idVentas();


        }

        private void Cb_idVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cb_idVenta.SelectedIndex >= 0)
            { 
 
                SqlDataAdapter datos = new SqlDataAdapter("select SalesVentaDetalle.idVentaDetalle, SalesVentaDetalle.precioVenta, SalesVentaDetalle.cantidad,SalesVentaDetalle.subtotal,SalesVentaDetalle.idVenta,SalesVentaDetalle.idPresentacion,PresentacionesProducto.idEmpaque,Empaques.nombre,Productos.idProducto,Productos.nombre,SalesVentaDetalle.estatus,SalesVentas.idCliente,SalesClientes.nombre,SalesVentas.idSucursal,Sucursales.nombre,SalesVentas.subtotal,SalesVentas.iva,SalesVentas.total,SalesVentas.fecha,SalesVentas.comentarios,SalesVentas.cantPagada from SalesVentaDetalle JOIN PresentacionesProducto ON PresentacionesProducto.idPresentacion = SalesVentaDetalle.idPresentacion JOIN Empaques ON Empaques.idEmpaque = PresentacionesProducto.idEmpaque JOIN SalesVentas ON SalesVentas.idVenta = SalesVentaDetalle.idVenta JOIN SalesClientes ON SalesClientes.idCliente = SalesVentas.idCliente JOIN Productos ON Productos.idProducto = PresentacionesProducto.idProducto JOIN Sucursales ON Sucursales.idSucursal = SalesVentas.idSucursal WHERE SalesVentas.estatus ='A' and SalesVentas.idVenta = '" + Cb_idVenta.SelectedItem + "'", con);//modificado
                DataSet ds = new DataSet();
                datos.Fill(ds, "SalesVentaDetalle");
                this.dataGridView1.DataSource = ds.Tables[0];

                btnExcelDescarga.Enabled = true;

            }

          
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnExcelDescarga_Click(object sender, EventArgs e)
        {
            ExportarDatos(dataGridView1);
        }
    }
}
