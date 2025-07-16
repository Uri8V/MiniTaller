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
    public partial class frmServiciosTiposDePago : Form
    {
        public frmServiciosTiposDePago()
        {
            InitializeComponent();
            _servicio = new ServicioDeServiciosTiposDePago();
            _servicioServicio = new ServiciosDeServicios();
            _servicioDeTipoPago = new ServicioDeTipoPago();
            this.WindowState = FormWindowState.Maximized;
        }
        private void toolStripButtonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmServiciosTiposDePago_Load(object sender, EventArgs e)
        {
            lista = _servicio.GetServiciosTiposDePagoPorPagina(registrosPorPagina, paginaActual, IdTipoPago, IdServicio);
            BuscarCliente(lista, texto);
            RecargarGrilla();
        }
        string texto = "";
        private List<ServicioTipoDePagoDto> lista;
        private IServicioDeServiciosTiposDePago _servicio;
        private IServicioDeServicios _servicioServicio;
        private IServicioDeTipoPago _servicioDeTipoPago;
        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 50;

        int? IdTipoPago = null;
        int? IdServicio = null;
        private void toolStripButtonActualizar_Click(object sender, EventArgs e)
        {
            IdTipoPago = null;
            IdServicio = null;
            RecargarGrilla();
            HabilitarBotones();
        }
        private void RecargarGrilla()
        {
            registros = _servicio.GetCantidad(IdTipoPago, IdServicio);
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            MostrarPaginado();
        }
        private void MostrarPaginado()
        {
            lista = _servicio.GetServiciosTiposDePagoPorPagina(registrosPorPagina, paginaActual, IdTipoPago, IdServicio);
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
            frmServiciosTiposDePagoAE frm = new frmServiciosTiposDePagoAE();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            ServicioTipoDePago ServicioTipoDePago = frm.GetServicio();
            if (!_servicio.Existe(ServicioTipoDePago))
            {
                _servicio.Guardar(ServicioTipoDePago);
                MessageBox.Show("Servicio agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Question);
                registros = _servicio.GetCantidad(IdTipoPago, IdServicio);
                paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
                MostrarPaginado();
            }
            else
            {
                MessageBox.Show("El servicio ya existe!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            ServicioTipoDePagoDto ServicioABorrar = (ServicioTipoDePagoDto)r.Tag;
            var servicio = _servicio.GetServicioTipoDePagoPorId(ServicioABorrar.IdServicioTipoDePago);
            DialogResult dr = MessageBox.Show($"¿Desea eliminar el Servicio {ServicioABorrar.servicio} con el precio (${ServicioABorrar.Precio})?", "Confirmar Selección", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) { return; }
            if (!_servicio.EstaRelacionado(servicio))
            {
                GridHelpers.QuitarFila(dgvDatos, r);
                _servicio.Borrar(ServicioABorrar.IdServicioTipoDePago);
                RecargarGrilla();
            }
            else
            {
                MessageBox.Show("El servicio esta relacionado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            ServicioTipoDePagoDto serviciosTipoPagoDto = (ServicioTipoDePagoDto)r.Tag;
            ServicioTipoDePagoDto CopiaServicio = (ServicioTipoDePagoDto)serviciosTipoPagoDto.Clone();

            ServicioTipoDePago servicios = _servicio.GetServicioTipoDePagoPorId(serviciosTipoPagoDto.IdServicioTipoDePago);
            try
            {
                frmServiciosTiposDePagoAE frm = new frmServiciosTiposDePagoAE() { Text = "Editar Servicio" };
                frm.SetServicio(servicios);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelpers.SetearFila(r, CopiaServicio);

                    return;
                }
                servicios = frm.GetServicio();
                if (!_servicio.Existe(servicios))
                {
                    if (servicios != null)
                    {
                        Servicioss s = _servicioServicio.GetServiciosPorId(servicios.IdServicio);
                        TiposDePagos t = _servicioDeTipoPago.GetTipoDePagoPorId(servicios.IdTipoPago);
                        //Crear el dto
                        serviciosTipoPagoDto.IdServicioTipoDePago = servicios.IdServicioTipoDePago;
                        serviciosTipoPagoDto.servicio = _servicioServicio.GetServiciosPorId(servicios.IdServicio).Servicio;
                        serviciosTipoPagoDto.Tipo = _servicioDeTipoPago.GetTipoDePagoPorId(servicios.IdTipoPago).Tipo;
                        serviciosTipoPagoDto.Precio = servicios.Precio;
                        GridHelpers.SetearFila(r, serviciosTipoPagoDto);
                        _servicio.Guardar(servicios);
                        RecargarGrilla();
                    }
                    else
                    {
                        //Recupero la copia del dto
                        GridHelpers.SetearFila(r, servicios);
                    }
                }
                else
                {
                    MessageBox.Show("El servicio ya existe!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void BuscarCliente(List<ServicioTipoDePagoDto> serviciosTipoGastoDto, string texto)
        {
            var listaFiltrada = serviciosTipoGastoDto;
            if (texto.Length != 0)
            {
                Func<ServicioTipoDePagoDto, bool> condicion = c => c.servicio.Contains(texto.ToUpper());
                listaFiltrada = serviciosTipoGastoDto.Where(condicion).ToList();
            }
            GridHelpers.MostrarDatosEnGrilla<ServicioTipoDePagoDto>(dgvDatos, listaFiltrada);
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            var texto = toolStripTextBox1.Text;
            BuscarCliente(lista, texto);
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.SelectAll();
        }

        private void formaDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSeleccionarTipoDePago frm = new frmSeleccionarTipoDePago();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            TiposDePagos tipo = frm.GetTipoPago();
            registros = _servicio.GetCantidad(tipo.IdTipoPago,IdServicio);
            IdTipoPago = tipo.IdTipoPago;
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            paginaActual = formHelper.RetornoPrimerPagina(registrosPorPagina, paginaActual);
            MostrarPaginado();
            DesabilitarBotones();
        }
    }
}
