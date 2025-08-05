using MiniTaller.Entidades.Dtos;
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
            _servicioDetallesVehiculosServicios = new ServicioDeDetallesVehiculosServicios();
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
        private IServicioDeDetallesVehiculosServicios _servicioDetallesVehiculosServicios;
        private IServicioDeVehiculosServicios _servicio;
        private IServicioDeVehiculos _serviciosVehiculos;
        private IServicioDeClientes _serviciosClientes;
        private IServicioDeServicios _servicioServicio;
        private IServicioDeServiciosTiposDePago _servicioDeServiciosTiposDePago;
        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 50;
        List<ServicioTipoDePago> listaServicioTipoDePago = new List<ServicioTipoDePago>();
        List<decimal> listaDePrecios = new List<decimal>();
        VehiculosServicios servicio;
        int? IdVehiculo = null;
        int? IDMovimiento = null;
        int? IdCliente = null;
        DateTime? fecha = null;
        bool? Yapago = null;
        DateTime fechaPago;
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
            servicio = frm.GetServicio();
            listaServicioTipoDePago = frm.GetListaDeServicios();
            listaDePrecios = frm.GetListaDePrecios();
            _servicio.Guardar(servicio, listaServicioTipoDePago, listaDePrecios,null);
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
            DialogResult drtodo = MessageBox.Show($"¿DESEA ELIMINAR TODOS LOS REGISTROS DE ESTE VEHICULO ({ServicioABorrar.Patente}) EN ESTA FECHA {ServicioABorrar.Fecha.ToShortDateString()} DE ESTE CLIENTE {ServicioABorrar.Nombre}, {ServicioABorrar.Apellido} - {ServicioABorrar.CUIT}{ServicioABorrar.Documento}?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (drtodo == DialogResult.Yes)
            {
                if (!_servicio.ExistenImagenesParaVehiculoServicio(servicio.IdVehiculoServicio))
                {
                    _servicioDetallesVehiculosServicios.BorrarTodosLosDetallesPorIdVehiculoFechaYIdCliente(servicio.IdVehiculo, servicio.Fecha, servicio.IdCliente);
                    _servicio.Borrar(ServicioABorrar.IdVehiculoServicio);
                    RecargarGrilla();
                }
                else
                {
                    MessageBox.Show("Este servicio tiene imágenes asociadas. No se puede eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show($"¿Desea eliminar el Servicio {ServicioABorrar.Servicio} del Cliente {ServicioABorrar.Apellido.ToUpper()}, {ServicioABorrar.Nombre} ({ServicioABorrar.Documento} {ServicioABorrar.CUIT}) con el vehiculo de la patente ({ServicioABorrar.Patente}) el cual debe (${ServicioABorrar.Debe})?", "Confirmar Selección", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                bool quedanDetalles = _servicioDetallesVehiculosServicios.ExistenDetallesParaVehiculoServicio(servicio.IdVehiculo, servicio.Fecha, servicio.IdCliente);//Verifico si hay más detalles para que no me aparezca el mensaje de esta realacionado
                if (quedanDetalles)
                {
                    bool tieneImagenes = _servicio.ExistenImagenesParaVehiculoServicio(servicio.IdVehiculoServicio);

                    if (!tieneImagenes)
                    {
                        EliminarDetalle(r, ServicioABorrar, servicio);
                        RecargarGrilla();
                    }
                    else
                    {
                        MessageBox.Show("Este servicio tiene imágenes asociadas. No se puede eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    EliminarDetalle(r, ServicioABorrar, servicio); //Borro el detalle del vehiculo servicio y luego verifico que no queden relaciones, ya que puede haber una imagen
                    if (!_servicio.EstaRelacionado(servicio))
                    {
                        _servicio.Borrar(ServicioABorrar.IdVehiculoServicio);
                        RecargarGrilla();
                    }
                    else
                    {
                        MessageBox.Show("El vehiculo esta relacionado con Imagenes o con Servicios ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
        }

        private void EliminarDetalle(DataGridViewRow r, VehiculosServiciosDto ServicioABorrar, VehiculosServicios servicio)
        {
            var detalles = _servicioDetallesVehiculosServicios.GetDetallesVehiculosServiciosPorIdVehiculoNombreServicioFechaYIdCliente(servicio.IdVehiculo, servicio.Fecha, servicio.IdCliente, ServicioABorrar.Servicio);
            _servicioDetallesVehiculosServicios.Borrar(detalles[0].Id);
            GridHelpers.QuitarFila(dgvDatos, r);
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
            servicio= _servicio.GetVehiculoServicioPorId(vehiculosServiciosDto.IdVehiculoServicio);
          
            DialogResult dr = MessageBox.Show($"¿Desea editar el Servicio {vehiculosServiciosDto.Servicio} del Cliente {vehiculosServiciosDto.Apellido.ToUpper()}, {vehiculosServiciosDto.Nombre} ({vehiculosServiciosDto.Documento} {vehiculosServiciosDto.CUIT}) con el vehiculo de la patente ({vehiculosServiciosDto.Patente}) el cual debe (${vehiculosServiciosDto.Debe})?", "Confirmar Selección", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                listaServicioTipoDePago = _servicioDetallesVehiculosServicios.GetServiciosTipoDePagoPorIdVehiculoNombreServicioFechaYIdCliente(servicio.IdVehiculo, servicio.Fecha, servicio.IdCliente, vehiculosServiciosDto.Servicio);
                listaDePrecios = _servicioDetallesVehiculosServicios.GetPreciosPorIdVehiculoNombreServicioFechaYIdCliente(servicio.IdVehiculo, servicio.Fecha, servicio.IdCliente, vehiculosServiciosDto.Servicio);
                fechaPago = _servicioDetallesVehiculosServicios.GetDetallesVehiculosServiciosPorIdVehiculoNombreServicioFechaYIdCliente(servicio.IdVehiculo,servicio.Fecha,servicio.IdCliente,vehiculosServiciosDto.Servicio)[0].FechaPago;
                try
                {
                    frmVehiculosServiciosAE frm = new frmVehiculosServiciosAE() { Text = "Editar Servicio" };
                    frm.SetServicio(servicio);
                    frm.SetServicios(listaServicioTipoDePago);
                    frm.SetPrecios(listaDePrecios);
                    frm.SetFechaPago(fechaPago);
                    DialogResult drt = frm.ShowDialog(this);
                    if (drt == DialogResult.Cancel)
                    {
                        GridHelpers.SetearFila(r, CopiaServicio);
                        return;
                    }
                    var vehiculosServicios = frm.GetServicio();
                    fechaPago= frm.GetFechaPago();
                    if (vehiculosServicios != null)
                    {
                        listaServicioTipoDePago = frm.GetListaDeServicios();
                        listaDePrecios = frm.GetListaDePrecios();
                        _servicio.Guardar(vehiculosServicios, listaServicioTipoDePago, listaDePrecios, fechaPago);
                        RecargarGrilla();
                    }
                    else
                    {
                        //Recupero la copia del dto
                        GridHelpers.SetearFila(r, servicio);
                    }
                }
                catch (Exception ex)
                {
                    GridHelpers.SetearFila(r, CopiaServicio);
                    MessageBox.Show(ex.Message, "UPS, ALGO SALIO MAL CON LA EDICIÓN", MessageBoxButtons.OK);
                }
             }
            else
            {
                listaServicioTipoDePago = _servicioDetallesVehiculosServicios.GetServiciosTipoDePagoPorIdVehiculoNombreServicioFechaYIdCliente(servicio.IdVehiculo, servicio.Fecha, servicio.IdCliente);
                listaDePrecios= _servicioDetallesVehiculosServicios.GetPreciosPorIdVehiculoNombreServicioFechaYIdCliente(servicio.IdVehiculo, servicio.Fecha, servicio.IdCliente);

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
