using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using GymApp.Core.Services;

namespace GymApp.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly ICalculationService _calculationService;
        private readonly IMvxNavigationService _navigationService;

        public MainViewModel(ICalculationService calculationService, IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _calculationService = calculationService;

            _navigationService.Navigate<MenuViewModel>();
        }
    }
}