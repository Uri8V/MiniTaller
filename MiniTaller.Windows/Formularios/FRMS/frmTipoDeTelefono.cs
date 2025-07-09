using MiniTaller.Entidades.Entidades;
using MiniTaller.Servicio.Interfaces;
using MiniTaller.Servicio.Servicios;
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
    public partial class frmTipoDeTelefono : Form
    {
        public frmTipoDeTelefono()
        {
            InitializeComponent();
            _servicios = new ServicioDeTipoDeTelefono();
            this.WindowState = FormWindowState.Maximized;
        }
        private readonly IServicioDeTipoDeTelefono _servicios;
        private List<TiposDeTelefono> lista;

        private void toolStripButtonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButtonAgregar_Click(object sender, EventArgs e)
        {
            frmTipoDeTelefonoAE frm = new frmTipoDeTelefonoAE();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                TiposDeTelefono nuevoTipo = frm.GetTipoDePago();
                if (!_servicios.Existe(nuevoTipo))
                {
                    _servicios.Guardar(nuevoTipo);
                    MostrarCantidad();
                    MostrarDatosEnGrilla();
                    MessageBox.Show("Tipo de Telefono agregado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El Tipo de Telefono ya existe en la base de Datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            MostrarCantidad();
            lista = _servicios.GetTiposDeTelefono();
            foreach (var tipo in lista)
            {
                DataGridViewRow r = GridHelpers.ConstruirFila(dgvDatos);
                GridHelpers.SetearFila(r, tipo);
                GridHelpers.AgregarFila(dgvDatos, r);
            }
        }

        private void MostrarCantidad()
        {
            txtCantidadTiposTelefono.Text = _servicios.GetCantidad().ToString();
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            TiposDeTelefono tipo = (TiposDeTelefono)r.Tag;
            try
            {
                DialogResult dr = MessageBox.Show($"¿Desea eliminar el Tipo de Telefono: {tipo.Tipo}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                if (!_servicios.EstaRelacionado(tipo))
                {
                    _servicios.Borrar(tipo.IdTipoDeTelefono);
                    GridHelpers.QuitarFila(dgvDatos, r);
                    MostrarCantidad();
                    MessageBox.Show("Registro Borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se puede eliminar el tipo de telefono porque está relacionado con algún Servicio", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            TiposDeTelefono tipo = (TiposDeTelefono)r.Tag;
            TiposDeTelefono tipoCopia = (TiposDeTelefono)tipo.Clone();
            try
            {
                frmTipoDeTelefonoAE frm = new frmTipoDeTelefonoAE();
                frm.SetTipoTelefono(tipo);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel) { return; }
                tipo = frm.GetTipoDePago();
                if (!_servicios.Existe(tipo))
                {
                    _servicios.Guardar(tipo);
                    MostrarDatosEnGrilla();
                    MessageBox.Show("Tipo de telefono editado editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    GridHelpers.SetearFila(r, tipoCopia);
                    MessageBox.Show("el Tipo de Telefono ya existe", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                GridHelpers.SetearFila(r, tipoCopia);
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frmTipoDeTelefono_Load(object sender, EventArgs e)
        {
            MostrarDatosEnGrilla();
        }

    }
}
