using Dapper;
using MiniTaller.Comun.Interfaces;
using MiniTaller.Entidades.ComboDto;
using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Repositorios.Repositorios
{
    public class RepositorioDeModelos:IRepositorioDeModelos
    {
        private readonly string cadenaDeConexion;
        public RepositorioDeModelos()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Agregar(Modelos modelos)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"INSERT INTO Modelos (Modelo, IdMarca) 
                                    Values (@Modelo, @IdMarca); SELECT SCOPE_IDENTITY();";
                int id = conn.ExecuteScalar<int>(selectQuery, modelos);
                modelos.IdModelo = id;
            }
        }

        public void Borrar(int IdModelo)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string deleteQuery = @"DELETE FROM Modelos WHERE IdModelo=@IdModelo";
                conn.Execute(deleteQuery, new { IdModelo = IdModelo });

            }
        }

        public void Editar(Modelos modelos)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string updateQuery = @"UPDATE Modelos SET Modelo=@Modelo, IdMarca=@IdMarca
                    WHERE IdModelo=@IdModelo";
                conn.Execute(updateQuery, modelos);
            }
        }

        public bool EstaRelacionada(Modelos modelos)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {

                string selectQuery = @"SELECT COUNT(*) FROM Vehiculos WHERE IdModelo=@IdModelo";
                cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdModelo = modelos.IdModelo });
            }
            return cantidad > 0;
        }

        public bool Existe(Modelos modelos)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (modelos.IdModelo == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Modelos 
                            WHERE IdMarca=@IdMarca AND Modelo=@Modelo ";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { IdMarca = modelos.IdMarca, Modelo = modelos.Modelo });
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Modelos 
                WHERE IdMarca=@IdMarca AND Modelo=@Modelo AND IdModelo!=@IdModelo";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { IdMarca = modelos.IdMarca, Modelo = modelos.Modelo, IdModelo = modelos.IdModelo });

                }
            }
            return cantidad > 0;
        }

        public int GetCantidad(int? IdMarca)
        {
            int cantidad = 0;
            string selectQuery;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                if (IdMarca == null)
                {
                    selectQuery = "SELECT COUNT(*) FROM Modelos";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else
                {
                    selectQuery = "SELECT COUNT(*) FROM Modelos WHERE IdMarca=@IdMarca ";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdMarca = IdMarca });
                }
            }
            return cantidad;
        }

        public List<ModelosComboDto> GetModelosCombos()
        {
            List<ModelosComboDto> lista;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT m.IdModelo, CONCAT('modelos: ',m.Modelo,' | Marca: ',ma.Marca) AS Info FROM Modelos m
                        INNER JOIN Marcas ma ON m.IdMarca=ma.IdMarca
                        ORDER BY Modelo";
                lista = conn.Query<ModelosComboDto>(selectQuery).ToList();

            }
            return lista;
        }

        public Modelos GetModelosPorId(int IdModelo)
        {
            Modelos modelos = null;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT IdModelo, Modelo, IdMarca 
                    FROM Modelos WHERE IdModelo=@IdModelo";
                modelos = conn.QuerySingleOrDefault<Modelos>(selectQuery,
                    new { IdModelo = IdModelo });
            }
            return modelos;
        }

        public List<ModelosDto> GetModelosPorPagina(int registrosPorPagina, int paginaActual, int? Idmarca)
        {
            List<ModelosDto> lista = new List<ModelosDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.AppendLine("SELECT m.IdModelo, m.Modelo,ma.Marca");
                selectQuery.AppendLine("FROM Modelos m");
                selectQuery.AppendLine("INNER JOIN Marcas ma ON ma.IdMarca=m.IdMarca");

                if (Idmarca != null)
                {
                    selectQuery.AppendLine("WHERE ma.idMarca = @IdMarca");
                }

                selectQuery.AppendLine("ORDER BY m.Modelo,ma.Marca");
                selectQuery.AppendLine("OFFSET @registrosSaltados ROWS FETCH NEXT @registrosPorPagina ROWS ONLY");

                var parametros = new { Idmarca, registrosSaltados = registrosPorPagina * (paginaActual - 1), registrosPorPagina };

                lista = conn.Query<ModelosDto>(selectQuery.ToString(), parametros).ToList();
                return lista;
            }
        }
    }
}
