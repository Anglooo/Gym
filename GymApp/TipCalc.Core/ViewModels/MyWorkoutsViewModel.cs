using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using GymApp.Core.Services;
using GymApp.Core.Model;
using GymApp.Core.Repositories;
using System.Collections.Generic;
using MvvmCross.Commands;
using Xamarin.Forms;

namespace GymApp.Core.ViewModels
{
    public class MyWorkoutsViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MyWorkoutsViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public async override void ViewAppearing()
        {
            base.ViewAppearing();
         }

        public override async Task Initialize()
        {
            await RefreshPage();
            //return await base.Initialize();
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            RefreshPage();
        }

        public async Task<bool> RefreshPage()
        {
            var workouts = await App.WorkoutDatabase.GetItemsAsync();
            Workouts = new MvxObservableCollection<Workout>(workouts);
            return true;
        }

        private MvxObservableCollection<Workout> _workouts;
        public MvxObservableCollection<Workout> Workouts
        {
            get
            {
                return _workouts;
            }
            set
            {
                _workouts = value;
                RaisePropertyChanged("Workouts");
            }
        }

        public MvxAsyncCommand NewWorkout
        {
            get
            {
                return new MvxAsyncCommand(async () =>
                {
                    await _navigationService.Navigate<NewWorkoutViewModel>();
                });
            }
        }

        public async Task<bool> EditWorkout(Workout editWorkout)
        {
            await _navigationService.Navigate<NewWorkoutViewModel, Workout>(editWorkout);
            await RefreshPage();
            return true;
        }

    }
}