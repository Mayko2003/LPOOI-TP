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
        #region Atributos
        private int indiceRowEliminar = -1;

        public int IndiceRowEliminar
        {
            get { return this.indiceRowEliminar; }
            set { this.indiceRowEliminar = value;  }
        }
        #endregion
        public FrmUsuario()
        {
            InitializeComponent();
            this.Visible = false;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
        }

        #region Metodos Formulario
        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            SendToBack();
            load_combo_rol();
            load_usuarios();
            lblCantidad.Text = "Cantidad de Usuarios: " + dgwUsuarios.Rows.Count.ToString();
        }
        private void load_combo_rol()
        {
            cmbRol.ValueMember = "rol_descripcion";
            cmbRol.DisplayMember = "rol_descripcion";
            cmbRol.DataSource = TrabajarRol.list_roles();
        }

        private void load_usuarios()
        {
            dgwUsuarios.DataSource = TrabajarUsuario.list_usuarios();
        }

        internal void clear_data_form()
        {
            txtUsuario.Enabled = true;
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtApellidoYNombre.Text = "";
            txtBuscar.Text = "Buscar por Nombre Usuario o AyN";
            lblTitulo.Text = "Formulario Crear Usuario";
        }

        private void actualizar_label_cantidad()
        {
            this.lblCantidad.Text = "Cantidad Usuarios: " + this.dgwUsuarios.Rows.Count.ToString();
        }
        #endregion


        #region Events
        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            //se obtiene el id del rol
            DataTable dt = TrabajarRol.search_rol_by_descripcion(cmbRol.Text);
            usuario.Rol_Codigo = (int)dt.Rows[0].ItemArray[0];//en el indice 0 porque ahi esta el codigo

            usuario.Usu_NombreUsuario = txtUsuario.Text;
            usuario.Usu_Contraseña = txtContraseña.Text;
            usuario.Usu_ApellidoNombre = txtApellidoYNombre.Text;

            if (TrabajarUsuario.exist_usuario(usuario.Usu_NombreUsuario))
            {
                if (txtUsuario.Enabled) MessageBox.Show("Ya hay un usuario con ese nombre de usuario");
                else
                {
                    var mbUpdate = MessageBox.Show("Confirme actualizacion", "Actualizacion", MessageBoxButtons.OKCancel);
                    if (mbUpdate == DialogResult.OK)
                    {
                        TrabajarUsuario.update_usuario(usuario);
                        load_usuarios();
                        clear_data_form();
                    }
                }
                return;
            }

            var mb = MessageBox.Show(
                "Nombre de Usuario: " + usuario.Usu_NombreUsuario + 
                "\nContraseña: " + usuario.Usu_Contraseña + 
                "\nApellido y Nombre: " + usuario.Usu_ApellidoNombre + 
                "\nRol: " + cmbRol.Text , "Datos Ingresados",MessageBoxButtons.OKCancel);

            if (mb == DialogResult.OK) 
            {
                TrabajarUsuario.insert_usuario(usuario);
                load_usuarios();
                actualizar_label_cantidad();
                clear_data_form();
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "Buscar por Nombre Usuario o AyN")
                dgwUsuarios.DataSource = TrabajarUsuario.search_usuarios(txtBuscar.Text);
            else
                load_usuarios();
            actualizar_label_cantidad();
        }
        private void dgwUsuarios_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dgwUsuarios.Rows[e.RowIndex];


            txtUsuario.Text = row.Cells["Nombre Usuario"].Value as string;
            txtContraseña.Text = row.Cells["Contraseña"].Value as string;
            txtApellidoYNombre.Text = row.Cells["Apellido y Nombre"].Value as string;
            cmbRol.Text = row.Cells["Rol"].Value as string;
            //set propiedades
            pnlUsuarioRegistrar.Visible = true;
            dgwUsuarios.Visible = false;
            pnlBuscar.Visible = false;
            txtUsuario.Enabled = false; // por cuestiones de unicidad
            lblCantidad.Visible = false;
            lblTitulo.Text = "Formulario Actualizar Usuario";
        }
        private void dgwUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.indiceRowEliminar != -1 && e.KeyCode == Keys.Delete)
            {
                var mb = MessageBox.Show("De verdad desea eliminar el usuario seleccionado?", "Eliminar Usuario", MessageBoxButtons.OKCancel);

                if (mb == DialogResult.OK)
                {
                    var cell = this.dgwUsuarios.Rows[this.indiceRowEliminar].Cells[0];
                    TrabajarUsuario.delete_usuario(cell.Value.ToString());
                    load_usuarios();
                    actualizar_label_cantidad();
                }
            }
        }

        private void dgwUsuarios_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.indiceRowEliminar = e.RowIndex;
        }

        private void FrmUsuario_Click(object sender, EventArgs e)
        {
            this.indiceRowEliminar = -1;
        }
        private void dgwUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                dgwUsuarios.Rows[e.RowIndex].Tag = e.Value;
                char systemPasswordChar = (new TextBox() { UseSystemPasswordChar = true }).PasswordChar;
                e.Value = new String(systemPasswordChar, e.Value.ToString().Length);
            }
        }
        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar por Nombre Usuario o AyN")
                txtBuscar.Text = "";
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
                txtBuscar.Text = "Buscar por Nombre Usuario o AyN";
        }
        #endregion  

        

    }
}
