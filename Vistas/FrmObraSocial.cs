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
    public partial class FrmObraSocial : Form
    {
        public FrmObraSocial()
        {
            InitializeComponent();
        }

        private void btnRegistrarObraSocial_Click(object sender, EventArgs e)
        {
            ObraSocial obraSocial = new ObraSocial();

            obraSocial.Os_CUIT = txtCuit.Text;
            obraSocial.Os_RazonSocial = txtRazonSocial.Text;
            obraSocial.Os_Direccion = txtDireccion.Text;
            obraSocial.Os_Telefono = txtTelefono.Text;


            MessageBox.Show("CUIT: " + txtCuit.Text + "\nRazón Social: " + txtRazonSocial.Text + "\nDireccion: " + txtDireccion.Text + "\nTelefono: " + txtTelefono.Text, "Datos Ingresados:");
        }
    }
}
