namespace CapaPresentacion.Procesos
{
    partial class frmCompras
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
            this.dgvCompra = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblIGV = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.gpbEmpleado = new System.Windows.Forms.GroupBox();
            this.lblNombreEmpleado = new System.Windows.Forms.Label();
            this.lblIdEmpleado = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gpbComprobante = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.lblIdComprobante = new System.Windows.Forms.Label();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gpbCliente = new System.Windows.Forms.GroupBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblrazonSocial = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIdProvedorC = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.lblNroComprobante = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompra)).BeginInit();
            this.gpbEmpleado.SuspendLayout();
            this.gpbComprobante.SuspendLayout();
            this.gpbCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCompra
            // 
            this.dgvCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompra.Location = new System.Drawing.Point(29, 301);
            this.dgvCompra.Name = "dgvCompra";
            this.dgvCompra.RowHeadersWidth = 51;
            this.dgvCompra.RowTemplate.Height = 24;
            this.dgvCompra.Size = new System.Drawing.Size(606, 150);
            this.dgvCompra.TabIndex = 112;
            this.dgvCompra.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCompra_RowsAdded);
            this.dgvCompra.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvCompra_RowsRemoved);
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Location = new System.Drawing.Point(787, 472);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(184, 26);
            this.lblTotal.TabIndex = 111;
            // 
            // lblIGV
            // 
            this.lblIGV.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblIGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIGV.Location = new System.Drawing.Point(787, 421);
            this.lblIGV.Name = "lblIGV";
            this.lblIGV.Size = new System.Drawing.Size(184, 26);
            this.lblIGV.TabIndex = 110;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSubTotal.Location = new System.Drawing.Point(787, 373);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(184, 26);
            this.lblSubTotal.TabIndex = 109;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(692, 431);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 16);
            this.label13.TabIndex = 108;
            this.label13.Text = "I.G.V.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(692, 481);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 16);
            this.label12.TabIndex = 107;
            this.label12.Text = "Total";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(692, 385);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 16);
            this.label11.TabIndex = 106;
            this.label11.Text = "SubTotal";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(341, 262);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(165, 34);
            this.btnQuitar.TabIndex = 105;
            this.btnQuitar.Text = "Quitar producto";
            this.btnQuitar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(110, 262);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(165, 34);
            this.btnAgregar.TabIndex = 104;
            this.btnAgregar.Text = "Agregar producto";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(510, 472);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 34);
            this.btnSalir.TabIndex = 103;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(359, 472);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 34);
            this.btnCancelar.TabIndex = 102;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(224, 472);
            this.btnInsertar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(92, 34);
            this.btnInsertar.TabIndex = 101;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(79, 472);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(92, 34);
            this.btnNuevo.TabIndex = 100;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // gpbEmpleado
            // 
            this.gpbEmpleado.Controls.Add(this.lblNombreEmpleado);
            this.gpbEmpleado.Controls.Add(this.lblIdEmpleado);
            this.gpbEmpleado.Controls.Add(this.label9);
            this.gpbEmpleado.Controls.Add(this.label8);
            this.gpbEmpleado.Location = new System.Drawing.Point(510, 168);
            this.gpbEmpleado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbEmpleado.Name = "gpbEmpleado";
            this.gpbEmpleado.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbEmpleado.Size = new System.Drawing.Size(419, 84);
            this.gpbEmpleado.TabIndex = 99;
            this.gpbEmpleado.TabStop = false;
            this.gpbEmpleado.Text = "Empleado";
            // 
            // lblNombreEmpleado
            // 
            this.lblNombreEmpleado.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblNombreEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNombreEmpleado.Location = new System.Drawing.Point(134, 54);
            this.lblNombreEmpleado.Name = "lblNombreEmpleado";
            this.lblNombreEmpleado.Size = new System.Drawing.Size(184, 26);
            this.lblNombreEmpleado.TabIndex = 83;
            // 
            // lblIdEmpleado
            // 
            this.lblIdEmpleado.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblIdEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIdEmpleado.Location = new System.Drawing.Point(134, 18);
            this.lblIdEmpleado.Name = "lblIdEmpleado";
            this.lblIdEmpleado.Size = new System.Drawing.Size(184, 25);
            this.lblIdEmpleado.TabIndex = 84;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 83;
            this.label9.Text = "Nombre";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 16);
            this.label8.TabIndex = 83;
            this.label8.Text = "Id empleado";
            // 
            // gpbComprobante
            // 
            this.gpbComprobante.Controls.Add(this.label10);
            this.gpbComprobante.Controls.Add(this.dateTimePicker1);
            this.gpbComprobante.Controls.Add(this.label7);
            this.gpbComprobante.Controls.Add(this.lblIdComprobante);
            this.gpbComprobante.Controls.Add(this.lblTipoComprobante);
            this.gpbComprobante.Controls.Add(this.label2);
            this.gpbComprobante.Location = new System.Drawing.Point(504, 26);
            this.gpbComprobante.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbComprobante.Name = "gpbComprobante";
            this.gpbComprobante.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbComprobante.Size = new System.Drawing.Size(495, 132);
            this.gpbComprobante.TabIndex = 98;
            this.gpbComprobante.TabStop = false;
            this.gpbComprobante.Text = "Comprobante";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 16);
            this.label10.TabIndex = 83;
            this.label10.Text = "Id comprobante";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(155, 89);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(289, 22);
            this.dateTimePicker1.TabIndex = 82;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 16);
            this.label7.TabIndex = 82;
            this.label7.Text = "Fecha emisión";
            // 
            // lblIdComprobante
            // 
            this.lblIdComprobante.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblIdComprobante.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIdComprobante.Location = new System.Drawing.Point(155, 55);
            this.lblIdComprobante.Name = "lblIdComprobante";
            this.lblIdComprobante.Size = new System.Drawing.Size(289, 19);
            this.lblIdComprobante.TabIndex = 83;
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblTipoComprobante.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTipoComprobante.Location = new System.Drawing.Point(155, 26);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(289, 16);
            this.lblTipoComprobante.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 82;
            this.label2.Text = "Tipo comprobante";
            // 
            // gpbCliente
            // 
            this.gpbCliente.Controls.Add(this.lblDireccion);
            this.gpbCliente.Controls.Add(this.lblEmail);
            this.gpbCliente.Controls.Add(this.lblrazonSocial);
            this.gpbCliente.Controls.Add(this.lbl1);
            this.gpbCliente.Controls.Add(this.label3);
            this.gpbCliente.Controls.Add(this.lblIdProvedorC);
            this.gpbCliente.Controls.Add(this.label4);
            this.gpbCliente.Controls.Add(this.label5);
            this.gpbCliente.Controls.Add(this.label6);
            this.gpbCliente.Controls.Add(this.txtRuc);
            this.gpbCliente.Location = new System.Drawing.Point(12, 26);
            this.gpbCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbCliente.Name = "gpbCliente";
            this.gpbCliente.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbCliente.Size = new System.Drawing.Size(454, 226);
            this.gpbCliente.TabIndex = 97;
            this.gpbCliente.TabStop = false;
            this.gpbCliente.Text = "Cliente";
            // 
            // lblDireccion
            // 
            this.lblDireccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDireccion.Location = new System.Drawing.Point(150, 177);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(279, 26);
            this.lblDireccion.TabIndex = 82;
            // 
            // lblEmail
            // 
            this.lblEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEmail.Location = new System.Drawing.Point(149, 141);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(279, 26);
            this.lblEmail.TabIndex = 81;
            // 
            // lblrazonSocial
            // 
            this.lblrazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblrazonSocial.Location = new System.Drawing.Point(148, 61);
            this.lblrazonSocial.Name = "lblrazonSocial";
            this.lblrazonSocial.Size = new System.Drawing.Size(279, 26);
            this.lblrazonSocial.TabIndex = 80;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(18, 36);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(84, 16);
            this.lbl1.TabIndex = 68;
            this.lbl1.Text = "Id proveedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 69;
            this.label3.Text = "Direccion";
            // 
            // lblIdProvedorC
            // 
            this.lblIdProvedorC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIdProvedorC.Location = new System.Drawing.Point(150, 26);
            this.lblIdProvedorC.Name = "lblIdProvedorC";
            this.lblIdProvedorC.Size = new System.Drawing.Size(279, 26);
            this.lblIdProvedorC.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 70;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 71;
            this.label5.Text = "RUC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 72;
            this.label6.Text = "Razon social";
            // 
            // txtRuc
            // 
            this.txtRuc.Location = new System.Drawing.Point(148, 110);
            this.txtRuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(280, 22);
            this.txtRuc.TabIndex = 74;
            this.txtRuc.TextChanged += new System.EventHandler(this.txtRuc_TextChanged);
            // 
            // lblNroComprobante
            // 
            this.lblNroComprobante.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblNroComprobante.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNroComprobante.Location = new System.Drawing.Point(787, 301);
            this.lblNroComprobante.Name = "lblNroComprobante";
            this.lblNroComprobante.Size = new System.Drawing.Size(184, 26);
            this.lblNroComprobante.TabIndex = 85;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(656, 311);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 16);
            this.label14.TabIndex = 85;
            this.label14.Text = "NroComprobante";
            // 
            // frmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 525);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblNroComprobante);
            this.Controls.Add(this.dgvCompra);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblIGV);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.gpbEmpleado);
            this.Controls.Add(this.gpbComprobante);
            this.Controls.Add(this.gpbCliente);
            this.Name = "frmCompras";
            this.Text = "frmCompras";
            this.Load += new System.EventHandler(this.frmCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompra)).EndInit();
            this.gpbEmpleado.ResumeLayout(false);
            this.gpbEmpleado.PerformLayout();
            this.gpbComprobante.ResumeLayout(false);
            this.gpbComprobante.PerformLayout();
            this.gpbCliente.ResumeLayout(false);
            this.gpbCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvCompra;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblIGV;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.GroupBox gpbEmpleado;
        public System.Windows.Forms.Label lblNombreEmpleado;
        public System.Windows.Forms.Label lblIdEmpleado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gpbComprobante;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblIdComprobante;
        private System.Windows.Forms.Label lblTipoComprobante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gpbCliente;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblrazonSocial;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIdProvedorC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRuc;
        public System.Windows.Forms.Label lblNroComprobante;
        private System.Windows.Forms.Label label14;
    }
}