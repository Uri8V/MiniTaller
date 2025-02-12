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
    public class RepositorioDeTiposDePagos : IRepositorioDeTiposDePagos
    {
        private readonly string cadenaDeConexion;
        public RepositorioDeTiposDePagos()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(TiposDePagos tipo)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string insertQuery = "INSERT INTO TiposDePagos (Tipo) VALUES(@Tipo); SELECT SCOPE_IDENTITY()";
                conn.Open();
                using (var comando = new SqlCommand(insertQuery, conn))
                {
                    comando.Parameters.Add("@Tipo", SqlDbType.NVarChar);
                    comando.Parameters["@Tipo"].Value = tipo.Tipo;

                    int tipoId = Convert.ToInt32(comando.ExecuteScalar());
                    tipo.IdTipoPago = tipoId;
                }
            }
        }

        public void Borrar(int TipoDePagoId)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM TiposDePagos WHERE IdTipoPago=@IdTipoPago";
                    using (var comando = new SqlCommand(deleteQuery, conn))
                    {
                        comando.Parameters.Add("@IdTipoPago", SqlDbType.Int);
                        comando.Parameters["@IdTipoPago"].Value = TipoDePagoId;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Editar(TiposDePagos tipo)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string updateQuery = "UPDATE TiposDePagos SET Tipo=@Tipo WHERE IdTipoPago=@IdTipoPago";
                    using (var comando = new SqlCommand(updateQuery, conn))
                    {
                        comando.Parameters.Add("@Tipo", SqlDbType.NVarChar);
                        comando.Parameters["@Tipo"].Value = tipo.Tipo;

                        comando.Parameters.Add("@IdTipoPago", SqlDbType.Int);
                        comando.Parameters["@IdTipoPago"].Value = tipo.IdTipoPago;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(TiposDePagos tipo)
        {
            int cantidad = 0;
            using (IDbConnection conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM Servicios WHERE IdTipoPago=@IdTipoPago";
                cantidad = conn.QuerySingle<int>(selectQuery, new { IdTipoPago = tipo.IdTipoPago });
            }
            return cantidad > 0;
        }

        public bool Existe(TiposDePagos tipo)
        {
            try
            {
                int cantidad;
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string selectQuery;
                    if (tipo.IdTipoPago == 0)
                    {
                        selectQuery = "SELECT COUNT(*) FROM TiposDePagos WHERE Tipo=@Tipo";
                    }
                    else
                    {
                        selectQuery = "SELECT COUNT(*) FROM TiposDePagos WHERE Tipo=@Tipo AND IdTipoPago!=@IdTipoPago";
                    }
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        comando.Parameters.Add("@Tipo", SqlDbType.NVarChar);
                        comando.Parameters["@Tipo"].Value = tipo.Tipo;

                        if (tipo.IdTipoPago != 0)
                        {
                            comando.Parameters.Add("@IdTipoPago", SqlDbType.Int);
                            comando.Parameters["@IdTipoPago"].Value = tipo.IdTipoPago;
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
                string selectQuery = "SELECT COUNT(*) FROM TiposDepagos";
                cantidad = conn.ExecuteScalar<int>(selectQuery);

            }
            return cantidad;
        }

        public TiposDePagos GetTipoDePagoPorId(int tipoId)
        {
            TiposDePagos tipo = null;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                conn.Open();
                string selectQuery = @"SELECT IdTipoPago,Tipo
                    FROM TiposDePagos WHERE IdTipoPago=@IdTipoPago";

                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add("@IdTipoPago", SqlDbType.Int);
                    cmd.Parameters["@IdTipoPago"].Value = tipoId;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            tipo = ConstruirTipoDePago(reader);
                        }
                    }
                }
            }
            return tipo;
        }

        public List<TiposDePagos> GetTiposDePagos()
        {
            List<TiposDePagos> lista = new List<TiposDePagos>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT IdTipoPago, Tipo FROM TiposDePagos
                         ORDER BY Tipo";
                conn.Open();
                using (var comando = new SqlCommand(selectQuery, conn))
                {
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tipoDePago = ConstruirTipoDePago(reader);
                            lista.Add(tipoDePago);
                        }
                    }
                }
            }
            return lista;
        }

        private TiposDePagos ConstruirTipoDePago(SqlDataReader reader)
        {
            TiposDePagos tipo = new TiposDePagos()
            {
                IdTipoPago = reader.GetInt32(0),
                Tipo = reader.GetString(1)
            };
            return tipo;
        }
    }
}
