﻿using System;
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
            cmd.CommandText = "INSERT INTO Cliente(cli_dni,cli_apellido,cli_nombre,cli_direccion,os_cuit,cli_nro_carnet) VALUES(@dni,@apellido,@nombre,@direccion,@oscuit,@nrocarnet)";
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
            cmd.CommandText += "C.os_cuit as 'OS Cuit' ";
            cmd.CommandText += "FROM Cliente as C ";
            cmd.CommandText += "LEFT JOIN ObraSocial as OS ON (OS.os_cuit=C.os_cuit)";

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
            cmd.CommandText += "WHERE cli_nombre LIKE @pattern OR cli_dni LIKE @pattern";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@pattern", "%" + sPattern + "%");

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
    }
}
