using MiniTaller.Comun.Interfaces;
using MiniTaller.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Servicio.Interfaces
{
    public interface IServicioDeTipoVehiculo
    {
        void Guardar(TiposDeVehiculos tipo);
        void Borrar(int TipoDeVehiculoId);
        bool Existe(TiposDeVehiculos tipo);
        int GetCantidad();
        List<TiposDeVehiculos> GetTiposDeVehiculo();
        bool EstaRelacionado(TiposDeVehiculos tipo);
        TiposDeVehiculos GetTipoDeVehiculoPorId(int tipoId);
    }
}
