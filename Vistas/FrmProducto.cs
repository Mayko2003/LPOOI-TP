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

        //ERROR: SINTAXIS EN PALABRA CLAVE WHERE

        private void dgwProductos_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dgwProductos.Rows[e.RowIndex];

            txtCodigo.Text = row.Cells["prod_codigo"].Value as string;
            txtCategoria.Text = row.Cells["prod_categoria"].Value as string;
            txtDescripcion.Text = row.Cells["prod_descripcion"].Value as string;
            txtPrecio.Text = row.Cells["prod_precio"].Value as string;

            //set propiedades

            dgwProductos.Visible = false;
            panel4.Visible = true;
            txtCodigo.Enabled = false; //se desabilita para evitar problemas de pk
        }

    }
}
