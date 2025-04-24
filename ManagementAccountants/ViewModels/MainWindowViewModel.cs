
using MathCore.ViewModels;
using MathCore.WPF.Commands;
using System.Windows.Input;
using ManagementAccountants.DataAccess.Entityes;
using ManagementAccountants.Interfaces;

namespace ManagementAccountants.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly IRepository<Accountant> _AccountantsRepository;
        private readonly IRepository<Customer> _CustomersRepository;
        private readonly IRepository<Report> _ReportsRepository;

        #region Title : string - Заголовок

        private string _Title = "Головне вікно";

        public string Title { get => _Title; set => Set(ref _Title, value); }
        #endregion

        #region CurrentModel : ViewModel - Поточна дочірня модель-представлення

        /// <summary> Поточна дочірня модель-представлення </summary>
        private ViewModel _CurrentModel;
        
        /// <summary> Поточна дочірня модель-представлення </summary>
        public ViewModel CurrentModel{ get => _CurrentModel; private set => Set(ref _CurrentModel, value); }
        #endregion


        #region Command ShowAccountantsView : ICommand - Показати бухгалтерів

        private ICommand _ShowAccountantsViewCommand;
        /// <summary> Показати бухгалтерів </summary>
        
        public ICommand ShowAccountantsViewCommand => _ShowAccountantsViewCommand 
            ??= new LambdaCommand(OnShowAccountantsViewCommandExecuted, CanShowAccountantsViewCommandExecuted);

        private bool CanShowAccountantsViewCommandExecuted() => true;

        private void OnShowAccountantsViewCommandExecuted() 
        {
            CurrentModel = new AccountantsViewModel(_AccountantsRepository);
        }

        #endregion

        #region Command ShowCustomersView : ICommand - Показати бухгалтерів

        private ICommand _ShowCustomersViewCommand;
        /// <summary> Показати клієнтів </summary>

        public ICommand ShowCustomersViewCommand => _ShowCustomersViewCommand
            ??= new LambdaCommand(OnShowCustomersViewCommandExecuted, CanShowCustomersViewCommandExecuted);

        private bool CanShowCustomersViewCommandExecuted() => true;

        private void OnShowCustomersViewCommandExecuted()
        {
            CurrentModel = new CustomersViewModel(_CustomersRepository);
        }

        #endregion

        #region Command ShowReportsView : ICommand - Показати бухгалтерів

        private ICommand _ShowReportsViewCommand;
        /// <summary> Показати звіти </summary>

        public ICommand ShowReportsViewCommand => _ShowReportsViewCommand
            ??= new LambdaCommand(OnShowReportsViewCommandExecuted, CanShowReportsViewCommandExecuted);

        private bool CanShowReportsViewCommandExecuted() => true;

        private void OnShowReportsViewCommandExecuted()
        {
            CurrentModel = new ReportsViewModel(_ReportsRepository);
        }

        #endregion

        public MainWindowViewModel(IRepository<Accountant> AccountantRepository)
        {
            //_AccountantsRepository = AccountantRepository;

            //var accountants = AccountantRepository.Items.Take(10).ToArray();
        }
    }
}
