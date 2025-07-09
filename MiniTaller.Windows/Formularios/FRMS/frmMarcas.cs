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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniTaller.Windows.Formularios.FRMS
{
    public partial class frmMarcas : Form
    {
        public frmMarcas()
        {
            InitializeComponent();
            _servicios = new ServicioDeMarcas();
            this.WindowState = FormWindowState.Maximized;
        }
        private readonly IServicioDeMarcas _servicios;
        private List<Marcas> lista;

        private void toolStripButtonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void toolStripButtonAgregar_Click(object sender, EventArgs e)
        {
            frmMarcasAE frm = new frmMarcasAE();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Marcas nuevaMarca = frm.GetMarca();
                if (!_servicios.Existe(nuevaMarca))
                {
                    _servicios.Guardar(nuevaMarca);
                    MostrarCantidad();
                    MostrarDatosEnGrilla();
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

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            MostrarCantidad();
            lista = _servicios.GetMarcas();
            foreach (var marca in lista)
            {
                DataGridViewRow r = GridHelpers.ConstruirFila(dgvDatos);
                GridHelpers.SetearFila(r, marca);
                GridHelpers.AgregarFila(dgvDatos, r);
            }
        }

        private void MostrarCantidad()
        {
            txtCantidadMarcas.Text = _servicios.GetCantidad().ToString();
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Marcas marca = (Marcas)r.Tag;
            try
            {
                //Se debe controlar que este relacionada
                DialogResult dr = MessageBox.Show($"¿Desea eliminar la Marca: {marca.Marca}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                if (!_servicios.EstaRelacionado(marca))
                {
                    _servicios.Borrar(marca.IdMarca);
                    GridHelpers.QuitarFila(dgvDatos, r);
                    MostrarCantidad();
                    MessageBox.Show("Registro Borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se puede borrar debido a que esta relacionada con un modelo", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Marcas marca = (Marcas)r.Tag;
            Marcas marcaCopia = (Marcas)marca.Clone();
            try
            {
                frmMarcasAE frm = new frmMarcasAE();
                frm.SetMarca(marca);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel) { return; }
                marca = frm.GetMarca();
                if (!_servicios.Existe(marca))
                {
                    _servicios.Guardar(marca);
                    MostrarDatosEnGrilla();
                    MessageBox.Show("Marca editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    GridHelpers.SetearFila(r, marcaCopia);
                    MessageBox.Show("La marca ya existe", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                GridHelpers.SetearFila(r, marcaCopia);
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


    }
}
