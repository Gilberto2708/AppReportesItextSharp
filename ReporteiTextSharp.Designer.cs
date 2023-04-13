
namespace waiTextSharp
{
  partial class ReporteiTextSharp
  {
    /// <summary>
    /// Variable del diseñador necesaria.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpiar los recursos que se estén usando.
    /// </summary>
    /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de Windows Forms

    /// <summary>
    /// Método necesario para admitir el Diseñador. No se puede modificar
    /// el contenido de este método con el editor de código.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteiTextSharp));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbImprimir = new System.Windows.Forms.ToolStripButton();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscboInformacion = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtExcepcion = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tssMensaje});
            this.statusStrip1.Location = new System.Drawing.Point(0, 329);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(600, 37);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::waiTextSharp.Properties.Resources.Print_16x;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(162, 32);
            this.toolStripStatusLabel1.Text = "Vidal TI Consultor, 2021";
            // 
            // tssMensaje
            // 
            this.tssMensaje.Name = "tssMensaje";
            this.tssMensaje.Size = new System.Drawing.Size(140, 32);
            this.tssMensaje.Text = " - [ Estado del proceso... ]";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbImprimir,
            this.tsbSalir,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tscboInformacion,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(600, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Menu_ItemClicked);
            // 
            // tsbImprimir
            // 
            this.tsbImprimir.Image = global::waiTextSharp.Properties.Resources.Print_16x;
            this.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimir.Name = "tsbImprimir";
            this.tsbImprimir.Size = new System.Drawing.Size(89, 36);
            this.tsbImprimir.Text = "&Imprimir";
            // 
            // tsbSalir
            // 
            this.tsbSalir.Image = global::waiTextSharp.Properties.Resources.Exit_16x;
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(65, 36);
            this.tsbSalir.Text = "&Salir";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(107, 36);
            this.toolStripLabel1.Text = "Obtener reporte de";
            // 
            // tscboInformacion
            // 
            this.tscboInformacion.AutoCompleteCustomSource.AddRange(new string[] {
            "Empleado",
            "Persona",
            "Prodcuto"});
            this.tscboInformacion.Items.AddRange(new object[] {
            "Empleado",
            "Persona",
            "Producto"});
            this.tscboInformacion.Name = "tscboInformacion";
            this.tscboInformacion.Size = new System.Drawing.Size(92, 39);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtExcepcion);
            this.groupBox1.Location = new System.Drawing.Point(10, 203);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(581, 119);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excepción";
            // 
            // txtExcepcion
            // 
            this.txtExcepcion.Location = new System.Drawing.Point(4, 17);
            this.txtExcepcion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtExcepcion.Multiline = true;
            this.txtExcepcion.Name = "txtExcepcion";
            this.txtExcepcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExcepcion.Size = new System.Drawing.Size(573, 98);
            this.txtExcepcion.TabIndex = 0;
            // 
            // ReporteiTextSharp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ReporteiTextSharp";
            this.Text = "Generar reportes PDF con iTextSharp";
            this.Load += new System.EventHandler(this.ReporteiTextSharp_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton tsbImprimir;
    private System.Windows.Forms.ToolStripButton tsbSalir;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStripComboBox tscboInformacion;
    private System.Windows.Forms.ToolStripStatusLabel tssMensaje;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox txtExcepcion;
  }
}

