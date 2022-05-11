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
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.Usu_NombreUsuario = txtUsuario.Text;
            usuario.Usu_Contraseña = txtContraseña.Text;
            usuario.Usu_ApellidoNombre = txtApellidoYNombre.Text;
            usuario.Rol_Codigo = int.Parse(txtRol.Text);


            MessageBox.Show("Nombre de Usuario: " + txtUsuario.Text + "\nContraseña: " + txtContraseña.Text + "\nApellido y Nombre: " + txtApellidoYNombre.Text + "\nCódigo de Rol: " + txtRol.Text, "Datos Ingresados:");
        }

        
    }
}
