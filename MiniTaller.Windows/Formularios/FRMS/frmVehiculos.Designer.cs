﻿namespace MiniTaller.Windows.Formularios.FRMS
{
    partial class frmVehiculos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.colPatente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoDeVehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKilometros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEcu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPINCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnPrimero = new System.Windows.Forms.Button();
            this.lblPaginas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPaginaActual = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCerrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAgregar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBorrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFiltrar = new System.Windows.Forms.ToolStripDropDownButton();
            this.modeloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 54);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvDatos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnUltimo);
            this.splitContainer1.Panel2.Controls.Add(this.btnSiguiente);
            this.splitContainer1.Panel2.Controls.Add(this.btnAnterior);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrimero);
            this.splitContainer1.Panel2.Controls.Add(this.lblPaginas);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.lblPaginaActual);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.lblRegistros);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Size = new System.Drawing.Size(579, 396);
            this.splitContainer1.SplitterDistance = 324;
            this.splitContainer1.TabIndex = 7;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeColumns = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPatente,
            this.colTipoDeVehiculo,
            this.colModelo,
            this.colKilometros,
            this.colEcu,
            this.colVIN,
            this.colPINCode});
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.Location = new System.Drawing.Point(0, 0);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(579, 324);
            this.dgvDatos.TabIndex = 2;
            // 
            // colPatente
            // 
            this.colPatente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPatente.HeaderText = "Patente";
            this.colPatente.Name = "colPatente";
            this.colPatente.ReadOnly = true;
            // 
            // colTipoDeVehiculo
            // 
            this.colTipoDeVehiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTipoDeVehiculo.HeaderText = "Tipo de Vehiculo";
            this.colTipoDeVehiculo.Name = "colTipoDeVehiculo";
            this.colTipoDeVehiculo.ReadOnly = true;
            // 
            // colModelo
            // 
            this.colModelo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colModelo.HeaderText = "Modelo";
            this.colModelo.Name = "colModelo";
            this.colModelo.ReadOnly = true;
            // 
            // colKilometros
            // 
            this.colKilometros.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colKilometros.HeaderText = "Kilometros";
            this.colKilometros.Name = "colKilometros";
            this.colKilometros.ReadOnly = true;
            // 
            // colEcu
            // 
            this.colEcu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEcu.HeaderText = "ECU";
            this.colEcu.Name = "colEcu";
            this.colEcu.ReadOnly = true;
            // 
            // colVIN
            // 
            this.colVIN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colVIN.HeaderText = "VIN";
            this.colVIN.Name = "colVIN";
            this.colVIN.ReadOnly = true;
            // 
            // colPINCode
            // 
            this.colPINCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPINCode.HeaderText = "PIN Code";
            this.colPINCode.Name = "colPINCode";
            this.colPINCode.ReadOnly = true;
            // 
            // btnUltimo
            // 
            this.btnUltimo.Image = global::MiniTaller.Windows.Properties.Resources.Last_button_32px;
            this.btnUltimo.Location = new System.Drawing.Point(494, 15);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(75, 32);
            this.btnUltimo.TabIndex = 89;
            this.btnUltimo.UseVisualStyleBackColor = true;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Image = global::MiniTaller.Windows.Properties.Resources.next_32px;
            this.btnSiguiente.Location = new System.Drawing.Point(413, 15);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 32);
            this.btnSiguiente.TabIndex = 90;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Image = global::MiniTaller.Windows.Properties.Resources.previous_32px;
            this.btnAnterior.Location = new System.Drawing.Point(332, 15);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 32);
            this.btnAnterior.TabIndex = 91;
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnPrimero
            // 
            this.btnPrimero.Image = global::MiniTaller.Windows.Properties.Resources.First_32px;
            this.btnPrimero.Location = new System.Drawing.Point(251, 15);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(75, 32);
            this.btnPrimero.TabIndex = 92;
            this.btnPrimero.UseVisualStyleBackColor = true;
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // lblPaginas
            // 
            this.lblPaginas.AutoSize = true;
            this.lblPaginas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaginas.Location = new System.Drawing.Point(193, 40);
            this.lblPaginas.Name = "lblPaginas";
            this.lblPaginas.Size = new System.Drawing.Size(14, 13);
            this.lblPaginas.TabIndex = 86;
            this.lblPaginas.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "de";
            // 
            // lblPaginaActual
            // 
            this.lblPaginaActual.AutoSize = true;
            this.lblPaginaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaginaActual.Location = new System.Drawing.Point(133, 40);
            this.lblPaginaActual.Name = "lblPaginaActual";
            this.lblPaginaActual.Size = new System.Drawing.Size(14, 13);
            this.lblPaginaActual.TabIndex = 87;
            this.lblPaginaActual.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "Página:";
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.Location = new System.Drawing.Point(133, 15);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(14, 13);
            this.lblRegistros.TabIndex = 88;
            this.lblRegistros.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "Cantidad de Registros:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCerrar,
            this.toolStripButtonAgregar,
            this.toolStripButtonBorrar,
            this.toolStripButtonEditar,
            this.toolStripSeparator1,
            this.toolStripButtonFiltrar,
            this.toolStripButtonActualizar,
            this.toolStripSeparator2,
            this.toolStripTextBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(579, 54);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonCerrar
            // 
            this.toolStripButtonCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonCerrar.Image = global::MiniTaller.Windows.Properties.Resources.Close_32px;
            this.toolStripButtonCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCerrar.Name = "toolStripButtonCerrar";
            this.toolStripButtonCerrar.Size = new System.Drawing.Size(43, 51);
            this.toolStripButtonCerrar.Text = "Cerrar";
            this.toolStripButtonCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonCerrar.Click += new System.EventHandler(this.toolStripButtonCerrar_Click);
            // 
            // toolStripButtonAgregar
            // 
            this.toolStripButtonAgregar.Image = global::MiniTaller.Windows.Properties.Resources.add_32px;
            this.toolStripButtonAgregar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAgregar.Name = "toolStripButtonAgregar";
            this.toolStripButtonAgregar.Size = new System.Drawing.Size(53, 51);
            this.toolStripButtonAgregar.Text = "Agregar";
            this.toolStripButtonAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonAgregar.Click += new System.EventHandler(this.toolStripButtonAgregar_Click);
            // 
            // toolStripButtonBorrar
            // 
            this.toolStripButtonBorrar.Image = global::MiniTaller.Windows.Properties.Resources.Delete_Key_32px;
            this.toolStripButtonBorrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBorrar.Name = "toolStripButtonBorrar";
            this.toolStripButtonBorrar.Size = new System.Drawing.Size(43, 51);
            this.toolStripButtonBorrar.Text = "Borrar";
            this.toolStripButtonBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonBorrar.Click += new System.EventHandler(this.toolStripButtonBorrar_Click);
            // 
            // toolStripButtonEditar
            // 
            this.toolStripButtonEditar.Image = global::MiniTaller.Windows.Properties.Resources.edit_property_32px;
            this.toolStripButtonEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditar.Name = "toolStripButtonEditar";
            this.toolStripButtonEditar.Size = new System.Drawing.Size(41, 51);
            this.toolStripButtonEditar.Text = "Editar";
            this.toolStripButtonEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonEditar.Click += new System.EventHandler(this.toolStripButtonEditar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // toolStripButtonFiltrar
            // 
            this.toolStripButtonFiltrar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modeloToolStripMenuItem,
            this.tipoDeVehiculoToolStripMenuItem});
            this.toolStripButtonFiltrar.Image = global::MiniTaller.Windows.Properties.Resources.filter_32px;
            this.toolStripButtonFiltrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFiltrar.Name = "toolStripButtonFiltrar";
            this.toolStripButtonFiltrar.Size = new System.Drawing.Size(50, 51);
            this.toolStripButtonFiltrar.Text = "Filtrar";
            this.toolStripButtonFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // modeloToolStripMenuItem
            // 
            this.modeloToolStripMenuItem.Name = "modeloToolStripMenuItem";
            this.modeloToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.modeloToolStripMenuItem.Text = "Modelo";
            this.modeloToolStripMenuItem.Click += new System.EventHandler(this.modeloToolStripMenuItem_Click);
            // 
            // tipoDeVehiculoToolStripMenuItem
            // 
            this.tipoDeVehiculoToolStripMenuItem.Name = "tipoDeVehiculoToolStripMenuItem";
            this.tipoDeVehiculoToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.tipoDeVehiculoToolStripMenuItem.Text = "Tipo De Vehiculo";
            this.tipoDeVehiculoToolStripMenuItem.Click += new System.EventHandler(this.tipoDeVehiculoToolStripMenuItem_Click);
            // 
            // toolStripButtonActualizar
            // 
            this.toolStripButtonActualizar.Image = global::MiniTaller.Windows.Properties.Resources.refresh_32px;
            this.toolStripButtonActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonActualizar.Name = "toolStripButtonActualizar";
            this.toolStripButtonActualizar.Size = new System.Drawing.Size(63, 51);
            this.toolStripButtonActualizar.Text = "Actualizar";
            this.toolStripButtonActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonActualizar.Click += new System.EventHandler(this.toolStripButtonActualizar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(200, 54);
            this.toolStripTextBox1.ToolTipText = "Buscador de Vehiculos por Patente / Tipo / Modelo / ECU / VIN / PIN CODE";
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // frmVehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 450);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.MaximumSize = new System.Drawing.Size(595, 489);
            this.MinimumSize = new System.Drawing.Size(595, 489);
            this.Name = "frmVehiculos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVehiculos";
            this.Load += new System.EventHandler(this.frmVehiculos_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnPrimero;
        private System.Windows.Forms.Label lblPaginas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPaginaActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonCerrar;
        private System.Windows.Forms.ToolStripButton toolStripButtonAgregar;
        private System.Windows.Forms.ToolStripButton toolStripButtonBorrar;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonFiltrar;
        private System.Windows.Forms.ToolStripMenuItem modeloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeVehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoDeVehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKilometros;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEcu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPINCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}