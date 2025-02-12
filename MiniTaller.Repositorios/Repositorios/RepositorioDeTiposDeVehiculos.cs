using MiniTaller.Comun.Interfaces;
using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;

namespace MiniTaller.Repositorios.Repositorios
{
    public class RepositorioDeTiposDeVehiculos:IRepositorioDeTipoDeVehiculos
    {
        private readonly string cadenaDeConexion;
        public RepositorioDeTiposDeVehiculos()
        {
          cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Agregar(TiposDeVehiculos tipo)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string insertQuery = "INSERT INTO TiposDeVehiculos (Tipo) VALUES(@Tipo); SELECT SCOPE_IDENTITY()";
                conn.Open();
                using (var comando = new SqlCommand(insertQuery, conn))
                {
                    comando.Parameters.Add("@Tipo", SqlDbType.NVarChar);
                    comando.Parameters["@Tipo"].Value = tipo.Tipo;

                    int TipoVehiculoId = Convert.ToInt32(comando.ExecuteScalar());
                    tipo.IdTipoVehiculo = TipoVehiculoId;
                }
            }
        }

        public void Borrar(int TipoDeVehiculoId)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM TiposDeVehiculos WHERE IdTipoVehiculo=@IdTipoVehiculo";
                    using (var comando = new SqlCommand(deleteQuery, conn))
                    {
                        comando.Parameters.Add("@IdTipoVehiculo", SqlDbType.Int);
                        comando.Parameters["@IdTipoVehiculo"].Value = TipoDeVehiculoId;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    

        public void Editar(TiposDeVehiculos tipo)
        {

            try
            {
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string updateQuery = "UPDATE TiposDeVehiculos SET Tipo=@Tipo WHERE IdTipoVehiculo=@IdTipoVehiculo";
                    using (var comando = new SqlCommand(updateQuery, conn))
                    {
                        comando.Parameters.Add("@Tipo", SqlDbType.NVarChar);
                        comando.Parameters["@Tipo"].Value = tipo.Tipo;

                        comando.Parameters.Add("@IdTipoVehiculo", SqlDbType.NVarChar);
                        comando.Parameters["@IdTipoVehiculo"].Value = tipo.IdTipoVehiculo;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(TiposDeVehiculos tipo)
        {
            int cantidad = 0;
            using (IDbConnection conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM Vehiculos WHERE IdTipoVehiculo=@IdTipoVehiculo";
                cantidad = conn.QuerySingle<int>(selectQuery, new { IdTipoVehiculo = tipo.IdTipoVehiculo });
            }
            return cantidad > 0;
        }

        public bool Existe(TiposDeVehiculos tipo)
        {
            try
            {
                int cantidad;
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string selectQuery;
                    if (tipo.IdTipoVehiculo == 0)
                    {
                        selectQuery = "SELECT COUNT(*) FROM TiposDeVehiculos WHERE Tipo=@Tipo";
                    }
                    else
                    {
                        selectQuery = "SELECT COUNT(*) FROM TiposDeVehiculos WHERE Tipo=@Tipo AND IdTipoVehiculo!=@IdTipoVehiculo";
                    }
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        comando.Parameters.Add("@Tipo", SqlDbType.NVarChar);
                        comando.Parameters["@Tipo"].Value = tipo.Tipo;

                        if (tipo.IdTipoVehiculo != 0)
                        {
                            comando.Parameters.Add("@IdTipoVehiculo", SqlDbType.Int);
                            comando.Parameters["@IdTipoVehiculo"].Value = tipo.IdTipoVehiculo;
                        }
                        cantidad = (int)comando.ExecuteScalar();
                    }
                }
                return cantidad > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad()
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM TiposDeVehiculos";
                cantidad = conn.ExecuteScalar<int>(selectQuery); 
            }
            return cantidad;
        }

        public TiposDeVehiculos GetTipoDeVehiculoPorId(int tipoId)
        {
            TiposDeVehiculos tipo = null;
            try
            {
                using (var con = new SqlConnection(cadenaDeConexion))
                {
                    con.Open();
                    string selectQuery = "SELECT IdTipoVehiculo, Tipo FROM TiposDeVehiculos WHERE IdTipoVehiculo=@IdTipoVehiculo";
                    using (var comando = new SqlCommand(selectQuery, con))
                    {
                        comando.Parameters.Add("@IdTipoVehiculo", SqlDbType.Int);
                        comando.Parameters["@IdTipoVehiculo"].Value = tipoId;

                        using (var reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                tipo = ConstruirTipoVehiculo(reader);
                            }
                        }
                    }
                }
                return tipo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TiposDeVehiculos> GetTiposDeVehiculos()
        {
            List<TiposDeVehiculos> lista = new List<TiposDeVehiculos>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT IdTipoVehiculo, Tipo FROM TiposDeVehiculos
                         ORDER BY Tipo";
                conn.Open();
                using (var comando = new SqlCommand(selectQuery, conn))
                {
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tipo = ConstruirTipoVehiculo(reader);
                            lista.Add(tipo);
                        }
                    }
                }
            }
            return lista;
        }

        private TiposDeVehiculos ConstruirTipoVehiculo(SqlDataReader reader)
        {
            TiposDeVehiculos tipo = new TiposDeVehiculos()
            {
                IdTipoVehiculo = reader.GetInt32(0),
                Tipo = reader.GetString(1)
            };
            return tipo;
        }
    }
}
