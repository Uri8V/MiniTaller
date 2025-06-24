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
    public partial class frmModelos : Form
    {
        public frmModelos()
        {
            InitializeComponent();
            _servicio = new ServicioDeModelos();
            _servicioMarca = new ServicioDeMarcas();
        }
        private List<ModelosDto> lista;
        private IServicioDeModelos _servicio;
        private IServicioDeMarcas _servicioMarca;
        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 50;
        int? marca = null;


        private void toolStripButtonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void toolStripButtonActualizar_Click(object sender, EventArgs e)
        {
            marca = null;
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

        private void frmModelos_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            registros = _servicio.GetCantidad(null);
            paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
            MostrarPaginado();
        }

        private void MostrarPaginado()
        {
            lista = _servicio.GetModelosPorPagina(registrosPorPagina, paginaActual, marca);
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
            frmModelosAE frm = new frmModelosAE();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var modelo = frm.GetModelo();
            if (!_servicio.Existe(modelo))
            {
                _servicio.Guardar(modelo);
                MessageBox.Show("Modelo Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Question);
                registros = _servicio.GetCantidad(null);
                paginas = formHelper.CalcularPaginas(registros, registrosPorPagina);
                MostrarPaginado();
            }
            else
            {
                MessageBox.Show("El modelo ya existe!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            ModelosDto modeloABorrar = (ModelosDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea eliminar el modelo: {modeloABorrar.Modelo}, {modeloABorrar.Marca}?", "Confirmar Selcción", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) { return; }
            Modelos MODELOaborrar = _servicio.GetModelosPorId(modeloABorrar.IdModelo);
            //Falta metodo de objeto relacionado
            if (!_servicio.EstaRelacionada(MODELOaborrar))
            {
                GridHelpers.QuitarFila(dgvDatos, r);
                _servicio.Borrar(modeloABorrar.IdModelo);
                RecargarGrilla();
            }
            else
            {
                MessageBox.Show("El modelo no se puede eliminar porque esta relacionado con algún Vehiculo", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            ModelosDto modeloDto = (ModelosDto)r.Tag;
            ModelosDto CopiaModelo = (ModelosDto)modeloDto.Clone();

            Modelos modelos = _servicio.GetModelosPorId(modeloDto.IdModelo);
            try
            {
                frmModelosAE frm = new frmModelosAE() { Text = "Editar Cliente" };
                frm.SetModelos(modelos);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelpers.SetearFila(r, CopiaModelo);

                    return;
                }
                modelos = frm.GetModelo();
                if (!_servicio.Existe(modelos))
                {
                    if (modelos != null)
                    {
                        //Crear el dto
                        modeloDto.IdModelo = modelos.IdModelo;
                        modeloDto.Modelo = modelos.Modelo;
                        modeloDto.Marca = _servicioMarca.GetMarcaPorId(modelos.IdMarca).Marca;
                        GridHelpers.SetearFila(r, modeloDto);
                        _servicio.Guardar(modelos);
                    }
                    else
                    {
                        //Recupero la copia del dto
                        GridHelpers.SetearFila(r, CopiaModelo);
                    }
                }
                else
                {
                    MessageBox.Show("El modelo ya existe!!!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                GridHelpers.SetearFila(r, CopiaModelo);
                MessageBox.Show(ex.Message, "UPS, ALGO SALIO MAL CON LA EDICIÓN", MessageBoxButtons.OK);
            }
        }
        private void toolStripButtonFiltrar_Click(object sender, EventArgs e)
        {
            frmSeleccionarMarca frm = new frmSeleccionarMarca();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                HabilitarBotones();
                return;
            }
            var MArca = frm.GetMarca();
            registros = _servicio.GetCantidad(MArca.IdMarca);
            marca = MArca.IdMarca;
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

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.SelectAll();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            var texto = toolStripTextBox1.Text;
            BuscarModelos(lista, texto);
        }
        private void BuscarModelos(List<ModelosDto> serviciosVehiculosDto, string texto)
        {
            var listaFiltrada = serviciosVehiculosDto;
            if (texto.Length != 0)
            {
                Func<ModelosDto, bool> condicion = c => c.Modelo.ToUpper().Contains(texto.ToUpper());
                listaFiltrada = serviciosVehiculosDto.Where(condicion).ToList();
            }
            GridHelpers.MostrarDatosEnGrilla<ModelosDto>(dgvDatos, listaFiltrada);
        }
    }
}
