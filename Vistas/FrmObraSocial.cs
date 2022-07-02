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
        #region Atributos
        private int indiceRowEliminar = -1;
        public int IndiceRowEliminar
        {
            set { this.indiceRowEliminar = value; }
            get { return this.indiceRowEliminar; }
        }
        #endregion

        public FrmObraSocial()
        {
            InitializeComponent();
            this.Visible = false;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
        }
        private void frmObraSocial_Load(object sender, EventArgs e)
        {
            this.SendToBack();
            this.cargar_obrasSocial();
            this.lblCantidad.Text = "Cantidad de OS: " + this.dgwObrasSocial.Rows.Count.ToString();
        }

        #region Metodos Formulario
        private void cargar_obrasSocial()
        {
            dgwObrasSocial.DataSource = TrabajarObraSocial.list_obrasSocial();
        }
        internal void clear_data_form() 
        { 
            txtCuit.Text = "";
            txtDireccion.Text = "";
            txtRazonSocial.Text = "";
            txtTelefono.Text = "";
            txtBuscar.Text = "Buscar por CUIT";
            lblTitulo.Text = "Formulario Registrar Obra Social";
        }
        private void actualizar_label_cantidad()
        {
            this.lblCantidad.Text = "Cantidad Obras Sociales: " + this.dgwObrasSocial.Rows.Count.ToString();
        }
        #endregion

        #region Events
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
            actualizar_label_cantidad();
            //Limpia el formulario
            clear_data_form();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "Buscar por CUIT")
                dgwObrasSocial.DataSource = TrabajarObraSocial.search_obrasSocial(txtBuscar.Text);
            else
                cargar_obrasSocial();

            actualizar_label_cantidad();
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
            pnlOSRegistrar.Visible = true;
            txtCuit.Enabled = false;
            lblCantidad.Visible = false;
            lblTitulo.Text = "Formulario Actualizar Obra Social";
        }

        private void dgwObrasSocial_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.indiceRowEliminar != -1 && e.KeyCode == Keys.Delete)
            {
                var cell = this.dgwObrasSocial.Rows[this.indiceRowEliminar].Cells[0];
                var mb = MessageBox.Show("De verdad desea eliminar la obra social?", "Eliminar Obra social", MessageBoxButtons.OKCancel);
                if (mb == DialogResult.OK)
                {
                    TrabajarObraSocial.delete_obraSocial(cell.Value.ToString());
                    cargar_obrasSocial();
                    actualizar_label_cantidad();
                }
            }
        }

        private void dgwObrasSocial_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.indiceRowEliminar = e.RowIndex;
        }
        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar por CUIT")
                txtBuscar.Text = "";
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
                txtBuscar.Text = "Buscar por CUIT";
        }
        #endregion
    }
}
