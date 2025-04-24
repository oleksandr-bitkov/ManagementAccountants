using MathCore.ViewModels;
using ManagementAccountants.DataAccess.Entityes;
using ManagementAccountants.Interfaces;

namespace ManagementAccountants.ViewModels
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
