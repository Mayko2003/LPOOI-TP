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
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            cliente.Cli_DNI = txtDNI.Text;
            cliente.Cli_Apellido = txtApellido.Text;
            cliente.Cli_Nombre = txtNombre.Text;
            cliente.Cli_Direccion = txtDireccion.Text;
            cliente.Os_CUIT = txtCUIT.Text;
            cliente.Cli_NroCarnet = txtNumeroCarnet.Text;

            MessageBox.Show("DNI: " + txtDNI.Text + "\nApellido: " + txtApellido.Text + "\nNombre: " + txtNombre.Text + "\nDireccion: " + txtDireccion.Text + "\nCUIT: " + txtCUIT.Text + "\nNumero Carnet: " + txtNumeroCarnet.Text, "Datos Ingresados:");
        }
    }
}
