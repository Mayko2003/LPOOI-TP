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
        #region Atributes
        internal string action;
        private int indiceRowEliminar = -1;
        public int IndiceRowEliminar
        {
            set { this.indiceRowEliminar = value; }
            get { return this.indiceRowEliminar; }
        }
        #endregion

        public FrmCliente()
        {
            InitializeComponent();
            this.Visible = false;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
        }
        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.SendToBack();
            this.load_combos();
            this.load_clientes();
            this.lblCantidad.Text = "Cantidad de Clientes: " + this.dgwClientes.Rows.Count.ToString();
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

            //load obras sociales combo
            dt = TrabajarObraSocial.list_obrasSocial();
            cmbFiltrarOS.DataSource = dt;
            cmbFiltrarOS.DisplayMember = "CUIT";
            cmbFiltrarOS.ValueMember = "CUIT";

        }
        private void load_clientes()
        {
            dgwClientes.DataSource = TrabajarCliente.list_clientes();

        }
        internal void clear_data_form() 
        {
            txtDNI.Enabled = true;
            txtDNI.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtNombre.Text = "";
            txtNumeroCarnet.Text = "";
            txtBuscar.Text = "Buscar por DNI, Nombre o Apellido";
            lblTitulo.Text = "Formulario Registrar Cliente";
            load_combos();
        }

        private void actualizar_label_cantidad()
        {
            this.lblCantidad.Text = "Cantidad Clientes: " + this.dgwClientes.Rows.Count.ToString();
        }
        #endregion

        #region Events
        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            //recuperar datos
            Cliente cliente = new Cliente();
            cliente.Cli_DNI = txtDNI.Text;
            cliente.Cli_Apellido = txtApellido.Text;
            cliente.Cli_Nombre = txtNombre.Text;
            cliente.Cli_Direccion = txtDireccion.Text;
            cliente.Os_CUIT = cmbOS_Cuit.Text;
            cliente.Cli_NroCarnet = txtNumeroCarnet.Text;
            cliente.Cli_Estado = true;

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
                actualizar_label_cantidad();
                clear_data_form();
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "Buscar por DNI, Nombre o Apellido")
                dgwClientes.DataSource = TrabajarCliente.search_clientes(txtBuscar.Text);
            else
                load_clientes();

            actualizar_label_cantidad();
        }

        private void dgwClientes_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dgwClientes.Rows[e.RowIndex];
            if (action == "select")
            {
                Cliente seleccionado = new Cliente(){
                    Cli_Apellido=row.Cells["Apellido"].Value.ToString(),
                    Cli_DNI=row.Cells["DNI"].Value.ToString(),
                    Cli_Nombre=row.Cells["Nombre"].Value.ToString(),
                    Cli_Direccion=row.Cells["Direccion"].Value.ToString(),
                    Cli_NroCarnet=row.Cells["Nro Carnet"].Value.ToString(),
                    Os_CUIT=row.Cells["OS CUIT"].Value.ToString()
                };
                ((FrmMain)this.ParentForm).btnNuevaVenta_click(seleccionado,new EventArgs());
                return;
            }

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
            lblCantidad.Visible = false;
            lblTitulo.Text = "Formulario Actualizar Cliente";
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
                    actualizar_label_cantidad();
                }
            }
        }

        private void dgwClientes_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.indiceRowEliminar = e.RowIndex;
        }

        private void cmbOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrden.SelectedValue != null)
            {
                dgwClientes.DataSource = TrabajarCliente.sort_by(
                    cmbOrderBy.SelectedValue.ToString(), cmbOrden.SelectedValue.ToString());

                actualizar_label_cantidad();
            }


        }
        private void cmbOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgwClientes.DataSource = TrabajarCliente.sort_by(
                cmbOrderBy.SelectedValue.ToString(), cmbOrden.SelectedValue.ToString());

            actualizar_label_cantidad();
        }
        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar por DNI, Nombre o Apellido")
                txtBuscar.Text = "";
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
                txtBuscar.Text = "Buscar por DNI, Nombre o Apellido";
        }
        private void cmbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOptions.SelectedValue.ToString() == "Buscar")
            {
                pnlBuscar.Visible = true;
                pnlFiltrarCliente.Visible = pnlSortCliente.Visible = false;
            }
            else if (cmbOptions.SelectedValue.ToString() == "Filtrar")
            {
                pnlFiltrarCliente.Visible = true;
                pnlSortCliente.Visible = pnlBuscar.Visible = false;
            }
            else
            {
                pnlSortCliente.Visible = true;
                pnlFiltrarCliente.Visible = pnlBuscar.Visible = false;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string cuit = cmbFiltrarOS.SelectedValue.ToString();

            dgwClientes.DataSource = TrabajarCliente.filter_by_os(cuit);

            actualizar_label_cantidad();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            load_clientes();
            actualizar_label_cantidad();
        }
        #endregion  

        

        

        
    }
}
