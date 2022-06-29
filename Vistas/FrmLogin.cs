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

        #region Metodos formulario
        private void clear_data_form()
        {
            txtPassword.Text = "";
            txtUserName.Text = "";
        }
        #endregion

        #region Events
        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "")
                MessageBox.Show("Ingrese sus credenciales!");
            else if(TrabajarUsuario.check_credenciales(txtUserName.Text,txtPassword.Text))
            {
                FrmMain frmMain = new FrmMain();

                DataTable dt = TrabajarUsuario.search_usuarios(txtUserName.Text);
                    
                //creacion del usuario logeado y del rol, fila 0 porque busca primero por username
                Usuario logeado = new Usuario();
                logeado.Usu_ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                logeado.Usu_Contraseña = dt.Rows[0]["Contraseña"].ToString();
                logeado.Usu_NombreUsuario = dt.Rows[0]["Nombre Usuario"].ToString();
                logeado.Usu_Contraseña = dt.Rows[0]["Apellido y Nombre"].ToString();

                frmMain.UsuarioLogeado = logeado;
                frmMain.RolLogeado = dt.Rows[0]["Rol"].ToString();

                //se oculta el login y se carga el formulario principal segun el rol
                this.Hide();
                frmMain.LoadSegunRol();
                this.Show();
            }
            else MessageBox.Show("Usuario o contraseña incorrectas");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
        #endregion

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) btnIngresar.PerformClick();
        }

        
    }
}
