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

        private int indiceRowEliminar = -1;
        public int IndiceRowEliminar
        {
            set { this.indiceRowEliminar = value; }
            get { return this.indiceRowEliminar; }
        }
        #endregion

        public FrmVenta()
        {
            InitializeComponent();
            this.Visible = false;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.SendToBack();
        }
        


        #region Metodos Formulario
        private void load_cmb_cliente()
        {
            cmbDNICliente.DisplayMember = "DNI";
            cmbDNICliente.ValueMember = "DNI";
            cmbDNICliente.DataSource = TrabajarCliente.list_clientes();
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
        }
        private void load_ventas()
        {
            dgwVentas.DataSource = TrabajarVenta.list_ventas();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            load_cmb_cliente();
            load_detalles();
            load_ventas();
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

            var mb = MessageBox.Show(
                "Desea agregar la venta?", "Confirmacion", MessageBoxButtons.OKCancel);

            if (mb == DialogResult.OK)
            {
                TrabajarVenta.insert_venta(venta);
                FrmVenta.nroCompraActual = TrabajarVenta.get_current_index();
                btnAgregarDetalle.Enabled = true;
                load_ventas();
                load_detalles();
            }
        }
        private void dgwVentas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dgwVentas.Rows[e.RowIndex];

            cmbDNICliente.SelectedValue = row.Cells["DNI Cliente"].Value.ToString();
            dtpFecha.Value = (DateTime)row.Cells["Fecha"].Value;

            //set propiedades
            pnlBuscar.Visible = false;
            dgwVentas.Visible = false;
            FrmVenta.nroCompraActual = Convert.ToInt32(row.Cells["Nro."].Value);
            btnAgregarDetalle.Enabled = true;
            load_detalles();
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
        #endregion  



    }
}
