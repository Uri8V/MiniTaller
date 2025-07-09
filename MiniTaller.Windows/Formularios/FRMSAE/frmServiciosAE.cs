using MiniTaller.Entidades.Entidades;
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

namespace MiniTaller.Windows.Formularios.FRMSAE
{
    public partial class frmServiciosAE : Form
    {
        public frmServiciosAE()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Servicios != null)
            {
                txtServicio.Text = Servicios.Servicio;
            }
        }
        private Servicioss Servicios;
        internal Servicioss GetServicios()
        {
            return Servicios;
        }

        internal void SetServicio(Servicioss Servicios)
        {
            this.Servicios = Servicios;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (Servicios == null)
                {
                    Servicios = new Servicioss();
                }
                Servicios.Servicio = txtServicio.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtServicio.Text))
            {
                valido = false;
                errorProvider1.SetError(txtServicio, "Debe ingresar un Servicio");
            }
            return valido;
        }
    }
}
