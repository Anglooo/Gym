using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using GymApp.Core.Services;
using GymApp.Core.Model;
using GymApp.Core.Repositories;
using System.Collections.Generic;
using MvvmCross.Commands;
using Xamarin.Forms;
using System;

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

            LoggedWorkout workout = new LoggedWorkout();
            workout.Started = DateTime.Now;
            workout.Complete = DateTime.Now;
            workout.ID = Guid.NewGuid().ToString();
            workout.WorkoutComplete = true;
            //workout.WorkoutID = "27abfc92-5e6d-4064-b170-7641a009f1d1";
            workout.WorkoutName = "Push";

            //Excersize excersize = new Excersize();
            //excersize.ID = Guid.NewGuid().ToString();
            //excersize.Name = "Pushup";
            //excersize.DefaultSets = 3;
            //List<int> defReps = new List<int>();
            //defReps.Add(8);
            //defReps.Add(8);
            //defReps.Add(8);
            //excersize.DefaultRepetitions = defReps;
            //excersize.Description = "Testing";

            //Excersize excersize2 = new Excersize();
            //excersize2.ID = Guid.NewGuid().ToString();
            //excersize2.Name = "Pullup";
            //excersize2.DefaultSets = 3;
            //List<int> defReps2 = new List<int>();
            //defReps2.Add(8);
            //defReps2.Add(8);
            //defReps2.Add(8);
            //excersize2.DefaultRepetitions = defReps2;
            //excersize2.Description = "Testing";

            //ExcersizeLog loggedExcersize = new ExcersizeLog();
            //loggedExcersize.LoggedExcersize = excersize;
            //loggedExcersize.LoggedReps = defReps;
            //loggedExcersize.LoggedSets = 3;
            //List<string> LoggedWeights = new List<string>();
            //LoggedWeights.Add("20 Kg");
            //LoggedWeights.Add("20 Kg");
            //LoggedWeights.Add("20 Kg");

            //loggedExcersize.LoggedWeight = LoggedWeights;

            //ExcersizeLog loggedExcersize2 = new ExcersizeLog();
            //loggedExcersize2.LoggedExcersize = excersize2;
            //loggedExcersize2.LoggedReps = defReps;
            //loggedExcersize2.LoggedSets = 3;
            //loggedExcersize2.LoggedWeight = LoggedWeights;

            //ExcersizeLogs logs = new ExcersizeLogs();
            //logs.Logs = new List<ExcersizeLog>();
            //logs.Logs.Add(loggedExcersize);

            //workout.LoggedExcersize = logs;

            //await App.LoggedWorkoutDatabase.SaveItemAsync(workout);

            //List<LoggedWorkout> testing = await App.LoggedWorkoutDatabase.GetItemsAsync();

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

            return true;
        }
    }
}