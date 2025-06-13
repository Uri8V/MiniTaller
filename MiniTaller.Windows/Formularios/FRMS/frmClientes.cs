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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
            _servicio = new ServicioDeClientes();
            _servicioTipoCliente = new ServicioDeTipoCliente();
        }
        private List<ClientesDto> lista;
        private IServicioDeClientes _servicio;
        private IServicioDeTipoCliente _servicioTipoCliente;
        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 1;

        int? tipo = null;

        private void toolStripButtonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            RcargarGrilla();
        }

        private void RcargarGrilla()
        {
            registros = _servicio.GetCantidad(null);
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            MostrarPaginado();
        }

        private void MostrarPaginado()
        {
            lista = _servicio.GetClientesPorPagina(registrosPorPagina, paginaActual, tipo);
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
            RcargarGrilla();
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
            frmClientesAE frm = new frmClientesAE();
            DialogResult DR = frm.ShowDialog(this);
            if (DR == DialogResult.Cancel)
            {
                return;
            }
            var cliente = frm.GetCliente();
            if (!_servicio.Existe(cliente))
            {
                _servicio.Guardar(cliente);
                registros = _servicio.GetCantidad(null);
                paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
                MostrarPaginado();

            }
            else
            {
                MessageBox.Show("El Cliente ya existe", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            ClientesDto clienteABorrar = (ClientesDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea eliminar el cliente: {clienteABorrar.Apellido}, {clienteABorrar.Nombre}, {clienteABorrar.Documento}?", "Confirmar Selcción", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) { return; }
            Clientes CLIENTEaborrar = _servicio.GetClientePorId(clienteABorrar.IdCliente);
            if (!_servicio.EstaRelacionada(CLIENTEaborrar))
            {
                GridHelpers.QuitarFila(dgvDatos, r);
                _servicio.Borrar(clienteABorrar.IdCliente);
                RcargarGrilla();

            }
            else
            {
                MessageBox.Show("El cliente esta relacionado!!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            ClientesDto clienteDto = (ClientesDto)r.Tag;
            ClientesDto CopiaCliente = (ClientesDto)clienteDto.Clone();

            Clientes clientes = _servicio.GetClientePorId(clienteDto.IdCliente);
            try
            {
                frmClientesAE frm = new frmClientesAE() { Text = "Editar Cliente" };
                frm.SetCliente(clientes);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelpers.SetearFila(r, CopiaCliente);

                    return;
                }
                clientes = frm.GetCliente();
                if (!_servicio.Existe(clientes))
                {
                    if (clientes != null)
                    {
                        //Crear el dto
                        clienteDto.IdCliente = clientes.IdCliente;
                        clienteDto.Nombre = clientes.Nombre;
                        clienteDto.Apellido = clientes.Apellido;
                        clienteDto.Documento = clientes.Documento;
                        clienteDto.Domicilio = clientes.Domicilio;
                        clienteDto.CUIT = clientes.CUIT;
                        clienteDto.Tipo = _servicioTipoCliente.GetTipoClientePorId(clientes.IdTipoCliente).Tipo;
                        GridHelpers.SetearFila(r, clienteDto);
                        _servicio.Guardar(clientes);
                    }
                    else
                    {
                        //Recupero la copia del dto
                        GridHelpers.SetearFila(r, CopiaCliente);
                    }
                }
                else
                {
                    MessageBox.Show("El Cliente ya existe", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                GridHelpers.SetearFila(r, CopiaCliente);
                MessageBox.Show(ex.Message,"UPS, ALGO SALIO MAL CON LA EDICIÓN",MessageBoxButtons.OK);
            }
        }

        private void toolStripButtonFiltrar_Click(object sender, EventArgs e)
        {
            frmSeleccionarTipoCliente frm = new frmSeleccionarTipoCliente();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                HabilitarBotones();
                return;
            }
            var tipoCliente = frm.GetTipoCliente();
            registros = _servicio.GetCantidad(tipoCliente.IdTipoCliente);
            tipo = tipoCliente.IdTipoCliente;
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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

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
        private void BuscarCliente(List<ClientesDto> serviciosVehiculosDto, string texto)
        {
            var listaFiltrada = serviciosVehiculosDto;
            if (texto.Length != 0)
            {
                Func<ClientesDto, bool> condicion = c => c.Apellido.ToUpper().Contains(texto.ToUpper()) || c.Nombre.ToUpper().Contains(texto.ToUpper()) || c.CUIT.Contains(texto.ToUpper()) || c.Documento.Contains(texto.ToUpper());
                listaFiltrada = serviciosVehiculosDto.Where(condicion).ToList();
            }
            GridHelpers.MostrarDatosEnGrilla<ClientesDto>(dgvDatos, listaFiltrada);
        }
    }
}
