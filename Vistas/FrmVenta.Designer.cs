namespace Vistas
{
    partial class FrmVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVenta));
            this.pnlVentaRegistrar = new System.Windows.Forms.Panel();
            this.btnSeleCliente = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.dgwVentaDetalles = new System.Windows.Forms.DataGridView();
            this.btnAgregarDetalle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.dgwVentas = new System.Windows.Forms.DataGridView();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.cmbOptions = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pnlFiltrarVenta = new System.Windows.Forms.Panel();
            this.cbRangoFechas = new System.Windows.Forms.CheckBox();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFiltrarCliente = new System.Windows.Forms.ComboBox();
            this.pnlBuscar = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblCantidadLineas = new System.Windows.Forms.Label();
            this.pnlVentaRegistrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwVentaDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.pnlOptions.SuspendLayout();
            this.pnlFiltrarVenta.SuspendLayout();
            this.pnlBuscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlVentaRegistrar
            // 
            this.pnlVentaRegistrar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlVentaRegistrar.BackColor = System.Drawing.SystemColors.Info;
            this.pnlVentaRegistrar.Controls.Add(this.btnSeleCliente);
            this.pnlVentaRegistrar.Controls.Add(this.txtCliente);
            this.pnlVentaRegistrar.Controls.Add(this.dgwVentaDetalles);
            this.pnlVentaRegistrar.Controls.Add(this.btnAgregarDetalle);
            this.pnlVentaRegistrar.Controls.Add(this.label2);
            this.pnlVentaRegistrar.Controls.Add(this.dtpFecha);
            this.pnlVentaRegistrar.Controls.Add(this.pictureBox6);
            this.pnlVentaRegistrar.Controls.Add(this.pictureBox2);
            this.pnlVentaRegistrar.Controls.Add(this.panel5);
            this.pnlVentaRegistrar.Controls.Add(this.lblTitulo);
            this.pnlVentaRegistrar.Controls.Add(this.label6);
            this.pnlVentaRegistrar.Controls.Add(this.label1);
            this.pnlVentaRegistrar.Controls.Add(this.btnRegistrarVenta);
            this.pnlVentaRegistrar.Location = new System.Drawing.Point(111, 207);
            this.pnlVentaRegistrar.Name = "pnlVentaRegistrar";
            this.pnlVentaRegistrar.Size = new System.Drawing.Size(859, 353);
            this.pnlVentaRegistrar.TabIndex = 11;
            // 
            // btnSeleCliente
            // 
            this.btnSeleCliente.BackColor = System.Drawing.Color.Chocolate;
            this.btnSeleCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleCliente.FlatAppearance.BorderSize = 0;
            this.btnSeleCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.btnSeleCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleCliente.Location = new System.Drawing.Point(16, 177);
            this.btnSeleCliente.Name = "btnSeleCliente";
            this.btnSeleCliente.Size = new System.Drawing.Size(169, 29);
            this.btnSeleCliente.TabIndex = 17;
            this.btnSeleCliente.Text = "Seleccionar Cliente";
            this.btnSeleCliente.UseVisualStyleBackColor = false;
            this.btnSeleCliente.Click += new System.EventHandler(this.btnSeleCliente_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(191, 133);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(223, 20);
            this.txtCliente.TabIndex = 16;
            this.txtCliente.Text = "--NO SELECCIONADO--";
            // 
            // dgwVentaDetalles
            // 
            this.dgwVentaDetalles.AllowUserToAddRows = false;
            this.dgwVentaDetalles.AllowUserToResizeColumns = false;
            this.dgwVentaDetalles.AllowUserToResizeRows = false;
            this.dgwVentaDetalles.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dgwVentaDetalles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgwVentaDetalles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwVentaDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwVentaDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwVentaDetalles.GridColor = System.Drawing.SystemColors.HighlightText;
            this.dgwVentaDetalles.Location = new System.Drawing.Point(432, 136);
            this.dgwVentaDetalles.Name = "dgwVentaDetalles";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwVentaDetalles.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgwVentaDetalles.Size = new System.Drawing.Size(413, 197);
            this.dgwVentaDetalles.TabIndex = 15;
            this.dgwVentaDetalles.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwVentaDetalles_RowHeaderMouseClick);
            this.dgwVentaDetalles.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwVentaDetalles_RowHeaderMouseDoubleClick);
            this.dgwVentaDetalles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgwVentaDetalles_KeyDown);
            // 
            // btnAgregarDetalle
            // 
            this.btnAgregarDetalle.BackColor = System.Drawing.Color.Chocolate;
            this.btnAgregarDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarDetalle.FlatAppearance.BorderSize = 0;
            this.btnAgregarDetalle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.btnAgregarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarDetalle.Location = new System.Drawing.Point(717, 101);
            this.btnAgregarDetalle.Name = "btnAgregarDetalle";
            this.btnAgregarDetalle.Size = new System.Drawing.Size(128, 29);
            this.btnAgregarDetalle.TabIndex = 14;
            this.btnAgregarDetalle.Text = "Agregar Producto";
            this.btnAgregarDetalle.UseVisualStyleBackColor = false;
            this.btnAgregarDetalle.Click += new System.EventHandler(this.btnAgregarDetalle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(567, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Detalles Venta";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(195, 73);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(219, 20);
            this.dtpFecha.TabIndex = 11;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Vistas.Properties.Resources.dni;
            this.pictureBox6.Location = new System.Drawing.Point(16, 122);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(38, 38);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 7;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Vistas.Properties.Resources.date;
            this.pictureBox2.Location = new System.Drawing.Point(16, 61);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Chocolate;
            this.panel5.Location = new System.Drawing.Point(16, 293);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(13, 40);
            this.panel5.TabIndex = 6;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(303, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(260, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Formulario Registrar Venta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(60, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha";
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.BackColor = System.Drawing.SystemColors.Info;
            this.btnRegistrarVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarVenta.FlatAppearance.BorderSize = 0;
            this.btnRegistrarVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.btnRegistrarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarVenta.Location = new System.Drawing.Point(16, 293);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(201, 40);
            this.btnRegistrarVenta.TabIndex = 9;
            this.btnRegistrarVenta.Text = "Registrar Venta";
            this.btnRegistrarVenta.UseVisualStyleBackColor = false;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // dgwVentas
            // 
            this.dgwVentas.AllowUserToAddRows = false;
            this.dgwVentas.AllowUserToDeleteRows = false;
            this.dgwVentas.AllowUserToOrderColumns = true;
            this.dgwVentas.AllowUserToResizeRows = false;
            this.dgwVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwVentas.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgwVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgwVentas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgwVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwVentas.GridColor = System.Drawing.SystemColors.Info;
            this.dgwVentas.Location = new System.Drawing.Point(111, 207);
            this.dgwVentas.Name = "dgwVentas";
            this.dgwVentas.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwVentas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwVentas.Size = new System.Drawing.Size(859, 353);
            this.dgwVentas.TabIndex = 11;
            this.dgwVentas.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwVentas_RowHeaderMouseClick);
            this.dgwVentas.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwVentas_RowHeaderMouseDoubleClick);
            this.dgwVentas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgwVentas_KeyDown);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(307, 44);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(450, 120);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 12;
            this.pictureBox5.TabStop = false;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.cmbOptions);
            this.pnlOptions.Controls.Add(this.btnLimpiar);
            this.pnlOptions.Controls.Add(this.pnlFiltrarVenta);
            this.pnlOptions.Controls.Add(this.pnlBuscar);
            this.pnlOptions.Location = new System.Drawing.Point(111, 170);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(859, 31);
            this.pnlOptions.TabIndex = 28;
            // 
            // cmbOptions
            // 
            this.cmbOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbOptions.FormattingEnabled = true;
            this.cmbOptions.Location = new System.Drawing.Point(0, 3);
            this.cmbOptions.Name = "cmbOptions";
            this.cmbOptions.Size = new System.Drawing.Size(121, 21);
            this.cmbOptions.TabIndex = 23;
            this.cmbOptions.SelectedIndexChanged += new System.EventHandler(this.cmbOptions_SelectedIndexChanged);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Chocolate;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(782, 5);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(77, 22);
            this.btnLimpiar.TabIndex = 24;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // pnlFiltrarVenta
            // 
            this.pnlFiltrarVenta.Controls.Add(this.cbRangoFechas);
            this.pnlFiltrarVenta.Controls.Add(this.dtpFin);
            this.pnlFiltrarVenta.Controls.Add(this.label10);
            this.pnlFiltrarVenta.Controls.Add(this.dtpInicio);
            this.pnlFiltrarVenta.Controls.Add(this.label8);
            this.pnlFiltrarVenta.Controls.Add(this.btnFiltrar);
            this.pnlFiltrarVenta.Controls.Add(this.label4);
            this.pnlFiltrarVenta.Controls.Add(this.cmbFiltrarCliente);
            this.pnlFiltrarVenta.Location = new System.Drawing.Point(127, 2);
            this.pnlFiltrarVenta.Name = "pnlFiltrarVenta";
            this.pnlFiltrarVenta.Size = new System.Drawing.Size(656, 29);
            this.pnlFiltrarVenta.TabIndex = 21;
            this.pnlFiltrarVenta.Visible = false;
            // 
            // cbRangoFechas
            // 
            this.cbRangoFechas.AutoSize = true;
            this.cbRangoFechas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRangoFechas.Location = new System.Drawing.Point(184, 10);
            this.cbRangoFechas.Name = "cbRangoFechas";
            this.cbRangoFechas.Size = new System.Drawing.Size(12, 11);
            this.cbRangoFechas.TabIndex = 29;
            this.cbRangoFechas.UseVisualStyleBackColor = true;
            this.cbRangoFechas.CheckedChanged += new System.EventHandler(this.cbRangoFechas_CheckedChanged);
            // 
            // dtpFin
            // 
            this.dtpFin.CalendarTitleBackColor = System.Drawing.Color.LightSalmon;
            this.dtpFin.Enabled = false;
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(465, 4);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(101, 20);
            this.dtpFin.TabIndex = 28;
            this.dtpFin.Value = new System.DateTime(2022, 6, 6, 0, 0, 0, 0);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.Location = new System.Drawing.Point(393, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 17);
            this.label10.TabIndex = 25;
            this.label10.Text = "Fecha Fin:";
            // 
            // dtpInicio
            // 
            this.dtpInicio.CalendarTitleBackColor = System.Drawing.Color.LightSalmon;
            this.dtpInicio.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dtpInicio.Enabled = false;
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(286, 3);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(101, 20);
            this.dtpInicio.TabIndex = 24;
            this.dtpInicio.Tag = "";
            this.dtpInicio.Value = new System.DateTime(2022, 6, 6, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(202, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Fecha Inicio:";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.Chocolate;
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.Location = new System.Drawing.Point(572, 3);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(77, 22);
            this.btnFiltrar.TabIndex = 22;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Cliente:";
            // 
            // cmbFiltrarCliente
            // 
            this.cmbFiltrarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltrarCliente.FormattingEnabled = true;
            this.cmbFiltrarCliente.Location = new System.Drawing.Point(64, 2);
            this.cmbFiltrarCliente.Name = "cmbFiltrarCliente";
            this.cmbFiltrarCliente.Size = new System.Drawing.Size(107, 21);
            this.cmbFiltrarCliente.TabIndex = 16;
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.Controls.Add(this.txtBuscar);
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Location = new System.Drawing.Point(127, 2);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(302, 29);
            this.pnlBuscar.TabIndex = 25;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.SystemColors.Window;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(0, 0);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(219, 22);
            this.txtBuscar.TabIndex = 13;
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Chocolate;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(225, 0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(77, 22);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(853, 573);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(103, 13);
            this.lblCantidad.TabIndex = 29;
            this.lblCantidad.Text = "Cantidad de Ventas:";
            // 
            // lblCantidadLineas
            // 
            this.lblCantidadLineas.AutoSize = true;
            this.lblCantidadLineas.BackColor = System.Drawing.SystemColors.Info;
            this.lblCantidadLineas.Location = new System.Drawing.Point(825, 542);
            this.lblCantidadLineas.Name = "lblCantidadLineas";
            this.lblCantidadLineas.Size = new System.Drawing.Size(118, 13);
            this.lblCantidadLineas.TabIndex = 16;
            this.lblCantidadLineas.Text = "Cantidad de Productos:";
            // 
            // FrmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1080, 610);
            this.Controls.Add(this.lblCantidadLineas);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pnlVentaRegistrar);
            this.Controls.Add(this.dgwVentas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVenta";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "FrmCliente";
            this.Load += new System.EventHandler(this.FrmVenta_Load);
            this.VisibleChanged += new System.EventHandler(this.FrmVenta_VisibleChanged);
            this.pnlVentaRegistrar.ResumeLayout(false);
            this.pnlVentaRegistrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwVentaDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.pnlOptions.ResumeLayout(false);
            this.pnlFiltrarVenta.ResumeLayout(false);
            this.pnlFiltrarVenta.PerformLayout();
            this.pnlBuscar.ResumeLayout(false);
            this.pnlBuscar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel pnlVentaRegistrar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegistrarVenta;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgwVentas;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregarDetalle;
        private System.Windows.Forms.DataGridView dgwVentaDetalles;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.ComboBox cmbOptions;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Panel pnlFiltrarVenta;
        private System.Windows.Forms.CheckBox cbRangoFechas;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFiltrarCliente;
        private System.Windows.Forms.Panel pnlBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblCantidadLineas;
        private System.Windows.Forms.Button btnSeleCliente;
        private System.Windows.Forms.TextBox txtCliente;
    }
}