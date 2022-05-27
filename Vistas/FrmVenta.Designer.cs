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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVenta));
            this.pnlVentaRegistrar = new System.Windows.Forms.Panel();
            this.dgwVentaDetalles = new System.Windows.Forms.DataGridView();
            this.btnAgregarDetalle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cmbDNICliente = new System.Windows.Forms.ComboBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.mcRango = new System.Windows.Forms.MonthCalendar();
            this.dgwVentas = new System.Windows.Forms.DataGridView();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pnlBuscar = new System.Windows.Forms.Panel();
            this.pnlSortCliente = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbFiltrarCliente = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlVentaRegistrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwVentaDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.pnlBuscar.SuspendLayout();
            this.pnlSortCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlVentaRegistrar
            // 
            this.pnlVentaRegistrar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlVentaRegistrar.BackColor = System.Drawing.SystemColors.Info;
            this.pnlVentaRegistrar.Controls.Add(this.dgwVentaDetalles);
            this.pnlVentaRegistrar.Controls.Add(this.btnAgregarDetalle);
            this.pnlVentaRegistrar.Controls.Add(this.label2);
            this.pnlVentaRegistrar.Controls.Add(this.dtpFecha);
            this.pnlVentaRegistrar.Controls.Add(this.cmbDNICliente);
            this.pnlVentaRegistrar.Controls.Add(this.pictureBox6);
            this.pnlVentaRegistrar.Controls.Add(this.pictureBox2);
            this.pnlVentaRegistrar.Controls.Add(this.panel5);
            this.pnlVentaRegistrar.Controls.Add(this.label3);
            this.pnlVentaRegistrar.Controls.Add(this.label6);
            this.pnlVentaRegistrar.Controls.Add(this.label1);
            this.pnlVentaRegistrar.Controls.Add(this.btnRegistrarVenta);
            this.pnlVentaRegistrar.Location = new System.Drawing.Point(89, 207);
            this.pnlVentaRegistrar.Name = "pnlVentaRegistrar";
            this.pnlVentaRegistrar.Size = new System.Drawing.Size(859, 353);
            this.pnlVentaRegistrar.TabIndex = 11;
            // 
            // dgwVentaDetalles
            // 
            this.dgwVentaDetalles.AllowUserToAddRows = false;
            this.dgwVentaDetalles.AllowUserToResizeColumns = false;
            this.dgwVentaDetalles.AllowUserToResizeRows = false;
            this.dgwVentaDetalles.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dgwVentaDetalles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgwVentaDetalles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwVentaDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgwVentaDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwVentaDetalles.GridColor = System.Drawing.SystemColors.HighlightText;
            this.dgwVentaDetalles.Location = new System.Drawing.Point(432, 136);
            this.dgwVentaDetalles.Name = "dgwVentaDetalles";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwVentaDetalles.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgwVentaDetalles.Size = new System.Drawing.Size(413, 197);
            this.dgwVentaDetalles.TabIndex = 15;
            // 
            // btnAgregarDetalle
            // 
            this.btnAgregarDetalle.BackColor = System.Drawing.Color.Chocolate;
            this.btnAgregarDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarDetalle.Enabled = false;
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
            // cmbDNICliente
            // 
            this.cmbDNICliente.FormattingEnabled = true;
            this.cmbDNICliente.Location = new System.Drawing.Point(195, 136);
            this.cmbDNICliente.Name = "cmbDNICliente";
            this.cmbDNICliente.Size = new System.Drawing.Size(219, 21);
            this.cmbDNICliente.TabIndex = 10;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Vistas.Properties.Resources.iniciar_sesion;
            this.pictureBox6.Location = new System.Drawing.Point(16, 122);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(38, 38);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 7;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Vistas.Properties.Resources.iniciar_sesion;
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
            this.panel5.Location = new System.Drawing.Point(16, 212);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(13, 40);
            this.panel5.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(303, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Formulario Registrar Venta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(60, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "DNI Cliente";
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
            this.btnRegistrarVenta.Location = new System.Drawing.Point(16, 212);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(201, 40);
            this.btnRegistrarVenta.TabIndex = 9;
            this.btnRegistrarVenta.Text = "Registrar Venta";
            this.btnRegistrarVenta.UseVisualStyleBackColor = false;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // mcRango
            // 
            this.mcRango.Location = new System.Drawing.Point(652, 207);
            this.mcRango.MaxSelectionCount = 10000;
            this.mcRango.Name = "mcRango";
            this.mcRango.TabIndex = 21;
            this.mcRango.TitleBackColor = System.Drawing.Color.DarkSalmon;
            this.mcRango.Visible = false;
            this.mcRango.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcRango_DateSelected);
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgwVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwVentas.GridColor = System.Drawing.SystemColors.Info;
            this.dgwVentas.Location = new System.Drawing.Point(89, 207);
            this.dgwVentas.Name = "dgwVentas";
            this.dgwVentas.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Chocolate;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwVentas.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgwVentas.Size = new System.Drawing.Size(859, 353);
            this.dgwVentas.TabIndex = 11;
            this.dgwVentas.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwVentas_RowHeaderMouseClick);
            this.dgwVentas.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwVentas_RowHeaderMouseDoubleClick);
            this.dgwVentas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgwVentas_KeyDown);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(305, 44);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(450, 120);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 12;
            this.pictureBox5.TabStop = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(0, 0);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(219, 22);
            this.txtBuscar.TabIndex = 13;
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
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.Controls.Add(this.txtBuscar);
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Location = new System.Drawing.Point(89, 179);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(302, 22);
            this.pnlBuscar.TabIndex = 14;
            // 
            // pnlSortCliente
            // 
            this.pnlSortCliente.Controls.Add(this.button2);
            this.pnlSortCliente.Controls.Add(this.button1);
            this.pnlSortCliente.Controls.Add(this.btnFiltrar);
            this.pnlSortCliente.Controls.Add(this.label7);
            this.pnlSortCliente.Controls.Add(this.cmbFiltrarCliente);
            this.pnlSortCliente.Location = new System.Drawing.Point(457, 179);
            this.pnlSortCliente.Name = "pnlSortCliente";
            this.pnlSortCliente.Size = new System.Drawing.Size(491, 22);
            this.pnlSortCliente.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSalmon;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(194, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 22);
            this.button1.TabIndex = 23;
            this.button1.Text = "Rango Fechas";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.Chocolate;
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.Location = new System.Drawing.Point(336, 0);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(77, 22);
            this.btnFiltrar.TabIndex = 22;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Cliente:";
            // 
            // cmbFiltrarCliente
            // 
            this.cmbFiltrarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltrarCliente.FormattingEnabled = true;
            this.cmbFiltrarCliente.Location = new System.Drawing.Point(64, 2);
            this.cmbFiltrarCliente.Name = "cmbFiltrarCliente";
            this.cmbFiltrarCliente.Size = new System.Drawing.Size(124, 21);
            this.cmbFiltrarCliente.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Chocolate;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(419, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 22);
            this.button2.TabIndex = 24;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1064, 572);
            this.Controls.Add(this.mcRango);
            this.Controls.Add(this.pnlSortCliente);
            this.Controls.Add(this.pnlBuscar);
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
            this.pnlBuscar.ResumeLayout(false);
            this.pnlBuscar.PerformLayout();
            this.pnlSortCliente.ResumeLayout(false);
            this.pnlSortCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel pnlVentaRegistrar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegistrarVenta;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDNICliente;
        private System.Windows.Forms.DataGridView dgwVentas;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel pnlBuscar;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregarDetalle;
        private System.Windows.Forms.DataGridView dgwVentaDetalles;
        private System.Windows.Forms.Panel pnlSortCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbFiltrarCliente;
        private System.Windows.Forms.MonthCalendar mcRango;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}