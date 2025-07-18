﻿using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using MiniTaller.Servicios.Interfaces;
using MiniTaller.Servicios.Servicios;
using MiniTaller.Windows.Formularios.FRMSAE;
using MiniTaller.Windows.Formularios.FRMSFILTROS;
using MiniTaller.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniTaller.Windows.Formularios.FRMS
{
    public partial class frmVehiculosServicios : Form
    {
        public frmVehiculosServicios()
        {
            InitializeComponent();
            _servicio = new ServicioDeVehiculosServicios();
            _serviciosClientes = new ServicioDeClientes();
            _serviciosVehiculos = new ServicioDeVehiculos();
            _servicioServicio = new ServiciosDeServicios();
            _servicioDeServiciosTiposDePago = new ServicioDeServiciosTiposDePago();
            this.WindowState = FormWindowState.Maximized;
        }

        private void toolStripButtonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmVehiculosServicios_Load(object sender, EventArgs e)
        {
            lista = _servicio.GetVehiculoServicioPorPagina(registrosPorPagina, paginaActual, IdVehiculo, IDMovimiento, IdCliente, fecha, Yapago);
            BuscarCliente(lista, texto);
            RecargarGrilla();
        }
        string texto = "";
        private List<VehiculosServiciosDto> lista;
        private IServicioDeVehiculosServicios _servicio;
        private IServicioDeVehiculos _serviciosVehiculos;
        private IServicioDeClientes _serviciosClientes;
        private IServicioDeServicios _servicioServicio;
        private IServicioDeServiciosTiposDePago _servicioDeServiciosTiposDePago;
        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 50;

        int? IdVehiculo = null;
        int? IDMovimiento = null;
        int? IdCliente = null;
        DateTime? fecha = null;
        bool? Yapago = null;
        private void toolStripButtonActualizar_Click(object sender, EventArgs e)
        {
            IdVehiculo = null;
            IDMovimiento = null;
            IdCliente = null;
            fecha = null;
            Yapago = null;
            RecargarGrilla();
            HabilitarBotones();
        }
        private void RecargarGrilla()
        {
            registros = _servicio.GetCantidad(IdVehiculo, IDMovimiento, IdCliente, fecha, Yapago);
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            MostrarPaginado();
        }
        private void MostrarPaginado()
        {
            lista = _servicio.GetVehiculoServicioPorPagina(registrosPorPagina, paginaActual, IdVehiculo, IDMovimiento, IdCliente, fecha, Yapago);
            MostrarDatosEnGrilla();
        }
        private void MostrarDatosEnGrilla()
        {
            GridHelpers.LimpiarGrilla(dgvDatos);
            foreach (var item in lista)
            {
                DataGridViewRow r = GridHelpers.ConstruirFila(dgvDatos);
                GridHelpers.SetearFila(r, item);
                r.Cells[8].Value = "Ver Imagenes";
                GridHelpers.AgregarFila(dgvDatos, r);
            }
            lblRegistros.Text = registros.ToString();
            lblPaginas.Text = paginas.ToString();
            lblPaginaActual.Text = paginaActual.ToString();
        }
        private void HabilitarBotones()
        {
            toolStripButton4.BackColor = SystemColors.Control;
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton1.Enabled = true;
            toolStripButton4.Enabled = true;
            toolStripTextBox2.Enabled = true;
            btnAnterior.Enabled = true;
            btnPrimero.Enabled = true;
            btnSiguiente.Enabled = true;
            btnUltimo.Enabled = true;

        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual == paginas)
            {
                return;
            }
            paginaActual++;
            MostrarPaginado();

        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual == 1)
            {
                return;
            }
            paginaActual--;
            MostrarPaginado();
        }
        private void btnUltimo_Click(object sender, EventArgs e)
        {
            paginaActual = paginas;
            MostrarPaginado();
        }
        private void btnPrimero_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            MostrarPaginado();
        }
        private void toolStripButtonAgregar_Click(object sender, EventArgs e)
        {
            frmVehiculosServiciosAE frm = new frmVehiculosServiciosAE();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var VehiculoServicio = frm.GetServicio();
            var ListaServicios = frm.GetListaDeServicios();
            _servicio.Guardar(VehiculoServicio, ListaServicios);
            registros = _servicio.GetCantidad(IdVehiculo, IDMovimiento, IdCliente, fecha, Yapago);
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            MostrarPaginado();
        }
        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            VehiculosServiciosDto ServicioABorrar = (VehiculosServiciosDto)r.Tag;
            var servicio = _servicio.GetVehiculoServicioPorId(ServicioABorrar.IdVehiculoServicio);
            DialogResult dr = MessageBox.Show($"¿Desea eliminar el Servicio {ServicioABorrar.Servicio} del Cliente {ServicioABorrar.Apellido.ToUpper()}, {ServicioABorrar.Nombre} ({ServicioABorrar.Documento} {ServicioABorrar.CUIT}) con el vehiculo de la patente ({ServicioABorrar.Patente}) el cual debe (${ServicioABorrar.DebeServicio})?", "Confirmar Selección", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) { return; }
            if (!_servicio.EstaRelacionado(servicio))
            {
                GridHelpers.QuitarFila(dgvDatos, r);
                _servicio.Borrar(ServicioABorrar.IdVehiculoServicio);
                RecargarGrilla();
            }
            else
            {
                MessageBox.Show("El servicio del vehiculo esta relacionada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            VehiculosServiciosDto vehiculosServiciosDto = (VehiculosServiciosDto)r.Tag;
            VehiculosServiciosDto CopiaServicio = (VehiculosServiciosDto)vehiculosServiciosDto.Clone();

            VehiculosServicios servicios = _servicio.GetVehiculoServicioPorId(vehiculosServiciosDto.IdVehiculoServicio);
            try
            {
                frmVehiculosServiciosAE frm = new frmVehiculosServiciosAE() { Text = "Editar Servicio" };
                frm.SetServicio(servicios);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelpers.SetearFila(r, CopiaServicio);

                    return;
                }
                servicios = frm.GetServicio();

                if (servicios != null)
                {
                    ServicioTipoDePago st = _servicioDeServiciosTiposDePago.GetServicioTipoDePagoPorId(servicios.IdServicioTipoDePago);
                    Servicioss s = _servicioServicio.GetServiciosPorId(st.IdServicio);
                    Clientes c = _serviciosClientes.GetClientePorId(servicios.IdCliente);
                    //Crear el dto
                    vehiculosServiciosDto.IdVehiculoServicio = servicios.IdVehiculoServicio;
                    vehiculosServiciosDto.Patente = _serviciosVehiculos.GetVehiculosPorId(servicios.IdVehiculo).Patente;
                    vehiculosServiciosDto.Servicio = s.Servicio;
                    vehiculosServiciosDto.DebeServicio = st.Precio;
                    vehiculosServiciosDto.Apellido = c.Apellido;
                    vehiculosServiciosDto.Nombre = c.Nombre;
                    vehiculosServiciosDto.CUIT = c.CUIT;
                    vehiculosServiciosDto.Documento = c.Documento;
                    vehiculosServiciosDto.Descripcion = servicios.Descripcion;
                    vehiculosServiciosDto.Debe = servicios.Debe;
                    vehiculosServiciosDto.Haber = servicios.Haber;
                    vehiculosServiciosDto.Fecha = servicios.Fecha;
                    vehiculosServiciosDto.Kilometros = servicios.Kilometros;
                    GridHelpers.SetearFila(r, vehiculosServiciosDto);
                    var lista = frm.GetListaDeServicios();
                    _servicio.Guardar(servicios,lista);
                    RecargarGrilla();
                }
                else
                {
                    //Recupero la copia del dto
                    GridHelpers.SetearFila(r, servicios);
                }
            }
            catch (Exception ex)
            {
                GridHelpers.SetearFila(r, CopiaServicio);
                MessageBox.Show(ex.Message, "UPS, ALGO SALIO MAL CON LA EDICIÓN", MessageBoxButtons.OK);
            }
        }
        private void DesabilitarBotones()
        {
            toolStripButton4.BackColor = Color.DarkViolet;
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = false;
            toolStripButton1.Enabled = false;
            toolStripButton4.Enabled = false;
            toolStripTextBox2.Enabled = false;
            if (paginas == 1)
            {
                btnAnterior.Enabled = false;
                btnPrimero.Enabled = false;
                btnSiguiente.Enabled = false;
                btnUltimo.Enabled = false;
            }
            else
            {
                btnAnterior.Enabled = true;
                btnPrimero.Enabled = true;
                btnSiguiente.Enabled = true;
                btnUltimo.Enabled = true;
            }
        }
        private void fechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSeleccionarFecha frm = new frmSeleccionarFecha();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            DateTime Fecha = frm.GetFecha();
            registros = _servicio.GetCantidad(IdVehiculo, IDMovimiento, IdCliente, Fecha, Yapago);
            fecha = Fecha;
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            paginaActual = formHelper.RetornoPrimerPagina(registrosPorPagina, paginaActual);
            MostrarPaginado();
            DesabilitarBotones();
        }
        private void serviciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSeleccionarServicios frm = new frmSeleccionarServicios();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            ServicioTipoDePago service = frm.GetMovimiento();
            registros = _servicio.GetCantidad(IdVehiculo, service.IdServicioTipoDePago, IdCliente, fecha, Yapago);
            IDMovimiento = service.IdServicioTipoDePago;
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            paginaActual = formHelper.RetornoPrimerPagina(registrosPorPagina, paginaActual);
            MostrarPaginado();
            DesabilitarBotones();
        }
        private void vehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSeleccionarVehiculo frm = new frmSeleccionarVehiculo();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            Vehiculos vehiculo = frm.GetVehiculos();
            registros = _servicio.GetCantidad(vehiculo.IdVehiculo, IDMovimiento, IdCliente, fecha, Yapago);
            IdVehiculo = vehiculo.IdVehiculo;
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            paginaActual = formHelper.RetornoPrimerPagina(registrosPorPagina, paginaActual);
            MostrarPaginado();
            DesabilitarBotones();
        }
        private void BuscarCliente(List<VehiculosServiciosDto> serviciosVehiculosDto, string texto)
        {
            var listaFiltrada = serviciosVehiculosDto;
            if (texto.Length != 0)
            {
                Func<VehiculosServiciosDto, bool> condicion = c => c.Fecha.ToShortDateString().Contains(texto.ToUpper()) || c.Apellido.ToUpper().Contains(texto.ToUpper()) || c.Nombre.ToUpper().Contains(texto.ToUpper()) || c.CUIT.Contains(texto.ToUpper()) || c.Documento.Contains(texto.ToUpper()) || c.Patente.Contains(texto.ToUpper());
                listaFiltrada = serviciosVehiculosDto.Where(condicion).ToList();
            }
            GridHelpers.MostrarDatosEnGrilla<VehiculosServiciosDto>(dgvDatos, listaFiltrada);
        }
        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                if (dgvDatos.SelectedRows.Count == 0) { return; }
                var r = dgvDatos.SelectedRows[0];
                VehiculosServiciosDto VehiSer = (VehiculosServiciosDto)r.Tag;
                var VehiculoServicio = _servicio.GetVehiculoServicioPorId(VehiSer.IdVehiculoServicio);
                if (VehiculoServicio is null)
                {
                    return;
                }
                frmImagenes frm = new frmImagenes(null, VehiculoServicio);
                DialogResult dr = frm.ShowDialog(this);
            }
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            var texto = toolStripTextBox2.Text;
            BuscarCliente(lista, texto);
        }
        private void txtImprimir_Click(object sender, EventArgs e)
        {//Para agregar un documento html que luego va a ser convertido a PDF, debo descargar los paquetes itextSharp y itextSharo.xmlworker
         //Luego debo ir a las propiedades de la capa windows, apretar en Propiedades, recuros, agragamos un recuso ya existente
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            VehiculosServiciosDto vehiculosServiciosDto = (VehiculosServiciosDto)r.Tag;
            try
            {
                frmImprimirServicios frm = new frmImprimirServicios(vehiculosServiciosDto);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel) { return; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UPS, ALGO SALIO MAL CON LA IMPRESIÓN", MessageBoxButtons.OK);
            }
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox2.SelectAll();
        }

        private void serviciosPagadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yapago = true;
            registros = _servicio.GetCantidad(IdVehiculo, IDMovimiento, IdCliente, fecha, Yapago);
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            paginaActual = formHelper.RetornoPrimerPagina(registrosPorPagina, paginaActual);
            MostrarPaginado();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSeleccionarCliente frm = new frmSeleccionarCliente();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var clienteSeleccionado = frm.GetCliente();
            registros = _servicio.GetCantidad(IdVehiculo, IDMovimiento, clienteSeleccionado.IdCliente, fecha, Yapago);
            IdCliente = clienteSeleccionado.IdCliente;
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            paginaActual = formHelper.RetornoPrimerPagina(registrosPorPagina, paginaActual);
            MostrarPaginado();
            DesabilitarBotones();
        }
    }
}
