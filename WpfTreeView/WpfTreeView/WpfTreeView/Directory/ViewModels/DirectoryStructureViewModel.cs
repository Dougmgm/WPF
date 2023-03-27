using System.Linq;
using System.Collections.ObjectModel;

namespace WpfTreeView
{ 
    /// <summary>
    /// O view model da aplicação principal "Direcotory view"
    /// </summary>
    public class DirectoryStructureViewModel : BaseViewModel
    {
        #region Propriedades publicas

        /// <summary>
        /// Uma lista de todos os diretórios na máquina
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// 

        public DirectoryStructureViewModel()
        {
            var children = DirectoryStructure.GetLogicalDrives;

            this.Items = new ObservableCollection<DirectoryItemViewModel>
                (children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));
        }

        #endregion
    }
}
