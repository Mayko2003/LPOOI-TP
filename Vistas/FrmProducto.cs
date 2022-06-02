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
    public partial class FrmProducto : Form
    {

        #region Atributos
        private int indiceRowEliminar = -1;
        private bool fechasSeleccionadas = false;
        #endregion

        public FrmProducto()
        {
            InitializeComponent();
            this.Visible = false;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
        }


        #region Metodos Formulario
        private void FrmProducto_Load(object sender, EventArgs e)
        {
            load_productos();
            load_combos();
        }

        internal void clear_data_form()
        {
            txtCodigo.Enabled = true;
            txtCodigo.Text = "";
            txtCategoria.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtBuscar.Text = "Buscar por Codigo";
        }
        private void load_productos()
        {
            dgwProductos.DataSource = TrabajarProducto.list_productos();
            dgwProductos.Refresh();
        }

        private void load_combos()
        {
            //load combo para Ordenar
            DataTable dt = new DataTable();

            //Agregar las columnas de la tabla
            dt.Columns.Add("col_name");

            //Agregar las filas de la tabla
            dt.Rows.Add("Codigo");
            dt.Rows.Add("Categoria");
            dt.Rows.Add("Descripcion");
            dt.Rows.Add("Precio");

            cmbOrderBy.DisplayMember = "col_name";
            cmbOrderBy.ValueMember = "col_name";
            cmbOrderBy.DataSource = dt;

            //load combo orden
            dt = new DataTable();

            //Agregar las columnas de la tabla
            dt.Columns.Add("orden");

            //Agregar las filas de la tabla
            dt.Rows.Add("ASC");
            dt.Rows.Add("DESC");

            cmbOrden.DisplayMember = "orden";
            cmbOrden.ValueMember = "orden";
            cmbOrden.DataSource = dt;

            //load combo clientes
            dt = TrabajarCliente.list_clientes_resumen();
            cmbFiltrarCliente.DisplayMember = "Abreviacion";
            cmbFiltrarCliente.ValueMember = "DNI";

            dt.Rows.Add("------", "%%");

            cmbFiltrarCliente.DataSource = dt;
            
            //load combo opciones
            dt = new DataTable();

            //agregar columnas
            dt.Columns.Add("option");

            //agregar filas
            dt.Rows.Add("Buscar");
            dt.Rows.Add("Filtrar por Venta (DNI o Fechas)");
            dt.Rows.Add("Ordenar");

            cmbOptions.DisplayMember = "option";
            cmbOptions.ValueMember = "option";
            cmbOptions.DataSource = dt;
        }

        #endregion


        #region Events
        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();

            producto.Prod_Codigo = txtCodigo.Text;
            producto.Prod_Categoria = txtCategoria.Text;
            producto.Prod_Descripcion = txtDescripcion.Text;
            producto.Prod_precio = decimal.Parse(txtPrecio.Text);

            //si elcodigo exist avisar de error
            if (TrabajarProducto.exist_producto(txtCodigo.Text))
            {
                if (txtCodigo.Enabled) MessageBox.Show("Ya existe un producto con ese Codigo", "Error Codigo, ingrese otro por favor");
                else
                {
                    var mbUpdate = MessageBox.Show("Confirme actualizacion", "Actualizacion", MessageBoxButtons.OKCancel);
                    if (mbUpdate == DialogResult.OK)
                    {
                        TrabajarProducto.update_producto(producto);
                        txtCodigo.Enabled = true;
                        load_productos();
                        clear_data_form();
                    }
                }
              
                return;
            }
            else //se puede guardar nuevo producto
            {
                
                var mb = MessageBox.Show(
                    "Código: " + txtCodigo.Text +
                    "\nCategoría: " + txtCategoria.Text +
                    "\nDescripción: " + txtDescripcion.Text +
                    "\nPrecio: " + txtPrecio.Text, "Datos Ingresados:", MessageBoxButtons.OKCancel);

                if (mb == DialogResult.OK)
                {
                    TrabajarProducto.insert_producto(producto);
                    load_productos();
                    clear_data_form();
                }
            }
        }

        private void dgwProductos_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dgwProductos.Rows[e.RowIndex];

            txtCodigo.Text = row.Cells["Codigo"].Value.ToString();
            txtCategoria.Text = row.Cells["Categoria"].Value.ToString();
            txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
            txtPrecio.Text = row.Cells["Precio"].Value.ToString();

            //set propiedades
            pnlOptions.Visible = false;
            dgwProductos.Visible = false;
            pnlProductoRegistrar.Visible = true;
            txtCodigo.Enabled = false; //se desabilita para evitar problemas de pk
        }
        private void dgwProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.indiceRowEliminar != -1 && e.KeyCode == Keys.Delete)
            {
                var mb = MessageBox.Show("De verdad desea eliminar el producto seleccionado?", "Eliminar Producto", MessageBoxButtons.OKCancel);

                if (mb == DialogResult.OK)
                {
                    var cell = this.dgwProductos.Rows[this.indiceRowEliminar].Cells[0];
                    try
                    {
                        TrabajarProducto.delete_producto(cell.Value.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hay ventas que ocupan el producto, primero revise las ventas");
                    }
                    load_productos();
                }
            }
        }

        private void dgwProductos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.indiceRowEliminar = e.RowIndex;
        }

        private void cmbOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrden.SelectedValue != null)
                dgwProductos.DataSource = TrabajarProducto.sort_by(
                    cmbOrderBy.SelectedValue.ToString(), cmbOrden.SelectedValue.ToString());
        }

        private void cmbOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgwProductos.DataSource = TrabajarProducto.sort_by(
                    cmbOrderBy.SelectedValue.ToString(), cmbOrden.SelectedValue.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            load_productos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mcRango.Visible = !mcRango.Visible;
        }

        private void mcRango_DateSelected(object sender, DateRangeEventArgs e)
        {
            mcRango.Visible = false;
            this.fechasSeleccionadas = true;
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string dni = cmbFiltrarCliente.SelectedValue.ToString();
            if (this.fechasSeleccionadas)
            {
                //se obtiene la fecha de fin del rango pero se crea una nueva que 
                // incluye el dia completo es decir el dia de fin pero no a las 00:00
                //sino a las 23:59:59
                DateTime end = new DateTime(
                    mcRango.SelectionRange.End.Year,
                    mcRango.SelectionRange.End.Month,
                    mcRango.SelectionRange.End.Day,
                    23, 59, 59);

                dgwProductos.DataSource = TrabajarProducto.filter_by_dni_date(dni, mcRango.SelectionRange.Start, end);
            }
            else
            {
                dgwProductos.DataSource = TrabajarProducto.filter_by_dni_date(dni, new DateTime(1900, 1, 1), DateTime.Now);
            }
            fechasSeleccionadas = false;
        }
        private void cmbOptions_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbOptions.SelectedValue == null) return;
            if (cmbOptions.SelectedValue.ToString() == "Buscar")
            {
                pnlBuscar.Visible = true;
                pnlFiltrarProducto.Visible = pnlSortProducto.Visible = false;
            }
            else if (cmbOptions.SelectedValue.ToString() == "Ordenar")
            {
                pnlSortProducto.Visible = true;
                pnlBuscar.Visible = pnlFiltrarProducto.Visible = false;
            }
            else
            {
                pnlFiltrarProducto.Visible = true;
                pnlBuscar.Visible = pnlSortProducto.Visible = false;
            }
        }
        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
                txtBuscar.Text = "Buscar por Codigo";
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar por Codigo")
                txtBuscar.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "Buscar por Codigo")
                dgwProductos.DataSource = TrabajarProducto.search_productos(txtBuscar.Text);
            else
                load_productos();
        }
        private void mcRango_DateSelected_1(object sender, DateRangeEventArgs e)
        {
            this.fechasSeleccionadas = true;
            this.mcRango.Visible = false;
        }
        #endregion

        
    }
}
