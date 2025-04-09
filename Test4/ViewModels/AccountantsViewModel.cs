using MathCore.ViewModels;
using Test4.DataAccess.Entityes;
using Test4.Interfaces;

namespace Test4.ViewModels
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
   
