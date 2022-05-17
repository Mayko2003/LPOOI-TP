using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace ClasesBase
{
    public class TrabajarObraSocial
    {

        public static DataTable list_obra_social()
        {
            // conexion
           SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM ObraSocial";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public static void insert_obraSocial(ObraSocial obraSocial)
        {
            //Conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //Operaciones
            SqlCommand cmd = new SqlCommand();

            //Crear query
            cmd.CommandText = "INSERT INTO ObraSocial(os_cuit,os_razon_social,os_direccion,os_telefono) VALUES(@cuit,@razon,@direccion,@telefono)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@cuit", obraSocial.Os_CUIT);
            cmd.Parameters.AddWithValue("@razon", obraSocial.Os_RazonSocial);
            cmd.Parameters.AddWithValue("@direccion", obraSocial.Os_Direccion);
            cmd.Parameters.AddWithValue("@telefono", obraSocial.Os_Telefono);

            cnn.Open();//abrir conexion
            cmd.ExecuteNonQuery(); //ejecutar transaccion
            cnn.Close(); // cerrar conexion
        }
        public static void update_obraSocial(ObraSocial obraSocial) 
        {
            //Conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //Operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE ObraSocial SET ";
            cmd.CommandText += "os_razon_social = @razon, ";
            cmd.CommandText += "os_direccion = @direccion, ";
            cmd.CommandText += "os_telefono = @telefono ";
            cmd.CommandText += "WHERE os_cuit LIKE @cuit";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@cuit", obraSocial.Os_CUIT);
            cmd.Parameters.AddWithValue("@razon", obraSocial.Os_RazonSocial);
            cmd.Parameters.AddWithValue("@direccion", obraSocial.Os_Direccion);
            cmd.Parameters.AddWithValue("@telefono", obraSocial.Os_Telefono);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static DataTable list_obrasSocial()
        {
            //Conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //Operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT os_cuit as 'CUIT', ";
            cmd.CommandText += "os_razon_social as 'Razon Social', ";
            cmd.CommandText += "os_direccion as 'Direccion', ";
            cmd.CommandText += "os_telefono as 'Telefono' ";
            cmd.CommandText += "FROM ObraSocial as A";
       
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            //ejecutar la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
        public static DataTable search_obrasSocial(string cuitBuscado)
        {
            //Conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //Operaciones
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT os_cuit as 'CUIT', ";
            cmd.CommandText += "os_razon_social as 'Razon Social', ";
            cmd.CommandText += "os_direccion as 'Direccion', ";
            cmd.CommandText += "os_telefono as 'Telefono' ";
            cmd.CommandText += "FROM ObraSocial as A ";

            cmd.CommandText += "WHERE os_cuit LIKE @cuitBuscado";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@cuitBuscado",cuitBuscado);

            //ejecutar la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //llenar el data table
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public static bool exits_cuit(string cuit) 
        {
            //Conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //Operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM ObraSocial WHERE os_cuit LIKE @cuit";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@cuit", cuit);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0) return false;
            return true;
        }
        public static void delete_obraSocial(string pk)
        {
            //Conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //Operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE FROM ObraSocial WHERE os_cuit LIKE @cuit";
            cmd.Parameters.AddWithValue("@cuit", pk);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Determina si hay una obra social con algun cliente
        public static bool exists_cliente_cuit(string cuit) {
            //Conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //Operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM Cliente WHERE os_cuit LIKE @cuit";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@cuit", cuit);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0) return false;
            return true;
        }
    }
}
