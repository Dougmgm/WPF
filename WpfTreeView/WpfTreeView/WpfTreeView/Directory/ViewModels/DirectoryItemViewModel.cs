using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeView
{
    /// <summary>
    /// É um view model para cada item do diretório
    /// </summary>
    class DirectoryItemViewModel : BaseViewModel
    {
        public string FullPath { get; set; }

        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        /// <summary>
        /// Uma lista de todos os filhos contidos nesse item
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        /// <summary>
        /// Indica que se esse item pode ser expandido
        /// </summary>
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

        

        /// <summary>
        /// Indica se o atual item está expandido ou não
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }

            set
            {
                //Se a UI falar para expandir...   
                if(value == true)
                {
                    //Encontra todos os filhos
                    Expand();
                }
                //Se a UI falar para fechar...
                else
                {
                    this.ClearChildren();
                }
            }
        }

        

        /// <summary>
        /// Expande esse diretório e encontra todos os filhos
        /// </summary>
        private void Expand()
        {

        }

        /// <summary>
        /// Remove todos os filhos da lista adicionando um item dummy para mostrar o icone de expansão se necessário
        /// </summary>
        private void ClearChildren()
        {
            this.Children = new ObservableCollection<DirectoryItemViewModel>();

            //Mostra a flechinha de expandir se não for um arquivo
            if (this.Type != DirectoryItemType.File)
            {
                this.Children.Add(null);
            }
        }

        /// <summary>
        /// Comando para expandir esse item 
        /// </summary>
        public ICommand ExpandCommand { get; set; }

    }
}
