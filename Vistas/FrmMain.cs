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
        FrmCliente frmCliente = new FrmCliente();
        FrmProducto frmProducto = new FrmProducto();
        FrmObraSocial frmObraSocial = new FrmObraSocial();
        FrmUsuario frmUsuario = new FrmUsuario();
        FrmInicio frmInicio = new FrmInicio();


        public FrmMain()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // -------------CLIENTE-----------------
        private void btnCliente_Click(object sender, EventArgs e)
        {
            //pnlContenedor.Controls.Clear();
            while (pnlContenedor.Controls.Count > 4)
            {
                //Se va a eliminar el elemento que este en el indice 0
                pnlContenedor.Controls.RemoveAt(4);
            }
           //abrimos el submenu
            subMenuCliente.Visible = !subMenuCliente.Visible;
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            //AbrirForm(new Cliente());
            
            subMenuCliente.Visible = false;
            AbrirForm(frmCliente);
            

            /*frmProducto.TopLevel = false;
            frmObraSocial.TopLevel = false;
            frmUsuario.TopLevel = false;
            pnlContenedor.Controls.Add(frmCliente);
            pnlContenedor.Controls.Remove(frmProducto);
            pnlContenedor.Controls.Add(frmObraSocial);
            pnlContenedor.Controls.Add(frmUsuario);
            
            frmCliente.Show();
            frmObraSocial.Hide();
            frmUsuario.Hide();
            frmProducto.Hide();*/
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            subMenuCliente.Visible = false;
            //AbrirForm(frmCliente);
        }

        // -------------PRODUCTO-------------------
        private void btnProducto_Click(object sender, EventArgs e)
        {
            while (pnlContenedor.Controls.Count > 4)
            {
                //Se va a eliminar el elemento que este en el indice 0
                pnlContenedor.Controls.RemoveAt(4);
            }
            //abrimos el submenu
            subMenuProducto.Visible = !subMenuProducto.Visible;
            
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            subMenuProducto.Visible = false;
            AbrirForm(frmProducto);
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            subMenuProducto.Visible = false;
            //AbrirForm(frmCliente);
        }


        // -------------OBRA SOCIAL-------------------
        private void btnObraSocial_Click(object sender, EventArgs e)
        {
            while (pnlContenedor.Controls.Count > 4)
            {
                //Se va a eliminar el elemento que este en el indice 0
                pnlContenedor.Controls.RemoveAt(4);
            }
            //abrimos el submenu
            subMenuObraSocial.Visible = !subMenuObraSocial.Visible;
        }

        private void btnNuevaObraSocial_Click(object sender, EventArgs e)
        {
            subMenuObraSocial.Visible = false;
            AbrirForm(frmObraSocial);
        }

        private void btnEditarObraSocial_Click(object sender, EventArgs e)
        {
            subMenuObraSocial.Visible = false;
            //AbrirForm(frmCliente);
        }


        // -------------USUARIO-------------------
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            while (pnlContenedor.Controls.Count > 4)
            {
                //Se va a eliminar el elemento que este en el indice 0
                pnlContenedor.Controls.RemoveAt(4);
            }
            //pnlContenedor.Controls.Clear();
            //abrimos el submenu
            subMenuUsuario.Visible = !subMenuUsuario.Visible;

        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            
            
            subMenuUsuario.Visible = false;
            AbrirForm(frmUsuario);
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            subMenuUsuario.Visible = false;
            //AbrirForm(frmCliente);
        }


        private void AbrirForm(Form form) 
        {
            //Mientras la cantidad de controles que tenga el panel sea mayor a 0
            while (pnlContenedor.Controls.Count > 4) 
            {
                //Se va a eliminar el elemento que este en el indice 0
                pnlContenedor.Controls.RemoveAt(4);
            }

            Form formHijo = form;
            formHijo.TopLevel = false;
            //Hacemos que el formulario ocupe todo el espacio del contenedor
            formHijo.Dock = DockStyle.Fill;
            //Añadimos los elementos del formulario hijo
            pnlContenedor.Controls.Add(formHijo);
            //mostramos el formulario
            formHijo.Show();
            

            //Si existe algun control dentro de contenedor o panel
            /**if (this.pnlContenedor.Controls.Count > 0)
            {
                //Si es verdadero lo eliminamos
                this.pnlContenedor.Controls.RemoveAt(0);
                //Creamos un formulario con el nombre af igual al objeto que recibe la funcion, a ese objeto lo convertimos en un formulario
                Form af = formhija as Form;
                //Decimos que va a ser un formulario secundario
                af.TopLevel = false;
                //que se acople a todo el panel contenedor
                af.Dock = DockStyle.Fill;
                //agregamos al panel
                this.pnlContenedor.Controls.Add(af);
                this.pnlContenedor.Tag = af;
                //Lo mostramos
                af.Show();

            }**/
        }


        private void btnInicio_Click(object sender, EventArgs e)
        {
            /*while (pnlContenedor.Controls.Count > 4)
            {
                //Se va a eliminar el elemento que este en el indice 0
                pnlContenedor.Controls.RemoveAt(4);
            }*/

            AbrirForm(frmInicio);
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        
       }

    }

