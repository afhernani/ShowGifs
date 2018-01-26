/*
 * Creado por SharpDevelop.
 * Usuario: hernani
 * Fecha: 09/06/2017
 * Hora: 21:16
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ShowGifs
{
	/// <summary>
	/// Description of Explora.
	/// </summary>
	public partial class Explora : Form
	{
        private static Explora _instance = null;
		public Explora()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
            explorerTextCompnt1.Tracker();
		}
        public static Explora GetInstancia()
        {
            if (_instance == null)
            {
                _instance = new Explora();
            }
            return _instance;
        }

        private void explorerTextCompnt1_DirectorysInDir(object sender, TreeNodeMouseClickEventArgs e)
        {
            string txtPath = ((DirectoryInfo)e.Node.Tag).FullName;
            Debug.WriteLine(txtPath);
            explorerTextCompnt1.TrackPath = txtPath; //guardamos la dirección
            IForm forminterfas = this.Owner as IForm;
            forminterfas?.ChangeDirToExplore(txtPath);
        }

        private void Explora_Load(object sender, EventArgs e)
        {
            this.Location = Inicio.Default.ExplorerTop;
            this.Size = Inicio.Default.ExplorerSize;
        }

        private void Explora_FormClosing(object sender, FormClosingEventArgs e)
        {
            Inicio.Default.ExplorerTop = this.Location;
            Inicio.Default.ExplorerSize = this.Size;
            Inicio.Default.Save();
        }
    }
}
