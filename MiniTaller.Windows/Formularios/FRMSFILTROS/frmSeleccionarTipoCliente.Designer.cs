namespace MiniTaller.Windows.Formularios.FRMSFILTROS
{
    partial class frmSeleccionarTipoCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAgregarTipoCliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTipoCliente = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnAgregarTipoCliente
            // 
            this.btnAgregarTipoCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(140)))), ((int)(((byte)(71)))));
            this.btnAgregarTipoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTipoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnAgregarTipoCliente.Image = global::MiniTaller.Windows.Properties.Resources.add_50px;
            this.btnAgregarTipoCliente.Location = new System.Drawing.Point(585, 27);
            this.btnAgregarTipoCliente.Name = "btnAgregarTipoCliente";
            this.btnAgregarTipoCliente.Size = new System.Drawing.Size(62, 51);
            this.btnAgregarTipoCliente.TabIndex = 1;
            this.btnAgregarTipoCliente.Tag = "Agregar Tipo de Cliente";
            this.btnAgregarTipoCliente.UseVisualStyleBackColor = false;
            this.btnAgregarTipoCliente.Click += new System.EventHandler(this.btnAgregarTipoCliente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Seleccionar el tipo Cliente:";
            // 
            // comboBoxTipoCliente
            // 
            this.comboBoxTipoCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.comboBoxTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboBoxTipoCliente.FormattingEnabled = true;
            this.comboBoxTipoCliente.IntegralHeight = false;
            this.comboBoxTipoCliente.Location = new System.Drawing.Point(251, 37);
            this.comboBoxTipoCliente.MaxDropDownItems = 20;
            this.comboBoxTipoCliente.Name = "comboBoxTipoCliente";
            this.comboBoxTipoCliente.Size = new System.Drawing.Size(328, 32);
            this.comboBoxTipoCliente.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnConfirmar.Location = new System.Drawing.Point(142, 95);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(148, 42);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnCancelar.Location = new System.Drawing.Point(367, 95);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(148, 42);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmSeleccionarTipoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(661, 149);
            this.ControlBox = false;
            this.Controls.Add(this.btnAgregarTipoCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTipoCliente);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(561, 149);
            this.Name = "frmSeleccionarTipoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSeleccionarTipoCliente";
            this.Load += new System.EventHandler(this.frmSeleccionarTipoCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnAgregarTipoCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTipoCliente;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
    }
}