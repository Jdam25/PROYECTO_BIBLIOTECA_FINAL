using PROYECTO_BIBLIOTECA.MODELOS.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_BIBLIOTECA.MODELOS.DAO
{
    public class ClienteDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        public bool InsertarNuevoCliente(Cliente cliente)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO REGISTRAR ");
                sql.Append(" VALUES (@Nombre, @Numero, @Libro,FechaP,FechaE, @Precio); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql.ToString();

                comando.Parameters.Add("@Id", SqlDbType.NVarChar, 20).Value = cliente.Id;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = cliente.Nombre;
                comando.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = cliente.Numero;
                comando.Parameters.Add("@Libro", SqlDbType.NVarChar, 100).Value = cliente.Libro;
                comando.Parameters.Add("@FechaP", SqlDbType.NVarChar, 50).Value = cliente.FechaP;
                comando.Parameters.Add("@FechaE", SqlDbType.NVarChar, 50).Value = cliente.FechaE;
               comando.Parameters.Add("@Precio", SqlDbType.NVarChar, 100).Value = cliente.Precio;
                comando.ExecuteNonQuery();
                MiConexion.Close();
                inserto = true;
            }
            catch (Exception ex)
            {
                inserto = false;
                MiConexion.Close();
            }
            return inserto;
        }

        public DataTable GetClientes()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM REGISTRAR ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql.ToString();

                SqlDataReader dr = comando.ExecuteReader();
                dt.Load(dr);
                MiConexion.Close();
            }
            catch (Exception)
            {
                MiConexion.Close();
            }
            return dt;
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            bool actualizo = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE REGISTRAR ");
                sql.Append(" SET ID = @NOMBRE = @Nombre, NUMERO = @Numero, LIBRO = @Libro, FECHAP= @FechaP, FECHAE= @FechaE, PRECIO= @Precio ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql.ToString();

                comando.Parameters.Add("@Id", SqlDbType.Int).Value = cliente.Id;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 20).Value = cliente.Nombre;
                comando.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = cliente.Numero;
                comando.Parameters.Add("@Libro", SqlDbType.NVarChar, 50).Value = cliente.Libro;
                comando.Parameters.Add("@FechaP", SqlDbType.NVarChar, 100).Value = cliente.FechaP;
                comando.Parameters.Add("@FechaE", SqlDbType.NVarChar, 100).Value = cliente.FechaE;


                comando.ExecuteNonQuery();
                MiConexion.Close();
                actualizo = true;
            }
            catch (Exception ex)
            {
                actualizo = false;
                MiConexion.Close();
            }
            return actualizo;
        }



        public bool EliminarCliente(int id)
        {
            bool elimino = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM REGISTRAR ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql.ToString();

                comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                comando.ExecuteNonQuery();
                elimino = true;
                MiConexion.Close();

            }
            catch (Exception ex)
            {
                elimino = false;
                MiConexion.Close();
            }
            return elimino;
        }

       

        public Cliente GetClientePorIdentidad(string identidad)
        {
            Cliente cliente = new Cliente();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM REGISTRAR ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                //comando.Parameters.Add("@Id", SqlDbType.NVarChar, 20).Value = Id;
                SqlDataReader dr = comando.ExecuteReader();

                if (dr.Read())
                {
                    cliente.Id = (int)dr["ID"];
                    //cliente.Identidad = (string)dr["IDENTIDAD"];
                    cliente.Nombre = (string)dr["NOMBRE"];
                    cliente.Numero = (string)dr["NUMERO"];
                    cliente.Libro = (string)dr["LIBRO"];
                    cliente.FechaP = (string)dr["FECHAP"];
                    cliente.FechaE = (string)dr["FECHAE"];
                    cliente.Precio = (string)dr["PRECIO"];
                }

                MiConexion.Close();

            }
            catch (Exception ex)
            {

            }
            return cliente;
        }

        public DataTable GetClientesPorNombre(string nombre)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM REGISTRAR WHERE NOMBRE LIKE ('%" + nombre + "%') ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                SqlDataReader dr = comando.ExecuteReader();
                dt.Load(dr);
                MiConexion.Close();
            }
            catch (Exception)
            {
                MiConexion.Close();
            }
            return dt;
        }
    }
}