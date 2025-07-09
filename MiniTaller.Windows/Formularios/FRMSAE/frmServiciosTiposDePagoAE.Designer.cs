namespace MiniTaller.Windows.Formularios.FRMSAE
{
    partial class frmServiciosTiposDePagoAE
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
            this.btnAgregarServicio = new System.Windows.Forms.Button();
            this.btnAgregarTipoDePago = new System.Windows.Forms.Button();
            this.comboServicio = new System.Windows.Forms.ComboBox();
            this.comboTipoDePago = new System.Windows.Forms.ComboBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarServicio
            // 
            this.btnAgregarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(191)))), ((int)(((byte)(96)))));
            this.btnAgregarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarServicio.Image = global::MiniTaller.Windows.Properties.Resources.add_50px;
            this.btnAgregarServicio.Location = new System.Drawing.Point(669, 102);
            this.btnAgregarServicio.Name = "btnAgregarServicio";
            this.btnAgregarServicio.Size = new System.Drawing.Size(76, 58);
            this.btnAgregarServicio.TabIndex = 3;
            this.btnAgregarServicio.Tag = "Agregar Servicio";
            this.btnAgregarServicio.UseVisualStyleBackColor = false;
            this.btnAgregarServicio.Click += new System.EventHandler(this.btnAgregarServicio_Click);
            // 
            // btnAgregarTipoDePago
            // 
            this.btnAgregarTipoDePago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(191)))), ((int)(((byte)(96)))));
            this.btnAgregarTipoDePago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTipoDePago.Image = global::MiniTaller.Windows.Properties.Resources.add_50px;
            this.btnAgregarTipoDePago.Location = new System.Drawing.Point(707, 21);
            this.btnAgregarTipoDePago.Name = "btnAgregarTipoDePago";
            this.btnAgregarTipoDePago.Size = new System.Drawing.Size(76, 58);
            this.btnAgregarTipoDePago.TabIndex = 1;
            this.btnAgregarTipoDePago.Tag = "Agregar Tipo de Pago";
            this.btnAgregarTipoDePago.UseVisualStyleBackColor = false;
            this.btnAgregarTipoDePago.Click += new System.EventHandler(this.btnAgregarTipoDePago_Click);
            // 
            // comboServicio
            // 
            this.comboServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.comboServicio.FormattingEnabled = true;
            this.comboServicio.Location = new System.Drawing.Point(278, 110);
            this.comboServicio.MaxDropDownItems = 50;
            this.comboServicio.Name = "comboServicio";
            this.comboServicio.Size = new System.Drawing.Size(345, 37);
            this.comboServicio.TabIndex = 2;
            // 
            // comboTipoDePago
            // 
            this.comboTipoDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoDePago.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.comboTipoDePago.FormattingEnabled = true;
            this.comboTipoDePago.Location = new System.Drawing.Point(336, 29);
            this.comboTipoDePago.Name = "comboTipoDePago";
            this.comboTipoDePago.Size = new System.Drawing.Size(344, 37);
            this.comboTipoDePago.TabIndex = 0;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtPrecio.Location = new System.Drawing.Point(229, 170);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(255, 35);
            this.txtPrecio.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 29);
            this.label4.TabIndex = 34;
            this.label4.Text = "Seleccione el Servicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 29);
            this.label2.TabIndex = 35;
            this.label2.Text = "Seleccione el Tipo de Pago:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 29);
            this.label1.TabIndex = 36;
            this.label1.Text = "Ingrese el Precio:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(59)))), ((int)(((byte)(57)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnCancelar.Location = new System.Drawing.Point(454, 239);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(169, 64);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(166)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnConfirmar.Location = new System.Drawing.Point(205, 239);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(169, 64);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmServiciosTiposDePagoAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(41)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(795, 315);
            this.ControlBox = false;
            this.Controls.Add(this.btnAgregarServicio);
            this.Controls.Add(this.btnAgregarTipoDePago);
            this.Controls.Add(this.comboServicio);
            this.Controls.Add(this.comboTipoDePago);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimumSize = new System.Drawing.Size(795, 315);
            this.Name = "frmServiciosTiposDePagoAE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmServiciosTiposDeGastosAE";
            this.Load += new System.EventHandler(this.frmServiciosTiposDeGastosAE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAgregarServicio;
        private System.Windows.Forms.Button btnAgregarTipoDePago;
        private System.Windows.Forms.ComboBox comboServicio;
        private System.Windows.Forms.ComboBox comboTipoDePago;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}