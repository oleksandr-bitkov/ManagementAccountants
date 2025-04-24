using MathCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementAccountants.DataAccess.Entityes;
using ManagementAccountants.Interfaces;

namespace ManagementAccountants.ViewModels
{
    class CustomersViewModel : ViewModel
    {
        private IRepository<Customer> _CustomersRepository;

        public CustomersViewModel(IRepository<Customer> CustomersRepository)
        {
            this._CustomersRepository = CustomersRepository;
        }
    }
}
