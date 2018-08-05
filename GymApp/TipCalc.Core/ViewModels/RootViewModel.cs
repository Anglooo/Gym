using System;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace GymApp.Core.ViewModels
{
    public class RootViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public RootViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();
            _navigationService.Navigate<MainViewModel>();
            _navigationService.Navigate<MenuViewModel>();
        }
    }
}
