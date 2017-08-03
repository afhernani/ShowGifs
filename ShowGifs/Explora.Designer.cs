/*
 * Creado por SharpDevelop.
 * Usuario: hernani
 * Fecha: 09/06/2017
 * Hora: 21:16
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace ShowGifs
{
	partial class Explora
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private ExplorerLib.ExplorerTextCompnt explorerTextCompnt1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
            _instance = null;
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explora));
            this.explorerTextCompnt1 = new ExplorerLib.ExplorerTextCompnt(this.components);
            this.SuspendLayout();
            // 
            // explorerTextCompnt1
            // 
            this.explorerTextCompnt1.AutoScroll = true;
            this.explorerTextCompnt1.AutoSize = true;
            this.explorerTextCompnt1.Cursor = System.Windows.Forms.Cursors.Default;
            this.explorerTextCompnt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.explorerTextCompnt1.Location = new System.Drawing.Point(0, 0);
            this.explorerTextCompnt1.Name = "explorerTextCompnt1";
            this.explorerTextCompnt1.Size = new System.Drawing.Size(199, 206);
            this.explorerTextCompnt1.TabIndex = 0;
            this.explorerTextCompnt1.TrackPath = "";
            this.explorerTextCompnt1.DirectorysInDir += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.explorerTextCompnt1_DirectorysInDir);
            // 
            // Explora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 206);
            this.Controls.Add(this.explorerTextCompnt1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Explora";
            this.Text = "Explorer Directories";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
