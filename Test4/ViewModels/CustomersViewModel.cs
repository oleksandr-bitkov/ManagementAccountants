using MathCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test4.DataAccess.Entityes;
using Test4.Interfaces;

namespace Test4.ViewModels
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
