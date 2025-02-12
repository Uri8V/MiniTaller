using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Comun.Interfaces
{
    public interface IRepositorioDeTipoDeVehiculos
    {

        void Agregar(TiposDeVehiculos tipo);
        void Borrar(int TipoDeVehiculoId);
        void Editar(TiposDeVehiculos tipo);
        bool Existe(TiposDeVehiculos tipo);
        int GetCantidad();
        List<TiposDeVehiculos> GetTiposDeVehiculos();
        bool EstaRelacionado(TiposDeVehiculos tipo);
        TiposDeVehiculos GetTipoDeVehiculoPorId(int tipoId);
    }
}
