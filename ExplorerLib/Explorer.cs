using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace ExplorerLib
{
    public partial class Explorer : UserControl
    {
        private Task t;
        //Array de ficheros en el directorio en curso
        private FileInfo[] _fileInfos = null;
        //lista de directorios en el directori en curso
        private DirectoryInfo[] _directoryInfos = null;
        /// <summary>
        /// inicializador, sin parametros.
        /// </summary>
        public Explorer()
        {
            InitializeComponent();
            DriveList();
        }
        /// <summary>
        /// load drives pc.
        /// </summary>
        private void DriveList()
        {
            TreeNode nodeTreeNode = new TreeNode("Pc", 0, 0);
            int imageIndex = 0;
            int selectIndex = 0;
            
            this.Cursor = Cursors.WaitCursor;
            treeView_m.Nodes.Clear();
            treeView_m.Nodes.Add(nodeTreeNode);
            //set node collection
            TreeNodeCollection nodeCollection = nodeTreeNode.Nodes;
            DriveInfo[] drivers = DriveInfo.GetDrives();
         
            foreach (DriveInfo drive in drivers)
            {
                DirectoryInfo dir = new DirectoryInfo(drive.Name);
                switch (drive.DriveType)
                {
                    case DriveType.Removable: //removable drives
                        imageIndex = 7;
                        selectIndex = 7;
                        break;
                    case DriveType.Fixed: //Local drives
                        imageIndex = 4;
                        selectIndex = 4;
                        break;
                    case DriveType.CDRom: //CD rom drives
                        imageIndex = 6;
                        selectIndex = 6;
                        break;
                    case DriveType.Network: //Network drives
                        imageIndex = 5;
                        selectIndex = 5;
                        break;
                    case DriveType.NoRootDirectory:
                        imageIndex = 1;
                        selectIndex = 1;
                        break;
                    case DriveType.Ram:
                        imageIndex = 1;
                        selectIndex = 1;
                        break;
                    case DriveType.Unknown:
                        imageIndex = 1;
                        selectIndex = 1;
                        break;
                    default: //defalut to folder
                        imageIndex = 2;
                        selectIndex = 2;
                        break;
                }
                //create new drive node
                nodeTreeNode = new TreeNode(drive.Name, imageIndex, selectIndex);
                nodeTreeNode.Tag = dir;
                //add new node
                nodeCollection.Add(drive.Name,drive.Name, imageIndex, selectIndex).Tag=dir;
            }
            treeView_m.ExpandAll();
            treeView_m.SelectedNode = nodeTreeNode;
            this.Cursor = Cursors.Default;
        }

        protected virtual void treeView_m_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView_m_selectNode(e);
            //try
            //{
            //    t = Task.Factory.StartNew(() => treeView_m_selectNode(e));
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine("error treeview_m_NodeMouseClick: {ex}");
            //}
        }

        protected virtual void treeView_m_selectNode(TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            if (selectedNode.Tag == null) return;
            this.Cursor = Cursors.WaitCursor;
            if (selectedNode.Tag is DriveInfo)
            {
                DirectoryInfo dir = new DirectoryInfo(((DriveInfo)selectedNode.Tag).Name);
                selectedNode.Tag = dir;
            }
            DirectoryInfo nodeDirInfo = (DirectoryInfo)selectedNode.Tag;
            try
            {
                if (selectedNode.GetNodeCount(false) == 0)
                {
                    if (nodeDirInfo.GetDirectories().Count() > 0)
                    {
                        //DelegateGetDirectorios getDirectorios = new DelegateGetDirectorios(this.GetDirectorios);
                        GetDirectorios(nodeDirInfo.GetDirectories(), selectedNode, 1);
                    }
                    //MessageBox.Show(selectedNode.GetNodeCount(false).ToString());
                    //MessageBox.Show(nodeDirInfo.GetDirectories().Count().ToString());
                }

                _fileInfos = nodeDirInfo.GetFiles();
                _directoryInfos = nodeDirInfo.GetDirectories();

                filesInDir?.Invoke(_fileInfos, e);
                DirectorysInDir?.Invoke(_directoryInfos, e);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }

            this.Cursor = Cursors.Default;
        }
        
        //private delegate void DelegateGetDirectorios(DirectoryInfo[] directoryInfo, TreeNode rootNode, int nodenivel);
        private void GetDirectorios(DirectoryInfo[] directoryInfo, TreeNode rootNode, int nodenivel)
        {
            if (nodenivel > 1) return; //carga dos niveles maximo.
            TreeNode aNode;
            //Color TextColor;
            foreach (DirectoryInfo subDir in directoryInfo)
            {
                aNode = new TreeNode(subDir.Name, 2, 3);
                aNode.Tag = subDir;
                try
                {
                    GetDirectorios(subDir.GetDirectories(), aNode, nodenivel + 1);
                    rootNode.Nodes.Add(aNode);
                    // .rootNode.Expand();
                }
                catch
                {

                    ;
                }
            }
            if (rootNode.Level > 1) rootNode.Expand();
        }

        public event TreeNodeMouseClickEventHandler filesInDir;
        public event TreeNodeMouseClickEventHandler DirectorysInDir;

        //nota: hacer que guarde una dirección track.
        //en que ha estado. por defecto.
        #region designFavoritoDir

        private string _TrackFolderPath = string.Empty;
        /// <summary>
        /// propiedad refiere el track de preferencia.
        /// </summary>
        public string TrackPath
        {
            get { return _TrackFolderPath;}
            set
            {
                _TrackFolderPath = value;
                if (!String.IsNullOrEmpty(_TrackFolderPath))
                {
                    saveTrackToReg();
                }
            }
        }
        
        /// <summary>
        /// guarda la dirección track en el registro.
        /// </summary>
        private void saveTrackToReg()
        {
            if (treeView_m.SelectedNode != null)
            {
                DirectoryInfo nodeDirInfo = (DirectoryInfo)treeView_m.SelectedNode.Tag;
                _TrackFolderPath = nodeDirInfo.FullName;
                Reedit.SetRegistryKey("FavFolderPath", _TrackFolderPath);
            }
        }
        /// <summary>
        /// obtiene la direccion de registro track y repersenta en treeview.
        /// </summary>
        private void loadTrackToReg()
        {
            _TrackFolderPath = Reedit.GetRegistryKey("FavFolderPath");
            if (!String.IsNullOrEmpty(_TrackFolderPath))
            {             
                LoadTrackToTreeView(this, new EventArgs());
            }
        }
        /// <summary>
        /// función publica.
        /// carga la dirección Track almacenada en registro al treeview
        /// </summary>
        public void Tracker()
        {
            loadTrackToReg();
        }
        /// <summary>
        /// logica de recorrido hasta la dirección track almacenada en el registro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadTrackToTreeView(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (!String.IsNullOrEmpty(_TrackFolderPath))
                {
                    string[] arrPath = _TrackFolderPath.Split('\\');
                    arrPath[0] += @"\";
                    TreeNodeCollection nodeList = treeView_m.Nodes;                 
                    TreeNode selectedNode = null;
                    TreeNode[] node = nodeList.Find(arrPath[0], true);
                    DirectoryInfo dirInfo = (DirectoryInfo) node[0].Tag;
                    if (node[0].GetNodeCount(false) == 0)
                    {
                        if (dirInfo.GetDirectories().Count() > 0)
                        {
                            GetDirectorios(dirInfo.GetDirectories(), node[0], 1);
                        }
                    }
                    nodeList = node[0].Nodes;
                    bool nodefound;
                    for (int i = 1; i < arrPath.Length; i++)
                    {
                        nodefound = false;
                        for (int j = 0; j < nodeList.Count; j++)
                        {
                            
                            dirInfo = (DirectoryInfo)nodeList[j].Tag;
                            if (dirInfo.Name == arrPath[i])
                            {
                                selectedNode = nodeList[j];
                                selectedNode.Expand();
                                nodefound = true;
                                if (selectedNode.GetNodeCount(false) == 0)
                                {
                                    if (dirInfo.GetDirectories().Count() > 0)
                                    {
                                        GetDirectorios(dirInfo.GetDirectories(), selectedNode, 1);
                                    }
                                }
                                break;
                            }
                            else
                            {
                                nodeList[j].Collapse();
                            }
                        }
                        if (!nodefound || selectedNode.Nodes.Count == 0)
                        {
                            break;
                        }
                        else
                        {
                            nodeList = selectedNode.Nodes;
                        }
                    }
                    if (selectedNode != null)
                    {
                        selectedNode.Expand();
                        treeView_m.SelectedNode = selectedNode;
                        this.Cursor = Cursors.Default;
                        treeView_m_selectNode(new TreeNodeMouseClickEventArgs(selectedNode,MouseButtons.Left,1,0,0));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("xx1 -> {"+ex.Message+"}");
                this.Cursor = Cursors.Default;
            }
            
        }

        #endregion

    }
}