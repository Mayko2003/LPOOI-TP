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
        private int indiceRowEliminar = -1;
        public int IndiceRowEliminar
        {
            set { this.indiceRowEliminar = value; }
            get { return this.indiceRowEliminar; }
        }

        public FrmCliente()
        {
            InitializeComponent();
            this.Visible = false;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
        }
        private void FrmCliente_Load(object sender, EventArgs e)
        {
            load_combos();
            load_clientes();
        }


        #region Metodos Formulario
        private void load_combos()
        {
            //load combo para Obra Social
            cmbOS_Cuit.DisplayMember = "os_cuit";
            cmbOS_Cuit.ValueMember = "os_cuit";
            cmbOS_Cuit.DataSource = TrabajarObraSocial.list_obra_social();

            //load combo para Ordenar
            DataTable dt = new DataTable();

            //Agregar las columnas de la tabla
            dt.Columns.Add("col_name");

            //Agregar las filas de la tabla
            dt.Rows.Add("DNI");
            dt.Rows.Add("Apellido");
            dt.Rows.Add("Nombre");
            dt.Rows.Add("Direccion");
            dt.Rows.Add("OS Cuit");
            dt.Rows.Add("Nro. Carnet");

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

        }
        private void load_clientes()
        {
            dgwClientes.DataSource = TrabajarCliente.list_clientes();

            var dt = dgwClientes.DataSource as DataTable;
        }
        internal void clear_data_form() 
        {
            txtDNI.Enabled = true;
            txtDNI.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtNombre.Text = "";
            txtNumeroCarnet.Text = "";
        }
        #endregion

        #region Events
        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            //recuperar datos
            Cliente cliente = new Cliente();
            cliente.Cli_DNI = txtDNI.Text;
            cliente.Cli_Apellido = txtApellido.Text;
            cliente.Cli_Nombre = txtNombre.Text;
            cliente.Cli_Direccion = txtDireccion.Text;
            cliente.Os_CUIT = cmbOS_Cuit.Text;
            cliente.Cli_NroCarnet = txtNumeroCarnet.Text;

            //si el dni existe, actualizar o avisar de error
            if (TrabajarCliente.exist_cliente(txtDNI.Text))
            {
                if (txtDNI.Enabled) MessageBox.Show("Ya existe un cliente con ese DNI", "Error DNI");
                else
                {
                    var mbUpdate = MessageBox.Show("Confirme actualizacion","Actualizacion",MessageBoxButtons.OKCancel);
                    if (mbUpdate == DialogResult.OK) {
                        TrabajarCliente.update_cliente(cliente);
                        txtDNI.Enabled = true;
                        load_clientes();
                        clear_data_form();
                    }
                }
                return;
            }

            //sino guardar nuevo cliente si se confirma
            var mb = MessageBox.Show(
                "DNI: " + txtDNI.Text + 
                "\nApellido: " + txtApellido.Text + 
                "\nNombre: " + txtNombre.Text + 
                "\nDireccion: " + txtDireccion.Text + 
                "\nCUIT: " + cmbOS_Cuit.Text + 
                "\nNumero Carnet: " + txtNumeroCarnet.Text, "Datos Ingresados",MessageBoxButtons.OKCancel);

            if (mb == DialogResult.OK)
            {
                TrabajarCliente.insert_cliente(cliente);
                load_clientes();
                clear_data_form();
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
                dgwClientes.DataSource = TrabajarCliente.search_clientes(txtBuscar.Text);
            else
                load_clientes();
        }

        private void dgwClientes_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dgwClientes.Rows[e.RowIndex];

            txtDNI.Text = row.Cells["DNI"].Value as string;
            txtApellido.Text = row.Cells["Apellido"].Value as string;
            txtNombre.Text = row.Cells["Nombre"].Value as string;
            txtDireccion.Text = row.Cells["Direccion"].Value as string;
            txtNumeroCarnet.Text = row.Cells["Nro Carnet"].Value as string;
            cmbOS_Cuit.Text = row.Cells["OS Cuit"].Value as string;

            //set propiedades
            pnlBuscar.Visible = false;
            dgwClientes.Visible = false;
            pnlClienteRegistrar.Visible = true;
            pnlSortCliente.Visible = false;
            txtDNI.Enabled = false; //se desabilita para evitar problemas de pk
        }
        private void dgwClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.indiceRowEliminar != -1 && e.KeyCode == Keys.Delete)
            {
                var mb = MessageBox.Show("De verdad desea eliminar el cliente seleccionado?", "Eliminar Cliente", MessageBoxButtons.OKCancel);

                if (mb == DialogResult.OK)
                {
                    var cell = this.dgwClientes.Rows[this.indiceRowEliminar].Cells[0];
                    TrabajarCliente.delete_cliente(cell.Value.ToString());
                    load_clientes();
                }
            }
        }

        private void dgwClientes_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.indiceRowEliminar = e.RowIndex;
        }

        private void cmbOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbOrden.SelectedValue != null)
            dgwClientes.DataSource = TrabajarCliente.sort_by(
                cmbOrderBy.SelectedValue.ToString(), cmbOrden.SelectedValue.ToString());
        }
        private void cmbOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgwClientes.DataSource = TrabajarCliente.sort_by(
                cmbOrderBy.SelectedValue.ToString(), cmbOrden.SelectedValue.ToString());
        }
        #endregion  

        

        
    }
}
