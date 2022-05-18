using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    class TrabajarUsuario
    {
        public static void insert_usuario(Usuario usuario)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            //crear query
            cmd.CommandText = "INSER INTO Usuario(usu_id,usu_nombreUsuario,usu_contraseña,usu_apellidoNombre,rol_codigo) ";
            cmd.CommandText += "VALUES(@id,@usuario,@contraseña,@apellido_nombre,@cod_rol) ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@id",usuario.Usu_ID);
            cmd.Parameters.AddWithValue("@usuario",usuario.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@contraseña",usuario.Usu_Contraseña);
            cmd.Parameters.AddWithValue("@apellido_nombre",usuario.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@cod_rol", usuario.Rol_Codigo);

            cnn.Open(); //Abrir conexion
            cmd.ExecuteNonQuery(); //Ejecuta transaccion
            cnn.Close(); //cerrar conexion

        }
        public static void update_usuario(Usuario usuario)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE Usuario SET ";
            cmd.CommandText += "usu_nombreUsuario = @usuario, ";
            cmd.CommandText += "usu_contraseña = @contraseña, ";
            cmd.CommandText += "usu_apellidoNombre = @apellido_nombre, ";
            cmd.CommandText += "rol_codigo = @cod_rol ";
            cmd.CommandText += "WHIERE usu_id LIKE @id";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@id", usuario.Usu_ID);
            cmd.Parameters.AddWithValue("@usuario", usuario.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@contraseña", usuario.Usu_Contraseña);
            cmd.Parameters.AddWithValue("@apellid_nombre", usuario.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@cod_rol", usuario.Rol_Codigo);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable list_usuarios()
        {
            //conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT usu_id as 'ID', ";
            cmd.CommandText += "usu_nombreUsuario as 'Usuaio', ";
            cmd.CommandText += "usu_apellidoNombre as 'Apellido y Nombre', ";
            cmd.CommandText += "usu_contraseña as 'Contraseña', ";
            cmd.CommandText += "rol_codigo as 'Codigo Rol', ";
            cmd.CommandText += "U.rol_codigo as 'ROL' ";
            cmd.CommandText += "FROM Usuario as U ";
            cmd.CommandText += "LEFT JOIN Roles as R ON (R.rol_codigo=C.rol_codigo)";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            //ejecutar la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //llenar el data table
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static DataTable search_usuarios(string sPattern)
        {
            //conexion con la base de datos
            SqlConnection cnn = new SqlConnection();

            //operaciones
            SqlCommand cmd = new SqlCommand();

            //centencias de busqueda
            cmd.CommandText = "SELECT usu_id as 'ID', ";
            cmd.CommandText = "usu_nombreUsuario as 'Usuario', ";
            cmd.CommandText = "usu_apellidoNombre as 'Nombre y apellido', ";
            cmd.CommandText = "usu_constraseña as 'Contraseña', ";
            cmd.CommandText = "rol_codigo as 'Codigo Rol', ";
            cmd.CommandText = "U.rol_ccodigo as 'Rol' ";
            cmd.CommandText = "FROM Usuario as U ";
            cmd.CommandText = "LEFT JOIN Roles as R ON (R.rol_codigo=U.rol_codigo) ";
            cmd.CommandText = "WHERE usu_apellidoNombre LIKE @pattern OR usu_usuario LIKE @patern OR usu_id LIKE @pattern";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@pattern", "%" + sPattern + "%");

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static bool existe_usuario(string id)
        {
            //coneccion con la base de datos
            SqlConnection cnn = new SqlConnection();

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECTO * FROM Usuario WHERE usu_id LIKE @id";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0) return false;
            return true;
        }

        public static void delete_usuario(string pk)
        {
            //conexion con la base de datos
            SqlConnection cnn = new SqlConnection();

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE FROM Usuario WHERE usu_id LIKE @id";
            cmd.Parameters.AddWithValue("@id", pk);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
