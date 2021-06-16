
namespace Vistas
{
    partial class Excel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Excel));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Cb_idVenta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btncerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnExcelDescarga = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txt_xml = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnpdf = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btncerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 112);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1789, 587);
            this.dataGridView1.TabIndex = 149;
            // 
            // Cb_idVenta
            // 
            this.Cb_idVenta.FormattingEnabled = true;
            this.Cb_idVenta.Location = new System.Drawing.Point(16, 757);
            this.Cb_idVenta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cb_idVenta.Name = "Cb_idVenta";
            this.Cb_idVenta.Size = new System.Drawing.Size(169, 24);
            this.Cb_idVenta.TabIndex = 151;
            this.Cb_idVenta.SelectedIndexChanged += new System.EventHandler(this.Cb_idVenta_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(16, 729);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 150;
            this.label2.Text = "Venta";
            // 
            // btncerrar
            // 
            this.btncerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncerrar.BackColor = System.Drawing.Color.Transparent;
            this.btncerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncerrar.Image = ((System.Drawing.Image)(resources.GetObject("btncerrar.Image")));
            this.btncerrar.ImageActive = null;
            this.btncerrar.Location = new System.Drawing.Point(1753, 2);
            this.btncerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(40, 37);
            this.btncerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btncerrar.TabIndex = 152;
            this.btncerrar.TabStop = false;
            this.btncerrar.Zoom = 10;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // btnExcelDescarga
            // 
            this.btnExcelDescarga.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnExcelDescarga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnExcelDescarga.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcelDescarga.BorderRadius = 3;
            this.btnExcelDescarga.ButtonText = "EXP. EXCEL";
            this.btnExcelDescarga.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcelDescarga.DisabledColor = System.Drawing.Color.Gray;
            this.btnExcelDescarga.Enabled = false;
            this.btnExcelDescarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcelDescarga.Iconcolor = System.Drawing.Color.Transparent;
            this.btnExcelDescarga.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnExcelDescarga.Iconimage")));
            this.btnExcelDescarga.Iconimage_right = null;
            this.btnExcelDescarga.Iconimage_right_Selected = null;
            this.btnExcelDescarga.Iconimage_Selected = null;
            this.btnExcelDescarga.IconMarginLeft = 0;
            this.btnExcelDescarga.IconMarginRight = 0;
            this.btnExcelDescarga.IconRightVisible = true;
            this.btnExcelDescarga.IconRightZoom = 0D;
            this.btnExcelDescarga.IconVisible = true;
            this.btnExcelDescarga.IconZoom = 50D;
            this.btnExcelDescarga.IsTab = false;
            this.btnExcelDescarga.Location = new System.Drawing.Point(327, 757);
            this.btnExcelDescarga.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnExcelDescarga.Name = "btnExcelDescarga";
            this.btnExcelDescarga.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnExcelDescarga.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnExcelDescarga.OnHoverTextColor = System.Drawing.Color.White;
            this.btnExcelDescarga.selected = false;
            this.btnExcelDescarga.Size = new System.Drawing.Size(316, 62);
            this.btnExcelDescarga.TabIndex = 212;
            this.btnExcelDescarga.Text = "EXP. EXCEL";
            this.btnExcelDescarga.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExcelDescarga.Textcolor = System.Drawing.Color.White;
            this.btnExcelDescarga.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcelDescarga.Click += new System.EventHandler(this.btnExcelDescarga_Click);
            // 
            // txt_xml
            // 
            this.txt_xml.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.txt_xml.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.txt_xml.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txt_xml.BorderRadius = 3;
            this.txt_xml.ButtonText = "EXP. XML";
            this.txt_xml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txt_xml.DisabledColor = System.Drawing.Color.Gray;
            this.txt_xml.Enabled = false;
            this.txt_xml.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_xml.Iconcolor = System.Drawing.Color.Transparent;
            this.txt_xml.Iconimage = ((System.Drawing.Image)(resources.GetObject("txt_xml.Iconimage")));
            this.txt_xml.Iconimage_right = null;
            this.txt_xml.Iconimage_right_Selected = null;
            this.txt_xml.Iconimage_Selected = null;
            this.txt_xml.IconMarginLeft = 0;
            this.txt_xml.IconMarginRight = 0;
            this.txt_xml.IconRightVisible = true;
            this.txt_xml.IconRightZoom = 0D;
            this.txt_xml.IconVisible = true;
            this.txt_xml.IconZoom = 50D;
            this.txt_xml.IsTab = false;
            this.txt_xml.Location = new System.Drawing.Point(704, 757);
            this.txt_xml.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txt_xml.Name = "txt_xml";
            this.txt_xml.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.txt_xml.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.txt_xml.OnHoverTextColor = System.Drawing.Color.White;
            this.txt_xml.selected = false;
            this.txt_xml.Size = new System.Drawing.Size(316, 62);
            this.txt_xml.TabIndex = 213;
            this.txt_xml.Text = "EXP. XML";
            this.txt_xml.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_xml.Textcolor = System.Drawing.Color.White;
            this.txt_xml.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_xml.Click += new System.EventHandler(this.txt_xml_Click);
            // 
            // btnpdf
            // 
            this.btnpdf.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnpdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnpdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnpdf.BorderRadius = 3;
            this.btnpdf.ButtonText = "EXP. PDF";
            this.btnpdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnpdf.DisabledColor = System.Drawing.Color.Gray;
            this.btnpdf.Enabled = false;
            this.btnpdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpdf.Iconcolor = System.Drawing.Color.Transparent;
            this.btnpdf.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnpdf.Iconimage")));
            this.btnpdf.Iconimage_right = null;
            this.btnpdf.Iconimage_right_Selected = null;
            this.btnpdf.Iconimage_Selected = null;
            this.btnpdf.IconMarginLeft = 0;
            this.btnpdf.IconMarginRight = 0;
            this.btnpdf.IconRightVisible = true;
            this.btnpdf.IconRightZoom = 0D;
            this.btnpdf.IconVisible = true;
            this.btnpdf.IconZoom = 50D;
            this.btnpdf.IsTab = false;
            this.btnpdf.Location = new System.Drawing.Point(1093, 757);
            this.btnpdf.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnpdf.Name = "btnpdf";
            this.btnpdf.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnpdf.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnpdf.OnHoverTextColor = System.Drawing.Color.White;
            this.btnpdf.selected = false;
            this.btnpdf.Size = new System.Drawing.Size(316, 62);
            this.btnpdf.TabIndex = 214;
            this.btnpdf.Text = "EXP. PDF";
            this.btnpdf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnpdf.Textcolor = System.Drawing.Color.White;
            this.btnpdf.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpdf.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // Excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1821, 967);
            this.Controls.Add(this.btnpdf);
            this.Controls.Add(this.txt_xml);
            this.Controls.Add(this.btnExcelDescarga);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.Cb_idVenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Excel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btncerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox Cb_idVenta;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuImageButton btncerrar;
        private Bunifu.Framework.UI.BunifuFlatButton btnExcelDescarga;
        private Bunifu.Framework.UI.BunifuFlatButton txt_xml;
        private Bunifu.Framework.UI.BunifuFlatButton btnpdf;
    }
}