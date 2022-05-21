using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarProducto
    {

        public static void insert_producto(Producto producto)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            // crear query
            cmd.CommandText = "INSERT INTO Producto(prod_codigo,prod_categoria,prod_descripcion,prod_precio) VALUES(@codigo,@categoria,@descripcion,@precio)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@codigo", producto.Prod_Codigo);
            cmd.Parameters.AddWithValue("@categoria", producto.Prod_Categoria);
            cmd.Parameters.AddWithValue("@descripcion",producto.Prod_Descripcion);
            cmd.Parameters.AddWithValue("@precio",producto.Prod_precio);

            cnn.Open();//abrir conexion
            cmd.ExecuteNonQuery(); //ejecutar transaccion
            cnn.Close(); // cerrar conexion

        }

        public static void update_producto(Producto producto)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE Producto SET ";

            cmd.CommandText += "prod_codigo = @codigo, ";
            cmd.CommandText += "prod_categoria = @categoria, ";
            cmd.CommandText += "prod_descripcion = @descripcion, ";
            cmd.CommandText += "prod_precio = @precio ";
           
            cmd.CommandText += "WHERE prod_codigo LIKE @codigo";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@codigo", producto.Prod_Codigo);
            cmd.Parameters.AddWithValue("@categoria", producto.Prod_Categoria);
            cmd.Parameters.AddWithValue("@descripcion", producto.Prod_Descripcion);
            cmd.Parameters.AddWithValue("@precio", producto.Prod_precio);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();     
        }

        public static DataTable list_productos()
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT prod_codigo as 'Codigo', ";
            cmd.CommandText += "prod_categoria as 'Categoria', ";
            cmd.CommandText += "prod_descripcion as 'Descripcion', ";
            cmd.CommandText += "prod_precio as 'Precio' ";
            cmd.CommandText += "FROM Producto as P ";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
             

            //ejecutar la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //llenar el data table
            DataSet ds = new DataSet(); //lo cambie por data Set
            da.Fill(ds); 

            
            return ds.Tables[0];
        }

        public static DataTable search_productos(string codigoBuscado)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT prod_codigo as 'Codigo', ";

            cmd.CommandText += "prod_categoria as 'Categoria', ";
            cmd.CommandText += "prod_descripcion as 'Descripcion', ";
            cmd.CommandText += "prod_precio as 'Precio', ";
            cmd.CommandText += "FROM Producto as P ";
  
            cmd.CommandText += "WHERE prod_codigo LIKE @codigoBuscado";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@codigoBuscado",codigoBuscado);

            //ejecutar la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //llenar el data table
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static bool exist_producto(string codigo)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM Producto WHERE prod_codigo LIKE @codigo";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@codigo", codigo);

            //ejecutar la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //llenar el data table
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0) return false;
            else return true;
        }

    }
}
