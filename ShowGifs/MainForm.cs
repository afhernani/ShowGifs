/*
 * Creado por SharpDevelop.
 * Usuario: hernani
 * Fecha: 19/10/2016
 * Hora: 22:31
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ScanGifDir;
using System.Threading;
using Explora;
using Mark;

namespace ShowGifs
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form, IForm
    {
        wolker wol;//= new wolker();
        Thread s;
        public MainForm()
        {
            //Thread s = new Thread(new ThreadStart(SplastStrart));
            //s.Start();
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            //
            //Thread.Sleep(5000);
            //s.Abort();
        }

        private Task t;
        //private int nf = 0;
        private int _ancho = 160, _largo = 120;

        private void LoadImagesFromDirectoryAll(DirectoryInfo dir, FlowLayoutPanel flow)
        {
            foreach (FileInfo fileInfo in dir.GetFiles())
            {

                if (fileInfo.Extension == ".gif" || fileInfo.Extension == ".GIF")
                {
                    PictureBox sprite = new PictureBox()
                    {
                        Width = _ancho,
                        Height = _largo,
                        BackColor = Color.BurlyWood,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Tag = fileInfo.FullName,
                        Image = Utilities.Image.FromFile(fileInfo.FullName),
                        //Image = (Image)Image.FromFile(fileInfo.FullName).Clone(),                        
                    };
                    //sprite.Tag = fileInfo.FullName;
                    //sprite.Image = (Image)Image.FromFile(fileInfo.FullName).Clone();
                    sprite.SizeMode = PictureBoxSizeMode.Zoom;
                    sprite.Click += sprite_Click;
                    sprite.MouseClick += sprite_MouseClick;
                    flowControlsAdd(sprite, flow);
                }

            }
        }

        private delegate void setcallBackflowLayout(PictureBox sprite, FlowLayoutPanel flow);

        private void flowControlsAdd(PictureBox sprite, FlowLayoutPanel flow)
        {
            if (this.InvokeRequired)
            {
                setcallBackflowLayout call = new setcallBackflowLayout(flowControlsAdd);
                this.Invoke(call, new object[] { sprite, flow });
            }
            else
            {
                flow.Controls.Add(sprite);//todo: buscar el tabpage selected
                TabPage tabpage = (TabPage)flow.Parent;
                this.Text = @"ShowGif: -" + tabpage.Text + "-" + tabpage.Controls[0].Controls.Count.ToString() + " items";
                //flowLayoutPanel1.Refresh();
            }
        }

        #region eventos sprite

        public string CurrentFilePath { get; set; } = null;

        private void sprite_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox sprite = (PictureBox)sender;
            CurrentFilePath = sprite.Tag.ToString();
            string filesearch = GetFileNameFromString(sprite.Tag.ToString());
            CurrentFile = filesearch;
            Debug.WriteLine("sprite nombre -> " + sprite.Tag.ToString());
            toolStripMenuItemPlay.Enabled = true;
            if (e.Button == MouseButtons.Right)
            {
                Debug.Write("sprite_mouseclick_right");
                Debug.WriteLine(", sprite a eliminar con nombre : " + sprite.Tag.ToString());
                //propertyGrid1.SelectedObject = null;
                //tabControl1.SelectedTab.Controls[0].Controls.Remove(sprite); //todo revisar.
            }
            if (e.Button == MouseButtons.Left)
            {
                Debug.Write("sprite_mouseclick_left");
                Debug.WriteLine(", name = " + sprite.Tag.ToString());
                toolStripStatusLabel1.Text = sprite.Tag.ToString();
                if (Form.ModifierKeys == Keys.Control)
                {
                    //abrir formulario con la imagen.
                    FGif fgif = new FGif();
                    Size size = new Size(sprite.Image.Width, sprite.Image.Height);
                    fgif.Size = size;
                    fgif.ImageToView = sprite.Image;
                    fgif.Tag = sprite.Tag;
                    fgif.Show();
                    Debug.WriteLine("sprite_mouseClick_left + Key-Control: presed");
                }
                if (Form.ModifierKeys == Keys.Alt)
                {
                    if (Path.GetExtension(filesearch).Equals(".gif"))
                    {
                        MessageBox.Show("OOOfff");
                        return;
                    }
                    Search control = new Search()
                    {
                        SearchString = filesearch,
                        AutoProcess = true
                    };
                    control.Start();
                    Debug.WriteLine("sprite_mouseClick_left + Key-Alt: process");
                }
                if (Form.ModifierKeys == Keys.Shift)
                {
                    tabControl1.SelectedTab.Controls[0].Controls.Remove(sprite);
                    Debug.WriteLine("delete picture con Key -> Shift:");
                }

            }
        }

        private void sprite_Click(Object sender, EventArgs e)
        {
            Debug.WriteLine("sprite_Click");
            PictureBox sprite = (PictureBox)sender;
            CurrentFilePath = sprite.Tag.ToString();
            Debug.WriteLine("name = " + CombineAddressFileMovie(sprite.Tag.ToString()));
            //pictureBox1.Image = sprite.Sprite;
            //propertyGrid1.SelectedObject = sprite;
            //ctrlSearch1.SearchString = GetFileNameFromString(sprite.FileSprite);
        }

        private static string GetFileNameFromString(string name)
        {
            int pos = name.IndexOf(@"_thumbs_", StringComparison.Ordinal);
            if (pos == -1)
                return name;
            name = name.Substring(0, pos);
            return Path.GetFileName(name);
        }

        private static string CombineAddressFileMovie(string currentfilepath)
        {
            string name = null;
            string cad = null;
            if (!String.IsNullOrEmpty(currentfilepath))
            {
                name = GetFileNameFromString(currentfilepath);
                cad = Path.Combine(PathNivel(Path.GetDirectoryName(currentfilepath), 1), name);
            }
            Debug.WriteLine($"direccion fichero: {cad}");
            return cad;
        }

        #endregion

        #region ManejoKey
        private string CurrentFile { get; set; }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (String.IsNullOrEmpty(CurrentFile))
                return true;
            string filesearch = GetFileNameFromString(CurrentFile);
            if (keyData == (Keys.Control | Keys.Alt | Keys.S))
            {
                Debug.WriteLine("<CTRL> + Alt + S Captured");
                LanchCtrlSearch(filesearch);
                return true;
            }
            if (keyData == (Keys.Control | Keys.V))
            {
                Debug.WriteLine("<CTRL> + V Captured");
                SearchAndLunchVideo(filesearch);
                return true;
            }
            if (keyData == (Keys.Control | Keys.M))
            {
                Debug.WriteLine("<CTRL> + M Move");
                if (!String.IsNullOrEmpty(CurrentFilePath))
                    LanchMoveCurrentFilePath(CurrentFilePath);
                return true;
            }
            if (keyData == Keys.Left)
            {
                Debug.WriteLine("< <-- > + Arraw left");
                //TODO: hacer algo aqui.
                AdvancePage();
                return true;
            }
            if (keyData == Keys.Right)
            {
                Debug.WriteLine("< --> > + Arraw right");
                //TODO: hacer algo aqui.
                //retroceder explorando.
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// inicializa el wolker retrocediendo n niveles.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="nivel"></param>
	    private void InicializaWolker(string root, int n)
        {
            //TODO: introducir el directorio de scan.
            string pathroot = PathNivel(root, n);
            Debug.WriteLine($"Directorio para escanear: {pathroot}\n");
            wol = new wolker(pathroot);
            wol.InitialDirectory = root;
            wol.ScanRootPath();

        }
        /// <summary>
        /// Utilidad para retroceder
        /// devuelve el nivel n veces inferior en el path
        /// </summary>
        /// <param name="root"></param>
        /// <param name="n"></param>
        /// <returns></returns>
	    private static string PathNivel(string root, int n)
        {
            string[] name = root.Split(Convert.ToChar(@"\"));
            string path = name[0];
            for (int i = 1; i < name.Length - n; i++)
            {
                path += @"\" + name[i];
            }
            return path;
        }
        /// <summary>
        /// AdvancePage, siguiente directorio del raiz.
        /// </summary>
	    private void AdvancePage()
        {
            //limpia la pagina actual/seleccionada
            //añade los nuevos elementos del directorio siguiente
            FlowLayoutPanel flow = (FlowLayoutPanel)tabControl1.SelectedTab.Controls[0];
            //(FlowLayoutPanel)((TabPage)sender).Controls[0];
            flow.Controls.Clear();
            string dir = wol.Next();
            LoadPage(dir + @"\Thumbails");
        }
        /// <summary>
        /// PreviusPage, pagina anterior del directori raiz.
        /// </summary>
	    private void PreviusPage()
        {
            FlowLayoutPanel flow = (FlowLayoutPanel)tabControl1.SelectedTab.Controls[0]; //(FlowLayoutPanel)((TabPage)sender).Controls[0];
            flow.Controls.Clear();
            string dir = wol.Previus();
            LoadPage(dir + @"\Thumbails");
        }

        private void LanchMoveCurrentFilePath(string currentfilepath)
        {
            Debug.WriteLine("LanchMoveCurrentFilePath");
            Movefrm move = Movefrm.GetInstancia();
            move.FileGifPath = currentfilepath;
            move.FileMoviePaht = CurrentFile;
            move.InitializeInstancia();
            move.Show();
        }

        private void LanchCtrlSearch(string filesearch)
        {
            if (Path.GetExtension(filesearch).Equals(".gif"))
            {
                MessageBox.Show("OOOfff");
                return;
            }
            CtrlSearch ctrlsearch = CtrlSearch.GetInstancia();
            ctrlsearch.SearchString = filesearch;
            ctrlsearch.Show();

        }

        private void SearchAndLunchVideo(string filesearch)
        {
            if (Path.GetExtension(filesearch).Equals(".gif"))
            {
                MessageBox.Show("OOOfff");
                return;
            }
            Search control = new Search()
            {
                SearchString = filesearch,
                AutoProcess = true
            };
            control.Start();

        }

        #endregion

        /*
         * Acciones de Teclado.
         * muse-clik + Alt -> busqueda y visionado del video
         * mouse-clik + Ctrl -> open ventana formulario FGif.
         * mouse-Click + Shift -> borra elemento del programa
         * Ctrl+Alt+S -> lanzar formulario CtrlSearch
		 * Ctrl + V -> lanza busqueda y visionado del fichero.
         */

        #region contexmenustrip

        //lista de directorio favorito.
        string PathsToLoadForApply { get; set; }

        void OpenDirToolStripMenuItemClick(object sender, EventArgs e)
        {
            //crear pagina nueva.
            NewPageToolStripMenuItemClick(new object() { }, new EventArgs());
            FolderBrowserDialog setDirectory = new FolderBrowserDialog()
            {
                RootFolder = Environment.SpecialFolder.MyComputer,
            };
            DialogResult result = setDirectory.ShowDialog();
            if (result == DialogResult.OK)
            {
                //setWorkDirectory = setDirectory.SelectedPath;
                //aqui iniciamos la carga de todos los ficheros de imagen
                //contenidos en el directorio.
                //PathsToLoadForApply = setDirectory.SelectedPath;

                string selectedPath = setDirectory.SelectedPath;

                string dirthumbails = selectedPath + @"\Thumbails";
                InicializaWolker(selectedPath, 1);
                LoadPage(dirthumbails);

            }
        }

        void NewPageToolStripMenuItemClick(object sender, EventArgs e)
        {
            TabPage tabpage = new TabPage("tabPage" + (tabControl1.Controls.Count + 1).ToString());
            FlowLayoutPanel flow = new FlowLayoutPanel()
            {
                AutoScroll = true,
                Dock = DockStyle.Fill
            };
            tabpage.Controls.Add(flow);
            tabControl1.Controls.Add(tabpage);
            tabControl1.SelectedTab = tabpage;
        }
        private bool modificado = false;
        void ClosePageToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (!modificado)
            {
                TabPage page = tabControl1.SelectedTab;
                tabControl1.Controls.Remove(page);
            }

        }
        void OpenFileToolStripMenuItemClick(object sender, EventArgs e)
        {
            string filename = "xmlwriter.txt";
            //crear pagina nueva.
            NewPageToolStripMenuItemClick(new object() { }, new EventArgs());
            OpenFileDialog openfile = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "Txt File (*.txt)|*.txt",
                FilterIndex = 1,
                Title = "Open file",
                //InitialDirectory = Environment.CurrentDirectory,
                RestoreDirectory = false,
            };
            if (openfile.ShowDialog() == DialogResult.OK)
                filename = openfile.FileName;
            else
                return;
            FlowLayoutPanel flow = (FlowLayoutPanel)tabControl1.SelectedTab.Controls[0];
            flow.Controls.Clear();
            Debug.WriteLine("DeSerialize list controls");
            try
            {
                tabControl1.SelectedTab.Text = Path.GetFileNameWithoutExtension(filename);
                t = Task.Factory.StartNew(() => ThreadDeSerializeControls(filename, flow));
                //ThreadDeSerializeControls(filename);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error Deserializar lista controles: {" + ex + "}");
            }
        }

        void SaveFileToolStripMenuItemClick(object sender, EventArgs e)
        {
            //salvar lista de componentes. < lista simple >
            Debug.WriteLine("event SaveFileToolStripMenuItemClick");
            string filename = "xmlwriter.txt";
            SaveFileDialog savefile = new SaveFileDialog
            {
                Filter = @"Txt File (*.txt)|*.txt",
                FilterIndex = 1,
                Title = @"Save file",
                //InitialDirectory = Environment.CurrentDirectory,
                RestoreDirectory = false,
            };
            if (savefile.ShowDialog() == DialogResult.OK)
                filename = savefile.FileName;
            else
                return;

            Debug.WriteLine("Serialize list controls");
            try
            {
                FlowLayoutPanel flow = (FlowLayoutPanel)tabControl1.SelectedTab.Controls[0];
                tabControl1.SelectedTab.Text = Path.GetFileNameWithoutExtension(filename);
                t = Task.Factory.StartNew(() => ThreadSerializeControls(filename, flow));
                //ThreadSerializeControls(filename);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error serializar lista controles: " + ex.Message);
            }
        }
        void QuitToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.Close();
        }

        void SaveDirFavoritoToolStripMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                FlowLayoutPanel flow = (FlowLayoutPanel)tabControl1.SelectedTab.Controls[0];
                string dir = Path.GetDirectoryName((string)flow.Controls[0].Tag);
                PathsToLoadForApply = dir;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void ToolStripMenuItemPlayClick(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(CurrentFile))
                return;
            string filesearch = GetFileNameFromString(CurrentFile);
            Debug.WriteLine("<MenuStrip> + Captured and Play");
            SearchAndLunchVideo(filesearch);
        }
        #endregion

        #region eventformulario

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Inicio.Default.FormSize = this.Size;
                Inicio.Default.Save();
            }

            if (!String.IsNullOrEmpty(PathsToLoadForApply))
            {
                Inicio.Default.DirOpenedPreviusCesion = PathsToLoadForApply;
                Inicio.Default.Save();
            }

        }
        private void SplastStrart()
        {
            Application.Run(Creditos.GetCreditos());
        }
        void MainForm_Load(object sender, EventArgs e)
        {
            if (Inicio.Default.FormSize.Height != 0 && Inicio.Default.FormSize.Width != 0)
            {
                this.Size = Inicio.Default.FormSize;
            }
            LoadPage(Inicio.Default.DirOpenedPreviusCesion);

        }
        /// <summary>
        /// load-page for dir specific.
        /// </summary>
        /// <param name="dir"></param>
	    private void LoadPage(string dir)
        {
            if (Directory.Exists(dir))
            {
                //if(MessageBox.Show("Do you wish open the last cession "+ Inicio.Default.DirOpenedPreviusCesion
                //                   ,"Open Dirs",MessageBoxButtons.OKCancel
                //                   ,MessageBoxIcon.Asterisk)
                //                   == DialogResult.OK){ 	}
                try
                {
                    FlowLayoutPanel flow = (FlowLayoutPanel)tabControl1.SelectedTab.Controls[0]; //(FlowLayoutPanel)((TabPage)sender).Controls[0];
                    string[] name = dir.Split(Convert.ToChar(@"\"));
                    tabControl1.SelectedTab.Text = name[name.Length - 2];
                    t = Task.Factory.StartNew(() => LoadImagesFromDirectoryAll(new DirectoryInfo(dir), flow));
                    //Task.WaitAll(t);
                }
                catch (AggregateException ex)
                {
                    Debug.WriteLine("OpenDirectory error:-> " + ex.Message);
                    // Display information about each exception. 
                    foreach (var v in ex.InnerExceptions)
                    {
                        if (v is TaskCanceledException)
                            Debug.WriteLine("   TaskCanceledException: Task {0}",
                                ((TaskCanceledException)v).Task.Id);
                        else
                            Debug.WriteLine("   Exception: {0}", v.GetType().Name);
                    }
                    Debug.WriteLine("");
                }
                finally
                {
                    //tokenSource.Dispose();
                }
            }
        }

        /// <summary>
        /// Captura y sobreescribe el manejo de la rueda del raton para el panel
        /// flowLayoutPanel activo en el momento, en su scroll vertical unicamente.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            /* codigo aqui ...*/
            Debug.Write("OnMouseWheel acction ");
            int ingrementVertical;
            FlowLayoutPanel flow = (FlowLayoutPanel)tabControl1.SelectedTab.Controls[0];
            if (flow != null)
            {
                ScrollProperties Vscroll = flow.VerticalScroll;
                Debug.WriteLine("SmalChanges: {Vscroll.SmallChange} , LargeChange: {Vscroll.LargeChange}");
                Debug.WriteLine("on flow {e.Delta};");
                int newValor = Vscroll.Value - e.Delta;
                if (newValor < Vscroll.Minimum || newValor > Vscroll.Maximum)
                {
                    Debug.WriteLine("<Out of Minimum and Maximum>");
                    base.OnMouseWheel(e);
                    return;
                }
                //habra que depurar mas para no salirse de los limites de los valores
                //if Value+=e.Deta esta ente el minimo y maximo de los se suma.
                //analizamos el asunto despues.....
                flow.VerticalScroll.Value = newValor;
            }
            flow.Invalidate();
            base.OnMouseWheel(e);
        }

        #endregion

        #region drag-drog

        protected string[] ArrayFilesNames = null;
        //protected string lastFilename=String.Empty;
        protected DragDropEffects effect;
        protected bool validData;

        private void OnDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Debug.WriteLine("OnDragDrop");
            if (validData)
            {
                //nota: aqui vamos generar el proceso que interesa.
                if (ArrayFilesNames != null)
                {
                    //LoadFilesDragDrog();
                    //una carga en segundo plano
                    //consegimos el flowlayoutpanel activo-
                    FlowLayoutPanel flow = (FlowLayoutPanel)tabControl1.SelectedTab.Controls[0];
                    try
                    {
                        t = Task.Factory.StartNew(() => LoadArrayDragDrog(ArrayFilesNames, flow));

                    }
                    catch (Exception ex)
                    {

                        Debug.WriteLine(ex.Message);
                    }

                }
            }
        }

        private void LoadArrayDragDrog(string[] array, FlowLayoutPanel flow)
        {

            foreach (var item in array)
            {
                if (item.GetType() == typeof(string))
                {
                    Debug.WriteLine("item: {" + item + "}");
                }
                if (File.Exists(item))
                {

                    PictureBox sprite = new PictureBox()
                    {
                        Width = _ancho,
                        Height = _largo,
                        BackColor = Color.BurlyWood,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Tag = item,
                        Image = (Image)Utilities.Image.FromFile(item).Clone(),
                    };
                    //sprite.Tag = fileInfo.FullName;
                    //sprite.Image = (Image)Image.FromFile(fileInfo.FullName).Clone();
                    sprite.SizeMode = PictureBoxSizeMode.Zoom;
                    sprite.Click += sprite_Click;
                    sprite.MouseClick += sprite_MouseClick;
                    lock (flow)
                    {
                        flowControlsAdd(sprite, flow);
                    }

                }
            }
        }

        /*
		private void LoadFilesDragDrog()
		{
			foreach (var element in ArrayFilesNames) {
				
				PictureBox sprite = new PictureBox()
				{
					Width = _ancho,
					Height = _largo,
					BackColor = Color.BurlyWood,
					SizeMode = PictureBoxSizeMode.StretchImage,
					Tag = element,
					Image = (Image)Image.FromFile(element).Clone(),
				};
				//sprite.Tag = fileInfo.FullName;
				//sprite.Image = (Image)Image.FromFile(fileInfo.FullName).Clone();
				sprite.SizeMode=PictureBoxSizeMode.Zoom;
				sprite.Click += sprite_Click;
				sprite.MouseClick += sprite_MouseClick;
				FlowLayoutPanel flow = (FlowLayoutPanel)tabControl1.SelectedTab.Controls[0];
				flowControlsAdd(sprite, flow);
				
			}
		} */

        private void OnDragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Debug.WriteLine("OnDragEnter");
            string filename;
            string[] filesnames;
            validData = GetFilename(out filename, out filesnames, e);
            if (validData)
            {
                /*if (lastFilename != filename)
				{
					
					lastFilename=filename;
					
				}
				else
				{
					//
				}*/
                if (!Array.Equals(ArrayFilesNames, filesnames))
                {
                    Debug.WriteLine("son desiguales");
                    //listBox1.Items.Clear(); //no interesa aqui si no cuando se suelta
                    ArrayFilesNames = filesnames;
                }
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void OnDragLeave(object sender, System.EventArgs e)
        {
            Debug.WriteLine("OnDragLeave");
            //
        }

        private void OnDragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Debug.WriteLine("OnDragOver");
            if (validData)
            {
                //sobre el formulario sin soltar.
            }
        }

        protected bool GetFilename(out string filename, out string[] filesnames, DragEventArgs e)
        {
            bool ret = false;
            filename = String.Empty;
            filesnames = null;

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileDrop") as Array;
                if (data != null)
                {
                    /*if ( (data.Length == 1) && (data.GetValue(0) is String) )
					{
						filename=((string[])data)[0];
						string ext=Path.GetExtension(filename).ToLower();
						if ( (ext==".gif") )
						{
							ret=true;
						}
					}*/
                    if (data.Length >= 1)
                    {

                        filesnames = ((string[])data);
                        filesnames = filesnames.Where(x => IsExtUtil(Path.GetExtension(x).ToLower())).ToArray();
                        if (filesnames.Length == 0)
                            ret = false;
                        else
                        { //al menos hay uno.
                            filename = filesnames[0];
                            ret = true;
                        }

                    }
                }
            }
            return ret;
        }

        private static string[] limpiaEspaciosVaciosString(string cadena)
        {
            string[] datos = cadena.Split(" ".ToCharArray());
            datos = datos.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return datos;
        }

        private static bool IsExtUtil(string ext)
        {
            if ((ext == ".gif"))
            {//||(ext==".mp4")||(ext==".avi")||(ext==".mpeg")||(ext==".wmv")||(ext==".mov")){
                return true;
            }
            else
                return false;
        }

        #endregion

        #region listaserializada

        /// <summary>
        /// Serializa la lista de gif a un fichero
        /// </summary>
        /// <param name="fileName"></param>
        private void SaveList(string fileName, List<string> list)
        {
            using (TextWriter w = new StreamWriter(fileName))
            {
                try
                {
                    XmlSerializer s = new XmlSerializer(typeof(List<string>));
                    //, new Type[] { typeof(Prueba), typeof(PointF[]), typeof(PointU[]) });
                    //desabilitar el xmlseralizerNamespaces de windows
                    XmlSerializerNamespaces names = new XmlSerializerNamespaces();
                    names.Add("gif", "ShowGifs");
                    s.Serialize(w, list, names);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    //MessageBox.Show(ex.ToString());
                }
                finally
                {
                    //w.Close(); tampoco por el using
                }
            }
        }

        private void ThreadSerializeControls(string filename, FlowLayoutPanel flow)
        {

            List<string> listfilesGif = new List<string>();
            Control.ControlCollection controls;
            lock (flow)
            {
                controls = flow.Controls;
            }
            List<PictureBox> _listPictures = controls.Cast<PictureBox>().ToList();
            if (_listPictures.Count == -1)
                return;
            try
            {
                foreach (var element in _listPictures)
                {
                    listfilesGif.Add((string)element.Tag);
                }
                SaveList(filename, listfilesGif);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
        private void ThreadDeSerializeControls(string filename, FlowLayoutPanel flow)
        {
            try
            {
                LoadList(filename, flow);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Deserializa la lista de gif comprobando si existen. call to LoadList
        /// </summary>
        /// <param name="fileName"></param>
        private void LoadList(string fileName, FlowLayoutPanel flow)
        {
            List<string> list = null;

            if (!File.Exists(fileName))
                return; //si el fichero no existe esto no sirve.
            XmlSerializer s = new XmlSerializer(typeof(List<string>));
            //, new Type[] { typeof(Prueba), typeof(PointF[]), typeof(PointU[]) });
            using (TextReader r = new StreamReader(fileName))
            {
                try
                {
                    list = (List<string>)s.Deserialize(r);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            foreach (var item in list)
            {
                if (item.GetType() == typeof(string))
                {
                    Debug.WriteLine("item: {" + item + "}");
                }
                if (File.Exists(item))
                {

                    PictureBox sprite = new PictureBox()
                    {
                        Width = _ancho,
                        Height = _largo,
                        BackColor = Color.BurlyWood,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Tag = item,
                        Image = (Image)Utilities.Image.FromFile(item).Clone(),
                    };
                    //sprite.Tag = fileInfo.FullName;
                    //sprite.Image = (Image)Image.FromFile(fileInfo.FullName).Clone();
                    sprite.SizeMode = PictureBoxSizeMode.Zoom;
                    sprite.Click += sprite_Click;
                    sprite.MouseClick += sprite_MouseClick;
                    lock (flow)
                    {
                        flowControlsAdd(sprite, flow);
                    }

                }
            }
        }
        #endregion

        private void toolStripAfter_Click(object sender, EventArgs e)
        {
            if (wol == null) return;
            AdvancePage();
        }

        private void toolStripBefore_Click(object sender, EventArgs e)
        {
            if (wol == null) return;
            PreviusPage();
        }

        private void toolStripReproducir_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(CurrentFilePath)) return;
            string movie = CombineAddressFileMovie(CurrentFilePath);
            if (File.Exists(movie)) Process.Start(movie);

        }

        private void toolStripScull_Click(object sender, EventArgs e)
        {
            //TODO enlazar el wolker con la pagina activa.
            FlowLayoutPanel flow = (FlowLayoutPanel)tabControl1.SelectedTab.Controls[0];
            if (flow.Controls.Count == 0)
                return;
            PictureBox picture = (PictureBox)flow.Controls[0];
            if (picture != null)
            {
                string direccion = picture.Tag.ToString();
                InicializaWolker(PathNivel(Path.GetDirectoryName(direccion), 1), 1);
            }
        }

        void TabControl1Selected(object sender, TabControlEventArgs e)
        {
            TabControl tabcontrol = (TabControl)sender;
            if (tabcontrol.SelectedTab != null)
            {
                this.Text = "ShowGif: -" + tabcontrol.SelectedTab.Text + "- " +
                tabcontrol.SelectedTab.Controls[0].Controls.Count.ToString() + " items";
            }
        }
        void ToolStripGifClick(object sender, EventArgs e)
        {
            Image sprite = Image.FromFile(CurrentFilePath);
            FGif fgif = new FGif();
            Size size = new Size(sprite.Width, sprite.Height);
            fgif.Size = size;
            fgif.ImageToView = sprite;
            fgif.Tag = CurrentFilePath;// sprite.Tag;
            fgif.Show();
        }
        void ToolStripAboutClick(object sender, EventArgs e)
        {
            Creditos pres = Creditos.GetCreditos();
            pres.Show();
        }
        void ToolStripExplorerClick(object sender, EventArgs e)
        {
            Explora explo = Explora.GetInstancia();
            explo.Show(this);
        }

        void IForm.ChangeDirToExplore(string pathdir)
        {
            Debug.WriteLine($"Mainform: {pathdir}");
            if (Directory.Exists(pathdir + @"\Thumbails"))
            {
                //limpia la pagina actual/seleccionada
                //añade los nuevos elementos del directorio siguiente
                FlowLayoutPanel flow = (FlowLayoutPanel)tabControl1.SelectedTab.Controls[0];
                //(FlowLayoutPanel)((TabPage)sender).Controls[0];
                flow.Controls.Clear();
                LoadPage(pathdir + @"\Thumbails");
            }

        }
        /// <summary>
        /// lanza el formulario buscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		void ToolStripBuscarClick(object sender, EventArgs e)
        {
            Busca fr = new Busca();
            fr.Show(this);
        }

        private FlowLayoutPanel flowsearch;
        public void AddFileFoundedSeached(FileInfo file)
        {
            Debug.WriteLine($"addfilefoundedseached {file.FullName}");
            flowsearch = (FlowLayoutPanel)tabControl1.SelectedTab.Controls[0];
            try
            {
                if (file.Extension == ".gif" || file.Extension == ".GIF")
                {
                    PictureBox sprite = new PictureBox()
                    {
                        Width = _ancho,
                        Height = _largo,
                        BackColor = Color.BurlyWood,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Tag = file.FullName,
                        Image = Utilities.Image.FromFile(file.FullName),
                        //Image = (Image)Image.FromFile(fileInfo.FullName).Clone(),                        
                    };
                    //sprite.Tag = fileInfo.FullName;
                    //sprite.Image = (Image)Image.FromFile(fileInfo.FullName).Clone();
                    sprite.SizeMode = PictureBoxSizeMode.Zoom;
                    sprite.Click += sprite_Click;
                    sprite.MouseClick += sprite_MouseClick;
                    flowsearch.Controls.Add(sprite);
                    TabPage tabpage = (TabPage)flowsearch.Parent;
                    this.Text = @"ShowGif: -" + tabpage.Text + "-" + tabpage.Controls[0].Controls.Count.ToString() + " items";
                }
                flowsearch.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.ToString());
            }
        }
    }
}
