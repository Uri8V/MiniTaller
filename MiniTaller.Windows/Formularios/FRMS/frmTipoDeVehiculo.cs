using MiniTaller.Entidades.Entidades;
using MiniTaller.Servicio.Interfaces;
using MiniTaller.Servicio.Servicios;
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
    public partial class frmTipoDeVehiculo : Form
    {
        public frmTipoDeVehiculo()
        {
            InitializeComponent();
            _servicios = new ServicioDeTipoVehiculo();
            this.WindowState = FormWindowState.Maximized;
        }
        private readonly IServicioDeTipoVehiculo _servicios;
        private List<TiposDeVehiculos> lista;
        private void toolStripButtonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmTipoVehiculo_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            dgvDatos.Rows.Clear();
            MostrarCantidad();
            lista = _servicios.GetTiposDeVehiculo();
            foreach (var tipo in lista)
            {
                DataGridViewRow r = GridHelpers.ConstruirFila(dgvDatos);
                GridHelpers.SetearFila(r, tipo);
                GridHelpers.AgregarFila(dgvDatos, r);
            }
        }

        private void toolStripButtonAgregar_Click(object sender, EventArgs e)
        {
            frmTipoDeVehiculoAE frm = new frmTipoDeVehiculoAE();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                TiposDeVehiculos nuevoTipo = frm.GetTipoVehiculo();
                if (!_servicios.Existe(nuevoTipo))
                {
                    _servicios.Guardar(nuevoTipo);
                    MostrarCantidad();
                    RecargarGrilla();
                    MessageBox.Show("Marca agregado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La Marca ya existe en la base de Datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MostrarCantidad()
        {
            txtCantidadTipos.Text = _servicios.GetCantidad().ToString();
        }
        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            TiposDeVehiculos tipo = (TiposDeVehiculos)r.Tag;
            try
            {
                //Se debe controlar que este relacionada
                DialogResult dr = MessageBox.Show($"¿Desea eliminar el Tipo de Vehiculo: {tipo.Tipo}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                if (!_servicios.EstaRelacionado(tipo))
                {
                    _servicios.Borrar(tipo.IdTipoVehiculo);
                    GridHelpers.QuitarFila(dgvDatos, r);
                    MostrarCantidad();
                    MessageBox.Show("Registro Borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se puede borrar este Tipo de Vehiculo porque está relacionado con algún Vehiculo", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            TiposDeVehiculos tipo = (TiposDeVehiculos)r.Tag;
            TiposDeVehiculos copiaTipo = (TiposDeVehiculos)tipo.Clone(); ;
            try
            {
                frmTipoDeVehiculoAE frm = new frmTipoDeVehiculoAE();
                frm.SetTipoVehiculo(tipo);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel) { return; }
                tipo = frm.GetTipoVehiculo();
                if (!_servicios.Existe(tipo))
                {
                    _servicios.Guardar(tipo);
                    RecargarGrilla();
                    MessageBox.Show("Tipo de Vehiculo editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    GridHelpers.SetearFila(r, copiaTipo);
                    MessageBox.Show("El Tipo de Vehiculo ya existe", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                GridHelpers.SetearFila(r, copiaTipo);
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
