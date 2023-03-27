using System.ComponentModel;
using PropertyChanged;

namespace WpfTreeView
{
    /// <summary>
    /// Um view model de base que dispara eventos do Property Changed conforme necessita
    /// </summary>
    /// 

    //[AddINotifyPropertyChangedInterface]

    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// O evento que foi disparado quando qualquer propriedade filho muda seu valor
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {};

    }
}
