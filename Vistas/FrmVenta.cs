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

        #endregion

        public FrmVenta()
        {
            InitializeComponent();
            this.Visible = false;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
        }
        


        #region Metodos Formulario
        private void load_combos()
        {
            DataTable dt = TrabajarCliente.list_clientes_resumen();
            //load combo para DNI de Detalles de venta
            cmbDNICliente.DisplayMember = "Abreviacion";
            cmbDNICliente.ValueMember = "DNI";
            cmbDNICliente.DataSource = dt;
            
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
            dt.Rows.Add("Filtrar por DNI o Fechas");

            cmbOptions.DisplayMember = "option";
            cmbOptions.ValueMember = "option";
            cmbOptions.DataSource = dt;
        }
        internal void load_detalles()
        {
            if(FrmVenta.nroCompraActual != -1)
                dgwVentaDetalles.DataSource = TrabajarVentaDetalle.list_venta_detalle(FrmVenta.nroCompraActual);
        }
        internal void clear_data_form()
        {
            FrmVenta.nroCompraActual = -1;
            btnAgregarDetalle.Enabled = false;
            dgwVentaDetalles.DataSource = null;
            txtBuscar.Text = "Buscar por Nro. Venta";
            dtpFecha.Value = DateTime.Now;
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
            frmVentaDetalle.Parent = this.Parent;
        }
        private void FrmVenta_VisibleChanged(object sender, EventArgs e)
        {
            load_detalles();
        }
        #endregion


        #region Events
        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmVentaDetalle.Visible = true;
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta();

            venta.Cli_DNI = cmbDNICliente.SelectedValue.ToString();
            venta.Ven_Fecha = dtpFecha.Value;
            venta.Ven_Nro = FrmVenta.nroCompraActual;

            string msg = this.action == "new" ? "Desea agregar la venta?" : "Confirme actualizacion";
            var mb = MessageBox.Show(
                msg, "Confirmacion", MessageBoxButtons.OKCancel);

            if (mb == DialogResult.OK)
            {
                if (this.action == "new")
                {
                    TrabajarVenta.insert_venta(venta);
                    FrmVenta.nroCompraActual = TrabajarVenta.get_current_index();
                    btnAgregarDetalle.Enabled = true;
                    load_ventas();
                    load_detalles();
                }
                else if (this.action == "edit")
                {
                    TrabajarVenta.update_venta(venta);
                    clear_data_form();
                    load_ventas();
                }
                
            }
        }
        
        private void dgwVentas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dgwVentas.Rows[e.RowIndex];

            cmbDNICliente.SelectedValue = row.Cells["DNI Cliente"].Value.ToString();
            dtpFecha.Value = (DateTime)row.Cells["Fecha"].Value;

            //set propiedades
            pnlBuscar.Visible = false;
            pnlFiltrarVenta.Visible = false;
            dgwVentas.Visible = false;
            FrmVenta.nroCompraActual = Convert.ToInt32(row.Cells["Nro. Venta"].Value);
            btnAgregarDetalle.Enabled = true;
            load_detalles();
            this.action = "edit";
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

        }
        
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            load_ventas();
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "Buscar por Nro. Venta")
                dgwVentas.DataSource = TrabajarVenta.search_ventas(Convert.ToInt32(txtBuscar.Text));
            else
                load_ventas();
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
        
        #endregion  

        

        



        
    }
}
