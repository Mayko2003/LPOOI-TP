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
    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {

            if (TrabajarUsuario.exist_usuario(txtUserName.Text))
            {
                DataTable dt = TrabajarUsuario.search_usuarios(txtUserName.Text);
                //como busca por username primero y ya sabemos que existe, entonces
                //evaluamos el primer registro en la contraseña
                string password = dt.Rows[0]["Contraseña"].ToString();

                if (password == txtPassword.Text)
                {
                    MessageBox.Show("Bienvenido: " + dt.Rows[0]["Apellido y Nombre"].ToString(), "Bienvenida");
                    FrmMain frmMain = new FrmMain();
                    
                    //creacion del usuario logeado y del rol
                    Usuario logeado = new Usuario();
                    logeado.Usu_ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    logeado.Usu_Contraseña = dt.Rows[0]["Contraseña"].ToString();
                    logeado.Usu_NombreUsuario = dt.Rows[0]["Nombre Usuario"].ToString();
                    logeado.Usu_Contraseña = dt.Rows[0]["Apellido y Nombre"].ToString();

                    frmMain.UsuarioLogeado = logeado;
                    frmMain.RolLogeado = dt.Rows[0]["Rol"].ToString();
                    //se cargan las funcionalidades segun el rol y se lo muestra al form
                    frmMain.LoadFuncionalidades();
                    this.Hide();
                }
                else MessageBox.Show("Contraseña incorrecta");
            }
            else MessageBox.Show("El usuario no existe");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_MouseHover(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.Chocolate;
        }

        private void btnIngresar_MouseLeave(object sender, EventArgs e)
        {
            btnIngresar.BackColor = SystemColors.Info;
        }


    }
}
