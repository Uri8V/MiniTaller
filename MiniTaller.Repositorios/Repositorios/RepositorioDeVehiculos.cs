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
    public class RepositorioDeVehiculos:IRepositorioDeVehiculos
    {
        private readonly string cadenaDeConexion;
        public RepositorioDeVehiculos()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Agregar(Vehiculos vehiculos)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"INSERT INTO Vehiculos (Patente, Kilometros,IdModelo, IdTipoVehiculo,ECU, VIN, PINCode) 
                                    Values (UPPER(@Patente), @Kilometros, @IdModelo, @IdTipoVehiculo, @ECU, @VIN, @PINCode); SELECT SCOPE_IDENTITY();";
                int id = conn.ExecuteScalar<int>(selectQuery, vehiculos);
                vehiculos.IdVehiculo = id;
            }
        }

        public void Borrar(int IdVehiculo)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string deleteQuery = "DELETE FROM Vehiculos WHERE IdVehiculo=@IdVehiculo";
                conn.Execute(deleteQuery, new { IdVehiculo = IdVehiculo });
            }
        }

        public void Editar(Vehiculos vehiculos)
        {
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string updateQuery = @"UPDATE Vehiculos SET Patente=UPPER(@Patente), Kilometros=@Kilometros, IdModelo=@IdModelo, IdTipoVehiculo=@IdTipoVehiculo, ECU=@ECU,VIN=@VIN,PINCode=@PINCode
                WHERE IdVehiculo=@IdVehiculo";
                conn.Execute(updateQuery, vehiculos);
            }
        }

        public bool EstaRelacionada(Vehiculos vehiculos)
        {
            int cantidad= 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT COUNT(*) FROM VehiculosServicios WHERE IdVehiculo = @IdVehiculo";
                cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdVehiculo = vehiculos.IdVehiculo });
            }
            return cantidad> 0;
        }

        public bool Existe(Vehiculos vehiculos)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (vehiculos.IdVehiculo == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Vehiculos 
                            WHERE Patente=@Patente";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { Patente = vehiculos.Patente });
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Vehiculos 
                WHERE Patente=@Patente AND  IdVehiculo!=@IdVehiculo";
                    cantidad = conn.ExecuteScalar<int>(
                        selectQuery, new { Patente = vehiculos.Patente, IdVehiculo = vehiculos.IdVehiculo });
                }
            }
            return cantidad > 0;
        }

        public int GetCantidad(int? IdModelo, int? IdTipoVehiculo)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery;
                if (IdModelo == null && IdTipoVehiculo == null)
                {
                    selectQuery = "SELECT COUNT(*) FROM Vehiculos";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else if (IdModelo == null && IdTipoVehiculo != null)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Vehiculos 
                        WHERE  (IdTipoVehiculo=@IdTipoVehiculo)";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdTipoVehiculo = IdTipoVehiculo });
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Vehiculos 
                        WHERE  (IdModelo=@IdModelo)";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdModelo = IdModelo });
                }
            }
            return cantidad;
        }

        public List<VehiculosComboDto> GetVehiculosCombos()
        {
            List<VehiculosComboDto> lista;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT v.IdVehiculo, CONCAT(UPPER(v.Patente),' | Tipo Vehiculo: ',t.Tipo,' | Modelo: ', m.Modelo,' | VIN: ',v.VIN,' | ECU: ',v.ECU, ' | PIN Code: ',v.PINCode ) AS Info FROM Vehiculos v
                                       INNER JOIN TiposDeVehiculos t ON v.IdTipoVehiculo=t.IdTipoVehiculo
                                       INNER JOIN Modelos m ON m.IdModelo=v.IdModelo
                                       ORDER BY v.Patente";
                lista = conn.Query<VehiculosComboDto>(selectQuery).ToList();

            }
            return lista;
        }

        public Vehiculos GetVehiculosPorId(int IdVehiculo)
        {
            Vehiculos vehiculo = null;
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                string selectQuery = @"SELECT IdVehiculo, Patente, Kilometros, IdTipoVehiculo, IdModelo, ECU,PINCode,VIN 
                    FROM Vehiculos WHERE IdVehiculo=@IdVehiculo";
                vehiculo = conn.QuerySingleOrDefault<Vehiculos>(selectQuery,
                    new { IdVehiculo = IdVehiculo });
            }
            return vehiculo;
        }

        public List<VehiculosDto> GetVehiculosPorPagina(int registrosPorPagina, int paginaActual, int? IdModelo, int? IdTipoVehiculo)
        {
            List<VehiculosDto> lista = new List<VehiculosDto>();
            using (var conn = new SqlConnection(cadenaDeConexion))
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.AppendLine("SELECT");
                selectQuery.AppendLine("v.IdVehiculo,");
                selectQuery.AppendLine("v.Patente,");
                selectQuery.AppendLine("v.Kilometros,");
                selectQuery.AppendLine("v.VIN,");
                selectQuery.AppendLine("v.ECU,");
                selectQuery.AppendLine("v.PINCode,");
                selectQuery.AppendLine("t.Tipo,");
                selectQuery.AppendLine("m.Modelo");
                selectQuery.AppendLine("FROM Vehiculos v");
                selectQuery.AppendLine("INNER JOIN Modelos m ON v.IdModelo = m.IdModelo");
                selectQuery.AppendLine("INNEr JOIN TiposDeVehiculos t ON v.IdTipoVehiculo = t.IdTipoVehiculo");

                if (IdModelo != null || IdTipoVehiculo != null)
                {
                    selectQuery.AppendLine("WHERE  m.IdModelo= @IdModelo OR t.IdTipoVehiculo = @IdTipoVehiculo ");
                }
                selectQuery.AppendLine("ORDER BY v.Patente");
                selectQuery.AppendLine("OFFSET @cantidadRegistros ROWS FETCH NEXT @CantidadPorPagina ROWS ONLY");

                var parametros = new
                {
                    IdModelo,
                    IdTipoVehiculo,
                    cantidadRegistros = registrosPorPagina * (paginaActual - 1),
                    cantidadPorPagina = registrosPorPagina
                };
                lista = conn.Query<VehiculosDto>(selectQuery.ToString(), parametros).ToList();
            }
            return lista;
        }
    }
}
