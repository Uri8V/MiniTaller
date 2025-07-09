namespace MiniTaller.Windows.Formularios.FRMSFILTROS
{
    partial class frmSeleccionarTipoVehiculo
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
            this.btnAgregarTipoPago = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTipoDeVehiculo = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarTipoPago
            // 
            this.btnAgregarTipoPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(140)))), ((int)(((byte)(71)))));
            this.btnAgregarTipoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTipoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnAgregarTipoPago.Image = global::MiniTaller.Windows.Properties.Resources.add_50px;
            this.btnAgregarTipoPago.Location = new System.Drawing.Point(692, 13);
            this.btnAgregarTipoPago.Name = "btnAgregarTipoPago";
            this.btnAgregarTipoPago.Size = new System.Drawing.Size(62, 51);
            this.btnAgregarTipoPago.TabIndex = 1;
            this.btnAgregarTipoPago.Tag = "Agregar Tipo de Vehiculo";
            this.btnAgregarTipoPago.UseVisualStyleBackColor = false;
            this.btnAgregarTipoPago.Click += new System.EventHandler(this.btnAgregarTipoDeVehiculo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Seleccionar el Tipo de Vehiculo:";
            // 
            // comboBoxTipoDeVehiculo
            // 
            this.comboBoxTipoDeVehiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.comboBoxTipoDeVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoDeVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboBoxTipoDeVehiculo.FormattingEnabled = true;
            this.comboBoxTipoDeVehiculo.IntegralHeight = false;
            this.comboBoxTipoDeVehiculo.Location = new System.Drawing.Point(299, 23);
            this.comboBoxTipoDeVehiculo.MaxDropDownItems = 20;
            this.comboBoxTipoDeVehiculo.Name = "comboBoxTipoDeVehiculo";
            this.comboBoxTipoDeVehiculo.Size = new System.Drawing.Size(387, 32);
            this.comboBoxTipoDeVehiculo.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnConfirmar.Location = new System.Drawing.Point(219, 94);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(149, 45);
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
            this.btnCancelar.Location = new System.Drawing.Point(432, 94);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(147, 45);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmSeleccionarTipoVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(766, 151);
            this.ControlBox = false;
            this.Controls.Add(this.btnAgregarTipoPago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTipoDeVehiculo);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(668, 151);
            this.Name = "frmSeleccionarTipoVehiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSeleccionarTipoVehiculo";
            this.Load += new System.EventHandler(this.frmSeleccionarTipoVehiculo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarTipoPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTipoDeVehiculo;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}