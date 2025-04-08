using MathCore.WPF.ViewModels;

namespace Test4.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region Title : string - Заголовок

        private string _Title = "Головне вікно";

        public string Title { get => _Title; set => Set(ref _Title, value); }
        #endregion
    }
}
