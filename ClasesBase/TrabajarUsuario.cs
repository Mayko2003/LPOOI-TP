using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarUsuario
    {

        public static void insert_usuario(Usuario usuario){
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            // crear query
            cmd.CommandText = "INSERT INTO Usuario(usu_nombreUsuario,usu_contrasenia,usu_apellidoNombre,rol_codigo) VALUES(@username,@password,@ayn,@rolcodigo)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@username", usuario.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@password", usuario.Usu_Contraseña);
            cmd.Parameters.AddWithValue("@ayn", usuario.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@rolcodigo", usuario.Rol_Codigo);


            cnn.Open();//abrir conexion
            cmd.ExecuteNonQuery(); //ejecutar transaccion
            cnn.Close(); // cerrar conexion

        }
        public static void update_usuario(Usuario usuario)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE Usuario SET ";
            cmd.CommandText += "usu_nombreUsuario = @username, ";
            cmd.CommandText += "usu_contrasenia = @password, ";
            cmd.CommandText += "usu_apellidoNombre = @ayn, ";
            cmd.CommandText += "rol_codigo = @rolcodigo ";
            cmd.CommandText += "WHERE usu_nombreUsuario LIKE @username";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@username",usuario.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@password",usuario.Usu_Contraseña);
            cmd.Parameters.AddWithValue("@ayn",usuario.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@rolcodigo",usuario.Rol_Codigo);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable list_usuarios()
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT usu_id as 'ID', ";
            cmd.CommandText += "usu_nombreUsuario as 'Nombre Usuario', ";
            cmd.CommandText += "usu_contrasenia as 'Contraseña', ";
            cmd.CommandText += "usu_apellidoNombre as 'Apellido y Nombre', ";
            cmd.CommandText += "R.rol_descripcion as 'Rol' ";
            cmd.CommandText += "FROM Usuario as U ";
            cmd.CommandText += "LEFT JOIN Rol as R ON (R.rol_codigo=U.rol_codigo)";

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
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT usu_id as 'ID', ";
            cmd.CommandText += "usu_nombreUsuario as 'Nombre Usuario', ";
            cmd.CommandText += "usu_contrasenia as 'Contraseña', ";
            cmd.CommandText += "usu_apellidoNombre as 'Apellido y Nombre', ";
            cmd.CommandText += "R.rol_descripcion as 'Rol' ";
            cmd.CommandText += "FROM Usuario as U ";
            cmd.CommandText += "LEFT JOIN Rol as R ON (R.rol_codigo=U.rol_codigo) ";
            cmd.CommandText += "WHERE usu_nombreUsuario LIKE @pattern OR usu_apellidoNombre LIKE @pattern";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@pattern", "%" + sPattern + "%");

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static bool check_credenciales(string username, string password)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM Usuario WHERE usu_nombreUsuario = @username AND usu_contrasenia = @password";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0) return false;
            return true;
        
        }

        public static bool exist_usuario(string nombreUsuario)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM Usuario WHERE usu_nombreUsuario LIKE @username";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@username", nombreUsuario);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            if (dt.Rows.Count == 0) return false;
            return true;
        }

        public static void delete_usuario(string pk)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE FROM Usuario WHERE usu_id = @id";
            cmd.Parameters.AddWithValue("@id", pk);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
