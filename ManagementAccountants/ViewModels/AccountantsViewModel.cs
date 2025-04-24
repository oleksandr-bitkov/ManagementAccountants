using MathCore.ViewModels;
using ManagementAccountants.DataAccess.Entityes;
using ManagementAccountants.Interfaces;

namespace ManagementAccountants.ViewModels
{
    class AccountantsViewModel : ViewModel
    {
        private readonly IRepository<Accountant> _AccountantsRepository;
        public AccountantsViewModel(IRepository<Accountant> AccountantsRepository)
        {
            _AccountantsRepository = AccountantsRepository;
        }
    }

}
   
