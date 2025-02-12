using MiniTaller.Windows.Formularios.FRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniTaller.Windows
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            frmMarcas frm= new frmMarcas();
            frm.ShowDialog(this);
        }

        private void btnTipoDePago_Click(object sender, EventArgs e)
        {
            frmTipoDePago frm= new frmTipoDePago();
            frm.ShowDialog(this);
        }

        private void btnTipoVehiculos_Click(object sender, EventArgs e)
        {
            frmTipoDeVehiculo frm= new frmTipoDeVehiculo();
            frm.ShowDialog(this);
        }

        private void btnTiposClientes_Click(object sender, EventArgs e)
        {
            frmTiposDeClientes frm= new frmTiposDeClientes();
            frm.ShowDialog(this);
        }

        private void btnModelos_Click(object sender, EventArgs e)
        {
            frmModelos frm= new frmModelos();
            frm.ShowDialog(this);
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            frmServicios frm= new frmServicios();
            frm.ShowDialog(this);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes frm= new frmClientes();
            frm.ShowDialog(this);
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            frmVehiculos frm= new frmVehiculos();       
            frm.ShowDialog(this);
        }

        private void btnTelefonos_Click(object sender, EventArgs e)
        {
            frmTelefonos frm= new frmTelefonos();
            frm.ShowDialog(this);
        }
    }
}
