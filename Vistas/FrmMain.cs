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
        #endregion


        #endregion
        public FrmMain()
        {
            InitializeComponent();
        }

        #region Metodos Formulario

        internal void LoadFuncionalidades()
        {
            if (rolLogeado == "Operario")
            {
                mnuVertical.Controls.Remove(btnCliente);
                mnuVertical.Controls.Remove(panel1);
                mnuVertical.Controls.Remove(pictureBox2);
                btnCliente.Visible = false;
                panel1.Visible = false;
                pictureBox2.Visible = false;
            }
            this.Show();
        }

        private void removerControlesPnlContenedor()
        {
            foreach (Control ctl in pnlContenedor.Controls)
            {
                if (ctl.Name == subMenuCliente.Name || ctl.Name == subMenuObraSocial.Name
                   || ctl.Name == subMenuProducto.Name || ctl.Name == subMenuUsuario.Name)
                {
                    continue;
                }

                ctl.Visible = false;
                pnlContenedor.Controls.Remove(ctl);
            }
        }

        private void AbrirForm(Form form)
        {
            if (form.Visible) return;

            removerControlesPnlContenedor();

            Form formHijo = form;
            formHijo.TopLevel = false;
            //Hacemos que el formulario ocupe todo el espacio del contenedor
            formHijo.Dock = DockStyle.Fill;
            //Añadimos los elementos del formulario hijo
            pnlContenedor.Controls.Add(formHijo);
            //mostramos el formulario
            formHijo.Visible = true;
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
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            subMenuCliente.Visible = false;
            frmCliente.Controls["dgwClientes"].Visible = false;
            frmCliente.Controls["pnlBuscar"].Visible = false;
            frmCliente.Controls["pnlClienteRegistrar"].Visible = true;
            frmCliente.clear_data_form();
            AbrirForm(frmCliente);
        }
        private void btnMostrarClientes_Click(object sender, EventArgs e)
        {
            subMenuCliente.Visible = false;
            frmCliente.Controls["dgwClientes"].Visible = true;
            frmCliente.Controls["pnlBuscar"].Visible = true;
            frmCliente.Controls["pnlClienteRegistrar"].Visible = false;
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
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            subMenuProducto.Visible = false;
            frmProducto.Controls["dgwProductos"].Visible = false;
            frmProducto.Controls["btnUpdateProd"].Visible = false;
            frmProducto.Controls["btnDeleteProd"].Visible = false;
            AbrirForm(frmProducto);
        }

        private void btnMostrarProductos_Click(object sender, EventArgs e)
        {
            subMenuProducto.Visible = false;
            frmProducto.Controls["dgwProductos"].Visible = true;
            frmProducto.Controls["btnUpdateProd"].Visible = true;
            frmProducto.Controls["btnDeleteProd"].Visible = true;
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
        }

        private void btnNuevaObraSocial_Click(object sender, EventArgs e)
        {
            subMenuObraSocial.Visible = false;
            frmObraSocial.Controls["dgwObrasSocial"].Visible = false;
            frmObraSocial.Controls["pnlBuscar"].Visible = false;
            frmObraSocial.Controls["pnlOSRegistrar"].Visible = true;
            frmObraSocial.clear_data_form();
            AbrirForm(frmObraSocial);
        }

        private void btnMostrarObraSocial_Click(object sender, EventArgs e)
        {
            subMenuObraSocial.Visible = false;
            frmObraSocial.Controls["dgwObrasSocial"].Visible = true;
            frmObraSocial.Controls["pnlBuscar"].Visible = true;
            frmObraSocial.Controls["pnlOSRegistrar"].Visible = false;
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
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            subMenuUsuario.Visible = false;
            frmUsuario.Controls["pnlUsuarioRegistrar"].Visible = true;
            frmUsuario.Controls["pnlBuscar"].Visible = false;
            frmUsuario.Controls["dgwUsuarios"].Visible = false;
            frmUsuario.clear_data_form();
            AbrirForm(frmUsuario);
        }

        private void btnMostrarUsuarios_Click(object sender, EventArgs e)
        {
            subMenuUsuario.Visible = false;
            frmUsuario.Controls["pnlUsuarioRegistrar"].Visible = false;
            frmUsuario.Controls["pnlBuscar"].Visible = true;
            frmUsuario.Controls["dgwUsuarios"].Visible = true;
            AbrirForm(frmUsuario);
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
            Application.Exit();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion


       

    }
}

