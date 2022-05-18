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
        private int indiceRowEliminar = -1;
        public int IndiceRowEliminar
        {
            set { this.indiceRowEliminar = value; }
            get { return this.indiceRowEliminar; }
        }
        public FrmObraSocial()
        {
            InitializeComponent();
        }
        internal void clear_data_form() 
        { 
            txtCuit.Text = "";
            txtDireccion.Text = "";
            txtRazonSocial.Text = "";
            txtTelefono.Text = "";
        }
        private void btnRegistrarObraSocial_Click(object sender, EventArgs e)
        {
            ObraSocial obraSocial = new ObraSocial();

            obraSocial.Os_CUIT = txtCuit.Text;
            obraSocial.Os_RazonSocial = txtRazonSocial.Text;
            obraSocial.Os_Direccion = txtDireccion.Text;
            obraSocial.Os_Telefono = txtTelefono.Text;
            //Si el cuit existe, actualizar o avisar de error
            if (TrabajarObraSocial.exits_cuit(txtCuit.Text)) 
            {
                if (txtCuit.Enabled) MessageBox.Show("Ya existe tal cuit");
                else
                {
                    var mbUpdate = MessageBox.Show("Confirme actualizacion", "Actualizacion", MessageBoxButtons.OKCancel);
                    if (mbUpdate == DialogResult.OK)
                    {
                        TrabajarObraSocial.update_obraSocial(obraSocial);
                        txtCuit.Enabled = true;
                        cargar_obrasSocial();
                        clear_data_form();
                    }
                }
                return;
            }
            MessageBox.Show("CUIT: " + txtCuit.Text + "\nRazón Social: " + txtRazonSocial.Text + "\nDireccion: " + txtDireccion.Text + "\nTelefono: " + txtTelefono.Text, "Datos Ingresados:");
            //Agrega la obra social a la bd
            TrabajarObraSocial.insert_obraSocial(obraSocial);
            //Agrega la obra social en el dataGridView
            cargar_obrasSocial();
            //Limpia el formulario
            clear_data_form();
        }

        private void frmObraSocial_Load(object sender, EventArgs e)
        {
            cargar_obrasSocial();
        }
        private void cargar_obrasSocial(){
            dgwObrasSocial.DataSource = TrabajarObraSocial.list_obrasSocial();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
                dgwObrasSocial.DataSource = TrabajarObraSocial.search_obrasSocial(txtBuscar.Text);
            else
                cargar_obrasSocial();
        }

        private void dgwObrasSocial_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dgwObrasSocial.Rows[e.RowIndex];
            txtRazonSocial.Text = row.Cells["Razon social"].Value as string;
            txtDireccion.Text = row.Cells["Direccion"].Value as string;
            txtTelefono.Text = row.Cells["Telefono"].Value as string;
            txtCuit.Text = row.Cells["Cuit"].Value as string;

            pnlBuscar.Visible = false;
            dgwObrasSocial.Visible = false;
            panel4.Visible = true;
            txtCuit.Enabled = false;

        }

        private void dgwObrasSocial_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.indiceRowEliminar != -1 && e.KeyCode == Keys.Delete)
            {
                var cell = this.dgwObrasSocial.Rows[this.indiceRowEliminar].Cells[0];
                if (TrabajarObraSocial.exists_cliente_cuit(cell.Value.ToString()))
                {
                    MessageBox.Show("No puede eliminar esta obra social");
                }
                else
                {
                    var mb = MessageBox.Show("De verdad desea eliminar la obra social?", "Eliminar Obra social", MessageBoxButtons.OKCancel);
                    if (mb == DialogResult.OK)
                    {
                        TrabajarObraSocial.delete_obraSocial(cell.Value.ToString());
                        cargar_obrasSocial();
                    }
                }
            }
        }

        private void dgwObrasSocial_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.indiceRowEliminar = e.RowIndex;
        }
    }
}
