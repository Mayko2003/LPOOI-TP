using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
            
            cmd.CommandType = CommandType.StoredProcedure; // Sin SP -> Text
            cmd.Connection = cnn;

            /* SIN SP
            cmd.CommandText = "INSERT INTO Producto(prod_codigo,prod_categoria,prod_descripcion,prod_precio) VALUES(@codigo,@categoria,@descripcion,@precio)";
            cmd.Parameters.AddWithValue("@codigo", producto.Prod_Codigo);
            cmd.Parameters.AddWithValue("@categoria", producto.Prod_Categoria);
            cmd.Parameters.AddWithValue("@descripcion",producto.Prod_Descripcion);
            cmd.Parameters.AddWithValue("@precio",producto.Prod_precio);
             */

            //CON SP
            cmd.CommandText = "AgregarProducto";
            SqlParameter param = new SqlParameter("@codigo", SqlDbType.VarChar);
            param.Value = producto.Prod_Codigo;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@categoria", SqlDbType.VarChar);
            param.Value = producto.Prod_Categoria;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@descripcion", SqlDbType.VarChar);
            param.Value = producto.Prod_Descripcion;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@precio", SqlDbType.Decimal, 16) {
                Precision = 16,
                Scale = 2
            };
            param.Value = producto.Prod_precio;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

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
            cmd.CommandType = CommandType.StoredProcedure; // SIN SP-> Text
            cmd.Connection = cnn;

            /* SIN SP
            cmd.CommandText = "UPDATE Producto SET ";

            cmd.CommandText += "prod_codigo = @codigo, ";
            cmd.CommandText += "prod_categoria = @categoria, ";
            cmd.CommandText += "prod_descripcion = @descripcion, ";
            cmd.CommandText += "prod_precio = @precio ";
           
            cmd.CommandText += "WHERE prod_codigo LIKE @codigo";
             
            cmd.Parameters.AddWithValue("@codigo", producto.Prod_Codigo);
            cmd.Parameters.AddWithValue("@categoria", producto.Prod_Categoria);
            cmd.Parameters.AddWithValue("@descripcion", producto.Prod_Descripcion);
            cmd.Parameters.AddWithValue("@precio", producto.Prod_precio);
             
             */

            //CON SP
            cmd.CommandText = "UpdateProducto";

            

            SqlParameter param = new SqlParameter("@codigo", SqlDbType.VarChar);
            param.Value = producto.Prod_Codigo;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@categoria", SqlDbType.VarChar);
            param.Value = producto.Prod_Categoria;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@descripcion", SqlDbType.VarChar);
            param.Value = producto.Prod_Descripcion;
            
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@precio", SqlDbType.Decimal);
            param.Value = producto.Prod_precio;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

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
            cmd.CommandText += "FROM Producto WHERE prod_estado = 1";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
             

            //ejecutar la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //llenar el data table
            DataSet ds = new DataSet(); //lo cambie por data Set
            da.Fill(ds); 

            
            return ds.Tables[0];
        }
        public static DataTable list_productos_resumen()
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM ProductoResumenView";

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
            cmd.CommandText += "prod_precio as 'Precio' ";
            cmd.CommandText += "FROM Producto ";
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

        public static void delete_producto(string codigo)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure; // SIN SP -> Text
            cmd.Connection = cnn;

            /*SIN SP
            cmd.CommandText = "DELETE FROM Producto WHERE prod_codigo = @codigo"
            cmd.Parameters.AddWithValue("@codigo",codigo);
            */

            //CON SP
            cmd.CommandText = "DeleteProducto";
            SqlParameter param = new SqlParameter("@codigo", SqlDbType.VarChar);
            param.Value = codigo;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (SqlException e)
            {
                throw;
            }
            
        }

        public static DataTable sort_by(string by, string orden)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.CommandText = "OrdenarProductos";

            //asignar parametros

            SqlParameter param;
            param = new SqlParameter("@by", SqlDbType.VarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = by;

            cmd.Parameters.Add(param);

            param = new SqlParameter("@orden", SqlDbType.VarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = orden;

            cmd.Parameters.Add(param);

            //crear y retornar data table

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        
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

            cmd.CommandText = "FiltrarProductoDNIFecha";

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
