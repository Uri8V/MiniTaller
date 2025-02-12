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
    public partial class frmServicios : Form
    {
        public frmServicios()
        {
            InitializeComponent();
            _servicio = new ServiciosDeServicios();
            _serviciosTipoDePago = new ServicioDeTipoPago();
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }
        private void toolStripButtonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private List<ServiciosDto> lista;
        private IServicioDeServicios _servicio;
        private IServicioDeTipoPago _serviciosTipoDePago;
        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 100;

        int? IdTipoDePago = null;


        private void toolStripButtonActualizar_Click(object sender, EventArgs e)
        {
            IdTipoDePago = null;
            RecargarGrilla();
            HabilitarBotones();
        }

        private void RecargarGrilla()
        {
            registros = _servicio.GetCantidad(null);
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            MostrarPaginado();
        }

        private void MostrarPaginado()
        {
            lista = _servicio.GetServiciosPorPagina(registrosPorPagina, paginaActual, IdTipoDePago);
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelpers.LimpiarGrilla(dgvDatos);
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
            frmServiciosAE frm = new frmServiciosAE();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var Servicio = frm.GetServicios();
            //preguntar si existe
            if (!_servicio.Existe(Servicio))
            {
                _servicio.Guardar(Servicio);
                MessageBox.Show("Servicio agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Question);
                registros = _servicio.GetCantidad(null);
                paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
                MostrarPaginado();
            }
            else
            {
                MessageBox.Show("El Servicio ya existe!!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            ServiciosDto ServicioABorrar = (ServiciosDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea eliminar el Servicio de: {ServicioABorrar.Servicio} del cual debe (${ServicioABorrar.Debe})?", "Confirmar Selección", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) { return; }
            Servicioss Servicioaborrar = _servicio.GetServiciosPorId(ServicioABorrar.IdServicio);
            //Falta metodo de objeto relacionado
            if (!_servicio.EstaRelacionada(Servicioaborrar))
            {
                GridHelpers.QuitarFila(dgvDatos, r);
                _servicio.Borrar(ServicioABorrar.IdServicio);
                RecargarGrilla();
            }
            else
            {
                MessageBox.Show("El Servicio no se puede borrar debido a que esta relacionado con algún Vehiculo ", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            ServiciosDto ServicioDto = (ServiciosDto)r.Tag;
            ServiciosDto CopiaServicio = (ServiciosDto)ServicioDto.Clone();

            Servicioss Servicios = _servicio.GetServiciosPorId(ServicioDto.IdServicio);
            try
            {
                frmServiciosAE frm = new frmServiciosAE() { Text = "Editar Servicio" };
                frm.SetServicio(Servicios);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelpers.SetearFila(r, CopiaServicio);

                    return;
                }
                Servicios = frm.GetServicios();
                if (!_servicio.Existe(Servicios))
                {
                    if (Servicios != null)
                    {
                        //Crear el dto
                        ServicioDto.IdServicio = Servicios.IdServicio;
                        ServicioDto.Servicio = Servicios.Servicio;
                        ServicioDto.Debe = Servicios.Debe;
                        ServicioDto.Tipo = _serviciosTipoDePago.GetTipoDePagoPorId(Servicios.IdTipoPago).Tipo;
                        GridHelpers.SetearFila(r, ServicioDto);
                        _servicio.Guardar(Servicios);
                    }
                    else
                    {
                        //Recupero la copia del dto
                        GridHelpers.SetearFila(r, Servicios);
                    }
                }
                else
                {
                    MessageBox.Show("El Servicio ya existe!!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                GridHelpers.SetearFila(r, CopiaServicio);
                throw;
            }
        }

        private void toolStripButtonFiltrar_Click(object sender, EventArgs e)
        {
            frmSeleccionarTipoDePago frm = new frmSeleccionarTipoDePago();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                HabilitarBotones();
                return;
            }
            var tipoPago = frm.GetTipoPago();
            registros = _servicio.GetCantidad(tipoPago.IdTipoPago);
            IdTipoDePago = tipoPago.IdTipoPago;
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

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "";
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            var texto = toolStripTextBox1.Text;
            BuscarCliente(lista, texto);
        }
        private void BuscarCliente(List<ServiciosDto> serviciosVehiculosDto, string texto)
        {
            var listaFiltrada = serviciosVehiculosDto;
            if (texto.Length != 0)
            {
                Func<ServiciosDto, bool> condicion = c => c.Servicio.ToUpper().Contains(texto.ToUpper());
                listaFiltrada = serviciosVehiculosDto.Where(condicion).ToList();
            }
            GridHelpers.MostrarDatosEnGrilla<ServiciosDto>(dgvDatos, listaFiltrada);
        }
    }
}
