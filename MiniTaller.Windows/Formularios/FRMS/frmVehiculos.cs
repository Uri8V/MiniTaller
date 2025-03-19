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
    public partial class frmVehiculos : Form
    {
        public frmVehiculos()
        {
            InitializeComponent();
            _servicio= new ServicioDeVehiculos();
            _servicioModelos= new ServicioDeModelos();
            _servicioTipoVehiculo = new ServicioDeTipoVehiculo();
        }
        private List<VehiculosDto> lista;
        private IServicioDeVehiculos _servicio;
        private IServicioDeTipoVehiculo _servicioTipoVehiculo;
        private IServicioDeModelos _servicioModelos;
        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina =1;

        int? tipo = null;
        int? modelo = null;
        private void toolStripButtonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmVehiculos_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            registros = _servicio.GetCantidad(modelo, tipo);
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            MostrarPaginado();
        }

        private void MostrarPaginado()
        {
            lista = _servicio.GetVehiculosPorPagina(registrosPorPagina, paginaActual, modelo, tipo);
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var item in lista)
            {
                DataGridViewRow r = GridHelpers.ConstruirFila(dgvDatos);
                GridHelpers.SetearFila(r, item);
                GridHelpers.AgregarFila(dgvDatos, r);
            }
            lblRegistros.Text = registros.ToString();
            lblPaginas.Text = paginas.ToString();
            lblPaginaActual.Text = paginaActual.ToString();
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

        private void toolStripButtonActualizar_Click(object sender, EventArgs e)
        {
            tipo = null;
            modelo = null;
            RecargarGrilla();
            HabilitarBotones();
        }

        private void HabilitarBotones()
        {
            toolStripButtonFiltrar.BackColor = SystemColors.Control;
            toolStripButtonEditar.Enabled = true;
            toolStripButtonBorrar.Enabled = true;
            toolStripButtonAgregar.Enabled = true;
            toolStripButtonFiltrar.Enabled = true;
            btnAnterior.Enabled = true;
            btnPrimero.Enabled = true;
            btnSiguiente.Enabled = true;
            btnUltimo.Enabled = true;
        }
        private void toolStripButtonAgregar_Click(object sender, EventArgs e)
        {
            frmVehiculosAE frm = new frmVehiculosAE();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var vehiculo = frm.GetVehiculo();
            //preguntar si existe
            if (!_servicio.Existe(vehiculo))
            {
                _servicio.Guardar(vehiculo);
                MessageBox.Show("Vehiculo Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Question);
                RecargarGrilla();
            }
            else
            {
                MessageBox.Show("El vehiculo ya existe!!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            { 
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            VehiculosDto vehiculoABorrar = (VehiculosDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea eliminar el vehiculo: Patente({vehiculoABorrar.Patente}), Modelo:{vehiculoABorrar.Modelo}?", "Confirmar Selcción", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) { return; }
            //Falta metodo de objeto relacionado
            Vehiculos VEHICULOaborrar = _servicio.GetVehiculosPorId(vehiculoABorrar.IdVehiculo);
            if (!_servicio.EstaRelacionada(VEHICULOaborrar))
            {
                GridHelpers.QuitarFila(dgvDatos, r);
                _servicio.Borrar(vehiculoABorrar.IdVehiculo);
                RecargarGrilla();
            }
            else
            {
                MessageBox.Show("El vehiculo esta relacionado!!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            VehiculosDto vehiculoDto = (VehiculosDto)r.Tag;
            VehiculosDto CopiaVehiculo = (VehiculosDto)vehiculoDto.Clone();

            Vehiculos vehiculos = _servicio.GetVehiculosPorId(vehiculoDto.IdVehiculo);
            try
            {
                frmVehiculosAE frm = new frmVehiculosAE() { Text = "Editar Vehiculo" };
                frm.SetVehiculo(vehiculos);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelpers.SetearFila(r, CopiaVehiculo);

                    return;
                }
                vehiculos = frm.GetVehiculo();
                if (!_servicio.Existe(vehiculos))
                {
                    if (vehiculos != null)
                    {
                        //Crear el dto
                        vehiculoDto.IdVehiculo = vehiculos.IdVehiculo;
                        vehiculoDto.Patente = vehiculos.Patente;
                        vehiculoDto.Modelo = _servicioModelos.GetModelosPorId(vehiculos.IdModelo).Modelo;
                        vehiculoDto.Tipo = _servicioTipoVehiculo.GetTipoDeVehiculoPorId(vehiculos.IdTipoVehiculo).Tipo;
                        GridHelpers.SetearFila(r, vehiculoDto);
                        _servicio.Guardar(vehiculos);
                    }
                    else
                    {
                        //Recupero la copia del dto
                        GridHelpers.SetearFila(r, vehiculos);
                    }
                }
                else
                {
                    MessageBox.Show("El vehiculo ya existe!!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                GridHelpers.SetearFila(r, CopiaVehiculo);
                throw;
            }
        }

        private void modeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSeleccionarModelo frm = new frmSeleccionarModelo();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var modeloSeleccionado = frm.GetModelo();
            registros = _servicio.GetCantidad(modeloSeleccionado.IdModelo, null);
            modelo = modeloSeleccionado.IdModelo;
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            paginaActual = formHelper.RetornoPrimerPagina(registrosPorPagina, paginaActual);
            MostrarPaginado();
            DesabilitarBotones();
        }
        private void DesabilitarBotones()
        {
            toolStripButtonFiltrar.BackColor = Color.DarkViolet;
            toolStripButtonEditar.Enabled = false;
            toolStripButtonBorrar.Enabled = false;
            toolStripButtonAgregar.Enabled = false;
            toolStripButtonFiltrar.Enabled = false;
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
        private void tipoDeVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSeleccionarTipoVehiculo frm = new frmSeleccionarTipoVehiculo();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var tipoVehiculoSeleccionado = frm.GetTipoVehiculo();
            registros = _servicio.GetCantidad(null, tipoVehiculoSeleccionado.IdTipoVehiculo);
            tipo = tipoVehiculoSeleccionado.IdTipoVehiculo;
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            paginaActual = formHelper.RetornoPrimerPagina(registrosPorPagina, paginaActual);
            MostrarPaginado();
            DesabilitarBotones();
        }

    }
}
