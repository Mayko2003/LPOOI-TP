using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace ClasesBase
{
    public class TrabajarVenta
    {

        public static void insert_venta(Venta venta)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            // crear query
            cmd.CommandText = "INSERT INTO Venta(ven_fecha,cli_dni) VALUES(@fecha,@dni)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            
            cmd.Parameters.AddWithValue("@fecha", venta.Ven_Fecha);
            cmd.Parameters.AddWithValue("@dni", venta.Cli_DNI);


            cnn.Open();//abrir conexion
            cmd.ExecuteNonQuery(); //ejecutar transaccion
            cnn.Close(); // cerrar conexion

        }

        public static DataTable list_ventas()
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            // crear query
            cmd.CommandText = "SELECT ven_nro as 'Nro. Venta', ";
            cmd.CommandText += "ven_fecha as 'Fecha', ";
            cmd.CommandText += "cli_dni as 'DNI Cliente' ";
            cmd.CommandText += "FROM Venta";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }

        public static void delete_venta(string venNro)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE FROM Venta WHERE ven_nro LIKE @ven_nro";
            cmd.Parameters.AddWithValue("@ven_nro", venNro);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static DataTable search_ventas(int nro)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            // crear query
            cmd.CommandText = "SELECT ven_nro as 'Nro. Venta', ";
            cmd.CommandText += "ven_fecha as 'Fecha', ";
            cmd.CommandText += "cli_dni as 'DNI Cliente' ";
            cmd.CommandText += "FROM Venta WHERE ven_nro = @ven_nro";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@ven_nro", nro);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
        public static void update_venta(Venta venta)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();


            // crear query
            cmd.CommandText = "UPDATE Venta SET ";
            cmd.CommandText += "cli_dni = @cli_dni, ";
            cmd.CommandText += "ven_fecha = @ven_fecha ";
            cmd.CommandText += "WHERE ven_nro = @ven_nro";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@ven_nro", venta.Ven_Nro);
            cmd.Parameters.AddWithValue("@ven_fecha", venta.Ven_Fecha);
            cmd.Parameters.AddWithValue("@cli_dni", venta.Cli_DNI);

            cnn.Open();

            cmd.ExecuteNonQuery();

            cnn.Close();
        }

        public static int get_current_index()
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            // crear query
            cmd.CommandText = "SELECT ven_nro FROM Venta ORDER BY ven_nro DESC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return Convert.ToInt32(dt.Rows[0][0].ToString());
        }

        public static DataTable filter_by_dni_date(string dni, DateTime start, DateTime end)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            // crear query
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.CommandText = "FiltrarVentaDNIFecha";

            SqlParameter param = new SqlParameter("@dni", SqlDbType.VarChar);
            param.Value = dni;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@start", SqlDbType.DateTime);
            param.Value = start;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@end", SqlDbType.DateTime);
            param.Value = end;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;

        }
    }
}
