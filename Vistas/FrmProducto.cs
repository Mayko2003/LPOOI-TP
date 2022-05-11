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

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();

            producto.Prod_Codigo = txtCodigo.Text;
            producto.Prod_Categoria = txtCategoria.Text;
            producto.Prod_Descripcion = txtDescripcion.Text;
            producto.Prod_precio = decimal.Parse(txtPrecio.Text);


            MessageBox.Show("Código: " + txtCodigo.Text + "\nCategoría: " + txtCategoria.Text + "\nDescripción: " + txtDescripcion.Text + "\nPrecio: " + txtPrecio.Text, "Datos Ingresados:");
        }
    }
}
