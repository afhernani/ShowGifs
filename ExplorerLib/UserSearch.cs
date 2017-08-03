/*
 * Creado por SharpDevelop.
 * Usuario: hernani
 * Fecha: 02/08/2017
 * Hora: 21:57
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace ExplorerLib
{
	/// <summary>
	/// Description of Search.
	/// </summary>
	public partial class UserSearch : UserControl
	{
		public string Root{ get; set; }
	    public string StrSearch { get; set; } = "Cadena de busqueda";
		
		public UserSearch()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		    textBoxRoot.Text = Root;
		    textBoxString.Text = StrSearch;
		}
		void BtnRootClick(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog() {
				
			};
			if (!String.IsNullOrEmpty(Root)) {
				dialog.SelectedPath = Path.GetDirectoryName(Root);
			}
			if (dialog.ShowDialog() == DialogResult.OK) {
				Root = textBoxRoot.Text = dialog.SelectedPath;
			}
		}

        private void textBoxString_Click(object sender, EventArgs e)
        {
            textBoxString.SelectAll();
        }

        private void textBoxRoot_Click(object sender, EventArgs e)
        {
            textBoxRoot.SelectAll();
        }
        #region funcionesbusqueda

        /// <summary>
        /// delegado genericoa implement interfaz IEnumerable
        /// </summary>
        public delegate IEnumerable getChilds<T>(T element);
        /// <summary>
        /// Función generica de busqueda implement interfaz IEnumerable
        /// se obtiene los nodos de busqueda IEnumerable (elementos) por
        /// que los elementos sólo implementan la interfaz no generiaca.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent">Elemento contenedor</param>
        /// <param name="elements">coleccion de elementos implementan IEnumerable</param>
        /// <param name="criterial">logica del criterio de busqueda</param>
        /// <returns></returns>
        IEnumerable<T> FindRescursive<T>(T parent, getChilds<T> elements, Predicate<T> criterial)
        {
            foreach (T element in elements.Invoke(parent))
            {
                if (criterial.Invoke(element))
                    yield return element;
                foreach (T element2 in FindRescursive<T>(element, elements, criterial))
                {
                    yield return element2;
                }
            }
        }//end FindRecursive.
        /// <summary>
        /// Criterio de busqueda bajo la definicion de delegado.
        /// </summary>
        readonly Predicate<DirectoryInfo> LookForDirectory = (DirectoryInfo D) => D is DirectoryInfo;
        /// <summary>
        /// este delegado define como se obtiene los subdirectorios.
        /// </summary>
        readonly getChilds<DirectoryInfo> getChildDirectorys = (DirectoryInfo D) => D.GetDirectories();
        /// <summary>
        /// busca recursiva un fichero en el directorio y subdirectorios pasado
        /// devuelve cauantas veces se repite, si se repite.
        /// </summary>
        /// <param name="Dir">directorio donde buscar</param>
        /// <param name="file">nombre del fichero a buscar</param>
        public void SearchFileinDirectory(DirectoryInfo Dir, FileInfo file, CancellationTokenSource cs)
        {
            bool encontrado = false;
            foreach (DirectoryInfo element in FindRescursive<DirectoryInfo>(Dir, getChildDirectorys, LookForDirectory))
            {
                cs.Token.ThrowIfCancellationRequested();
                //Console.WriteLine(element.Name);
                Debug.WriteLine(element.Name);
                foreach (FileInfo item in element.GetFiles())
                {
                    if (item.Name.Equals(file.Name))
                    {
                        encontrado = true;
                        OnFileFounderHandler(item);
                        //Console.WriteLine($"found in directory:{element.Name} fichero: {item.FullName}");
                        Debug.WriteLine("found in directory: " + element.Name + " fichero: " + item.FullName);
                    }
                }
            }
            if (!encontrado)
            {
                //no fue encontrado.
                FilesNotFound.Add(file.Name);

            }
            OnFileFounderHandler(null);//simepre que termina la busqueda
        }

        /// <summary>
        /// buscar fichros semejantes.
        /// </summary>
        /// <param name="Dir"></param>
        /// <param name="cad"></param>
        public void SearchFileinDirectory(DirectoryInfo Dir, string cad, CancellationTokenSource cs)
        {
            bool encontrado = false;
            foreach (DirectoryInfo element in FindRescursive<DirectoryInfo>(Dir, getChildDirectorys, LookForDirectory))
            {
                cs.Token.ThrowIfCancellationRequested();
                if (element.Name.Equals("Thumbails"))
                {
                    Debug.WriteLine(element.Name);
                    foreach (FileInfo item in element.GetFiles(cad))
                    {

                        encontrado = true;
                        OnFileFounderHandler(item);
                        //Console.WriteLine($"found in directory:{element.Name} fichero: {item.FullName}");
                        Debug.WriteLine("found in directory: " + element.Name + " fichero: " + item.FullName);
                    }
                }
            }
            if (!encontrado)
            {
                //no fue encontrado.
                //FilesNotFound.Add(file.Name);

            }
            OnFileFounderHandler(null);//simepre que termina la busqueda
        }


        List<string> FilesNotFound { get; set; } = new List<string>();
        /// <summary>
        /// devuelve un array string de los nombres de ficheros
        /// contenidos en el directorio pasado.
        /// -devuelve null si no existe nada.
        /// </summary>
        /// <param name="dir">directorio a extraer la lista de ficheros</param>
        /// <returns></returns>
        public static string[] ArrayFilesFromDirectory(string dir)
        {
            if (!String.IsNullOrEmpty(dir) && Directory.Exists(dir))
            {
                string[] files = Directory.GetFiles(dir, "*.*");
                string[] filesNames = new string[files.Length];
                for (int i = 0; i < files.Length; i++)
                {
                    filesNames[i] = Path.GetFileName(files[i]);
                }
                return filesNames;
            }
            return null;
        }
        public static string[] ArrayFilesFromDirectory(string dir, string lookfor)
        {

            if (!String.IsNullOrEmpty(dir) && Directory.Exists(dir))
            {
                string[] files = Directory.GetFiles(dir, lookfor);
                string[] filesNames = new string[files.Length];
                for (int i = 0; i < files.Length; i++)
                {
                    filesNames[i] = Path.GetFileName(files[i]);
                }
                return filesNames;
            }
            return null;
        }

        public delegate void FileFounder(FileInfo file);
        public event FileFounder FileFounderEvent;
        private void OnFileFounderHandler(FileInfo file)
        {
            FileFounderEvent?.Invoke(file);
        }

        #endregion
        #region Keys_manager

        #endregion
        Task _tarea;
	    public CancellationTokenSource Cs ;
        private void textBoxString_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Debug.WriteLine($"codigo pulsado: {e.KeyCode}:{Keys.Enter}:");
                //todo: aqui vamos a lanzar la busqueda.
                Cs = new CancellationTokenSource();
                StrSearch=$"Buscando: => * { textBoxString.Text} * /(amplia).\n";
                //lib.SearchFileinDirectory(new DirectoryInfo(txtWhere.Text),"*"+txtWhat.Text+"*");
                _tarea = new Task(() => SearchFileinDirectory(new DirectoryInfo(Root), $"*{textBoxString.Text}*", Cs));
                _tarea.Start();
            }
        }
    }
}
