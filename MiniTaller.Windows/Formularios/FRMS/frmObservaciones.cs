using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using MiniTaller.Servicio.Interfaces;
using MiniTaller.Servicio.Servicios;
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
    public partial class frmObservaciones: Form
    {
        public frmObservaciones()
        {
            InitializeComponent();
            _servicio = new ServicioDeObservaciones();
            _serviciosClientes = new ServicioDeClientes();
            _serviciosVehiculos = new ServicioDeVehiculos();
            _servicioDeModelos = new ServicioDeModelos();
            _servicioDeMarcas = new ServicioDeMarcas();
        }

        private void toolStripButtonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        string texto = "";
        private List<ObservacionDto> lista;
        private IServicioDeObservaciones _servicio;
        private IServicioDeVehiculos _serviciosVehiculos;
        private IServicioDeClientes _serviciosClientes;
        private IServicioDeModelos _servicioDeModelos;
        private IServicioDeMarcas _servicioDeMarcas;
        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 50;

        int? IdVehiculo = null;
        int? IDMovimiento = null;
        int? IdCliente = null;
        DateTime? fecha = null;

        private void toolStripButtonActualizar_Click(object sender, EventArgs e)
        {
            IdVehiculo = null;
            IDMovimiento = null;
            IdCliente = null;
            fecha = null;
            RecargarGrilla();
            HabilitarBotones();
        }
        private void RecargarGrilla()
        {
            registros = _servicio.GetCantidad(null, null, null);
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            MostrarPaginado();
        }
        private void MostrarPaginado()
        {
            lista = _servicio.GetVehiculoObservacionPorPagina(registrosPorPagina, paginaActual, IdVehiculo, IdCliente, fecha);
            MostrarDatosEnGrilla();
        }
        private void MostrarDatosEnGrilla()
        {
            GridHelpers.LimpiarGrilla(dgvDatos);
            foreach (var item in lista)
            {
                DataGridViewRow r = GridHelpers.ConstruirFila(dgvDatos);
                GridHelpers.SetearFila(r, item);
                r.Cells[4].Value = "Ver Imagenes";
                GridHelpers.AgregarFila(dgvDatos, r);
            }
            lblRegistros.Text = registros.ToString();
            lblPaginas.Text = paginas.ToString();
            lblPaginaActual.Text = paginaActual.ToString();
        }
        private void HabilitarBotones()
        {
            toolStripDropDownButtonFiltrar.BackColor = SystemColors.Control;
            toolStripButtonEditar.Enabled = true;
            toolStripButtonBorrar.Enabled = true;
            toolStripButtonAgregar.Enabled = true;
            toolStripDropDownButtonFiltrar.Enabled = true;
            toolStripTextBox1.Enabled = true;
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
            frmObservacionesAE frm = new frmObservacionesAE();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var observaciones = frm.GetServicio();
            //preguntar si existe
            if (!_servicio.Existe(observaciones))
            {
                _servicio.Guardar(observaciones);
                MessageBox.Show("Observación agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Question);
                registros = _servicio.GetCantidad(null, null, null);
                paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
                MostrarPaginado();
            }
            else
            {
                MessageBox.Show("La observación ya existe!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            ObservacionDto ObservacionABorrar = (ObservacionDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea eliminar la observación ({ObservacionABorrar.Observacion}) del Cliente {ObservacionABorrar.Cliente} con el vehiculo {ObservacionABorrar.Vehiculo}?", "Confirmar Selección", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) { return; }
            var observacion = _servicio.GetVehiculoObservacionPorId(ObservacionABorrar.IdObservacion);
            if (!_servicio.EstaRelacionado(observacion))
            {
                GridHelpers.QuitarFila(dgvDatos, r);
                _servicio.Borrar(ObservacionABorrar.IdObservacion);
                RecargarGrilla(); 
            }
            else
            {
                MessageBox.Show("La observación esta relacionada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            ObservacionDto observacionDto = (ObservacionDto)r.Tag;
            ObservacionDto CopiaObservacion = (ObservacionDto)observacionDto.Clone();

            Observaciones observaciones = _servicio.GetVehiculoObservacionPorId(observacionDto.IdObservacion);
            try
            {
                frmObservacionesAE frm = new frmObservacionesAE() { Text = "Editar Observación" };
                frm.SetServicio(observaciones);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelpers.SetearFila(r, CopiaObservacion);

                    return;
                }
                observaciones = frm.GetServicio();
                if (!_servicio.Existe(observaciones))
                {
                    if (observaciones != null)
                    {
                        Clientes c = _serviciosClientes.GetClientePorId(observaciones.IdCliente);
                        Vehiculos v = _serviciosVehiculos.GetVehiculosPorId(observaciones.IdVehiculo);
                        Modelos m = _servicioDeModelos.GetModelosPorId(v.IdModelo);
                        Marcas ma = _servicioDeMarcas.GetMarcaPorId(m.IdMarca);
                        //Crear el dto
                        observacionDto.IdObservacion = observaciones.IdObservacion;
                        observacionDto.Cliente = string.Concat(c.Apellido,", ",c.Nombre,'|',c.Documento,c.CUIT);
                        observacionDto.Vehiculo = string.Concat(v.Patente," | ", m.Modelo," | ",ma.Marca);
                        observacionDto.Fecha = observaciones.Fecha;
                        GridHelpers.SetearFila(r, observacionDto);
                        _servicio.Guardar(observaciones);
                        RecargarGrilla();
                    }
                    else
                    {
                        //Recupero la copia del dto
                        GridHelpers.SetearFila(r, CopiaObservacion);
                    }
                }
                else
                {
                    MessageBox.Show("La observación ya existe!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                GridHelpers.SetearFila(r, CopiaObservacion);
                MessageBox.Show(ex.Message, "UPS, ALGO SALIO MAL CON LA EDICIÓN", MessageBoxButtons.OK);
            }
        }
        private void DesabilitarBotones()
        {
            toolStripDropDownButtonFiltrar.BackColor = Color.DarkViolet;
            toolStripButtonEditar.Enabled = false;
            toolStripButtonBorrar.Enabled = false;
            toolStripButtonAgregar.Enabled = false;
            toolStripDropDownButtonFiltrar.Enabled = false;
            toolStripTextBox1.Enabled = false;
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
            registros = _servicio.GetCantidad(IdVehiculo, IdCliente, Fecha);
            fecha = Fecha;
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
            registros = _servicio.GetCantidad(vehiculo.IdVehiculo, IdCliente, fecha);
            IdVehiculo = vehiculo.IdVehiculo;
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            paginaActual = formHelper.RetornoPrimerPagina(registrosPorPagina, paginaActual);
            MostrarPaginado();
            DesabilitarBotones();
        }
        private void BuscarCliente(List<ObservacionDto> serviciosVehiculosDto, string texto)
        {
            var listaFiltrada = serviciosVehiculosDto;
            if (texto.Length != 0)
            {
                Func<ObservacionDto, bool> condicion = c => c.Vehiculo.Contains(texto.ToUpper()) || c.Vehiculo.Contains(texto.ToUpper());
                listaFiltrada = serviciosVehiculosDto.Where(condicion).ToList();
            }
            GridHelpers.MostrarDatosEnGrilla<ObservacionDto>(dgvDatos, listaFiltrada);
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            var texto = toolStripTextBox1.Text;
            BuscarCliente(lista, texto);
        }
        private void frmObservaciones_Load(object sender, EventArgs e)
        {
            lista = _servicio.GetVehiculoObservacionPorPagina(registrosPorPagina, paginaActual, IdVehiculo, IdCliente, fecha);
            BuscarCliente(lista, texto);
            RecargarGrilla();
        }
        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (dgvDatos.SelectedRows.Count == 0) { return; }
                var r = dgvDatos.SelectedRows[0];
                ObservacionDto observacion = (ObservacionDto)r.Tag;
                var obser = _servicio.GetVehiculoObservacionPorId(observacion.IdObservacion);
                if (obser is null)
                {
                    return;
                }
                frmImagenes frm = new frmImagenes(obser);
                DialogResult dr = frm.ShowDialog(this);
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.SelectAll();
        }
    }
}
