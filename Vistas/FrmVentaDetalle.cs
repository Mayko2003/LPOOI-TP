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
        #region Atributos
        internal VentaDetalle vdActual;
        internal int detalleRowIndex = -1;
        #endregion

        public FrmVentaDetalle()
        {
            InitializeComponent();
            this.Visible = false;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.SendToBack();
        }
        private void FrmVentaDetalle_Load(object sender, EventArgs e)
        {
            this.SendToBack();
            this.load_combo_productos();
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
            txtTotal.Text = "";
        }
        #endregion

        #region Events
        private void calcularTotal()
        {
            try
            {
                decimal cantidad = Convert.ToInt32(this.txtCantidad.Text);
                decimal precioActual = Convert.ToDecimal(txtPrecio.Text);

                this.txtTotal.Text = (cantidad * precioActual).ToString();
            }
            catch (FormatException e) { }
        }
        private void cmbProductos_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)cmbProductos.DataSource;
            int index = cmbProductos.SelectedIndex;
            if (index > -1)
            {
                txtPrecio.Text = dt.Rows[index]["Precio"].ToString();
                calcularTotal();
            }
        }
        
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                calcularTotal();
            }
        }
        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {

            vdActual.Det_Cantidad = Convert.ToDecimal(txtCantidad.Text);
            vdActual.Det_Precio = Convert.ToDecimal(txtPrecio.Text);
            vdActual.Det_Total = Convert.ToDecimal(txtTotal.Text);
            vdActual.Prod_Codigo = cmbProductos.SelectedValue.ToString();

            var mb = MessageBox.Show(
                "Codigo de producto: " + vdActual.Prod_Codigo +
                "\nCantidad: " + vdActual.Det_Cantidad +
                "\nTotal: " + vdActual.Det_Total, "Confirmacion", MessageBoxButtons.OKCancel);

            if (mb == DialogResult.OK)
            {
                //agregar linea de venta al data table temporal si esta en modo crear
                if(this.detalleRowIndex == -1)
                {
                    FrmVenta.dtVentaDetalle.Rows.Add(
                        vdActual.Prod_Codigo,
                        vdActual.Det_Precio,
                        vdActual.Det_Cantidad,
                        vdActual.Det_Total,
                        0
                    );
                }
                //modificar linea de venta sino
                else
                {
                    Object[] datos = new Object[]{
                        vdActual.Prod_Codigo,
                        vdActual.Det_Precio,
                        vdActual.Det_Cantidad,
                        vdActual.Det_Total,
                        vdActual.Det_Nro,
                    };
                    FrmVenta.dtVentaDetalle.Rows[this.detalleRowIndex].ItemArray = datos;
                }
                    
                
                clear_data_form();
                this.Visible = false;
                this.Parent.Controls["frmVenta"].Visible = true;
            }
        }
        #endregion  

        private void FrmVentaDetalle_VisibleChanged(object sender, EventArgs e)
        {
            if (vdActual != null)
            {
                this.txtCantidad.Text = vdActual.Det_Cantidad.ToString();
                this.txtPrecio.Text = vdActual.Det_Precio.ToString();
                this.txtTotal.Text = vdActual.Det_Total.ToString();

                this.cmbProductos.SelectedValue = vdActual.Prod_Codigo;
            }
            else vdActual = new VentaDetalle();
            
        }
    }
}
