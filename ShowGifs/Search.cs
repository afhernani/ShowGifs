/*
 * Creado por SharpDevelop.
 * Usuario: hernani
 * Fecha: 20/10/2016
 * Hora: 12:37
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ShowGifs
{
	/// <summary>
	/// Description of Search.
	/// </summary>
	public partial class Search : Control
	{
		public Search()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			AutoProcess=false;
			LoadDir();
		}
		
		#region listaSerializableDeDirectoriosDeBusqueda

        private List<string> _listDir = new List<string>();
        
        public List<string> ListDir
        {
        	get{return _listDir;}
        	set
        	{
        		_listDir=value;
        	}
        }
        
		/// <summary>
		/// Adicionar a la lista de directorios a buscar.
		/// y guarda a fichero.
		/// </summary>
		/// <param name="str"></param>
        public void AddDir(string str){
        	int index = _listDir.IndexOf(str);
        	if(index ==-1){     		
        		_listDir.Add(str);
        	}
        }
		
		public void RemoveDir(string str){
			int index = _listDir.IndexOf(str);
			if(index !=-1){
				_listDir.Remove(str);
			}	
		}
		
		public string[] ToArrayDir(){
			return _listDir.ToArray();
		}
        /// <summary>
        /// guardar lista de directorios de busqueda.
        /// llama a SaveList()
        /// </summary>
        public void Setting()
        {
            var currdir = Environment.CurrentDirectory;
            var filename = Path.Combine(currdir, "listdir.txt");
            SaveList(filename);
            Debug.WriteLine("Setting -> SaveList("+filename+")");
        }

        /// <summary>
        /// Serializa la lista de directorios de busqueda a fichero
        /// </summary>
        /// <param name="fileName"></param>
        private void SaveList(string fileName)
        {
            using (TextWriter w = new StreamWriter(fileName))
            {
                try
                {
                    XmlSerializer s = new XmlSerializer(typeof(List<string>));
                        //, new Type[] { typeof(Prueba), typeof(PointF[]), typeof(PointU[]) });
                    //desabilitar el xmlseralizerNamespaces de windows
                    XmlSerializerNamespaces names = new XmlSerializerNamespaces();
                    names.Add("CtrlSearch", "CtrlSearch");
                    s.Serialize(w, _listDir, names);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    //MessageBox.Show(ex.ToString());
                }
                finally
                {
                    //w.Close(); tampoco por el using
                }
            }
        }

        
        /// <summary>
        /// Deserializar la lista de directorios de busqueda.
        /// </summary>
        public void LoadDir()
        {
            _listDir.Clear();
            var currdir = Environment.CurrentDirectory;
            var filename = Path.Combine(currdir, "listdir.txt");
            LoadList(filename);
        }

        /// <summary>
        /// Deserializa la lista de directorios de busqueda, leyendo
        /// el fichero correspondiente si existe. call to LoadList
        /// </summary>
        /// <param name="fileName"></param>
        private void LoadList(string fileName)
        {
            if (!File.Exists(fileName)) return; //si el fichero no existe esto no sirve.
            XmlSerializer s = new XmlSerializer(typeof(List<string>));
                //, new Type[] { typeof(Prueba), typeof(PointF[]), typeof(PointU[]) });
            using (TextReader r = new StreamReader(fileName))

            {
                try
                {
                    _listDir = (List<string>) s.Deserialize(r);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            foreach (var item in _listDir)
            {
                //listBoxDir.Items.Add(item);
                if (item.GetType() == typeof(string))
                {
                    Debug.WriteLine("item: {"+item+"}");
                }
            }
        }

        #endregion
		#region Search
        
        /// <summary>
        /// Cadena a buscar.
        /// </summary>
        public string SearchString{get;set;}
        
        public bool AutoProcess { get; set; } //= false;
        
        /// <summary>
        /// lista de localizaciones de ficheros encontrados.
        /// solo lectura. - el resultado de la busqueda siempre
        /// es el ultimo.-
        /// </summary>
        public List<string> FoundFilesPath{
        	get{
        		return _lstFilesFound;
        	}
        	set{
        		_lstFilesFound=value;
        	}
        }

        private List<string> _lstFilesFound = new List<string>();
        
        /// <summary>
        /// lanza tarea de busqueda.
        /// </summary>
        public void Start()
        {
            try
            {
                t = Task.Factory.StartNew(ThreadSearch);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Searching the firth coincidence of string in directory of search.
        /// </summary>
        /// <param name="sDir"></param>
        /// <param name="canonSearch"></param>
        /// <returns></returns>
        private static string SearchingInDir(string sDir, string canonSearch)
        {
            Debug.WriteLine("into a Searching directory: {"+sDir+"}.");
            if (String.IsNullOrEmpty(canonSearch) || String.IsNullOrEmpty(sDir)) return "NOT";
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d, canonSearch))
                    {
                        return f;
                    }
                    //if (_searched) return;
                    SearchingInDir(d, canonSearch);
                }
            }
            catch (System.Exception excpt)
            {
                Debug.WriteLine(excpt.Message);
            }
            return "NOT";
        }

        /// <summary>
        /// Searching the firth coincidence of string to a list the directorys to
        /// looking for.
        /// </summary>
        /// <param name="lstDir"></param>
        /// <param name="canonSearch"></param>
        /// <returns></returns>
        private static string SearchingInAllDir(List<string> lstDir, string canonSearch)
        {
            Debug.WriteLine("Making a Search in all Directorys of: {"+canonSearch+"}.");
            if (String.IsNullOrEmpty(canonSearch) || lstDir == null) return "NOT";
            string res = string.Empty;
            try
            {
                foreach (string sdir in lstDir)
                {
                    res = SearchingInDir(sdir, canonSearch);
                    if (!String.IsNullOrEmpty(res) && !res.Equals("NOT", StringComparison.Ordinal)) return res;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return "NOT";
        }

        private Task t;

        private void ThreadSearch()
        {
            Debug.Write("ThreadSearch : ");
            string res = string.Empty;
            try
            {
                res = SearchingInAllDir(_listDir, SearchString);
                if (!String.IsNullOrEmpty(res) && !res.Equals("NOT", StringComparison.Ordinal))
                {
                    ThreadResult(res);
                }
                else
                {
                    ThreadResult(res);
                    Debug.WriteLine("Xdd");
                } //todo: este loop no hace nada.
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            Debug.WriteLine("founder --> {"+res+"}");
        }
        
        public delegate void SearchedHandler(string res);
        public event SearchedHandler SearchedFileFound;

        private delegate void callbackThreadSearch(string res);

        private void ThreadResult(string result)
        {
            Debug.Write("ThreadResult : ");
            if (this.InvokeRequired)
            {
                Debug.WriteLine("invokeRequired -> {"+result+"}");
                callbackThreadSearch call = new callbackThreadSearch(ThreadResult);
                this.Invoke(call, new object[] {result});
            }
            else
            {
            	Debug.WriteLine( "Result found \n");
            	Debug.WriteLine( result);
                _lstFilesFound.Add(result);
                if(SearchedFileFound!=null) SearchedFileFound(result);
                //SearchedFileFound?.Invoke(result);
                //btnOK.Enabled = true;
                Debug.WriteLine("load-> {"+result+"}");
                if (AutoProcess)
                {
                    if (!result.Equals("NOT"))
                        ThrowProcess();
                    else
                        MessageBox.Show("El fichero o fue encontrado");
                }
            }
        }

       

        /// <summary>
        /// Lanza la aplicasion de video.
        /// </summary>
        public void Run()
        {
            Debug.WriteLine("btnProcess .... ");
            if (FoundFilesPath.Count == 0) return;
            ThrowProcess();
        }

        /// <summary>
        /// Lanza proceso de la ultima busqueda.
        /// </summary>
        private void ThrowProcess()
        {
            Debug.WriteLine("ThrowProcess");
            if (!(FoundFilesPath[FoundFilesPath.Count - 1]).Equals("NOT"))
                Process.Start(FoundFilesPath[FoundFilesPath.Count - 1]);
        }
        
        #endregion
        
	}
}
