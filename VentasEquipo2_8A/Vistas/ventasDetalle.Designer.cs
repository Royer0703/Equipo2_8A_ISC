
namespace Vistas
{
    partial class ventasDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventasDetalle));
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
            this.btnEditar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnEliminar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnNuevo = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_precioVenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_subTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Cb_Estatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Cb_idVenta = new System.Windows.Forms.ComboBox();
            this.txt_idPresentacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_idventaDetalle = new System.Windows.Forms.TextBox();
            this.Cb_idPresentacion = new System.Windows.Forms.ComboBox();
            this.txt_fechaVenta = new System.Windows.Forms.TextBox();
            this.txt_cantPagadaVenta = new System.Windows.Forms.TextBox();
            this.txt_ivaVenta = new System.Windows.Forms.TextBox();
            this.txt_totalVenta = new System.Windows.Forms.TextBox();
            this.txt_comentarisVenta = new System.Windows.Forms.TextBox();
            this.txt_clienteVenta = new System.Windows.Forms.TextBox();
            this.txt_sucursalVenta = new System.Windows.Forms.TextBox();
            this.txt_empleadoVenta = new System.Windows.Forms.TextBox();
            this.txt_tipoVenta = new System.Windows.Forms.TextBox();
            this.txt_estatusVenta = new System.Windows.Forms.TextBox();
            this.btncerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.txt_subTotalVenta = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btncerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_DatosaMostar
            // 
            this.txt_DatosaMostar.Location = new System.Drawing.Point(130, 475);
            this.txt_DatosaMostar.Name = "txt_DatosaMostar";
            this.txt_DatosaMostar.Size = new System.Drawing.Size(57, 20);
            this.txt_DatosaMostar.TabIndex = 62;
            this.txt_DatosaMostar.TextChanged += new System.EventHandler(this.txt_DatosaMostar_TextChanged);
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
            this.label11.TabIndex = 61;
            this.label11.Text = "Datos a Mostar:";
            // 
            // btn_atras
            // 
            this.btn_atras.Enabled = false;
            this.btn_atras.Location = new System.Drawing.Point(424, 473);
            this.btn_atras.Name = "btn_atras";
            this.btn_atras.Size = new System.Drawing.Size(75, 23);
            this.btn_atras.TabIndex = 60;
            this.btn_atras.Text = "<<<";
            this.btn_atras.UseVisualStyleBackColor = true;
            this.btn_atras.Click += new System.EventHandler(this.btn_atras_Click);
            // 
            // btn_adelante
            // 
            this.btn_adelante.Location = new System.Drawing.Point(267, 473);
            this.btn_adelante.Name = "btn_adelante";
            this.btn_adelante.Size = new System.Drawing.Size(75, 23);
            this.btn_adelante.TabIndex = 59;
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
            this.label9.TabIndex = 58;
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
            this.label8.TabIndex = 57;
            this.label8.Text = "Total de Datos:";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(838, 475);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(47, 20);
            this.textBox3.TabIndex = 56;
            // 
            // txtCantidadTotal
            // 
            this.txtCantidadTotal.Enabled = false;
            this.txtCantidadTotal.Location = new System.Drawing.Point(645, 477);
            this.txtCantidadTotal.Name = "txtCantidadTotal";
            this.txtCantidadTotal.Size = new System.Drawing.Size(50, 20);
            this.txtCantidadTotal.TabIndex = 55;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "SalesVentaDetalle.idVentaDetalle",
            "SalesVentaDetalle.precioVenta",
            "SalesVentaDetalle.cantidad",
            "SalesVentaDetalle.subtotal",
            "SalesVentaDetalle.idVenta",
            "SalesVentaDetalle.idPresentacion",
            "PresentacionesProducto.idEmpaque",
            "Empaques.nombre",
            "SalesVentaDetalle.estatus",
            "SalesVentas.idVenta",
            "SalesVentas.idCliente",
            "SalesClientes.nombre"});
            this.comboBox1.Location = new System.Drawing.Point(310, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(249, 21);
            this.comboBox1.TabIndex = 54;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(38, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 20);
            this.label10.TabIndex = 53;
            this.label10.Text = "Buscar";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(265, 20);
            this.textBox1.TabIndex = 52;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.BorderRadius = 3;
            this.btnGuardar.ButtonText = "GUARDAR";
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
            this.btnGuardar.TabIndex = 51;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Textcolor = System.Drawing.Color.White;
            this.btnGuardar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnGuardar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnGuardar_MouseClick);
            this.btnGuardar.MouseHover += new System.EventHandler(this.btnGuardar_MouseHover);
            // 
            // btnEditar
            // 
            this.btnEditar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.BorderRadius = 3;
            this.btnEditar.ButtonText = "EDITAR";
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.DisabledColor = System.Drawing.Color.Gray;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEditar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnEditar.Iconimage")));
            this.btnEditar.Iconimage_right = null;
            this.btnEditar.Iconimage_right_Selected = null;
            this.btnEditar.Iconimage_Selected = null;
            this.btnEditar.IconMarginLeft = 0;
            this.btnEditar.IconMarginRight = 0;
            this.btnEditar.IconRightVisible = true;
            this.btnEditar.IconRightZoom = 0D;
            this.btnEditar.IconVisible = true;
            this.btnEditar.IconZoom = 50D;
            this.btnEditar.IsTab = false;
            this.btnEditar.Location = new System.Drawing.Point(238, 511);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnEditar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnEditar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEditar.selected = false;
            this.btnEditar.Size = new System.Drawing.Size(188, 40);
            this.btnEditar.TabIndex = 50;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.Textcolor = System.Drawing.Color.White;
            this.btnEditar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.BorderRadius = 3;
            this.btnEliminar.ButtonText = "ELIMINAR";
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
            this.btnEliminar.Location = new System.Drawing.Point(460, 511);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnEliminar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnEliminar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEliminar.selected = false;
            this.btnEliminar.Size = new System.Drawing.Size(188, 40);
            this.btnEliminar.TabIndex = 49;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.Textcolor = System.Drawing.Color.White;
            this.btnEliminar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevo.BorderRadius = 3;
            this.btnNuevo.ButtonText = "NUEVO";
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
            this.btnNuevo.Location = new System.Drawing.Point(680, 511);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnNuevo.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.btnNuevo.OnHoverTextColor = System.Drawing.Color.White;
            this.btnNuevo.selected = false;
            this.btnNuevo.Size = new System.Drawing.Size(188, 40);
            this.btnNuevo.TabIndex = 48;
            this.btnNuevo.Text = "NUEVO";
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
            this.label1.Size = new System.Drawing.Size(195, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "Listado De Ventas Detalle";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(869, 379);
            this.dataGridView1.TabIndex = 46;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(908, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 63;
            this.label2.Text = "Venta";
            // 
            // txt_precioVenta
            // 
            this.txt_precioVenta.Enabled = false;
            this.txt_precioVenta.Location = new System.Drawing.Point(904, 353);
            this.txt_precioVenta.Name = "txt_precioVenta";
            this.txt_precioVenta.Size = new System.Drawing.Size(115, 20);
            this.txt_precioVenta.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(904, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "Precio de Venta";
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(908, 234);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(115, 20);
            this.txt_cantidad.TabIndex = 68;
            this.txt_cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cantidad_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(908, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 67;
            this.label4.Text = "Cantidad";
            // 
            // txt_subTotal
            // 
            this.txt_subTotal.Enabled = false;
            this.txt_subTotal.Location = new System.Drawing.Point(904, 402);
            this.txt_subTotal.Name = "txt_subTotal";
            this.txt_subTotal.Size = new System.Drawing.Size(115, 20);
            this.txt_subTotal.TabIndex = 70;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(904, 379);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 69;
            this.label5.Text = "subtotal";
            // 
            // Cb_Estatus
            // 
            this.Cb_Estatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_Estatus.FormattingEnabled = true;
            this.Cb_Estatus.Items.AddRange(new object[] {
            "A"});
            this.Cb_Estatus.Location = new System.Drawing.Point(904, 464);
            this.Cb_Estatus.Name = "Cb_Estatus";
            this.Cb_Estatus.Size = new System.Drawing.Size(116, 21);
            this.Cb_Estatus.TabIndex = 72;
            this.Cb_Estatus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Cb_Estatus_MouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(904, 441);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 71;
            this.label7.Text = "Estatus";
            // 
            // Cb_idVenta
            // 
            this.Cb_idVenta.FormattingEnabled = true;
            this.Cb_idVenta.Location = new System.Drawing.Point(908, 114);
            this.Cb_idVenta.Name = "Cb_idVenta";
            this.Cb_idVenta.Size = new System.Drawing.Size(116, 21);
            this.Cb_idVenta.TabIndex = 73;
            this.Cb_idVenta.SelectedIndexChanged += new System.EventHandler(this.Cb_idVenta_SelectedIndexChanged);
            this.Cb_idVenta.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Cb_idVenta_MouseClick);
            // 
            // txt_idPresentacion
            // 
            this.txt_idPresentacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_idPresentacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_idPresentacion.Enabled = false;
            this.txt_idPresentacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_idPresentacion.Location = new System.Drawing.Point(1061, 289);
            this.txt_idPresentacion.Name = "txt_idPresentacion";
            this.txt_idPresentacion.Size = new System.Drawing.Size(28, 13);
            this.txt_idPresentacion.TabIndex = 75;
            this.txt_idPresentacion.TextChanged += new System.EventHandler(this.txt_Presentacion_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(904, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 20);
            this.label6.TabIndex = 74;
            this.label6.Text = "Presentacion";
            // 
            // txt_idventaDetalle
            // 
            this.txt_idventaDetalle.BackColor = System.Drawing.SystemColors.Control;
            this.txt_idventaDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_idventaDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_idventaDetalle.Location = new System.Drawing.Point(908, 68);
            this.txt_idventaDetalle.Name = "txt_idventaDetalle";
            this.txt_idventaDetalle.Size = new System.Drawing.Size(100, 13);
            this.txt_idventaDetalle.TabIndex = 76;
            // 
            // Cb_idPresentacion
            // 
            this.Cb_idPresentacion.FormattingEnabled = true;
            this.Cb_idPresentacion.Location = new System.Drawing.Point(904, 288);
            this.Cb_idPresentacion.Name = "Cb_idPresentacion";
            this.Cb_idPresentacion.Size = new System.Drawing.Size(140, 21);
            this.Cb_idPresentacion.TabIndex = 79;
            this.Cb_idPresentacion.SelectedIndexChanged += new System.EventHandler(this.Cb_idPresentacion_SelectedIndexChanged);
            // 
            // txt_fechaVenta
            // 
            this.txt_fechaVenta.BackColor = System.Drawing.SystemColors.Control;
            this.txt_fechaVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_fechaVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_fechaVenta.Location = new System.Drawing.Point(140, 12);
            this.txt_fechaVenta.Name = "txt_fechaVenta";
            this.txt_fechaVenta.Size = new System.Drawing.Size(100, 13);
            this.txt_fechaVenta.TabIndex = 80;
            // 
            // txt_cantPagadaVenta
            // 
            this.txt_cantPagadaVenta.BackColor = System.Drawing.SystemColors.Control;
            this.txt_cantPagadaVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_cantPagadaVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_cantPagadaVenta.Location = new System.Drawing.Point(267, 12);
            this.txt_cantPagadaVenta.Name = "txt_cantPagadaVenta";
            this.txt_cantPagadaVenta.Size = new System.Drawing.Size(100, 13);
            this.txt_cantPagadaVenta.TabIndex = 81;
            // 
            // txt_ivaVenta
            // 
            this.txt_ivaVenta.BackColor = System.Drawing.SystemColors.Control;
            this.txt_ivaVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ivaVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_ivaVenta.Location = new System.Drawing.Point(460, 12);
            this.txt_ivaVenta.Name = "txt_ivaVenta";
            this.txt_ivaVenta.Size = new System.Drawing.Size(66, 13);
            this.txt_ivaVenta.TabIndex = 82;
            // 
            // txt_totalVenta
            // 
            this.txt_totalVenta.BackColor = System.Drawing.SystemColors.Control;
            this.txt_totalVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_totalVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_totalVenta.Location = new System.Drawing.Point(538, 12);
            this.txt_totalVenta.Name = "txt_totalVenta";
            this.txt_totalVenta.Size = new System.Drawing.Size(66, 13);
            this.txt_totalVenta.TabIndex = 83;
            // 
            // txt_comentarisVenta
            // 
            this.txt_comentarisVenta.BackColor = System.Drawing.SystemColors.Control;
            this.txt_comentarisVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_comentarisVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_comentarisVenta.Location = new System.Drawing.Point(610, 12);
            this.txt_comentarisVenta.Name = "txt_comentarisVenta";
            this.txt_comentarisVenta.Size = new System.Drawing.Size(66, 13);
            this.txt_comentarisVenta.TabIndex = 84;
            // 
            // txt_clienteVenta
            // 
            this.txt_clienteVenta.Enabled = false;
            this.txt_clienteVenta.Location = new System.Drawing.Point(908, 173);
            this.txt_clienteVenta.Name = "txt_clienteVenta";
            this.txt_clienteVenta.Size = new System.Drawing.Size(181, 20);
            this.txt_clienteVenta.TabIndex = 85;
            // 
            // txt_sucursalVenta
            // 
            this.txt_sucursalVenta.BackColor = System.Drawing.SystemColors.Control;
            this.txt_sucursalVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_sucursalVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_sucursalVenta.Location = new System.Drawing.Point(766, 12);
            this.txt_sucursalVenta.Name = "txt_sucursalVenta";
            this.txt_sucursalVenta.Size = new System.Drawing.Size(66, 13);
            this.txt_sucursalVenta.TabIndex = 86;
            // 
            // txt_empleadoVenta
            // 
            this.txt_empleadoVenta.BackColor = System.Drawing.SystemColors.Control;
            this.txt_empleadoVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_empleadoVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_empleadoVenta.Location = new System.Drawing.Point(838, 12);
            this.txt_empleadoVenta.Name = "txt_empleadoVenta";
            this.txt_empleadoVenta.Size = new System.Drawing.Size(66, 13);
            this.txt_empleadoVenta.TabIndex = 87;
            // 
            // txt_tipoVenta
            // 
            this.txt_tipoVenta.BackColor = System.Drawing.SystemColors.Control;
            this.txt_tipoVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_tipoVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_tipoVenta.Location = new System.Drawing.Point(910, 12);
            this.txt_tipoVenta.Name = "txt_tipoVenta";
            this.txt_tipoVenta.Size = new System.Drawing.Size(66, 13);
            this.txt_tipoVenta.TabIndex = 88;
            // 
            // txt_estatusVenta
            // 
            this.txt_estatusVenta.BackColor = System.Drawing.SystemColors.Control;
            this.txt_estatusVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_estatusVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_estatusVenta.Location = new System.Drawing.Point(686, 12);
            this.txt_estatusVenta.Name = "txt_estatusVenta";
            this.txt_estatusVenta.Size = new System.Drawing.Size(66, 13);
            this.txt_estatusVenta.TabIndex = 89;
            // 
            // btncerrar
            // 
            this.btncerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncerrar.BackColor = System.Drawing.Color.Transparent;
            this.btncerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncerrar.Image = ((System.Drawing.Image)(resources.GetObject("btncerrar.Image")));
            this.btncerrar.ImageActive = null;
            this.btncerrar.Location = new System.Drawing.Point(2, 10);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(30, 30);
            this.btncerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btncerrar.TabIndex = 100;
            this.btncerrar.TabStop = false;
            this.btncerrar.Zoom = 10;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // txt_subTotalVenta
            // 
            this.txt_subTotalVenta.BackColor = System.Drawing.SystemColors.Control;
            this.txt_subTotalVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_subTotalVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.txt_subTotalVenta.Location = new System.Drawing.Point(388, 12);
            this.txt_subTotalVenta.Name = "txt_subTotalVenta";
            this.txt_subTotalVenta.Size = new System.Drawing.Size(66, 13);
            this.txt_subTotalVenta.TabIndex = 101;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(908, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 20);
            this.label12.TabIndex = 102;
            this.label12.Text = "Cliente";
            // 
            // ventasDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_subTotalVenta);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.txt_estatusVenta);
            this.Controls.Add(this.txt_tipoVenta);
            this.Controls.Add(this.txt_empleadoVenta);
            this.Controls.Add(this.txt_sucursalVenta);
            this.Controls.Add(this.txt_clienteVenta);
            this.Controls.Add(this.txt_comentarisVenta);
            this.Controls.Add(this.txt_totalVenta);
            this.Controls.Add(this.txt_ivaVenta);
            this.Controls.Add(this.txt_cantPagadaVenta);
            this.Controls.Add(this.txt_fechaVenta);
            this.Controls.Add(this.Cb_idPresentacion);
            this.Controls.Add(this.txt_idventaDetalle);
            this.Controls.Add(this.txt_idPresentacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Cb_idVenta);
            this.Controls.Add(this.Cb_Estatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_subTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_cantidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_precioVenta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
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
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ventasDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ventasDetalle";
            this.Load += new System.EventHandler(this.ventasDetalle_Load);
            this.Leave += new System.EventHandler(this.ventasDetalle_Leave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ventasDetalle_MouseMove);
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
        private Bunifu.Framework.UI.BunifuFlatButton btnEditar;
        private Bunifu.Framework.UI.BunifuFlatButton btnEliminar;
        private Bunifu.Framework.UI.BunifuFlatButton btnNuevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_precioVenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_subTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Cb_Estatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Cb_idVenta;
        private System.Windows.Forms.TextBox txt_idPresentacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_idventaDetalle;
        private System.Windows.Forms.ComboBox Cb_idPresentacion;
        private System.Windows.Forms.TextBox txt_fechaVenta;
        private System.Windows.Forms.TextBox txt_cantPagadaVenta;
        private System.Windows.Forms.TextBox txt_ivaVenta;
        private System.Windows.Forms.TextBox txt_totalVenta;
        private System.Windows.Forms.TextBox txt_comentarisVenta;
        private System.Windows.Forms.TextBox txt_clienteVenta;
        private System.Windows.Forms.TextBox txt_sucursalVenta;
        private System.Windows.Forms.TextBox txt_empleadoVenta;
        private System.Windows.Forms.TextBox txt_tipoVenta;
        private System.Windows.Forms.TextBox txt_estatusVenta;
        private Bunifu.Framework.UI.BunifuImageButton btncerrar;
        private System.Windows.Forms.TextBox txt_subTotalVenta;
        private System.Windows.Forms.Label label12;
    }
}