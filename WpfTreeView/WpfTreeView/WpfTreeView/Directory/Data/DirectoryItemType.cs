using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeView
{
    /// <summary>
    /// O tipo de um item do diretório
    /// </summary>
    public enum DirectoryItemType
    {
        //Disco
        Drive,
        //Um arquivo físico 
        File,
        //Uma pasta
        Folder
    }
}
