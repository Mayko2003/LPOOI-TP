using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarCliente
    {

        public static void insert_cliente(Cliente cliente)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            // crear query
            cmd.CommandText = "INSERT INTO Cliente(cli_dni,cli_apellido,cli_nombre,cli_direccion,os_cuit,cli_nro_carnet,cli_estado) VALUES(@dni,@apellido,@nombre,@direccion,@oscuit,@nrocarnet,1)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@dni", cliente.Cli_DNI);
            cmd.Parameters.AddWithValue("@apellido", cliente.Cli_Apellido);
            cmd.Parameters.AddWithValue("@nombre", cliente.Cli_Nombre);
            cmd.Parameters.AddWithValue("@direccion", cliente.Cli_Direccion);
            cmd.Parameters.AddWithValue("@oscuit", cliente.Os_CUIT);
            cmd.Parameters.AddWithValue("@nrocarnet", cliente.Cli_NroCarnet);


            cnn.Open();//abrir conexion
            cmd.ExecuteNonQuery(); //ejecutar transaccion
            cnn.Close(); // cerrar conexion

        }
        public static void update_cliente(Cliente cliente)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE Cliente SET ";
            cmd.CommandText += "cli_apellido = @apellido, ";
            cmd.CommandText += "cli_nombre = @nombre, ";
            cmd.CommandText += "cli_direccion = @direccion, ";
            cmd.CommandText += "cli_nro_carnet = @nrocarnet, ";
            cmd.CommandText += "os_cuit = @oscuit ";
            cmd.CommandText += "WHERE cli_dni LIKE @dni";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@apellido",cliente.Cli_Apellido);
            cmd.Parameters.AddWithValue("@nombre",cliente.Cli_Nombre);
            cmd.Parameters.AddWithValue("@direccion",cliente.Cli_Direccion);
            cmd.Parameters.AddWithValue("@nrocarnet",cliente.Cli_NroCarnet);
            cmd.Parameters.AddWithValue("@oscuit",cliente.Os_CUIT);
            cmd.Parameters.AddWithValue("@dni", cliente.Cli_DNI);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable list_clientes()
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT cli_dni as 'DNI', ";
            cmd.CommandText += "cli_apellido as 'Apellido', ";
            cmd.CommandText += "cli_nombre as 'Nombre', ";
            cmd.CommandText += "cli_direccion as 'Direccion', ";
            cmd.CommandText += "cli_nro_carnet as 'Nro Carnet', ";
            cmd.CommandText += "os_cuit as 'OS Cuit' ";
            cmd.CommandText += "FROM Cliente WHERE cli_estado = 1";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            //ejecutar la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //llenar el data table
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public static DataTable list_clientes_resumen()
        {
        // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM ClienteResumenView";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            //ejecutar la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //llenar el data table
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static DataTable search_clientes(string sPattern)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT cli_dni as 'DNI', ";
            cmd.CommandText += "cli_apellido as 'Apellido', ";
            cmd.CommandText += "cli_nombre as 'Nombre', ";
            cmd.CommandText += "cli_direccion as 'Direccion', ";
            cmd.CommandText += "cli_nro_carnet as 'Nro Carnet', ";
            cmd.CommandText += "C.os_cuit as 'OS Cuit' ";
            cmd.CommandText += "FROM Cliente as C ";
            cmd.CommandText += "LEFT JOIN ObraSocial as OS ON (OS.os_cuit=C.os_cuit) ";
            cmd.CommandText += "WHERE cli_apellido LIKE @pattern OR cli_dni LIKE @pattern OR cli_nombre LIKE @pattern";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@pattern", "%" + sPattern + "%");

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static DataTable seach_cliente_dni(string dni)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT cli_dni as 'DNI', ";
            cmd.CommandText += "cli_apellido as 'Apellido', ";
            cmd.CommandText += "cli_nombre as 'Nombre', ";
            cmd.CommandText += "cli_direccion as 'Direccion', ";
            cmd.CommandText += "cli_nro_carnet as 'Nro Carnet', ";
            cmd.CommandText += "os_cuit as 'OS Cuit' ";
            cmd.CommandText += "FROM Cliente ";
            cmd.CommandText += "WHERE cli_dni = @dni";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@dni", dni);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static bool exist_cliente(string dni)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM Cliente WHERE cli_dni LIKE @dni";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@dni", dni);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            if (dt.Rows.Count == 0) return false;
            return true;
        }

        public static void delete_cliente(string pk)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE Cliente SET cli_estado = 0 WHERE cli_dni = @dni";
            cmd.Parameters.AddWithValue("@dni", pk);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable sort_by(string by, string orden)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "OrdenarClientes";
            cmd.CommandType = CommandType.StoredProcedure;

            //PARAMS para el SP
            SqlParameter param;
            param = new SqlParameter("@by",SqlDbType.VarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = by;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@orden", SqlDbType.VarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = orden;

            cmd.Parameters.Add(param);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }

        public static DataTable filter_by_os(string osCuit)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT cli_dni as 'DNI', ";
            cmd.CommandText += "cli_apellido as 'Apellido', ";
            cmd.CommandText += "cli_nombre as 'Nombre', ";
            cmd.CommandText += "cli_direccion as 'Direccion', ";
            cmd.CommandText += "cli_nro_carnet as 'Nro Carnet', ";
            cmd.CommandText += "C.os_cuit as 'OS Cuit' ";
            cmd.CommandText += "FROM Cliente as C ";
            cmd.CommandText += "WHERE os_cuit = @os_cuit";

            cmd.Parameters.AddWithValue("@os_cuit", osCuit);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
    }
}
