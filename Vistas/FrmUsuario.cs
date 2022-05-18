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
        private int indiceRowEliminar = -1;
        public int IndiceRowEliminar
        {
            set { this.indiceRowEliminar = value; }
            get { return this.indiceRowEliminar; }
        }
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            load_combo_rol();
            load_usuarios();
        }

        #region Metodos Formularios
        private void load_combo_rol()
        {
            cmbRol_codigo.DisplayMember = "rol_codigo";
            cmbRol_codigo.ValueMember = "rol_codigo";
            cmbRol_codigo.DataSource = TrabajarRol.list_rol();
        }
        private void load_usuarios()
        {
            dgwUsuarios.DataSource = TrabajarUsuario.list_usuarios();
        }
        internal void crear_data_form()
        {
            txtUsuario.Text = "";
            txtApellidoYNombre.Text = "";
            txtContraseña.Text = "";
            txtRol.Text = "";
        }
        #endregion

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
