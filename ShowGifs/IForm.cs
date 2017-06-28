using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowGifs
{
    /// <summary>
    /// interfaz interconectividad de ventanas
    /// </summary>
    public interface IForm
    {
        /// <summary>
        /// Cambia el directorio de exploracion.
        /// </summary>
        /// <param name="pathdir"></param>
        void ChangeDirToExplore(string pathdir);
    }
}
