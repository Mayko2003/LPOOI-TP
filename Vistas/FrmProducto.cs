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
            this.SendToBack();
            this.load_combos();
            this.load_productos();
            this.lblCantidad.Text = "Cantidad de Productos: " + this.dgwProductos.Rows.Count.ToString();
        }

        internal void clear_data_form()
        {
            txtCodigo.Enabled = true;
            txtCodigo.Text = "";
            txtCategoria.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtBuscar.Text = "Buscar por Codigo";
            lblTitulo.Text = "Formulario Registrar Producto";
        }
        private void load_productos()
        {
            dgwProductos.DataSource = TrabajarProducto.list_productos();
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
            cmbFiltrarCliente.DisplayMember = "Abreviacion";
            cmbFiltrarCliente.ValueMember = "DNI";

            dt = new DataTable();
            dt.Columns.Add("Abreviacion");
            dt.Columns.Add("DNI");
            dt.Rows.Add("Todos","%%");

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
            dt.Rows.Add("Ordenar");

            cmbOptions.DisplayMember = "option";
            cmbOptions.ValueMember = "option";
            cmbOptions.DataSource = dt;
        }

        private void actualizar_label_cantidad()
        {
            this.lblCantidad.Text = "Cantidad de Productos: " + this.dgwProductos.Rows.Count.ToString();
        }
        #endregion


        #region Events
        
        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();

            producto.Prod_Codigo = txtCodigo.Text;
            producto.Prod_Categoria = txtCategoria.Text;
            producto.Prod_Descripcion = txtDescripcion.Text;
            producto.Prod_precio = Convert.ToDecimal(txtPrecio.Text);
            producto.Prod_Estado = true;

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
                    actualizar_label_cantidad();
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
            lblCantidad.Visible = false;
            lblTitulo.Text = "Formulario Actualizar Producto";
        }
        
        private void dgwProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.indiceRowEliminar != -1 && e.KeyCode == Keys.Delete)
            {
                var mb = MessageBox.Show("De verdad desea eliminar el producto seleccionado?", "Eliminar Producto", MessageBoxButtons.OKCancel);

                if (mb == DialogResult.OK)
                {
                    var cell = this.dgwProductos.Rows[this.indiceRowEliminar].Cells[0];
                    TrabajarProducto.delete_producto(cell.Value.ToString());
                    load_productos();
                    actualizar_label_cantidad();
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
            {
                dgwProductos.DataSource = TrabajarProducto.sort_by(
                    cmbOrderBy.SelectedValue.ToString(), cmbOrden.SelectedValue.ToString());
                this.actualizar_label_cantidad();
            }
        }

        private void cmbOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgwProductos.DataSource = TrabajarProducto.sort_by(
                    cmbOrderBy.SelectedValue.ToString(), cmbOrden.SelectedValue.ToString());
            this.actualizar_label_cantidad();
        }
        
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            load_productos();
            this.actualizar_label_cantidad();
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
                
                dgwProductos.DataSource = TrabajarProducto.filter_by_dni_date(dni, dtpInicio.Value, end);
            }
            else
            {
                dgwProductos.DataSource = TrabajarProducto.filter_by_dni_date(dni, new DateTime(1900, 1, 1), DateTime.Now);
            }
            this.actualizar_label_cantidad();
        }
        
        private void cmbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            this.actualizar_label_cantidad();
        }
        
        private void cbRangoFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpInicio.Enabled = !dtpInicio.Enabled;
            dtpFin.Enabled = !dtpFin.Enabled;
            this.fechasSeleccionadas = !this.fechasSeleccionadas;
        }
        
        #endregion
    }
}
