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

        private int indiceRowEliminar = -1; //variable que se usara para eliminar un producto
        public int IndiceRowEliminar
        {
            set { this.indiceRowEliminar = value; }
            get { return this.indiceRowEliminar; }
        }

        //metodo que se usara para indicar en que producto se esta posicionado
        private void dgwProductos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.indiceRowEliminar = e.RowIndex;
        }

        public FrmProducto()
        {
            InitializeComponent();
        }
        private void FrmProducto_Load(object sender, EventArgs e)
        {
            load_productos();
            
        }

        internal void clear_data_form()
        {
            txtCodigo.Enabled = true;
            txtCodigo.Text = "";
            txtCategoria.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
        }
        private void load_productos()
        {
            dgwProductos.DataSource = TrabajarProducto.list_productos();
            dgwProductos.Refresh();
        }
        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();

            producto.Prod_Codigo = txtCodigo.Text;
            producto.Prod_Categoria = txtCategoria.Text;
            producto.Prod_Descripcion = txtDescripcion.Text;
            if (txtPrecio.Text != "") producto.Prod_precio = Convert.ToDecimal(txtPrecio.Text);

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

        //evento para editar los datos de un producto
        private void dgwProductos_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dgwProductos.Rows[e.RowIndex];

            txtCodigo.Text = row.Cells["Codigo"].Value as string;
            txtCategoria.Text = row.Cells["Categoria"].Value as string;
            txtDescripcion.Text = row.Cells["Descripcion"].Value as string;
            txtPrecio.Text = row.Cells["Precio"].Value as string;

            //set propiedades

            dgwProductos.Visible = false;
            panel4.Visible = true;
            txtCodigo.Enabled = false; //se desabilita para evitar problemas de pk
        }

        //evento para eliminar un producto de la base de datos
        private void dgwProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.indiceRowEliminar != -1 && e.KeyCode == Keys.Delete)
            {
                var mb = MessageBox.Show("Desea eliminar el producto seleccionado?", "Eliminar Producto", MessageBoxButtons.OKCancel);

                if (mb == DialogResult.OK)
                {
                    var cell = this.dgwProductos.Rows[this.indiceRowEliminar].Cells[0];
                    TrabajarProducto.delete_producto(cell.Value.ToString());
                    load_productos();
                }
            }
        }

        //metodo para filtrar la tabla por codigo
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (txtCodBuscado.Text != "")
                dgwProductos.DataSource = TrabajarProducto.search_productos(txtCodBuscado.Text);
            else
                load_productos();
        }    
    }
}
