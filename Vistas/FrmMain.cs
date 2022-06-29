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
    public partial class FrmMain : Form
    {

        #region Atributos y Propiedades

        private Usuario usuarioLogeado;
        private string rolLogeado;

        public Usuario UsuarioLogeado
        {
            get { return this.usuarioLogeado; }
            set { this.usuarioLogeado = value; }
        }
        public string RolLogeado 
        {
            get { return this.rolLogeado; }
            set { this.rolLogeado = value; }
        }

        #region Forms
        private FrmCliente frmCliente = new FrmCliente();
        private FrmProducto frmProducto = new FrmProducto();
        private FrmObraSocial frmObraSocial = new FrmObraSocial();
        private FrmUsuario frmUsuario = new FrmUsuario();
        private FrmInicio frmInicio = new FrmInicio();
        private FrmVenta frmVenta = new FrmVenta();
        #endregion


        #endregion
        public FrmMain()
        {
            InitializeComponent();
            pnlContenedor.Controls.Add(frmCliente);
            pnlContenedor.Controls.Add(frmInicio);
            pnlContenedor.Controls.Add(frmObraSocial);
            pnlContenedor.Controls.Add(frmUsuario);
            pnlContenedor.Controls.Add(frmProducto);
            pnlContenedor.Controls.Add(frmVenta);
        }

        #region Metodos Formulario

        internal void LoadSegunRol()
        {
            if (rolLogeado == "Operario")
            {
                //alinear botones y paneles
                pnlBtnVenta.Location = pnlBtnProducto.Location;
                pnlContenedor.Controls["subMenuVenta"].Location = pnlContenedor.Controls["subMenuProducto"].Location;


                // eliminamos los controles que no corresponden
                mnuVertical.Controls.Remove(pnlBtnUsuario);
                mnuVertical.Controls.Remove(pnlBtnProducto);
                mnuVertical.Controls.Remove(pnlBtnOS);
                pnlContenedor.Controls.RemoveByKey("subMenuUsuario");
                pnlContenedor.Controls.RemoveByKey("subMenuProducto");
                pnlContenedor.Controls.RemoveByKey("subMenuObraSocial");
            }
            else if (rolLogeado == "Administrador")
            {
                //alinear botones y paneles
                pnlBtnUsuario.Location = pnlBtnProducto.Location;
                pnlContenedor.Controls["subMenuUsuario"].Location = pnlContenedor.Controls["subMenuProducto"].Location;

                pnlBtnProducto.Location = pnlBtnCliente.Location;
                pnlContenedor.Controls["subMenuProducto"].Location = pnlContenedor.Controls["subMenuCliente"].Location;
                

                //eliminamos los controles que no corresponden
                mnuVertical.Controls.Remove(pnlBtnCliente);
                mnuVertical.Controls.Remove(pnlBtnOS);
                mnuVertical.Controls.Remove(pnlBtnVenta);
                pnlContenedor.Controls.RemoveByKey("subMenuCliente");
                pnlContenedor.Controls.RemoveByKey("subMenuObraSocial");
                pnlContenedor.Controls.RemoveByKey("subMenuVenta");
            }
            this.ShowDialog();
        }

        private void AbrirForm(Form form)
        {
            foreach (Control ctl in pnlContenedor.Controls)
            {
                if (ctl.Name == form.Name) form.Visible = true;
                else ctl.Visible = false;
            }
        }
        #endregion


        #region Cliente Form events
        // -------------CLIENTE-----------------
        private void btnCliente_Click(object sender, EventArgs e)
        {
            //removerControlesPnlContenedor();
            subMenuCliente.Visible = !subMenuCliente.Visible;
            subMenuObraSocial.Visible = false;
            subMenuProducto.Visible = false;
            subMenuUsuario.Visible = false;
            subMenuVenta.Visible = false;
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            subMenuCliente.Visible = false;
            frmCliente.Controls["dgwClientes"].Visible = false;
            frmCliente.Controls["pnlOptions"].Visible = false;
            frmCliente.Controls["pnlClienteRegistrar"].Visible = true;
            frmCliente.Controls["lblCantidad"].Visible = false;

            frmCliente.clear_data_form();
            AbrirForm(frmCliente);
        }
        internal void btnMostrarClientes_Click(object sender, EventArgs e)
        {
            if (sender != null && sender as string == "select") frmCliente.action = sender as string;
            else frmCliente.action = "show";
            subMenuCliente.Visible = false;
            frmCliente.Controls["dgwClientes"].Visible = true;
            frmCliente.Controls["pnlOptions"].Visible = true;
            frmCliente.Controls["pnlClienteRegistrar"].Visible = false;
            frmCliente.Controls["lblCantidad"].Visible = true;

            frmCliente.clear_data_form();
            AbrirForm(frmCliente);
        }
        #endregion


        #region Producto Form events
        // -------------PRODUCTO-------------------
        private void btnProducto_Click(object sender, EventArgs e)
        {
            //abrimos el submenu
            subMenuProducto.Visible = !subMenuProducto.Visible;
            subMenuObraSocial.Visible = false;
            subMenuCliente.Visible = false;
            subMenuUsuario.Visible = false;
            subMenuVenta.Visible = false;
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            subMenuProducto.Visible = false;
            frmProducto.Controls["dgwProductos"].Visible = false;
            frmProducto.Controls["pnlOptions"].Visible = false;
            frmProducto.Controls["pnlProductoRegistrar"].Visible = true;
            frmProducto.Controls["lblCantidad"].Visible = false;

            frmProducto.clear_data_form();
            AbrirForm(frmProducto);
        }

        private void btnMostrarProductos_Click(object sender, EventArgs e)
        {
            subMenuProducto.Visible = false;
            frmProducto.Controls["dgwProductos"].Visible = true;
            frmProducto.Controls["pnlOptions"].Visible = true;
            frmProducto.Controls["pnlProductoRegistrar"].Visible = false;
            frmProducto.Controls["lblCantidad"].Visible = true;

            frmProducto.clear_data_form();
            AbrirForm(frmProducto);
        }
        #endregion


        #region Obra Social Form events
        // -------------OBRA SOCIAL-------------------
        private void btnObraSocial_Click(object sender, EventArgs e)
        {
            //abrimos el submenu
            subMenuObraSocial.Visible = !subMenuObraSocial.Visible;
            subMenuCliente.Visible = false;
            subMenuProducto.Visible = false;
            subMenuUsuario.Visible = false;
            subMenuVenta.Visible = false;
        }

        private void btnNuevaObraSocial_Click(object sender, EventArgs e)
        {
            subMenuObraSocial.Visible = false;
            frmObraSocial.Controls["dgwObrasSocial"].Visible = false;
            frmObraSocial.Controls["pnlBuscar"].Visible = false;
            frmObraSocial.Controls["pnlOSRegistrar"].Visible = true;
            frmObraSocial.Controls["lblCantidad"].Visible = false;
            
            frmObraSocial.clear_data_form();
            AbrirForm(frmObraSocial);
        }

        private void btnMostrarObraSocial_Click(object sender, EventArgs e)
        {
            subMenuObraSocial.Visible = false;
            frmObraSocial.Controls["dgwObrasSocial"].Visible = true;
            frmObraSocial.Controls["pnlBuscar"].Visible = true;
            frmObraSocial.Controls["pnlOSRegistrar"].Visible = false;
            frmObraSocial.Controls["lblCantidad"].Visible = true;
            
            frmObraSocial.clear_data_form();
            AbrirForm(frmObraSocial);
        }
        #endregion


        #region Usuario Form events
        // -------------USUARIO-------------------
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            //abrimos el submenu
            subMenuUsuario.Visible = !subMenuUsuario.Visible;
            subMenuObraSocial.Visible = false;
            subMenuProducto.Visible = false;
            subMenuCliente.Visible = false;
            subMenuVenta.Visible = false;
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            subMenuUsuario.Visible = false;
            frmUsuario.Controls["pnlUsuarioRegistrar"].Visible = true;
            frmUsuario.Controls["pnlBuscar"].Visible = false;
            frmUsuario.Controls["dgwUsuarios"].Visible = false;
            frmUsuario.Controls["lblCantidad"].Visible = false;
            
            frmUsuario.clear_data_form();
            AbrirForm(frmUsuario);
        }

        private void btnMostrarUsuarios_Click(object sender, EventArgs e)
        {
            subMenuUsuario.Visible = false;
            frmUsuario.Controls["pnlUsuarioRegistrar"].Visible = false;
            frmUsuario.Controls["pnlBuscar"].Visible = true;
            frmUsuario.Controls["dgwUsuarios"].Visible = true;
            frmUsuario.Controls["lblCantidad"].Visible = true;
            
            frmUsuario.clear_data_form();
            AbrirForm(frmUsuario);
        }
        #endregion


        #region Venta Form events
        // -------------Venta-------------------
        private void btnVenta_click(object sender, EventArgs e)
        {
            //abrimos el submenu
            subMenuVenta.Visible = !subMenuVenta.Visible;
            subMenuUsuario.Visible = false;
            subMenuObraSocial.Visible = false;
            subMenuProducto.Visible = false;
            subMenuCliente.Visible = false;
        }

        internal void btnNuevaVenta_click(object sender, EventArgs e)
        {
            if (sender is Cliente) frmVenta.clienteSeleccionado = (Cliente)sender;
            else
            {
                frmVenta.clienteSeleccionado = null;
                frmVenta.Action = "new";
                frmVenta.clear_data_form();
            }
            
            subMenuVenta.Visible = false;
            frmVenta.Controls["pnlVentaRegistrar"].Visible = true;
            frmVenta.Controls["pnlOptions"].Visible = false;
            frmVenta.Controls["dgwVentas"].Visible = false;
            frmVenta.Controls["lblCantidad"].Visible = false;
            frmVenta.Controls["lblCantidadLineas"].Visible = true;

            
            AbrirForm(frmVenta);
        }

        private void btnMostrarVentas_click(object sender, EventArgs e)
        {
            subMenuVenta.Visible = false;
            frmVenta.Controls["pnlVentaRegistrar"].Visible = false;
            frmVenta.Controls["pnlOptions"].Visible = true;
            frmVenta.Controls["dgwVentas"].Visible = true;
            frmVenta.Controls["lblCantidad"].Visible = true;
            frmVenta.Controls["lblCantidadLineas"].Visible = false;

            frmVenta.clear_data_form();
            AbrirForm(frmVenta);
        }
        #endregion


        #region Inicio Form events
        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirForm(frmInicio);
        }
        #endregion
        
        
        #region Eventos adicionales
        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


    }
}

