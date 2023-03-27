<<<<<<< HEAD
﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace WpfTreeView
{
    /// <summary>
    /// É um view model para cada item do diretório
    /// </summary>
    class DirectoryItemViewModel : BaseViewModel
    {
        /// <summary>
        /// O tipo desse item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        public string ImageName => Type == DirectoryItemType.Drive ? "drive" : (Type == DirectoryItemType.File ? "file" : (IsExpanded ? "folder-open" : "folder-closed"));

        /// <summary>
        /// O caminho completo para esse item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// O nome do item do diretório
        /// </summary>
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
        /// Construtor padrão 
        /// </summary>
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            //Cria os comandos
            this.ExpandCommand = new RelayCommand(Expand);

            //Define o caminho e o tipo
            this.FullPath = fullPath;
            this.Type = type;
        }


        #region Helper Methods

        /// <summary>
        /// Remove todos os filhos da lista adicionando um item dummy para mostrar o icone de expansão se requirido
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

        #endregion

        /// <summary>
        /// Expande esse diretório e encontra todos os filhos
        /// </summary>
        private void Expand()
        {
            //Não se pode expandir um arquivo
            if (this.Type == DirectoryItemType.File)
            {
                return;
            }

            //Encontra todos os filhos
            this.Children = new ObservableCollection<DirectoryItemViewModel>
                (DirectoryStructure.GetDirectoryContents(this.FullPath).Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }

        /// <summary>
        /// Comando para expandir esse item  e encontrar todos os filhos
        /// </summary>
        public ICommand ExpandCommand { get; set; }

    }
}
=======
﻿using System;
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
>>>>>>> 7b33d45c0ed2551a87ced99b15e52e04945684ee
