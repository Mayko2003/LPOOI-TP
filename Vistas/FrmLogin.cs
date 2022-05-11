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

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            Boolean userFound = false;

            Usuario oUser1 = new Usuario("administrador", "1234");
            Usuario oUser2 = new Usuario("operador", "1234");
            Usuario oUser3 = new Usuario("auditor", "1234");

            FrmMain oFrmMain = new FrmMain();
            FrmLogin oFrmLogin = new FrmLogin();

            if (oUser1.Usu_NombreUsuario == txtUserName.Text && oUser1.Usu_Contraseña == txtPassword.Text)
            {
                userFound = true;
            }
            else if (oUser2.Usu_NombreUsuario == txtUserName.Text && oUser2.Usu_Contraseña == txtPassword.Text)
            {
                userFound = true;
            }
            else if (oUser3.Usu_NombreUsuario == txtUserName.Text && oUser3.Usu_Contraseña == txtPassword.Text)
            {
                userFound = true;
            }

            if (userFound)
            {
                MessageBox.Show(txtUserName.Text, "Bienvenido/a: ");
                oFrmMain.Show();
            }
            else
            {
                MessageBox.Show("Datos de acceso incorrectos");
            }
            this.Hide();
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
