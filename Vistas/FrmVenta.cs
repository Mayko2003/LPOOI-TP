using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClasesBase;

namespace Vistas
{
    public partial class FrmVenta : Form
    {
        #region Atributos
        internal Cliente clienteSeleccionado;
        internal static DataTable dtVentaDetalle = new DataTable();
        private FrmVentaDetalle frmVentaDetalle = new FrmVentaDetalle();
        internal static int nroCompraActual = -1;
        private string action = "new";
        public string Action
        {
            set { this.action = value; }
            get { return this.action; }
        }

        private int indiceRowEliminar = -1;
        public int IndiceRowEliminar
        {
            set { this.indiceRowEliminar = value; }
            get { return this.indiceRowEliminar; }
        }

        private bool fechasSeleccionadas = false;

        internal int detalleRowIndex = -1;
        public int DetalleRowIndex
        {
            set { this.detalleRowIndex = value;}
            get { return this.detalleRowIndex; }
        }

        #endregion

        public FrmVenta()
        {
            InitializeComponent();
            this.Visible = false;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            //columnas para la tabla de detalles de venta
            if (!dtVentaDetalle.Columns.Contains("Codigo Producto")) dtVentaDetalle.Columns.Add("Codigo Producto");
            if (!dtVentaDetalle.Columns.Contains("Precio Unidad")) dtVentaDetalle.Columns.Add("Precio Unidad");
            if (!dtVentaDetalle.Columns.Contains("Cantidad")) dtVentaDetalle.Columns.Add("Cantidad");
            if (!dtVentaDetalle.Columns.Contains("Total")) dtVentaDetalle.Columns.Add("Total");
            if (!dtVentaDetalle.Columns.Contains("Det. Nro.")) dtVentaDetalle.Columns.Add("Det. Nro.");
        }
        


        #region Metodos Formulario
        private void load_combos()
        {
            DataTable dt = TrabajarCliente.list_clientes_resumen();
            
            //load combo para el DNI de filtrar venta
            cmbFiltrarCliente.DisplayMember = "Abreviacion";
            cmbFiltrarCliente.ValueMember = "DNI";
            cmbFiltrarCliente.DataSource = dt;

            //.......................................................
            //load combo clientes
            cmbFiltrarCliente.DisplayMember = "Abreviacion";
            cmbFiltrarCliente.ValueMember = "DNI";

            dt = new DataTable();
            dt.Columns.Add("Abreviacion");
            dt.Columns.Add("DNI");
            dt.Rows.Add("Todos", "%%");

            //asi la palabra para seleccionar a todos esta al principio
            dt.Merge(TrabajarCliente.list_clientes_resumen());

            cmbFiltrarCliente.DataSource = dt;

            //load combo opciones
            dt = new DataTable();

            //agregar columnas
            dt.Columns.Add("option");

            //agregar filas
            dt.Rows.Add("Buscar");
            dt.Rows.Add("Filtrar");

            cmbOptions.DisplayMember = "option";
            cmbOptions.ValueMember = "option";
            cmbOptions.DataSource = dt;
        }
        internal void load_detalles()
        {
            dgwVentaDetalles.DataSource = dtVentaDetalle;
            this.lblCantidadLineas.Text = "Cantidad de Productos: " + dtVentaDetalle.Rows.Count.ToString();
        }

        internal void clear_data_form()
        {
            FrmVenta.nroCompraActual = -1;
            dtVentaDetalle.Rows.Clear();
            dgwVentaDetalles.DataSource = dtVentaDetalle;
            txtBuscar.Text = "Buscar por Nro. Venta";
            dtpFecha.Value = DateTime.Now;
            txtCliente.Text = "--NO SELECCIONADO--";
            load_ventas();
        }
        private void load_ventas()
        {
            dgwVentas.DataSource = TrabajarVenta.list_ventas();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.SendToBack();
            this.load_combos();
            this.load_detalles();
            this.load_ventas();
            this.lblCantidad.Text = "Cantidad de Ventas: " + dgwVentas.Rows.Count.ToString();
            this.lblCantidadLineas.Text = "Cantidad de Productos: " + dgwVentaDetalles.Rows.Count.ToString();
            frmVentaDetalle.Parent = this.Parent;
        }
        private void FrmVenta_VisibleChanged(object sender, EventArgs e)
        {
            if (clienteSeleccionado != null) txtCliente.Text = clienteSeleccionado.Cli_DNI + ", " + clienteSeleccionado.Cli_Apellido + " " + clienteSeleccionado.Cli_Nombre;
            load_detalles();
        }

        private void guardarLineasVenta(){
            foreach (DataRow dr in dtVentaDetalle.Rows) {
                VentaDetalle vd = new VentaDetalle();
                try
                {
                    vd.Det_Nro = Convert.ToInt32(dr["Det. Nro."]);
                    vd.Ven_Nro = FrmVenta.nroCompraActual;
                    vd.Det_Cantidad = Convert.ToDecimal(dr["Cantidad"]);
                    vd.Prod_Codigo = dr["Codigo Producto"].ToString();
                    vd.Det_Total = Convert.ToDecimal(dr["Total"]);
                    vd.Det_Precio = Convert.ToDecimal(dr["Precio Unidad"]);

                    if (vd.Det_Nro == 0) TrabajarVentaDetalle.insert_venta_detalle(vd);
                    else TrabajarVentaDetalle.update_vd(vd);
                }
                catch (Exception e) { }
            }
        }

        private void actualizar_label_cantidad()
        {
            this.lblCantidad.Text = "Cantidad Ventas:" + this.dgwVentaDetalles.Rows.Count.ToString();
        }
        private void actualizar_label_cantidad_detalles()
        {
            this.lblCantidadLineas.Text = "Cantidad Detalles: " + this.dgwVentaDetalles.Rows.Count.ToString();
        }
        #endregion


        #region Events
        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmVentaDetalle.detalleRowIndex = -1;
            frmVentaDetalle.Visible = true;
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            //evaluar si se selecciono un cliente
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente por favor", "Error");
                return;
            }
            //crear venta
            Venta venta = new Venta();
            venta.Cli_DNI = clienteSeleccionado.Cli_DNI;
            venta.Ven_Fecha = dtpFecha.Value;
            venta.Ven_Nro = FrmVenta.nroCompraActual;

            //mensaje de confirmacion
            string msg = this.action == "edit" ? "Confirme actualizacion":"Desea agregar la venta?";
            var mb = MessageBox.Show(
                msg, "Confirmacion", MessageBoxButtons.OKCancel);
            
            if (mb == DialogResult.OK)
            {
                //si esta en modo editar, modificar la compra actual
                if (this.action == "edit")
                {
                    //actualizar venta
                    TrabajarVenta.update_venta(venta);
                }
                //sino guardar como nueva
                else
                {
                    //insertar venta
                    TrabajarVenta.insert_venta(venta);
                    FrmVenta.nroCompraActual = TrabajarVenta.get_current_index();
                }
                guardarLineasVenta();//insertar o actualizar cada linea de venta
                load_ventas();
                actualizar_label_cantidad();
                clear_data_form();
            }
        }
        
        private void dgwVentas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dgwVentas.Rows[e.RowIndex];

            //recuperamos el cliente
            DataTable dt = TrabajarCliente.seach_cliente_dni(row.Cells["DNI Cliente"].Value.ToString());

            //cargamos el cliente seleccionado
            this.clienteSeleccionado = new Cliente()
            {
                Cli_DNI=dt.Rows[0].ItemArray[0].ToString(),//DNI
                Cli_Apellido = dt.Rows[0].ItemArray[1].ToString(),//Apellido
                Cli_Nombre = dt.Rows[0].ItemArray[2].ToString(),//Nombre
                Cli_Direccion = dt.Rows[0].ItemArray[3].ToString(),//Direccion
                Os_CUIT = dt.Rows[0].ItemArray[4].ToString(),//OS CUIT
                Cli_NroCarnet = dt.Rows[0].ItemArray[5].ToString()//Nro Carnet
            };

            //cargamos el text box para mostrar la info del cliente que hizo la compra
            txtCliente.Text = clienteSeleccionado.Cli_DNI + ", " + clienteSeleccionado.Cli_Apellido + " " + clienteSeleccionado.Cli_Nombre;
            
            dtpFecha.Value = (DateTime)row.Cells["Fecha"].Value;

            //set propiedades
            dgwVentas.Visible = false;
            FrmVenta.nroCompraActual = Convert.ToInt32(row.Cells["Nro. Venta"].Value);
            dtVentaDetalle = TrabajarVentaDetalle.list_venta_detalle(FrmVenta.nroCompraActual);
            
            load_detalles(); // cargar detalles
            this.action = "edit"; // cambiar modo edicion
            lblCantidad.Visible = false; //ocultar cantidad de ventas
            lblCantidadLineas.Visible = true; // mostrar cantidad de productos

            this.lblCantidadLineas.Text = "Cantidad de Productos: " + dgwVentaDetalles.Rows.Count.ToString();
            lblTitulo.Text = "Formulario Actualizar Venta";
           
            pnlOptions.Visible = false;
            pnlVentaRegistrar.Visible = true;
        }
        
        private void dgwVentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.indiceRowEliminar != -1 && e.KeyCode == Keys.Delete)
            {
                var mb = MessageBox.Show("De verdad desea eliminar la venta seleccionada?", "Eliminar Venta", MessageBoxButtons.OKCancel);

                if (mb == DialogResult.OK)
                {
                    var cell = this.dgwVentas.Rows[this.indiceRowEliminar].Cells[0];
                    TrabajarVenta.delete_venta(cell.Value.ToString());
                    load_ventas();
                    actualizar_label_cantidad();
                }
            }
        }

        private void dgwVentas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.indiceRowEliminar = e.RowIndex;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string dni = cmbFiltrarCliente.SelectedValue.ToString();
            if (this.fechasSeleccionadas)
            {
                DateTime end = new DateTime(
                    dtpFin.Value.Year,
                    dtpFin.Value.Month,
                    dtpFin.Value.Day,
                    23, 59, 59);

                dgwVentas.DataSource = TrabajarVenta.filter_by_dni_date(dni, dtpInicio.Value, end);
            }
            else
            {
                dgwVentas.DataSource = TrabajarVenta.filter_by_dni_date(dni, new DateTime(1900, 1, 1), DateTime.Now);
            }
            actualizar_label_cantidad();
        }
        
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            load_ventas();
            actualizar_label_cantidad();
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "Buscar por Nro. Venta")
                dgwVentas.DataSource = TrabajarVenta.search_ventas(Convert.ToInt32(txtBuscar.Text));
            else
                load_ventas();
            actualizar_label_cantidad();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar)) e.Handled = false;
            else e.Handled = true;
        }
        
        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar por Nro. Venta")
                txtBuscar.Text = "";
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
                txtBuscar.Text = "Buscar por Nro. Venta";
        }

        private void cmbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbOptions.SelectedValue.ToString() == "Buscar")
            {
                pnlBuscar.Visible = true;
                pnlFiltrarVenta.Visible = false;
            }
            else
            {
                pnlBuscar.Visible = false;
                pnlFiltrarVenta.Visible = true;
            }
                
                
        }
        
        private void cbRangoFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpFin.Enabled = !dtpFin.Enabled;
            dtpInicio.Enabled = !dtpInicio.Enabled;
            this.fechasSeleccionadas = !this.fechasSeleccionadas;
        }

        private void btnSeleCliente_Click(object sender, EventArgs e)
        {
            ((FrmMain)this.ParentForm).btnMostrarClientes_Click("select", new EventArgs());
        }

        private void dgwVentaDetalles_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.detalleRowIndex = e.RowIndex;
        }

        private void dgwVentaDetalles_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VentaDetalle vdActual = new VentaDetalle();

            vdActual.Det_Nro = Convert.ToInt32(dgwVentaDetalles["Det. Nro.", e.RowIndex].Value);
            vdActual.Det_Cantidad = Convert.ToDecimal(dgwVentaDetalles["Cantidad", e.RowIndex].Value);
            vdActual.Det_Precio = Convert.ToDecimal(dgwVentaDetalles["Precio Unidad", e.RowIndex].Value);
            vdActual.Det_Total = Convert.ToDecimal(dgwVentaDetalles["Total", e.RowIndex].Value);
            vdActual.Prod_Codigo = dgwVentaDetalles["Codigo Producto", e.RowIndex].Value.ToString();

            frmVentaDetalle.vdActual = vdActual;
            frmVentaDetalle.detalleRowIndex = this.detalleRowIndex;


            this.Visible = false;
            frmVentaDetalle.Visible = true;
        }

        private void dgwVentaDetalles_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.detalleRowIndex != -1 && e.KeyCode == Keys.Delete)
            {
                var mb = MessageBox.Show("Confirme eliminacion", "Eliminar Detalle", MessageBoxButtons.OKCancel);

                if (mb == DialogResult.OK)
                {
                    int detNro = Convert.ToInt32(this.dgwVentaDetalles.Rows[this.detalleRowIndex].Cells[0].Value);
                    if (detNro == -1) dtVentaDetalle.Rows.RemoveAt(detalleRowIndex);
                    else TrabajarVentaDetalle.delete_vd(detNro);
                    load_detalles();
                    this.actualizar_label_cantidad_detalles();
                }
            }
        }
        #endregion

    }
}
