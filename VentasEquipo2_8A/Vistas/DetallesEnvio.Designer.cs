
namespace Vistas
{
    partial class DetallesEnvio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetallesEnvio));
            this.txt_DatosaMostar = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_atras = new System.Windows.Forms.Button();
            this.btn_adelante = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtCantidadTotal = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnGuardar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnNuevo = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.Cb_idventa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Direccion_cliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_fechaEntrega = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_peso = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_ContactoCliente = new System.Windows.Forms.TextBox();
            this.txt_PesoEmpaque = new System.Windows.Forms.TextBox();
            this.txt_cantidpresenta1 = new System.Windows.Forms.TextBox();
            this.txt_cantidpresenta2 = new System.Windows.Forms.TextBox();
            this.pesoIdpre1 = new System.Windows.Forms.TextBox();
            this.pesoIdpre2 = new System.Windows.Forms.TextBox();
            this.txt_idPresenta1 = new System.Windows.Forms.TextBox();
            this.txt_idPresenta2 = new System.Windows.Forms.TextBox();
            this.btncerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_fechaRecepcion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Cb_idEnvio = new System.Windows.Forms.ComboBox();
            this.txt_capacidaUnidad = new System.Windows.Forms.TextBox();
            this.txt_totalEnvioSum = new System.Windows.Forms.TextBox();
            this.txt_EstatusEnvio = new System.Windows.Forms.TextBox();
            this.txt_idventaEnvio = new System.Windows.Forms.TextBox();
            this.btnEliminar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btncerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_DatosaMostar
            // 
            this.txt_DatosaMostar.Location = new System.Drawing.Point(130, 475);
            this.txt_DatosaMostar.Name = "txt_DatosaMostar";
            this.txt_DatosaMostar.Size = new System.Drawing.Size(57, 20);
            this.txt_DatosaMostar.TabIndex = 79;
            this.txt_DatosaMostar.TextChanged += new System.EventHandler(this.txt_DatosaMostar_TextChanged);
            this.txt_DatosaMostar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_DatosaMostar_KeyDown);
            this.txt_DatosaMostar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DatosaMostar_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(12, 476);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 20);
            this.label11.TabIndex = 78;
            this.label11.Text = "Datos a Mostar:";
            // 
            // btn_atras
            // 
            this.btn_atras.Enabled = false;
            this.btn_atras.Location = new System.Drawing.Point(424, 473);
            this.btn_atras.Name = "btn_atras";
            this.btn_atras.Size = new System.Drawing.Size(75, 23);
            this.btn_atras.TabIndex = 77;
            this.btn_atras.Text = "<<<";
            this.btn_atras.UseVisualStyleBackColor = true;
            this.btn_atras.Click += new System.EventHandler(this.btn_atras_Click);
            // 
            // btn_adelante
            // 
            this.btn_adelante.Location = new System.Drawing.Point(267, 473);
            this.btn_adelante.Name = "btn_adelante";
            this.btn_adelante.Size = new System.Drawing.Size(75, 23);
            this.btn_adelante.TabIndex = 76;
            this.btn_adelante.Text = ">>>";
            this.btn_adelante.UseVisualStyleBackColor = true;
            this.btn_adelante.Click += new System.EventHandler(this.btn_adelante_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(701, 476);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 20);
            this.label9.TabIndex = 75;
            this.label9.Text = "Total de Paginas:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(522, 476);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 20);
            this.label8.TabIndex = 74;
            this.label8.Text = "Total de Datos:";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(838, 475);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(47, 20);
            this.textBox3.TabIndex = 73;
            // 
            // txtCantidadTotal
            // 
            this.txtCantidadTotal.Enabled = false;
            this.txtCantidadTotal.Location = new System.Drawing.Point(645, 477);
            this.txtCantidadTotal.Name = "txtCantidadTotal";
            this.txtCantidadTotal.Size = new System.Drawing.Size(50, 20);
            this.txtCantidadTotal.TabIndex = 72;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "SalesDetallesEnvio.idEnvio",
            "SalesDetallesEnvio.idVenta",
            "SalesDetallesEnvio.idDireccion",
            "SalesDetallesEnvio.fechaEntregaPlaneada",
            "SalesDetallesEnvio.fechaRecepcion",
            "SalesDetallesEnvio.pesoTotal",
            "SalesDetallesEnvio.estatus",
            "SalesDetallesEnvio.idContacto"});
            this.comboBox1.Location = new System.Drawing.Point(308, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(231, 21);
            this.comboBox1.TabIndex = 71;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(48, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 20);
            this.label10.TabIndex = 70;
            this.label10.Text = "Buscar";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(265, 20);
            this.textBox1.TabIndex = 69;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.BorderRadius = 3;
            this.btnGuardar.ButtonText = "GUARDAR VENTA";
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.DisabledColor = System.Drawing.Color.Gray;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnGuardar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Iconimage")));
            this.btnGuardar.Iconimage_right = null;
            this.btnGuardar.Iconimage_right_Selected = null;
            this.btnGuardar.Iconimage_Selected = null;
            this.btnGuardar.IconMarginLeft = 0;
            this.btnGuardar.IconMarginRight = 0;
            this.btnGuardar.IconRightVisible = true;
            this.btnGuardar.IconRightZoom = 0D;
            this.btnGuardar.IconVisible = true;
            this.btnGuardar.IconZoom = 50D;
            this.btnGuardar.IsTab = false;
            this.btnGuardar.Location = new System.Drawing.Point(16, 511);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnGuardar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnGuardar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnGuardar.selected = false;
            this.btnGuardar.Size = new System.Drawing.Size(188, 40);
            this.btnGuardar.TabIndex = 68;
            this.btnGuardar.Text = "GUARDAR VENTA";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Textcolor = System.Drawing.Color.White;
            this.btnGuardar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevo.BorderRadius = 3;
            this.btnNuevo.ButtonText = "AGREGAR VENTA";
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.DisabledColor = System.Drawing.Color.Gray;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Iconcolor = System.Drawing.Color.Transparent;
            this.btnNuevo.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Iconimage")));
            this.btnNuevo.Iconimage_right = null;
            this.btnNuevo.Iconimage_right_Selected = null;
            this.btnNuevo.Iconimage_Selected = null;
            this.btnNuevo.IconMarginLeft = 0;
            this.btnNuevo.IconMarginRight = 0;
            this.btnNuevo.IconRightVisible = true;
            this.btnNuevo.IconRightZoom = 0D;
            this.btnNuevo.IconVisible = true;
            this.btnNuevo.IconZoom = 50D;
            this.btnNuevo.IsTab = false;
            this.btnNuevo.Location = new System.Drawing.Point(697, 515);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnNuevo.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnNuevo.OnHoverTextColor = System.Drawing.Color.White;
            this.btnNuevo.selected = false;
            this.btnNuevo.Size = new System.Drawing.Size(188, 40);
            this.btnNuevo.TabIndex = 65;
            this.btnNuevo.Text = "AGREGAR VENTA";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.Textcolor = System.Drawing.Color.White;
            this.btnNuevo.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 20);
            this.label1.TabIndex = 64;
            this.label1.Text = "Listado De Envios Detalle";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(869, 379);
            this.dataGridView1.TabIndex = 63;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(892, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 81;
            this.label3.Text = "Venta";
            // 
            // Cb_idventa
            // 
            this.Cb_idventa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_idventa.FormattingEnabled = true;
            this.Cb_idventa.Location = new System.Drawing.Point(896, 139);
            this.Cb_idventa.Name = "Cb_idventa";
            this.Cb_idventa.Size = new System.Drawing.Size(146, 21);
            this.Cb_idventa.TabIndex = 80;
            this.Cb_idventa.SelectedIndexChanged += new System.EventHandler(this.Cb_idventa_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(890, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 83;
            this.label2.Text = "Direccion";
            // 
            // txt_Direccion_cliente
            // 
            this.txt_Direccion_cliente.Enabled = false;
            this.txt_Direccion_cliente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_Direccion_cliente.Location = new System.Drawing.Point(894, 398);
            this.txt_Direccion_cliente.Name = "txt_Direccion_cliente";
            this.txt_Direccion_cliente.Size = new System.Drawing.Size(144, 20);
            this.txt_Direccion_cliente.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(888, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 85;
            this.label4.Text = "Fecha Entrega";
            // 
            // txt_fechaEntrega
            // 
            this.txt_fechaEntrega.Enabled = false;
            this.txt_fechaEntrega.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_fechaEntrega.Location = new System.Drawing.Point(892, 444);
            this.txt_fechaEntrega.Name = "txt_fechaEntrega";
            this.txt_fechaEntrega.Size = new System.Drawing.Size(147, 20);
            this.txt_fechaEntrega.TabIndex = 84;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(890, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 20);
            this.label5.TabIndex = 87;
            this.label5.Text = "Peso Total de venta";
            // 
            // txt_peso
            // 
            this.txt_peso.Enabled = false;
            this.txt_peso.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_peso.Location = new System.Drawing.Point(894, 352);
            this.txt_peso.Name = "txt_peso";
            this.txt_peso.Size = new System.Drawing.Size(144, 20);
            this.txt_peso.TabIndex = 86;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(891, 513);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 91;
            this.label6.Text = "Contacto";
            // 
            // txt_ContactoCliente
            // 
            this.txt_ContactoCliente.Enabled = false;
            this.txt_ContactoCliente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_ContactoCliente.Location = new System.Drawing.Point(895, 536);
            this.txt_ContactoCliente.Name = "txt_ContactoCliente";
            this.txt_ContactoCliente.Size = new System.Drawing.Size(143, 20);
            this.txt_ContactoCliente.TabIndex = 90;
            // 
            // txt_PesoEmpaque
            // 
            this.txt_PesoEmpaque.BackColor = System.Drawing.Color.White;
            this.txt_PesoEmpaque.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_PesoEmpaque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_PesoEmpaque.Location = new System.Drawing.Point(612, 59);
            this.txt_PesoEmpaque.Name = "txt_PesoEmpaque";
            this.txt_PesoEmpaque.Size = new System.Drawing.Size(100, 13);
            this.txt_PesoEmpaque.TabIndex = 97;
            // 
            // txt_cantidpresenta1
            // 
            this.txt_cantidpresenta1.BackColor = System.Drawing.SystemColors.Control;
            this.txt_cantidpresenta1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_cantidpresenta1.Enabled = false;
            this.txt_cantidpresenta1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_cantidpresenta1.Location = new System.Drawing.Point(898, 225);
            this.txt_cantidpresenta1.Name = "txt_cantidpresenta1";
            this.txt_cantidpresenta1.Size = new System.Drawing.Size(44, 13);
            this.txt_cantidpresenta1.TabIndex = 99;
            // 
            // txt_cantidpresenta2
            // 
            this.txt_cantidpresenta2.BackColor = System.Drawing.SystemColors.Control;
            this.txt_cantidpresenta2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_cantidpresenta2.Enabled = false;
            this.txt_cantidpresenta2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_cantidpresenta2.Location = new System.Drawing.Point(896, 313);
            this.txt_cantidpresenta2.Name = "txt_cantidpresenta2";
            this.txt_cantidpresenta2.Size = new System.Drawing.Size(44, 13);
            this.txt_cantidpresenta2.TabIndex = 100;
            // 
            // pesoIdpre1
            // 
            this.pesoIdpre1.BackColor = System.Drawing.SystemColors.Control;
            this.pesoIdpre1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pesoIdpre1.Enabled = false;
            this.pesoIdpre1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pesoIdpre1.Location = new System.Drawing.Point(948, 225);
            this.pesoIdpre1.Name = "pesoIdpre1";
            this.pesoIdpre1.Size = new System.Drawing.Size(44, 13);
            this.pesoIdpre1.TabIndex = 101;
            // 
            // pesoIdpre2
            // 
            this.pesoIdpre2.BackColor = System.Drawing.SystemColors.Control;
            this.pesoIdpre2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pesoIdpre2.Enabled = false;
            this.pesoIdpre2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pesoIdpre2.Location = new System.Drawing.Point(946, 313);
            this.pesoIdpre2.Name = "pesoIdpre2";
            this.pesoIdpre2.Size = new System.Drawing.Size(44, 13);
            this.pesoIdpre2.TabIndex = 102;
            // 
            // txt_idPresenta1
            // 
            this.txt_idPresenta1.BackColor = System.Drawing.SystemColors.Control;
            this.txt_idPresenta1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_idPresenta1.Enabled = false;
            this.txt_idPresenta1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_idPresenta1.Location = new System.Drawing.Point(897, 186);
            this.txt_idPresenta1.Name = "txt_idPresenta1";
            this.txt_idPresenta1.Size = new System.Drawing.Size(44, 13);
            this.txt_idPresenta1.TabIndex = 103;
            this.txt_idPresenta1.Text = "1";
            this.txt_idPresenta1.TextChanged += new System.EventHandler(this.txt_idPresenta1_TextChanged);
            // 
            // txt_idPresenta2
            // 
            this.txt_idPresenta2.BackColor = System.Drawing.SystemColors.Control;
            this.txt_idPresenta2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_idPresenta2.Enabled = false;
            this.txt_idPresenta2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_idPresenta2.Location = new System.Drawing.Point(896, 274);
            this.txt_idPresenta2.Name = "txt_idPresenta2";
            this.txt_idPresenta2.Size = new System.Drawing.Size(44, 13);
            this.txt_idPresenta2.TabIndex = 104;
            this.txt_idPresenta2.Text = "2";
            // 
            // btncerrar
            // 
            this.btncerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncerrar.BackColor = System.Drawing.Color.Transparent;
            this.btncerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncerrar.Image = ((System.Drawing.Image)(resources.GetObject("btncerrar.Image")));
            this.btncerrar.ImageActive = null;
            this.btncerrar.Location = new System.Drawing.Point(12, 9);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(30, 30);
            this.btncerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btncerrar.TabIndex = 105;
            this.btncerrar.TabStop = false;
            this.btncerrar.Zoom = 10;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(890, 467);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 20);
            this.label12.TabIndex = 107;
            this.label12.Text = "Fecha Recepcion";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // txt_fechaRecepcion
            // 
            this.txt_fechaRecepcion.Enabled = false;
            this.txt_fechaRecepcion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_fechaRecepcion.Location = new System.Drawing.Point(894, 490);
            this.txt_fechaRecepcion.Name = "txt_fechaRecepcion";
            this.txt_fechaRecepcion.Size = new System.Drawing.Size(144, 20);
            this.txt_fechaRecepcion.TabIndex = 106;
            this.txt_fechaRecepcion.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(709, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 109;
            this.label7.Text = "Envio";
            // 
            // Cb_idEnvio
            // 
            this.Cb_idEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_idEnvio.FormattingEnabled = true;
            this.Cb_idEnvio.Location = new System.Drawing.Point(713, 44);
            this.Cb_idEnvio.Name = "Cb_idEnvio";
            this.Cb_idEnvio.Size = new System.Drawing.Size(145, 21);
            this.Cb_idEnvio.TabIndex = 108;
            this.Cb_idEnvio.SelectedIndexChanged += new System.EventHandler(this.Cb_idEnvio_SelectedIndexChanged);
            // 
            // txt_capacidaUnidad
            // 
            this.txt_capacidaUnidad.Enabled = false;
            this.txt_capacidaUnidad.Location = new System.Drawing.Point(896, 45);
            this.txt_capacidaUnidad.Name = "txt_capacidaUnidad";
            this.txt_capacidaUnidad.Size = new System.Drawing.Size(144, 20);
            this.txt_capacidaUnidad.TabIndex = 110;
            // 
            // txt_totalEnvioSum
            // 
            this.txt_totalEnvioSum.Enabled = false;
            this.txt_totalEnvioSum.Location = new System.Drawing.Point(896, 91);
            this.txt_totalEnvioSum.Name = "txt_totalEnvioSum";
            this.txt_totalEnvioSum.Size = new System.Drawing.Size(145, 20);
            this.txt_totalEnvioSum.TabIndex = 111;
            // 
            // txt_EstatusEnvio
            // 
            this.txt_EstatusEnvio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_EstatusEnvio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_EstatusEnvio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_EstatusEnvio.Location = new System.Drawing.Point(612, 45);
            this.txt_EstatusEnvio.Name = "txt_EstatusEnvio";
            this.txt_EstatusEnvio.Size = new System.Drawing.Size(39, 13);
            this.txt_EstatusEnvio.TabIndex = 112;
            // 
            // txt_idventaEnvio
            // 
            this.txt_idventaEnvio.BackColor = System.Drawing.Color.White;
            this.txt_idventaEnvio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_idventaEnvio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_idventaEnvio.Location = new System.Drawing.Point(564, 45);
            this.txt_idventaEnvio.Name = "txt_idventaEnvio";
            this.txt_idventaEnvio.Size = new System.Drawing.Size(42, 13);
            this.txt_idventaEnvio.TabIndex = 113;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.BorderRadius = 3;
            this.btnEliminar.ButtonText = "BORRAR";
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.DisabledColor = System.Drawing.Color.Gray;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEliminar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Iconimage")));
            this.btnEliminar.Iconimage_right = null;
            this.btnEliminar.Iconimage_right_Selected = null;
            this.btnEliminar.Iconimage_Selected = null;
            this.btnEliminar.IconMarginLeft = 0;
            this.btnEliminar.IconMarginRight = 0;
            this.btnEliminar.IconRightVisible = true;
            this.btnEliminar.IconRightZoom = 0D;
            this.btnEliminar.IconVisible = true;
            this.btnEliminar.IconZoom = 50D;
            this.btnEliminar.IsTab = false;
            this.btnEliminar.Location = new System.Drawing.Point(480, 515);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnEliminar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnEliminar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEliminar.selected = false;
            this.btnEliminar.Size = new System.Drawing.Size(188, 40);
            this.btnEliminar.TabIndex = 114;
            this.btnEliminar.Text = "BORRAR";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.Textcolor = System.Drawing.Color.White;
            this.btnEliminar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(892, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 20);
            this.label13.TabIndex = 115;
            this.label13.Text = "Suma Peso Venta";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.Control;
            this.label14.Location = new System.Drawing.Point(890, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(162, 20);
            this.label14.TabIndex = 116;
            this.label14.Text = "Capacidad de Unidad";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.Control;
            this.label15.Location = new System.Drawing.Point(890, 163);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(172, 20);
            this.label15.TabIndex = 117;
            this.label15.Text = "Presenetacion Express";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.Control;
            this.label16.Location = new System.Drawing.Point(890, 202);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(155, 20);
            this.label16.TabIndex = 118;
            this.label16.Text = "Cant y Peso Express";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.Control;
            this.label17.Location = new System.Drawing.Point(892, 251);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(138, 20);
            this.label17.TabIndex = 119;
            this.label17.Text = "Presenetacion Vip";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.Control;
            this.label18.Location = new System.Drawing.Point(892, 290);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(121, 20);
            this.label18.TabIndex = 120;
            this.label18.Text = "Cant y Peso Vip";
            // 
            // DetallesEnvio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1079, 569);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.txt_idventaEnvio);
            this.Controls.Add(this.txt_EstatusEnvio);
            this.Controls.Add(this.txt_totalEnvioSum);
            this.Controls.Add(this.txt_capacidaUnidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Cb_idEnvio);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_fechaRecepcion);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.txt_idPresenta2);
            this.Controls.Add(this.txt_idPresenta1);
            this.Controls.Add(this.pesoIdpre2);
            this.Controls.Add(this.pesoIdpre1);
            this.Controls.Add(this.txt_cantidpresenta2);
            this.Controls.Add(this.txt_cantidpresenta1);
            this.Controls.Add(this.txt_PesoEmpaque);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_ContactoCliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_peso);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_fechaEntrega);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Direccion_cliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Cb_idventa);
            this.Controls.Add(this.txt_DatosaMostar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_atras);
            this.Controls.Add(this.btn_adelante);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtCantidadTotal);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DetallesEnvio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetallesEnvio";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btncerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_DatosaMostar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_atras;
        private System.Windows.Forms.Button btn_adelante;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtCantidadTotal;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private Bunifu.Framework.UI.BunifuFlatButton btnGuardar;
        private Bunifu.Framework.UI.BunifuFlatButton btnNuevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Cb_idventa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Direccion_cliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_fechaEntrega;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_peso;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_ContactoCliente;
        private System.Windows.Forms.TextBox txt_PesoEmpaque;
        private System.Windows.Forms.TextBox txt_cantidpresenta1;
        private System.Windows.Forms.TextBox txt_cantidpresenta2;
        private System.Windows.Forms.TextBox pesoIdpre1;
        private System.Windows.Forms.TextBox pesoIdpre2;
        private System.Windows.Forms.TextBox txt_idPresenta1;
        private System.Windows.Forms.TextBox txt_idPresenta2;
        private Bunifu.Framework.UI.BunifuImageButton btncerrar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_fechaRecepcion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Cb_idEnvio;
        private System.Windows.Forms.TextBox txt_capacidaUnidad;
        private System.Windows.Forms.TextBox txt_totalEnvioSum;
        private System.Windows.Forms.TextBox txt_EstatusEnvio;
        private System.Windows.Forms.TextBox txt_idventaEnvio;
        private Bunifu.Framework.UI.BunifuFlatButton btnEliminar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}