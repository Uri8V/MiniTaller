using MiniTaller.Entidades.ComboDto;
using MiniTaller.Entidades.Dtos;
using MiniTaller.Entidades.Entidades;
using MiniTaller.Servicios.Interfaces;
using MiniTaller.Servicios.Servicios;
using MiniTaller.Windows.Formularios.FRMS;
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

namespace MiniTaller.Windows.Formularios.FRMSFILTROS
{
    public partial class frmSeleccionarModelo : Form
    {
        public frmSeleccionarModelo()
        {
            InitializeComponent();
            _sericioDeModelos = new ServicioDeModelos();

        }
        private IServicioDeModelos _sericioDeModelos;
        private void frmSeleccionarModelo_Load(object sender, EventArgs e)
        {
            ComboHelper.CargarComboModelo(ref comboBoxModelo);
        }
        private Modelos modelo;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {
                ModelosComboDto modeloaSeleccionado = (ModelosComboDto)comboBoxModelo.SelectedItem;
                modelo = _sericioDeModelos.GetModelosPorId(modeloaSeleccionado.IdModelo);
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidaDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (comboBoxModelo.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboBoxModelo, "Debe seleccionar un Modelo");
                valido = false;
            }
            return valido;
        }

        private void btnAgregarModelo_Click(object sender, EventArgs e)
        {
            frmModelos frm = new frmModelos();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboModelo(ref comboBoxModelo);
                return;
            }
        }

        internal Modelos GetModelo()
        {
            return modelo;
        }
    }
}

