﻿using MiniTaller.Entidades;
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
    public partial class frmTiposDeClientesAE : Form
    {
        public frmTiposDeClientesAE()
        {
            InitializeComponent();
        }
        private TiposClientes tipo;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipo != null)
            {
                txtTipoDeCliente.Text = tipo.Tipo;
            }
        }
        internal TiposClientes GetTipoDeCliente()
        {
            return tipo;
        }

        internal void SetMarca(TiposClientes tipo)
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
                    tipo = new TiposClientes();
                }
                tipo.Tipo = txtTipoDeCliente.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool validar = true;
            if (string.IsNullOrEmpty(txtTipoDeCliente.Text))
            {
                errorProvider1.SetError(txtTipoDeCliente, " Debe ingresar un Tipo de Cliente");
                validar = false;
            }
            return validar;
        }

    }
}
