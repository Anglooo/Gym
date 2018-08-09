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
    public class WorkoutHistoryViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public WorkoutHistoryViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public async override void ViewAppearing()
        {
            base.ViewAppearing();

            await RefreshPage();
        }

        public async Task<bool> RefreshPage()
        {
            var workouts = await App.LoggedWorkoutDatabase.GetItemsAsync();
            Workouts = new MvxObservableCollection<LoggedWorkout>(workouts);
            return true;
        }

        private MvxObservableCollection<LoggedWorkout> _workouts;
        public MvxObservableCollection<LoggedWorkout> Workouts
        {
            get
            {
                return _workouts;
            }
            set
            {
                _workouts = value;
                RaisePropertyChanged("LoggedWorkout");
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

            return true;
        }
    }
}