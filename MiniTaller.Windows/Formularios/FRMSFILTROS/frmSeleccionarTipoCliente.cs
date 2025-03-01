﻿using MiniTaller.Entidades;
using MiniTaller.Entidades.Entidades;
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
    public partial class frmSeleccionarTipoCliente : Form
    {
        public frmSeleccionarTipoCliente()
        {
            InitializeComponent();
        }
        private TiposClientes tipo;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSeleccionarTipoCliente_Load(object sender, EventArgs e)
        {
            ComboHelper.CargarComboTipoCliente(ref comboBoxTipoCliente);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {
                tipo = (TiposClientes)comboBoxTipoCliente.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidaDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (comboBoxTipoCliente.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboBoxTipoCliente, "Debe seleccionar un Tipo de Cliente");
                valido = false;
            }
            return valido;
        }

        internal TiposClientes GetTipoCliente()
        {
            return tipo;
        }

        private void btnAgregarTipoCliente_Click(object sender, EventArgs e)
        {
            frmTiposDeClientes frm = new frmTiposDeClientes();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                ComboHelper.CargarComboTipoCliente(ref comboBoxTipoCliente);
                return;
            }
        }
    }
}
