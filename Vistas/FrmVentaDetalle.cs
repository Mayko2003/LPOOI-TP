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
    public partial class FrmVentaDetalle : Form
    {
        public FrmVentaDetalle()
        {
            InitializeComponent();
            this.Visible = false;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.SendToBack();
        }
        private void FrmCliente_Load(object sender, EventArgs e)
        {
            load_combo_productos();
        }


        #region Metodos Formulario
        private void load_combo_productos()
        {
            cmbProductos.DisplayMember = "Abreviacion";
            cmbProductos.ValueMember = "Codigo";
            cmbProductos.DataSource = TrabajarProducto.list_productos_resumen();

        }
        internal void clear_data_form()
        {
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtTotal.Text = "";
        }
        #endregion

        #region Events
        private void cmbProductos_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)cmbProductos.DataSource;
            int index = cmbProductos.SelectedIndex;
            if (index > -1) txtPrecio.Text = dt.Rows[index]["Precio"].ToString();
        }
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                decimal cantidad = Convert.ToInt32(this.txtCantidad.Text);
                decimal precioActual = Convert.ToDecimal(txtPrecio.Text);

                this.txtTotal.Text = (cantidad * precioActual).ToString();
            }
        }
        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            VentaDetalle vd = new VentaDetalle();

            vd.Det_Cantidad = Convert.ToDecimal(txtCantidad.Text);
            vd.Det_Precio = Convert.ToDecimal(txtPrecio.Text);
            vd.Det_Total = Convert.ToDecimal(txtTotal.Text);
            vd.Prod_Codigo = cmbProductos.SelectedValue.ToString();
            vd.Ven_Nro = FrmVenta.nroCompraActual;

            var mb = MessageBox.Show(
                "Codigo de producto: " + vd.Prod_Codigo +
                "\nCantidad: " + vd.Det_Cantidad +
                "\nTotal: " + vd.Det_Total, "Confirmacion", MessageBoxButtons.OKCancel);

            if (mb == DialogResult.OK)
            {
                TrabajarVentaDetalle.insert_venta_detalle(vd);
                clear_data_form();
                this.Visible = false;
                this.Parent.Controls["frmVenta"].Visible = true;
            }
        }
        #endregion  
    }
}
