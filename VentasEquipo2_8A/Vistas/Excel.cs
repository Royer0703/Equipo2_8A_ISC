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
using System.IO;
using System.Xml;
using iTextSharp.text.pdf;
using iTextSharp.text;

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
            string q = "select idVenta from SalesVentas where estatus = 'A' ";
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
                txt_xml.Enabled = true;
                btnpdf.Enabled = true;
            }

          
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnExcelDescarga_Click(object sender, EventArgs e)
        {
            ExportarDatos(dataGridView1);

            btnExcelDescarga.Enabled = false;
            txt_xml.Enabled = false;
        }

        private void txt_xml_Click(object sender, EventArgs e)
        {
            ExportXML();

            btnExcelDescarga.Enabled = false;
            txt_xml.Enabled = false;
        }

        private void ExportXML()
        {
            var ds = new DataSet();
            var dt = new DataTable();
            try
            {
                foreach (var column in dataGridView1.Columns.Cast<DataGridViewColumn>())
                {
                    dt.Columns.Add();
                }
                var cellValues = new object[dataGridView1.Columns.Count];

                foreach (var row in dataGridView1.Rows.Cast<DataGridViewRow>())
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        cellValues[i] = row.Cells[i].Value;
                    }
                    dt.Rows.Add(cellValues);
                }
                ds.Tables.Add(dt);

                string FileName = "Archivo.XML";
                FileStream Steam = new FileStream(FileName,FileMode.Create);
                XmlTextWriter xmlWriter = new XmlTextWriter(Steam, System.Text.Encoding.Unicode);
                ds.WriteXml(xmlWriter);
                xmlWriter.Close();

            
            }

            catch (Exception ex)                                                                       
            {

                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)

            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = "Result.pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {

                    if (File.Exists(save.FileName))

                    {

                        try

                        {

                            File.Delete(save.FileName);

                        }

                        catch (Exception ex)

                        {

                            ErrorMessage = true;

                            MessageBox.Show("Unable to wride data in disk" + ex.Message);

                        }

                    }

                    if (!ErrorMessage)

                    {

                        try

                        {

                            PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dataGridView1.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in dataGridView1.Rows)

                            {

                                foreach (DataGridViewCell dcell in viewRow.Cells)

                                {

                                    pTable.AddCell(dcell.Value.ToString());

                                }

                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))

                            {

                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);

                                PdfWriter.GetInstance(document, fileStream);

                                document.Open();

                                document.Add(pTable);

                                document.Close();

                                fileStream.Close();

                            }

                            MessageBox.Show("Data Export Successfully", "info");

                        }

                        catch (Exception ex)

                        {

                            MessageBox.Show("Error while exporting Data" + ex.Message);

                        }

                    }

                }

            }

            else

            {

                MessageBox.Show("No Record Found", "Info");

            }
        }
    }
}
