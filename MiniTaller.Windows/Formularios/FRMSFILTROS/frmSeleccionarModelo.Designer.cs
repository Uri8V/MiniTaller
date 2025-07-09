namespace MiniTaller.Windows.Formularios.FRMSFILTROS
{
    partial class frmSeleccionarModelo
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
            this.btnAgregarModelo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxModelo = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarModelo
            // 
            this.btnAgregarModelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(140)))), ((int)(((byte)(71)))));
            this.btnAgregarModelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnAgregarModelo.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarModelo.Image = global::MiniTaller.Windows.Properties.Resources.add_50px;
            this.btnAgregarModelo.Location = new System.Drawing.Point(487, 26);
            this.btnAgregarModelo.Name = "btnAgregarModelo";
            this.btnAgregarModelo.Size = new System.Drawing.Size(62, 51);
            this.btnAgregarModelo.TabIndex = 1;
            this.btnAgregarModelo.UseVisualStyleBackColor = false;
            this.btnAgregarModelo.Click += new System.EventHandler(this.btnAgregarModelo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Seleccionar Modelo:";
            // 
            // comboBoxModelo
            // 
            this.comboBoxModelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.comboBoxModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboBoxModelo.FormattingEnabled = true;
            this.comboBoxModelo.IntegralHeight = false;
            this.comboBoxModelo.Location = new System.Drawing.Point(190, 36);
            this.comboBoxModelo.MaxDropDownItems = 50;
            this.comboBoxModelo.Name = "comboBoxModelo";
            this.comboBoxModelo.Size = new System.Drawing.Size(291, 32);
            this.comboBoxModelo.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnConfirmar.ForeColor = System.Drawing.Color.Black;
            this.btnConfirmar.Location = new System.Drawing.Point(79, 96);
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
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(322, 96);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(148, 42);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmSeleccionarModelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(561, 160);
            this.ControlBox = false;
            this.Controls.Add(this.btnAgregarModelo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxModelo);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(561, 160);
            this.MinimumSize = new System.Drawing.Size(561, 160);
            this.Name = "frmSeleccionarModelo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSeleccionarModelo";
            this.Load += new System.EventHandler(this.frmSeleccionarModelo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarModelo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxModelo;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}