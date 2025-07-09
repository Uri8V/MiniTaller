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
    public partial class frmSeleccionarServicios : Form
    {
        public frmSeleccionarServicios()
        {
            InitializeComponent();
            _servicioServicio = new ServicioDeServiciosTiposDePago();
        }
        private IServicioDeServiciosTiposDePago _servicioServicio;
        private ServicioTipoDePago service;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {
                service = _servicioServicio.GetServicioTipoDePagoPorId((int)comboServicios.SelectedValue);
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidaDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (comboServicios.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboServicios, "Debe seleccionar un Servicio");
                valido = false;
            }
            return valido;
        }

        private void frmSeleccionarServicios_Load(object sender, EventArgs e)
        {
            ComboHelper.CargarComboServiciosTipoDePago(ref comboServicios);
        }

        private void btnAgregarServicios_Click(object sender, EventArgs e)
        {
            frmServiciosTiposDePago frm = new frmServiciosTiposDePago();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboServiciosTipoDePago(ref comboServicios);
                return;
            }
        }

        internal ServicioTipoDePago GetMovimiento()
        {
            return service;
        }
    }
}
