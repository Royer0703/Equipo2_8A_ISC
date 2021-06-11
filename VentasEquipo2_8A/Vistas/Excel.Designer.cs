
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1342, 477);
            this.dataGridView1.TabIndex = 149;
            // 
            // Cb_idVenta
            // 
            this.Cb_idVenta.FormattingEnabled = true;
            this.Cb_idVenta.Location = new System.Drawing.Point(12, 615);
            this.Cb_idVenta.Name = "Cb_idVenta";
            this.Cb_idVenta.Size = new System.Drawing.Size(128, 21);
            this.Cb_idVenta.TabIndex = 151;
            this.Cb_idVenta.SelectedIndexChanged += new System.EventHandler(this.Cb_idVenta_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(12, 592);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
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
            this.btncerrar.Location = new System.Drawing.Point(1315, 2);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(30, 30);
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
            this.btnExcelDescarga.Location = new System.Drawing.Point(259, 615);
            this.btnExcelDescarga.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExcelDescarga.Name = "btnExcelDescarga";
            this.btnExcelDescarga.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnExcelDescarga.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnExcelDescarga.OnHoverTextColor = System.Drawing.Color.White;
            this.btnExcelDescarga.selected = false;
            this.btnExcelDescarga.Size = new System.Drawing.Size(237, 50);
            this.btnExcelDescarga.TabIndex = 212;
            this.btnExcelDescarga.Text = "EXP. EXCEL";
            this.btnExcelDescarga.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExcelDescarga.Textcolor = System.Drawing.Color.White;
            this.btnExcelDescarga.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcelDescarga.Click += new System.EventHandler(this.btnExcelDescarga_Click);
            // 
            // Excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1366, 786);
            this.Controls.Add(this.btnExcelDescarga);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.Cb_idVenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
    }
}