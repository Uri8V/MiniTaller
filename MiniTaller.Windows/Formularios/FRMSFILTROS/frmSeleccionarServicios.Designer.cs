namespace MiniTaller.Windows.Formularios.FRMSFILTROS
{
    partial class frmSeleccionarServicios
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
            this.btnAgregarServicios = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboServicios = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarServicios
            // 
            this.btnAgregarServicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(140)))), ((int)(((byte)(71)))));
            this.btnAgregarServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnAgregarServicios.Image = global::MiniTaller.Windows.Properties.Resources.add_50px;
            this.btnAgregarServicios.Location = new System.Drawing.Point(619, 12);
            this.btnAgregarServicios.Name = "btnAgregarServicios";
            this.btnAgregarServicios.Size = new System.Drawing.Size(61, 51);
            this.btnAgregarServicios.TabIndex = 1;
            this.btnAgregarServicios.UseVisualStyleBackColor = false;
            this.btnAgregarServicios.Click += new System.EventHandler(this.btnAgregarServicios_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 24);
            this.label2.TabIndex = 22;
            this.label2.Text = "Seleccionar Servicios:";
            // 
            // comboServicios
            // 
            this.comboServicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.comboServicios.DropDownHeight = 200;
            this.comboServicios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboServicios.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboServicios.FormattingEnabled = true;
            this.comboServicios.IntegralHeight = false;
            this.comboServicios.Location = new System.Drawing.Point(214, 22);
            this.comboServicios.MaxDropDownItems = 50;
            this.comboServicios.Name = "comboServicios";
            this.comboServicios.Size = new System.Drawing.Size(399, 32);
            this.comboServicios.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnConfirmar.Location = new System.Drawing.Point(112, 87);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(148, 42);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseMnemonic = false;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnCancelar.Location = new System.Drawing.Point(296, 87);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(148, 42);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseMnemonic = false;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmSeleccionarServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(692, 151);
            this.ControlBox = false;
            this.Controls.Add(this.btnAgregarServicios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboServicios);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(563, 151);
            this.Name = "frmSeleccionarServicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Agregar Servicio";
            this.Text = "frmSeleccionarServicios";
            this.Load += new System.EventHandler(this.frmSeleccionarServicios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarServicios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboServicios;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}