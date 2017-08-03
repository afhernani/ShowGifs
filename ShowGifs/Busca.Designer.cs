/*
 * Creado por SharpDevelop.
 * Usuario: hernani
 * Fecha: 02/08/2017
 * Hora: 23:03
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace ShowGifs
{
	partial class Busca
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private ExplorerLib.UserSearch userSearch1;
		
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
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.userSearch1 = new ExplorerLib.UserSearch();
            this.SuspendLayout();
            // 
            // userSearch1
            // 
            this.userSearch1.Location = new System.Drawing.Point(12, 3);
            this.userSearch1.Name = "userSearch1";
            this.userSearch1.Root = null;
            this.userSearch1.Size = new System.Drawing.Size(290, 87);
            this.userSearch1.StrSearch = "Cadena de busqueda";
            this.userSearch1.TabIndex = 0;
            this.userSearch1.FileFounderEvent += new ExplorerLib.UserSearch.FileFounder(this.userSearch1_FileFounderEvent);
            // 
            // Busca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 94);
            this.Controls.Add(this.userSearch1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "Busca";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Busca_KeyDown);
            this.ResumeLayout(false);

		}
	}
}
