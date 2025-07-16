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
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }
        private void toolStripButtonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private List<Servicioss> lista;
        private IServicioDeServicios _servicio;
        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 50;


        private void toolStripButtonActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
            HabilitarBotones();
        }

        private void RecargarGrilla()
        {
            registros = _servicio.GetCantidad();
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            MostrarPaginado();
        }

        private void MostrarPaginado()
        {
            lista = _servicio.GetServiciosPorPagina(registrosPorPagina, paginaActual);
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
            toolStripButtonEditar.Enabled = true;
            toolStripButtonBorrar.Enabled = true;
            toolStripButtonAgregar.Enabled = true;
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
            if (!_servicio.Existe(Servicio))
            {
                _servicio.Guardar(Servicio);
                MessageBox.Show("Servicio agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Question);
                registros = _servicio.GetCantidad();
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
            Servicioss ServicioABorrar = (Servicioss)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea eliminar el Servicio: {ServicioABorrar.Servicio} ?", "Confirmar Selección", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) { return; }
            if (!_servicio.EstaRelacionada(ServicioABorrar))
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
            Servicioss Servicio = (Servicioss)r.Tag;
            Servicioss CopiaServicio = (Servicioss)Servicio.Clone();
            try
            {
                frmServiciosAE frm = new frmServiciosAE() { Text = "Editar Servicio" };
                frm.SetServicio(Servicio);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelpers.SetearFila(r, CopiaServicio);
                    return;
                }
                Servicio = frm.GetServicios();
                if (!_servicio.Existe(Servicio))
                {
                    if (Servicio != null)
                    {
                        GridHelpers.SetearFila(r, Servicio);
                        _servicio.Guardar(Servicio);
                        MostrarPaginado();
                        MessageBox.Show("Servicio editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //Recupero la copia del dto
                        GridHelpers.SetearFila(r, Servicio);
                    }
                }
                else
                {
                    GridHelpers.SetearFila(r,CopiaServicio);
                    MessageBox.Show("El Servicio ya existe!!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            toolStripButtonEditar.Enabled = false;
            toolStripButtonBorrar.Enabled = false;
            toolStripButtonAgregar.Enabled = false;
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
            toolStripTextBox1.SelectAll();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            var texto = toolStripTextBox1.Text;
            BuscarCliente(lista, texto);
        }
        private void BuscarCliente(List<Servicioss> serviciosVehiculosDto, string texto)
        {
            var listaFiltrada = serviciosVehiculosDto;
            if (texto.Length != 0)
            {
                Func<Servicioss, bool> condicion = c => c.Servicio.ToUpper().Contains(texto.ToUpper());
                listaFiltrada = serviciosVehiculosDto.Where(condicion).ToList();
            }
            GridHelpers.MostrarDatosEnGrilla<Servicioss>(dgvDatos, listaFiltrada);
        }
    }
}
