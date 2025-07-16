namespace MiniTaller.Windows.Formularios.FRMSAE
{
    partial class frmVehiculosAE
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
            this.btnAgregarTipoVehiculo = new System.Windows.Forms.Button();
            this.btnAgregarModelo = new System.Windows.Forms.Button();
            this.comboTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.comboModelo = new System.Windows.Forms.ComboBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtKilometros = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtECU = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVIN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPINCODE = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarTipoVehiculo
            // 
            this.btnAgregarTipoVehiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(191)))), ((int)(((byte)(96)))));
            this.btnAgregarTipoVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTipoVehiculo.Image = global::MiniTaller.Windows.Properties.Resources.add_50px;
            this.btnAgregarTipoVehiculo.Location = new System.Drawing.Point(861, 254);
            this.btnAgregarTipoVehiculo.Name = "btnAgregarTipoVehiculo";
            this.btnAgregarTipoVehiculo.Size = new System.Drawing.Size(76, 58);
            this.btnAgregarTipoVehiculo.TabIndex = 8;
            this.btnAgregarTipoVehiculo.Tag = "Agregar Tipo de Vehiculo";
            this.btnAgregarTipoVehiculo.UseVisualStyleBackColor = false;
            this.btnAgregarTipoVehiculo.Click += new System.EventHandler(this.btnAgregarTipoVehiculo_Click);
            // 
            // btnAgregarModelo
            // 
            this.btnAgregarModelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(191)))), ((int)(((byte)(96)))));
            this.btnAgregarModelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarModelo.Image = global::MiniTaller.Windows.Properties.Resources.add_50px;
            this.btnAgregarModelo.Location = new System.Drawing.Point(861, 163);
            this.btnAgregarModelo.Name = "btnAgregarModelo";
            this.btnAgregarModelo.Size = new System.Drawing.Size(76, 58);
            this.btnAgregarModelo.TabIndex = 6;
            this.btnAgregarModelo.Tag = "Agregar Modelo";
            this.btnAgregarModelo.UseVisualStyleBackColor = false;
            this.btnAgregarModelo.Click += new System.EventHandler(this.btnAgregarModelo_Click);
            // 
            // comboTipoVehiculo
            // 
            this.comboTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.comboTipoVehiculo.FormattingEnabled = true;
            this.comboTipoVehiculo.IntegralHeight = false;
            this.comboTipoVehiculo.Location = new System.Drawing.Point(365, 262);
            this.comboTipoVehiculo.Name = "comboTipoVehiculo";
            this.comboTipoVehiculo.Size = new System.Drawing.Size(490, 37);
            this.comboTipoVehiculo.TabIndex = 7;
            // 
            // comboModelo
            // 
            this.comboModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.comboModelo.FormattingEnabled = true;
            this.comboModelo.IntegralHeight = false;
            this.comboModelo.Location = new System.Drawing.Point(268, 171);
            this.comboModelo.MaxDropDownItems = 25;
            this.comboModelo.Name = "comboModelo";
            this.comboModelo.Size = new System.Drawing.Size(587, 37);
            this.comboModelo.TabIndex = 5;
            // 
            // txtPatente
            // 
            this.txtPatente.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtPatente.Location = new System.Drawing.Point(223, 11);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(259, 35);
            this.txtPatente.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(355, 29);
            this.label4.TabIndex = 14;
            this.label4.Text = "Seleccione el Tipo de Vehiculo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 29);
            this.label2.TabIndex = 15;
            this.label2.Text = "Seleccione el Modelo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 29);
            this.label1.TabIndex = 17;
            this.label1.Text = "Ingrese la Patente:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(59)))), ((int)(((byte)(53)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnCancelar.Location = new System.Drawing.Point(572, 346);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(169, 64);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(166)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnConfirmar.Location = new System.Drawing.Point(236, 346);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(169, 64);
            this.btnConfirmar.TabIndex = 9;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtKilometros
            // 
            this.txtKilometros.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtKilometros.Location = new System.Drawing.Point(756, 11);
            this.txtKilometros.Name = "txtKilometros";
            this.txtKilometros.Size = new System.Drawing.Size(181, 35);
            this.txtKilometros.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(501, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 29);
            this.label3.TabIndex = 24;
            this.label3.Text = "Ingrese el Kilometraje";
            // 
            // txtECU
            // 
            this.txtECU.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtECU.Location = new System.Drawing.Point(191, 59);
            this.txtECU.Name = "txtECU";
            this.txtECU.Size = new System.Drawing.Size(321, 35);
            this.txtECU.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 29);
            this.label5.TabIndex = 26;
            this.label5.Text = "Ingrese la ECU:";
            // 
            // txtVIN
            // 
            this.txtVIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtVIN.Location = new System.Drawing.Point(184, 106);
            this.txtVIN.Name = "txtVIN";
            this.txtVIN.Size = new System.Drawing.Size(328, 35);
            this.txtVIN.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(8, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 29);
            this.label6.TabIndex = 28;
            this.label6.Text = "Ingrese la VIN:";
            // 
            // txtPINCODE
            // 
            this.txtPINCODE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtPINCODE.Location = new System.Drawing.Point(758, 84);
            this.txtPINCODE.Name = "txtPINCODE";
            this.txtPINCODE.Size = new System.Drawing.Size(179, 35);
            this.txtPINCODE.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(515, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(237, 29);
            this.label7.TabIndex = 30;
            this.label7.Text = "Ingrese el PIN Code:";
            // 
            // frmVehiculosAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(41)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(949, 423);
            this.ControlBox = false;
            this.Controls.Add(this.txtPINCODE);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtVIN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtECU);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtKilometros);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAgregarTipoVehiculo);
            this.Controls.Add(this.btnAgregarModelo);
            this.Controls.Add(this.comboTipoVehiculo);
            this.Controls.Add(this.comboModelo);
            this.Controls.Add(this.txtPatente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimumSize = new System.Drawing.Size(881, 423);
            this.Name = "frmVehiculosAE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVehiculosAE";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarTipoVehiculo;
        private System.Windows.Forms.Button btnAgregarModelo;
        private System.Windows.Forms.ComboBox comboTipoVehiculo;
        private System.Windows.Forms.ComboBox comboModelo;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtKilometros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPINCODE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtVIN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtECU;
        private System.Windows.Forms.Label label5;
    }
}