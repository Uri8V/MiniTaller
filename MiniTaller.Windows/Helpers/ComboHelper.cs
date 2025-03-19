using MiniTaller.Entidades.Entidades;
using MiniTaller.Entidades;
using MiniTaller.Servicio.Interfaces;
using MiniTaller.Servicio.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniTaller.Servicios.Interfaces;
using MiniTaller.Servicios.Servicios;
using System.Reflection;
using MiniTaller.Entidades.ComboDto;

namespace MiniTaller.Windows.Helpers
{
    public class ComboHelper
    {
        public static void CargarComboTipoDeTelefono(ref ComboBox combo)
        {
            IServicioDeTipoDeTelefono serviciosTiposDeTelefono = new ServicioDeTipoDeTelefono();
            var lista = serviciosTiposDeTelefono.GetTiposDeTelefono();
            var defaultTipo = new TiposDeTelefono()
            {
                IdTipoDeTelefono = 0,
                Tipo = "Seleccione el Tipo de Telefono"
            };
            lista.Insert(0, defaultTipo);
            combo.DataSource = lista;
            combo.DisplayMember = "Tipo";
            combo.ValueMember = "IdTipoDeTelefono";
            combo.SelectedIndex = 0;
        }
        public static void CargarComboTipoCliente(ref ComboBox combo)
        {
            IServicioDeTipoCliente serviciosTipoCliente = new ServicioDeTipoCliente();
            var lista = serviciosTipoCliente.GetTiposDeClientes();
            var defaultPais = new TiposClientes()
            {
                IdTipoCliente = 0,
                Tipo = "Seleccione el Tipo de Cliente"
            };
            lista.Insert(0, defaultPais);
            combo.DataSource = lista;
            combo.DisplayMember = "Tipo";
            combo.ValueMember = "IdTipoCliente";
            combo.SelectedIndex = 0;
        }
        public static void CargarComboTipoDePago(ref ComboBox combo)
        {
            IServicioDeTipoPago serviciosTipoPago = new ServicioDeTipoPago();
            var lista = serviciosTipoPago.GetTiposDePagos();
            var defaultPais = new TiposDePagos()
            {
                IdTipoPago = 0,
                Tipo = "Seleccione el Tipo de Pago"
            };
            lista.Insert(0, defaultPais);
            combo.DataSource = lista;
            combo.DisplayMember = "Tipo";
            combo.ValueMember = "IdTipoPago";
            combo.SelectedIndex = 0;
        }
        public static void CargarComboMarcas(ref ComboBox combo)
        {
            IServicioDeMarcas serviciosMarca = new ServicioDeMarcas();
            var lista = serviciosMarca.GetMarcas();
            var defaultMarca = new Marcas()
            {
                IdMarca = 0,
                Marca = "Seleccione Marca"
            };
            lista.Insert(0, defaultMarca);
            combo.DataSource = lista;
            combo.DisplayMember = "Marca";
            combo.ValueMember = "IdMarca";
            combo.SelectedIndex = 0;
        }
        internal static void CargarComboTipoVehiculo(ref ComboBox combo)
        {
            IServicioDeTipoVehiculo serviciosTipoVehiculo = new ServicioDeTipoVehiculo();
            var lista = serviciosTipoVehiculo.GetTiposDeVehiculo();
            var defaultTipoVehiculo = new TiposDeVehiculos()
            {
                IdTipoVehiculo = 0,
                Tipo = "Seleccione el Tipo de Vehiculo"
            };
            lista.Insert(0, defaultTipoVehiculo);
            combo.DataSource = lista;
            combo.DisplayMember = "Tipo";
            combo.ValueMember = "IdTipoVehiculo";
            combo.SelectedIndex = 0;
        }

        internal static void CargarComboModelo(ref ComboBox combo)
        {
            IServicioDeModelos serviciosModelos = new ServicioDeModelos();
            var lista = serviciosModelos.GetModelosCombos();
            var defaultModelos = new ModelosComboDto()
            {
                IdModelo = 0,
                Info = "Seleccione el Modelo"
            };
            lista.Insert(0, defaultModelos);
            combo.DataSource = lista;
            combo.DisplayMember = "Info";
            combo.ValueMember = "IdModelo";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboClientesPersonas(ref ComboBox combo)
        {
            IServicioDeClientes serviciosClientes = new ServicioDeClientes();
            var lista = serviciosClientes.GetClientesCombos();
            var defaultProveedor = new ClientesComboDto()
            {
                IdCliente = 0,
                Info = "Seleccione Cliente"
            };
            lista.Insert(0, defaultProveedor);
            combo.DataSource = lista;
            combo.DisplayMember = "Info";
            combo.ValueMember = "IdCliente";
            combo.SelectedIndex = 0;
        }
        public static void CargarComboClientesEmpresas(ref ComboBox combo)
        {
            IServicioDeClientes serviciosClientes = new ServicioDeClientes();
            var lista = serviciosClientes.GetClientesCombosEmpresa();
            var defaultProveedor = new ClientesComboDto()
            {
                IdCliente = 0,
                Info = "Seleccione Empresa"
            };
            lista.Insert(0, defaultProveedor);
            combo.DataSource = lista;
            combo.DisplayMember = "Info";
            combo.ValueMember = "IdCliente";
            combo.SelectedIndex = 0;
        }
        internal static void CargarComboVehiculos(ref ComboBox combo)
        {
            IServicioDeVehiculos serviciosVehiculos = new ServicioDeVehiculos();
            var lista = serviciosVehiculos.GetVehiculosCombos();
            var defaultEmpleado = new VehiculosComboDto()
            {
                IdVehiculo = 0,
                Info = "Seleccione el Vehiculo"
            };
            lista.Insert(0, defaultEmpleado);
            combo.DataSource = lista;
            combo.DisplayMember = "Info";
            combo.ValueMember = "IdVehiculo";
            combo.SelectedIndex = 0;
        }

        internal static void CargarComboServicios(ref ComboBox combo)
        {
            IServicioDeServicios serviciosMovimientos = new ServiciosDeServicios();
            var lista = serviciosMovimientos.GetServiciosCombos();
            var defaultEmpleado = new ServiciosComboDto()
            {
                IdServicio = 0,
                Info = "Seleccione el Servicio"
            };
            lista.Insert(0, defaultEmpleado);
            combo.DataSource = lista;
            combo.DisplayMember = "Info";
            combo.ValueMember = "IdServicio";
            combo.SelectedIndex = 0;
        }
        internal static void CargarComboServiciosVehiculos(ref ComboBox combo)
        {
            IServicioDeVehiculosServicios serviciosVehiculos = new ServicioDeVehiculosServicios();
            var lista = serviciosVehiculos.GetServiciosCombo();
            var defaultservicio = new VehiculoServicioComboDto()
            {
                IdVehiculoServicio = 0,
                Info = "Seleccione el Servicio"
            };
            lista.Insert(0, defaultservicio);
            combo.DataSource = lista;
            combo.DisplayMember = "Info";
            combo.ValueMember = "IdVehiculoServicio";
            combo.SelectedIndex = 0;
        }

        internal static void CargarComboObservaciones(ref ComboBox combo)
        {
            IServicioDeObservaciones observaciones = new ServicioDeObservaciones();
            var lista = observaciones.GetObservacionesCombos();
            var defaultservicio = new ObservacionesComboDto()
            {
                IdObservacion = 0,
                Info = "Seleccione la Observacion"
            };
            lista.Insert(0, defaultservicio);
            combo.DataSource = lista;
            combo.DisplayMember = "Info";
            combo.ValueMember = "IdObservacion";
            combo.SelectedIndex = 0;
        }
    }
}
