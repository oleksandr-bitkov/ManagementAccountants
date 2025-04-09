using MathCore.ViewModels;
using Test4.DataAccess.Entityes;
using Test4.Interfaces;

namespace Test4.ViewModels
{
    class ReportsViewModel : ViewModel
    {
        private IRepository<Report> reportsRepository;

        public ReportsViewModel(IRepository<Report> reportsRepository)
        {
            this.reportsRepository = reportsRepository;
        }
    }
}
