using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using GymApp.Core.Services;

namespace GymApp.Core.ViewModels
{
    public class DashboardViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public DashboardViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.Navigate<MenuViewModel>();
        }
    }
}
