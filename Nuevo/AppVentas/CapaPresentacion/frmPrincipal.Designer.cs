
namespace CapaPresentacion
{
    partial class frmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMEmpleado = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMReiniciar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProcesos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.anularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasDelDiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasEntreFechasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kardexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSeguridad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCambiarEstado = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSCambiarContrasena = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSSi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSNo = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslNombreUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMantenimiento,
            this.tsmProcesos,
            this.tsmConsultas,
            this.tsmSeguridad,
            this.tsmSalir});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(827, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmMantenimiento
            // 
            this.tsmMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMEmpleado,
            this.tsmiMCliente,
            this.tsmiMProducto,
            this.proveedorToolStripMenuItem,
            this.tsmiMReiniciar});
            this.tsmMantenimiento.Name = "tsmMantenimiento";
            this.tsmMantenimiento.Size = new System.Drawing.Size(124, 24);
            this.tsmMantenimiento.Text = "Mantenimiento";
            // 
            // tsmiMEmpleado
            // 
            this.tsmiMEmpleado.Name = "tsmiMEmpleado";
            this.tsmiMEmpleado.Size = new System.Drawing.Size(160, 26);
            this.tsmiMEmpleado.Text = "Empleado";
            this.tsmiMEmpleado.Click += new System.EventHandler(this.tsmiMEmpleado_Click);
            // 
            // tsmiMCliente
            // 
            this.tsmiMCliente.Name = "tsmiMCliente";
            this.tsmiMCliente.Size = new System.Drawing.Size(160, 26);
            this.tsmiMCliente.Text = "Cliente";
            this.tsmiMCliente.Click += new System.EventHandler(this.tsmiMCliente_Click);
            // 
            // tsmiMProducto
            // 
            this.tsmiMProducto.Name = "tsmiMProducto";
            this.tsmiMProducto.Size = new System.Drawing.Size(160, 26);
            this.tsmiMProducto.Text = "Producto";
            this.tsmiMProducto.Click += new System.EventHandler(this.tsmiMProducto_Click);
            // 
            // proveedorToolStripMenuItem
            // 
            this.proveedorToolStripMenuItem.Name = "proveedorToolStripMenuItem";
            this.proveedorToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.proveedorToolStripMenuItem.Text = "Proveedor";
            this.proveedorToolStripMenuItem.Click += new System.EventHandler(this.proveedorToolStripMenuItem_Click);
            // 
            // tsmiMReiniciar
            // 
            this.tsmiMReiniciar.Name = "tsmiMReiniciar";
            this.tsmiMReiniciar.Size = new System.Drawing.Size(160, 26);
            this.tsmiMReiniciar.Text = "Reiniciar";
            this.tsmiMReiniciar.Click += new System.EventHandler(this.tsmiMReiniciar_Click);
            // 
            // tsmProcesos
            // 
            this.tsmProcesos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiVentas,
            this.anularToolStripMenuItem,
            this.comprasToolStripMenuItem});
            this.tsmProcesos.Name = "tsmProcesos";
            this.tsmProcesos.Size = new System.Drawing.Size(81, 24);
            this.tsmProcesos.Text = "Procesos";
            // 
            // tsmiVentas
            // 
            this.tsmiVentas.Name = "tsmiVentas";
            this.tsmiVentas.Size = new System.Drawing.Size(229, 26);
            this.tsmiVentas.Text = "Ventas";
            this.tsmiVentas.Click += new System.EventHandler(this.tsmiVentas_Click);
            // 
            // anularToolStripMenuItem
            // 
            this.anularToolStripMenuItem.Name = "anularToolStripMenuItem";
            this.anularToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.anularToolStripMenuItem.Text = "Anular comprobante";
            this.anularToolStripMenuItem.Click += new System.EventHandler(this.anularToolStripMenuItem_Click);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.comprasToolStripMenuItem.Text = "compras";
            this.comprasToolStripMenuItem.Click += new System.EventHandler(this.comprasToolStripMenuItem_Click);
            // 
            // tsmConsultas
            // 
            this.tsmConsultas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasDelDiaToolStripMenuItem,
            this.ventasEntreFechasToolStripMenuItem,
            this.empleadoToolStripMenuItem1,
            this.productosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.kardexToolStripMenuItem});
            this.tsmConsultas.Name = "tsmConsultas";
            this.tsmConsultas.Size = new System.Drawing.Size(86, 24);
            this.tsmConsultas.Text = "Consultas";
            // 
            // ventasDelDiaToolStripMenuItem
            // 
            this.ventasDelDiaToolStripMenuItem.Name = "ventasDelDiaToolStripMenuItem";
            this.ventasDelDiaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ventasDelDiaToolStripMenuItem.Text = "Ventas del dia";
            this.ventasDelDiaToolStripMenuItem.Click += new System.EventHandler(this.ventasDelDiaToolStripMenuItem_Click);
            // 
            // ventasEntreFechasToolStripMenuItem
            // 
            this.ventasEntreFechasToolStripMenuItem.Name = "ventasEntreFechasToolStripMenuItem";
            this.ventasEntreFechasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ventasEntreFechasToolStripMenuItem.Text = "Ventas entre fechas";
            // 
            // empleadoToolStripMenuItem1
            // 
            this.empleadoToolStripMenuItem1.Name = "empleadoToolStripMenuItem1";
            this.empleadoToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.empleadoToolStripMenuItem1.Text = "Empleado";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // kardexToolStripMenuItem
            // 
            this.kardexToolStripMenuItem.Name = "kardexToolStripMenuItem";
            this.kardexToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.kardexToolStripMenuItem.Text = "Kardex";
            this.kardexToolStripMenuItem.Click += new System.EventHandler(this.kardexToolStripMenuItem_Click);
            // 
            // tsmSeguridad
            // 
            this.tsmSeguridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCambiarEstado,
            this.tsmiSCambiarContrasena});
            this.tsmSeguridad.Name = "tsmSeguridad";
            this.tsmSeguridad.Size = new System.Drawing.Size(91, 24);
            this.tsmSeguridad.Text = "Seguridad";
            // 
            // tsmiCambiarEstado
            // 
            this.tsmiCambiarEstado.Name = "tsmiCambiarEstado";
            this.tsmiCambiarEstado.Size = new System.Drawing.Size(249, 26);
            this.tsmiCambiarEstado.Text = "Cambiar estado usuario";
            this.tsmiCambiarEstado.Click += new System.EventHandler(this.tsmiCambiarEstado_Click);
            // 
            // tsmiSCambiarContrasena
            // 
            this.tsmiSCambiarContrasena.Name = "tsmiSCambiarContrasena";
            this.tsmiSCambiarContrasena.Size = new System.Drawing.Size(249, 26);
            this.tsmiSCambiarContrasena.Text = "Cambiar contraseña";
            this.tsmiSCambiarContrasena.Click += new System.EventHandler(this.tsmiSCambiarContrasena_Click);
            // 
            // tsmSalir
            // 
            this.tsmSalir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSSi,
            this.tsmiSNo});
            this.tsmSalir.Name = "tsmSalir";
            this.tsmSalir.Size = new System.Drawing.Size(52, 24);
            this.tsmSalir.Text = "Salir";
            // 
            // tsmiSSi
            // 
            this.tsmiSSi.Name = "tsmiSSi";
            this.tsmiSSi.Size = new System.Drawing.Size(112, 26);
            this.tsmiSSi.Text = "Si";
            this.tsmiSSi.Click += new System.EventHandler(this.tsmiSSi_Click);
            // 
            // tsmiSNo
            // 
            this.tsmiSNo.Name = "tsmiSNo";
            this.tsmiSNo.Size = new System.Drawing.Size(112, 26);
            this.tsmiSNo.Text = "No";
            this.tsmiSNo.Click += new System.EventHandler(this.tsmiSNo_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.tsslFecha,
            this.tsslHora,
            this.tsslNombreUsuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 334);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(827, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(81, 20);
            this.toolStripStatusLabel1.Text = "NombrePC";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(122, 20);
            this.toolStripStatusLabel2.Text = "NombreMaquina";
            // 
            // tsslFecha
            // 
            this.tsslFecha.Name = "tsslFecha";
            this.tsslFecha.Size = new System.Drawing.Size(47, 20);
            this.tsslFecha.Text = "Fecha";
            // 
            // tsslHora
            // 
            this.tsslHora.Name = "tsslHora";
            this.tsslHora.Size = new System.Drawing.Size(42, 20);
            this.tsslHora.Text = "Hora";
            // 
            // tsslNombreUsuario
            // 
            this.tsslNombreUsuario.Name = "tsslNombreUsuario";
            this.tsslNombreUsuario.Size = new System.Drawing.Size(141, 20);
            this.tsslNombreUsuario.Text = "Nombre del usuario";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 360);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem tsmiMEmpleado;
        private System.Windows.Forms.ToolStripMenuItem tsmProcesos;
        private System.Windows.Forms.ToolStripMenuItem tsmConsultas;
        private System.Windows.Forms.ToolStripMenuItem tsmSeguridad;
        private System.Windows.Forms.ToolStripMenuItem tsmSalir;
        private System.Windows.Forms.ToolStripMenuItem tsmiMCliente;
        private System.Windows.Forms.ToolStripMenuItem tsmiMProducto;
        private System.Windows.Forms.ToolStripMenuItem tsmiVentas;
        private System.Windows.Forms.ToolStripMenuItem anularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiCambiarEstado;
        private System.Windows.Forms.ToolStripMenuItem tsmiSCambiarContrasena;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslFecha;
        private System.Windows.Forms.ToolStripStatusLabel tsslHora;
        private System.Windows.Forms.ToolStripMenuItem tsmiMReiniciar;
        private System.Windows.Forms.ToolStripMenuItem ventasDelDiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasEntreFechasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empleadoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kardexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSSi;
        private System.Windows.Forms.ToolStripMenuItem tsmiSNo;
        private System.Windows.Forms.ToolStripStatusLabel tsslNombreUsuario;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedorToolStripMenuItem;
    }
}