using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace ShowGifs
{
    /// <summary>
    /// Control de busqueda en directorios asignados por el usuario.
    /// Control con memoria de directorios a buscar
    /// Busqueda que devuelve la primera coincidencia.
    /// Lanzar el proceso del fichero encontrado.
    /// </summary>
    public partial class CtrlSearch : Form
    {
    	
    	private static CtrlSearch _instance = null;
    	private static Search search = null;
    	
        private CtrlSearch()
        {
            InitializeComponent();
            
            search = new Search();  
            btnProcess.Enabled = false;
            search.AutoProcess = false;
            search.SearchedFileFound += HandlerSearchedFile;
            LoadList();
        }
        
        public static CtrlSearch GetInstancia()
		{
			if (_instance == null)
			{
				_instance = new CtrlSearch();
			}
			return _instance;
		}

        /// <summary>
        /// Cadena a buscar.
        /// </summary>
        public string SearchString
        {
            get { return search.SearchString; }
            set { 
            	textBoxStringSearch.Text = value;
            	search.SearchString=value; 
            }
        }

        /// <summary>
        /// set lista directorios de busqueda.
        /// </summary>
        /// <param name="listDir"></param>
        public void SetListDir(List<string> listDir)
        {
        	search.ListDir=listDir;
        }

        

        #region listaSerializableDeDirectoriosDeBusqueda

        private List<string> _listDir = new List<string>();

        /// <summary>
        /// boton para guardar la lista de directorios de busqueda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetting_Click(object sender, EventArgs e)
        {
        	SetListDir(_listDir);
        	search.Setting();
        }
        
        private void LoadList()
        {
        	_listDir = search.ListDir;
        	listBoxDir.Items.AddRange(_listDir.ToArray());
        	Debug.WriteLine("Add list Dir to listBoxDir in Form "+this.Text);
            foreach (var item in listBoxDir.Items)
            {
                //listBoxDir.Items.Add(item);
                if (item.GetType() == typeof(string))
                {
                    Debug.WriteLine("item: {"+item+"}");
                }
            }
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxNewDir.Text)) return;
            var strdir = textBoxNewDir.Text;
            strdir = strdir.Trim();
            //Do: comprobar directorios virtuales. si/no raiz
            if (!Path.IsPathRooted(strdir))
            {
                Debug.WriteLine("NO TIENE RAIZ, ES UN DIRECTORIO VIRTUAL {"+strdir+"}");
            }
            // Do: comprobar si existe directorio si, no
            if (Directory.Exists(strdir))
            {
                listBoxDir.Items.Add(strdir);
                _listDir.Add(strdir);
                //search.Add(strdir);
            }
            else
            {
                Debug.WriteLine("DIRECTORI: {"+strdir+"}, NO EXISTE");
            }
            // Do: si añadir, no --> no añadir. 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = listBoxDir.SelectedIndex;
            if (index == -1 ) return; //nota / ningun index selecionado
            _listDir.Remove((string) listBoxDir.Items[index]);
            //search.Remove((string) listBoxDir.Items[index]);
            listBoxDir.Items.RemoveAt(index);
        }

        private void textBoxNewDir_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("textBocNewDir_Click");
            if (!String.IsNullOrEmpty(textBoxNewDir.Text))
            {
                textBoxNewDir.SelectionStart = 0;
                textBoxNewDir.SelectionLength = textBoxNewDir.Text.Length;
            }
        }

        /// <summary>
        /// lista de localizaciones de ficheros encontrados.
        /// solo lectura. - el resultado de la busqueda siempre
        /// es el ultimo.-
        /// </summary>
        public List<string> FoundFilesPath {get{return _lstFilesFound;}}

        private List<string> _lstFilesFound = new List<string>();

        /// <summary>
        /// Realiza una tarea de busqueda en los directorios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("btnOk_Click");
            btnOK.Enabled = false;
            search.Start();
            
        }

		void HandlerSearchedFile(string res)
		{
			if(this.InvokeRequired)
			{
				Search.SearchedHandler call = 
					new Search.SearchedHandler(HandlerSearchedFile);
				this.Invoke(call, new object[] {res});
			}
			else
			{
				if (res.Equals("NOT")){
					//no lo encontro
					lbResque.Text = "No fue encontrado el fichero";
				}else{
					//lo encontro
					lbResque.Text = res;
					btnProcess.Enabled = true;
				}
				btnOK.Enabled = true;
			}
		}
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("btnCancel_Click");
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("btnProcess .... ");
            if (search.FoundFilesPath.Count == 0) return;
            btnProcess.Enabled = false;
            ThrowProcess();
            this.Close();
        }

        private void ThrowProcess()
        {
            Debug.WriteLine("ThrowProcess");
            if (!(search.FoundFilesPath[search.FoundFilesPath.Count - 1]).Equals("NOT"))
                Process.Start(search.FoundFilesPath[search.FoundFilesPath.Count - 1]);
        }
        
        /// <summary>
        /// Introduce elemento seleccionado en el cuadro de texto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxDir.SelectedIndex;
            if (index == -1 ) return; //nota / ningun index selecionado
            var selected = listBoxDir.SelectedItem;
            textBoxNewDir.Text = selected.ToString();
        }
        /// <summary>
        /// Sube una nivel el elemento de la lista. listBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Up - list directory select: ");
            int index = listBoxDir.SelectedIndex;
            if (index == -1 || index ==0) return; //nota / ningun index selecionado o el primero
            int aboveIndex = index - 1;
            string aboveitem = (string)listBoxDir.Items[aboveIndex];
            listBoxDir.Items.RemoveAt(aboveIndex);
            listBoxDir.Items.Insert(index, aboveitem);
            //ahora en la lista.
            _listDir.RemoveAt(aboveIndex);
            _listDir.Insert(index,aboveitem);
            // guardamos los cambios
            search.ListDir = _listDir;
        }
    }
}