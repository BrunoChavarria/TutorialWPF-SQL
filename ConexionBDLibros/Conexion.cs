using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConexionBDLibros
{    
    public class Conexion
    {
        public SqlConnection Connect = new SqlConnection(@"Server=BRUNO-VBOOK15\SQLEXPRESS;Database=ConexionBDLibros;Trusted_Connection=True");      

        public DataTable listarClientes() 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListarClientes";
            cmd.Connection = Connect;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;        
        }

        public DataTable listarLibros()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListarLibros";
            cmd.Connection = Connect;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable listarPedidos()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListarPedidos";
            cmd.Connection = Connect;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public void NuevoCliente(string nombre, string apellido)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Nombre", SqlDbType.NVarChar);
                param[0].Value = nombre;
                param[1] = new SqlParameter("@Apellido", SqlDbType.NVarChar);
                param[1].Value = apellido;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NuevoCliente";
                cmd.Connection = Connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                MessageBox.Show("Cliente Registrado");
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la insercion");
            }
        }

        public void NuevoLibro(string TituloLibro)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@TituloLibro", SqlDbType.NVarChar);
                param[0].Value = TituloLibro;                

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NuevoLibro";
                cmd.Connection = Connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                MessageBox.Show("Libro Registrado");
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la insercion");
            }
        }

        public void NuevoPedido(string nombre, string apellido, string titulo, int cantidad)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@NombreCliente", SqlDbType.NVarChar);
                param[0].Value = nombre;
                param[1] = new SqlParameter("@ApellidoCliente", SqlDbType.NVarChar);
                param[1].Value = apellido;
                param[2] = new SqlParameter("@TituloLibro", SqlDbType.NVarChar);
                param[2].Value = titulo;
                param[3] = new SqlParameter("@Cantidad", SqlDbType.Int);
                param[3].Value = cantidad;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NuevoPedido";
                cmd.Connection = Connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                MessageBox.Show("Pedido Registrado");
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la insercion");
            }
        }

    }
}
