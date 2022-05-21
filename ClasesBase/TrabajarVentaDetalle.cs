using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace ClasesBase
{
    public class TrabajarVentaDetalle
    {
        public static void insert_venta_detalle(VentaDetalle vd)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            // crear query
            cmd.CommandText = "INSERT INTO VentaDetalle(ven_nro,prod_codigo,det_precio,det_cantidad,det_total) VALUES(@v_nro,@p_cod,@precio,@cantidad,@total)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@v_nro", vd.Ven_Nro);
            cmd.Parameters.AddWithValue("@p_cod", vd.Prod_Codigo);
            cmd.Parameters.AddWithValue("@precio", vd.Det_Precio);
            cmd.Parameters.AddWithValue("@cantidad", vd.Det_Cantidad);
            cmd.Parameters.AddWithValue("@total", vd.Det_Total);


            cnn.Open();//abrir conexion
            cmd.ExecuteNonQuery(); //ejecutar transaccion
            cnn.Close(); // cerrar conexion

        }


        public static DataTable list_venta_detalle(int venNro)
        {
            // conexion a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            //operaciones
            SqlCommand cmd = new SqlCommand();

            // crear query
            cmd.CommandText = "SELECT det_nro as 'Detalle Nro.', ";
            cmd.CommandText += "ven_nro as 'Venta Nro.', ";
            cmd.CommandText += "prod_codigo as 'Codigo Producto', ";
            cmd.CommandText += "det_precio as 'Precio Unidad', ";
            cmd.CommandText += "det_cantidad as 'Cantidad', ";
            cmd.CommandText += "det_total as 'Total' ";
            cmd.CommandText += "FROM VentaDetalle WHERE ven_nro = @ven_nro";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@ven_nro", venNro);


            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
    }
}
