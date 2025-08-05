namespace MiniTaller.Windows.Formularios.FRMS
{
    partial class frmServiciosTiposDePago
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.colServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormaDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.toolStripButtonCerrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAgregar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBorrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButtonFiltrar = new System.Windows.Forms.ToolStripDropDownButton();
            this.formaDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
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
            this.splitContainer1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 87);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvDatos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Black;
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
            this.splitContainer1.Size = new System.Drawing.Size(887, 387);
            this.splitContainer1.SplitterDistance = 293;
            this.splitContainer1.TabIndex = 12;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeColumns = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colServicio,
            this.colFormaDePago});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.dgvDatos.Location = new System.Drawing.Point(0, 0);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(887, 293);
            this.dgvDatos.TabIndex = 1;
            // 
            // colServicio
            // 
            this.colServicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colServicio.HeaderText = "Servicio";
            this.colServicio.Name = "colServicio";
            this.colServicio.ReadOnly = true;
            // 
            // colFormaDePago
            // 
            this.colFormaDePago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFormaDePago.HeaderText = "Forma de Pago";
            this.colFormaDePago.Name = "colFormaDePago";
            this.colFormaDePago.ReadOnly = true;
            // 
            // btnUltimo
            // 
            this.btnUltimo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btnUltimo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUltimo.Image = global::MiniTaller.Windows.Properties.Resources.Fast_Forward_50px;
            this.btnUltimo.Location = new System.Drawing.Point(741, 14);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(100, 64);
            this.btnUltimo.TabIndex = 79;
            this.btnUltimo.UseVisualStyleBackColor = false;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Image = global::MiniTaller.Windows.Properties.Resources.sort_right_50px;
            this.btnSiguiente.Location = new System.Drawing.Point(605, 14);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(100, 64);
            this.btnSiguiente.TabIndex = 80;
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Image = global::MiniTaller.Windows.Properties.Resources.sort_left_50px;
            this.btnAnterior.Location = new System.Drawing.Point(471, 14);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(100, 64);
            this.btnAnterior.TabIndex = 81;
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnPrimero
            // 
            this.btnPrimero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.btnPrimero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrimero.Image = global::MiniTaller.Windows.Properties.Resources.rewind_50px;
            this.btnPrimero.Location = new System.Drawing.Point(336, 14);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(100, 64);
            this.btnPrimero.TabIndex = 82;
            this.btnPrimero.UseVisualStyleBackColor = false;
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // lblPaginas
            // 
            this.lblPaginas.AutoSize = true;
            this.lblPaginas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaginas.ForeColor = System.Drawing.Color.White;
            this.lblPaginas.Location = new System.Drawing.Point(175, 56);
            this.lblPaginas.Name = "lblPaginas";
            this.lblPaginas.Size = new System.Drawing.Size(24, 25);
            this.lblPaginas.TabIndex = 76;
            this.lblPaginas.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(133, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 25);
            this.label4.TabIndex = 73;
            this.label4.Text = "de";
            // 
            // lblPaginaActual
            // 
            this.lblPaginaActual.AutoSize = true;
            this.lblPaginaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaginaActual.ForeColor = System.Drawing.Color.White;
            this.lblPaginaActual.Location = new System.Drawing.Point(103, 56);
            this.lblPaginaActual.Name = "lblPaginaActual";
            this.lblPaginaActual.Size = new System.Drawing.Size(24, 25);
            this.lblPaginaActual.TabIndex = 77;
            this.lblPaginaActual.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 74;
            this.label2.Text = "Página:";
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(249, 14);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(24, 25);
            this.lblRegistros.TabIndex = 78;
            this.lblRegistros.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 25);
            this.label3.TabIndex = 75;
            this.label3.Text = "Cantidad de Registros:";
            // 
            // toolStripButtonCerrar
            // 
            this.toolStripButtonCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.toolStripButtonCerrar.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.toolStripButtonCerrar.Image = global::MiniTaller.Windows.Properties.Resources.Close_50px;
            this.toolStripButtonCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCerrar.Name = "toolStripButtonCerrar";
            this.toolStripButtonCerrar.Size = new System.Drawing.Size(78, 84);
            this.toolStripButtonCerrar.Text = "Cerrar";
            this.toolStripButtonCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonCerrar.Click += new System.EventHandler(this.toolStripButtonCerrar_Click);
            // 
            // toolStripButtonAgregar
            // 
            this.toolStripButtonAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.toolStripButtonAgregar.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.toolStripButtonAgregar.Image = global::MiniTaller.Windows.Properties.Resources.add_50px;
            this.toolStripButtonAgregar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAgregar.Name = "toolStripButtonAgregar";
            this.toolStripButtonAgregar.Size = new System.Drawing.Size(96, 84);
            this.toolStripButtonAgregar.Text = "Agregar";
            this.toolStripButtonAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonAgregar.Click += new System.EventHandler(this.toolStripButtonAgregar_Click);
            // 
            // toolStripButtonBorrar
            // 
            this.toolStripButtonBorrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.toolStripButtonBorrar.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.toolStripButtonBorrar.Image = global::MiniTaller.Windows.Properties.Resources.Remove_50px;
            this.toolStripButtonBorrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBorrar.Name = "toolStripButtonBorrar";
            this.toolStripButtonBorrar.Size = new System.Drawing.Size(78, 84);
            this.toolStripButtonBorrar.Text = "Borrar";
            this.toolStripButtonBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonBorrar.Click += new System.EventHandler(this.toolStripButtonBorrar_Click);
            // 
            // toolStripButtonEditar
            // 
            this.toolStripButtonEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.toolStripButtonEditar.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.toolStripButtonEditar.Image = global::MiniTaller.Windows.Properties.Resources.pencil_50px;
            this.toolStripButtonEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditar.Name = "toolStripButtonEditar";
            this.toolStripButtonEditar.Size = new System.Drawing.Size(72, 84);
            this.toolStripButtonEditar.Text = "Editar";
            this.toolStripButtonEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonEditar.Click += new System.EventHandler(this.toolStripButtonEditar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 87);
            // 
            // toolStripDropDownButtonFiltrar
            // 
            this.toolStripDropDownButtonFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.toolStripDropDownButtonFiltrar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formaDePagoToolStripMenuItem});
            this.toolStripDropDownButtonFiltrar.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.toolStripDropDownButtonFiltrar.Image = global::MiniTaller.Windows.Properties.Resources.filter_50px;
            this.toolStripDropDownButtonFiltrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButtonFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonFiltrar.Name = "toolStripDropDownButtonFiltrar";
            this.toolStripDropDownButtonFiltrar.Size = new System.Drawing.Size(81, 84);
            this.toolStripDropDownButtonFiltrar.Text = "Filtrar";
            this.toolStripDropDownButtonFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // formaDePagoToolStripMenuItem
            // 
            this.formaDePagoToolStripMenuItem.Name = "formaDePagoToolStripMenuItem";
            this.formaDePagoToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.formaDePagoToolStripMenuItem.Text = "Forma De Pago";
            this.formaDePagoToolStripMenuItem.Click += new System.EventHandler(this.formaDePagoToolStripMenuItem_Click);
            // 
            // toolStripButtonActualizar
            // 
            this.toolStripButtonActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.toolStripButtonActualizar.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.toolStripButtonActualizar.Image = global::MiniTaller.Windows.Properties.Resources.reset_50px;
            this.toolStripButtonActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonActualizar.Name = "toolStripButtonActualizar";
            this.toolStripButtonActualizar.Size = new System.Drawing.Size(110, 84);
            this.toolStripButtonActualizar.Text = "Actualizar";
            this.toolStripButtonActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonActualizar.Click += new System.EventHandler(this.toolStripButtonActualizar_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 84);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.toolStripTextBox1.MaxLength = 100;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(300, 87);
            this.toolStripTextBox1.Text = "Buscador por Servicio";
            this.toolStripTextBox1.ToolTipText = "Buscador por Servicio";
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Black;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCerrar,
            this.toolStripButtonAgregar,
            this.toolStripButtonBorrar,
            this.toolStripButtonEditar,
            this.toolStripSeparator1,
            this.toolStripDropDownButtonFiltrar,
            this.toolStripButtonActualizar,
            this.toolStripLabel1,
            this.toolStripTextBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(887, 87);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // frmServiciosTiposDePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(887, 474);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimumSize = new System.Drawing.Size(887, 474);
            this.Name = "frmServiciosTiposDePago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmServiciosTiposDePago";
            this.Load += new System.EventHandler(this.frmServiciosTiposDePago_Load);
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
        private System.Windows.Forms.ToolStripButton toolStripButtonCerrar;
        private System.Windows.Forms.ToolStripButton toolStripButtonAgregar;
        private System.Windows.Forms.ToolStripButton toolStripButtonBorrar;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonFiltrar;
        private System.Windows.Forms.ToolStripMenuItem formaDePagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonActualizar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormaDePago;
    }
}