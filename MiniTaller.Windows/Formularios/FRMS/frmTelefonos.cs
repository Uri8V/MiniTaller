using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using MiniTaller.Servicios.Interfaces;
using MiniTaller.Servicios.Servicios;
using MiniTaller.Windows.Formularios.FRMSAE;
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
    public partial class frmTelefonos : Form
    {
        public frmTelefonos()
        {
            InitializeComponent();
            _servicio = new ServicioDeTelefonos();
            _serviciosClientes = new ServicioDeClientes();
        }
        private List<TelefonosDto> lista;
        private IServicioDeTelefonos _servicio;
        private IServicioDeClientes _serviciosClientes;
        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 3;

        int? empleado = null;
        int? cliente = null;
        string Texto = null;

        private void toolStripButtonActualizar_Click(object sender, EventArgs e)
        {
            empleado = null;
            cliente = null;
            Texto = null;
            RecargarGrilla();
            HabilitarBotones();
        }

        private void RecargarGrilla()
        {
            registros = _servicio.GetCantidad(cliente, Texto);
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            MostrarPaginado();
        }

        private void MostrarPaginado()
        {
            if (empleado != null || cliente != null || Texto != null)
            {
                lista = _servicio.GetTelefonosPorPagina(registrosPorPagina, paginaActual, cliente, Texto);
            }
            else
            {
                lista = _servicio.GetTelefonosPorPagina(registrosPorPagina, paginaActual, cliente, Texto);
            }
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
        private void toolStripButtonCerrar_Click(object sender, EventArgs e)
        {
            Close();
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

        private void frmTelefonos_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }
        private void toolStripButtonAgregar_Click(object sender, EventArgs e)
        {
            frmTelefonosAE frm = new frmTelefonosAE();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var telefono = frm.GetTelefono();
            //preguntar si existe
            if (!_servicio.Existe(telefono))
            {
                _servicio.Guardar(telefono);
                MessageBox.Show("Telefono Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Question);
                registros = _servicio.GetCantidad(null, null);
                paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
                MostrarPaginado();
            }
            else
            {
                MessageBox.Show("El telefono ya existe!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            TelefonosDto telefonoABorrar = (TelefonosDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea eliminar el Telefono: {telefonoABorrar.Apellido} {telefonoABorrar.Nombre}({telefonoABorrar.Documento} {telefonoABorrar.CUIT}), {telefonoABorrar.Telefono}?", "Confirmar Selcción", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) { return; }
            //Falta metodo de objeto relacionado
            GridHelpers.QuitarFila(dgvDatos, r);
            _servicio.Borrar(telefonoABorrar.IdTelefono);
            RecargarGrilla();
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            TelefonosDto telefonoDto = (TelefonosDto)r.Tag;
            TelefonosDto CopiaTelefono = (TelefonosDto)telefonoDto.Clone();

            Telefonos telefono = _servicio.GetTelefonoPorId(telefonoDto.IdTelefono);
            try
            {
                frmTelefonosAE frm = new frmTelefonosAE() { Text = "Editar Vehiculo" };
                frm.SetTelefono(telefono);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelpers.SetearFila(r, CopiaTelefono);

                    return;
                }
                telefono = frm.GetTelefono();
                if (!_servicio.Existe(telefono))
                {
                    if (telefono != null)
                    {
                        //Crear el dto
                        telefonoDto.IdTelefono = telefono.IdTelefono;
                        telefonoDto.Telefono = telefono.Telefono;
                        telefonoDto.TipoTelefono = telefono.TipoTelefono;

                        telefonoDto.Apellido = _serviciosClientes.GetClientePorId(telefono.IdCliente).Apellido;
                        telefonoDto.Nombre = _serviciosClientes.GetClientePorId(telefono.IdCliente).Nombre;
                        telefonoDto.Documento = _serviciosClientes.GetClientePorId(telefono.IdCliente).Documento;

                        GridHelpers.SetearFila(r, telefonoDto);
                        _servicio.Guardar(telefono);
                    }
                    else
                    {
                        //Recupero la copia del dto
                        GridHelpers.SetearFila(r, telefono);

                    }

                }
                else
                {
                    MessageBox.Show("El telefono ya existe!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                GridHelpers.SetearFila(r, CopiaTelefono);
                throw;
            }
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

        //private void tipoDeTelefonoToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmSeleccionarPorNombre frm = new frmSeleccionarPorNombre();
        //    DialogResult dr = frm.ShowDialog(this);
        //    if (dr == DialogResult.Cancel)
        //    {
        //        return;
        //    }
        //    var texto = frm.GetTexto();
        //    registros = _servicio.GetCantidad(null, null, texto);
        //    Texto = texto;
        //    paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
        //    paginaActual = formHelper.RetornoPrimerPagina(registrosPorPagina, paginaActual);
        //    MostrarPaginado();
        //    DesabilitarBotones();
        //}
        private void BuscarCliente(List<TelefonosDto> serviciosVehiculosDto, string texto)
        {
            var listaFiltrada = serviciosVehiculosDto;
            if (texto.Length != 0)
            {
                Func<TelefonosDto, bool> condicion = c => c.Apellido.ToUpper().Contains(texto.ToUpper()) || c.Nombre.ToUpper().Contains(texto.ToUpper()) || c.CUIT.Contains(texto.ToUpper()) || c.Documento.Contains(texto.ToUpper());
                listaFiltrada = serviciosVehiculosDto.Where(condicion).ToList();
            }
            GridHelpers.MostrarDatosEnGrilla<TelefonosDto>(dgvDatos, listaFiltrada);
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
    }
}
