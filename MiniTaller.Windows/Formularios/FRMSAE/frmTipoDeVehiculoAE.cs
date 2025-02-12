using MiniTaller.Entidades.Entidades;
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
    public partial class frmTipoDeVehiculoAE : Form
    {
        public frmTipoDeVehiculoAE()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipo != null)
            {
                txtTipoVehiculo.Text = tipo.Tipo;
            }
        }
        private TiposDeVehiculos tipo;
        internal TiposDeVehiculos GetTipoVehiculo()
        {
            return tipo;
        }

        internal void SetTipoVehiculo(TiposDeVehiculos tipo)
        {
            this.tipo = tipo;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipo == null)
                {
                    tipo = new TiposDeVehiculos();
                }
                tipo.Tipo = txtTipoVehiculo.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtTipoVehiculo.Text))
            {
                errorProvider1.SetError(txtTipoVehiculo, "Debe ingresar un tipo de vehiculo");
                valido = false;
            }
            return valido;
        }

    }
}
