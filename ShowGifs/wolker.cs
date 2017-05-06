/*
 * Creado por SharpDevelop.
 * Usuario: hernani
 * Fecha: 05/05/2017
 * Hora: 20:25
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Explora;

namespace Mark
{
	/// <summary>
	/// Description of wolker.
	/// </summary>
	public partial class wolker : UserControl
	{
		string newling = Environment.NewLine;
		UserControlLibrary lib;
		
		public string RootPath{ get; set; }
		
		public wolker(string root):this()
		{
			RootPath = root;
		}
		
		public wolker()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			lib = new UserControlLibrary();
			lib.DirFounderEvent += DirFound;
			Index = 0;
		}
		List<DirectoryInfo> ListDirectories = new List<DirectoryInfo>();
		void DirFound(DirectoryInfo dir)
		{
			//if (this.InvokeRequired) this.Invoke(new Action(() =>
    		//{
				if (!dir.Name.Equals("Thumbails"))
					ListDirectories.Add(dir);
			//}));	
		}
		Task tarea;
		CancellationTokenSource cs = new CancellationTokenSource();
        /// <summary>
        /// Run Scan looking for Directories into path roon
        /// </summary>
        public void ScanRootPath()
		{
			//salimos si no tenemos una raiz
			if(String.IsNullOrEmpty(RootPath)) return; 
			cs = new CancellationTokenSource();
			//hacemos la tarea.
			tarea = new Task(()=>lib.SearchDirectories(new DirectoryInfo(RootPath), cs));
			tarea.Start();
		}
		//Iteracion de la lista.
		
		int Index{ get; set; }
		/// <summary>
        /// String path next Directory list
        /// </summary>
        /// <returns></returns>
		public string Next()
		{
			if (ListDirectories == null)
				return null;
			if (ListDirectories.Count == 0)
				return null;
			Index++;
			if(Index >= ListDirectories.Count)
			{
				Index = 0;
			}
			return ListDirectories[Index].FullName;
		}
		/// <summary>
        /// return string path previus directory list
        /// </summary>
        /// <returns></returns>
		public string Previus()
		{
			if (ListDirectories == null)
				return null;
			if (ListDirectories.Count == 0)
				return null;
			Index--;
			if(Index < 0 )
			{
				Index = ListDirectories.Count-1;
			}
			return ListDirectories[Index].FullName;	
		}
		
		//set root
		
		public void SetUrl()
		{
			FolderBrowserDialog setDirectory = new FolderBrowserDialog() {
				RootFolder = Environment.SpecialFolder.MyComputer,
			};
			DialogResult result = setDirectory.ShowDialog();
			if (result == DialogResult.OK) {
				RootPath = setDirectory.SelectedPath;
				ScanRootPath();
				//aqui iniciamos la carga de todos los ficheros de imagen
				//contenidos en el directorio.
				//PathsToLoadForApply = setDirectory.SelectedPath;
			} else {
				return;
			}
		}
		public void CancelScan()
		{
			cs.Cancel();
		}
		
	}
}
