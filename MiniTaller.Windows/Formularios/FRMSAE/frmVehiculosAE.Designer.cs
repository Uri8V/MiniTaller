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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarTipoVehiculo
            // 
            this.btnAgregarTipoVehiculo.Image = global::MiniTaller.Windows.Properties.Resources.add_32px;
            this.btnAgregarTipoVehiculo.Location = new System.Drawing.Point(371, 103);
            this.btnAgregarTipoVehiculo.Name = "btnAgregarTipoVehiculo";
            this.btnAgregarTipoVehiculo.Size = new System.Drawing.Size(48, 42);
            this.btnAgregarTipoVehiculo.TabIndex = 22;
            this.btnAgregarTipoVehiculo.UseVisualStyleBackColor = true;
            this.btnAgregarTipoVehiculo.Click += new System.EventHandler(this.btnAgregarTipoVehiculo_Click);
            // 
            // btnAgregarModelo
            // 
            this.btnAgregarModelo.Image = global::MiniTaller.Windows.Properties.Resources.add_32px;
            this.btnAgregarModelo.Location = new System.Drawing.Point(371, 46);
            this.btnAgregarModelo.Name = "btnAgregarModelo";
            this.btnAgregarModelo.Size = new System.Drawing.Size(48, 42);
            this.btnAgregarModelo.TabIndex = 23;
            this.btnAgregarModelo.UseVisualStyleBackColor = true;
            this.btnAgregarModelo.Click += new System.EventHandler(this.btnAgregarModelo_Click);
            // 
            // comboTipoVehiculo
            // 
            this.comboTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoVehiculo.FormattingEnabled = true;
            this.comboTipoVehiculo.Location = new System.Drawing.Point(171, 115);
            this.comboTipoVehiculo.Name = "comboTipoVehiculo";
            this.comboTipoVehiculo.Size = new System.Drawing.Size(176, 21);
            this.comboTipoVehiculo.TabIndex = 20;
            // 
            // comboModelo
            // 
            this.comboModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboModelo.FormattingEnabled = true;
            this.comboModelo.Location = new System.Drawing.Point(171, 58);
            this.comboModelo.Name = "comboModelo";
            this.comboModelo.Size = new System.Drawing.Size(176, 21);
            this.comboModelo.TabIndex = 21;
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(103, 11);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(100, 20);
            this.txtPatente.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Seleccione el Tipo de Vehiculo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Seleccione el Modelo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Ingrese la Patente";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(250, 162);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 51);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(103, 162);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(92, 51);
            this.btnConfirmar.TabIndex = 13;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtKilometros
            // 
            this.txtKilometros.Location = new System.Drawing.Point(322, 11);
            this.txtKilometros.Name = "txtKilometros";
            this.txtKilometros.Size = new System.Drawing.Size(100, 20);
            this.txtKilometros.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Ingrese el Kilometraje";
            // 
            // frmVehiculosAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 221);
            this.ControlBox = false;
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
            this.MaximumSize = new System.Drawing.Size(444, 260);
            this.MinimumSize = new System.Drawing.Size(444, 260);
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
    }
}