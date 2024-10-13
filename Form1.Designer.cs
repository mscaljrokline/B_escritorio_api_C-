
namespace BCP_AMHCH
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adicionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abonoRetiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saldosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 248);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionToolStripMenuItem,
            this.abonoRetiroToolStripMenuItem,
            this.transferenciaToolStripMenuItem,
            this.saldosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adicionToolStripMenuItem
            // 
            this.adicionToolStripMenuItem.Name = "adicionToolStripMenuItem";
            this.adicionToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.adicionToolStripMenuItem.Text = "Adicion";
            this.adicionToolStripMenuItem.Click += new System.EventHandler(this.adicionToolStripMenuItem_Click);
            // 
            // abonoRetiroToolStripMenuItem
            // 
            this.abonoRetiroToolStripMenuItem.Name = "abonoRetiroToolStripMenuItem";
            this.abonoRetiroToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.abonoRetiroToolStripMenuItem.Text = "Abono/Retiro";
            this.abonoRetiroToolStripMenuItem.Click += new System.EventHandler(this.abonoRetiroToolStripMenuItem_Click);
            // 
            // transferenciaToolStripMenuItem
            // 
            this.transferenciaToolStripMenuItem.Name = "transferenciaToolStripMenuItem";
            this.transferenciaToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.transferenciaToolStripMenuItem.Text = "Transferencias";
            this.transferenciaToolStripMenuItem.Click += new System.EventHandler(this.transferenciaToolStripMenuItem_Click);
            // 
            // saldosToolStripMenuItem
            // 
            this.saldosToolStripMenuItem.Name = "saldosToolStripMenuItem";
            this.saldosToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.saldosToolStripMenuItem.Text = "Saldos";
            this.saldosToolStripMenuItem.Click += new System.EventHandler(this.saldosToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adicionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abonoRetiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saldosToolStripMenuItem;
    }
}

