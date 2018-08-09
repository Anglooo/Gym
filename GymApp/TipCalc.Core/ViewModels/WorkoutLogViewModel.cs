using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using GymApp.Core.Services;
using GymApp.Core.Model;
using System;
using System.Collections.Generic;

namespace GymApp.Core.ViewModels
{
    public class WorkoutLogViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public WorkoutLogViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public async override void ViewAppearing()
        {
            base.ViewAppearing();
        }


    }
}