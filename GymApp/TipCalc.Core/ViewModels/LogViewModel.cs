using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using GymApp.Core.Services;
using GymApp.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System;
using MvvmCross.Commands;

namespace GymApp.Core.ViewModels
{
    public class LogViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public LogViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public async override void ViewAppearing()
        {
            base.ViewAppeared();
        }

        public override async Task Initialize()
        {
            var workoutList = await App.WorkoutDatabase.GetItemsAsync();
            Workouts = new MvxObservableCollection<Workout>(workoutList);

            Set set1 = new Set();
            set1.denomination = Denomination.KG;
            set1.Reps = 10;
            set1.SetNumber = 1;
            set1.Weight = 2;

            Set set2 = new Set();
            set2.denomination = Denomination.KG;
            set2.Reps = 10;
            set2.SetNumber = 2;
            set2.Weight = 2;

            List<Set> defaultSets = new List<Set>();
            defaultSets.Add(set1);
            defaultSets.Add(set2);

            var logged1 = new LoggedExcersize
            {

                ID = Guid.NewGuid().ToString(),
                Name = "Over Head Press",
                Description = "Blank",
                DefaultSets = defaultSets,
                DropDownShown = false,
                LoggedSets = new MvxObservableCollection<Set>(defaultSets)
            };

            var logged2 = new LoggedExcersize
            {
                ID = Guid.NewGuid().ToString(),
                Name = "Bench press",
                Description = "Blank",
                DefaultSets = defaultSets,
                DropDownShown = false,
                LoggedSets = new MvxObservableCollection<Set>(defaultSets)
            };

            Excersizes = new MvxObservableCollection<LoggedExcersize>();
            //Excersizes.Add(logged1);
            //Excersizes.Add(logged2);

            //App.ExcersizeDatabase.SaveItemAsync(logged1 as Excersize);
            //App.ExcersizeDatabase.SaveItemAsync(logged2 as Excersize);

            if (LoggingWorkout == null)
            {
                LoggingWorkout = new LoggedWorkout();
                LoggingWorkout.Started = DateTime.Now;
                LoggingWorkout.ID = Guid.NewGuid().ToString();
            }
            //return base.Initialize();
        }

        private LoggedWorkout _loggingWorkout;
        public LoggedWorkout LoggingWorkout
        {
            get
            {
                return _loggingWorkout;
            }
            set
            {
                _loggingWorkout = value;
                RaisePropertyChanged("LoggingWorkout");
                SaveLoggedWorkoutProgress();
            }
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

        public Workout _selectedWorkout;
        public Workout SelectedWorkout
        {
            get
            {
                return _selectedWorkout;
            }
            set
            {
                _selectedWorkout = value;
                RaisePropertyChanged("SelectedWorkout");
            }
        }

        public void UpdateExcersizeListUI()
        {
            if(PickerSelectedIndex != -1)
            {
                LoggingWorkout.WorkoutName = SelectedWorkout.Name;
                Excersizes = new MvxObservableCollection<LoggedExcersize>();
                foreach (var item in SelectedWorkout.DefaultExcersizes)
                {
                    Excersizes.Add(new LoggedExcersize(item));
                }
                ExcersizeListShown = true;
            }
        }

        public bool _excersizeListShown;
        public bool ExcersizeListShown
        {
            get
            {
                return _excersizeListShown;
            }
            set
            {
                _excersizeListShown = value;
                RaisePropertyChanged("ExcersizeListShown");
            }
        }

        public MvxObservableCollection<LoggedExcersize> _excersizes;
        public MvxObservableCollection<LoggedExcersize> Excersizes
        {
            get
            {
                return _excersizes;
            }
            set
            {
                _excersizes = value;
                RaisePropertyChanged("Excersizes");
            }
        }

        private int _pickerSelectedIndex;
        public int PickerSelectedIndex
        {
            get
            {
                return _pickerSelectedIndex;   
            }
            set
            {
                if(value != -1)
                {
                    _pickerSelectedIndex = value;
                }
                RaisePropertyChanged("PickerSelectedIndex");
            }
        }

        public async Task LoggedExcersizeSelected(LoggedExcersize excersize)
        {
            LoggedExcersize newLoggedExcersize = await _navigationService.Navigate<LogExcersizeViewModel, LoggedExcersize, LoggedExcersize>(excersize);

            if(newLoggedExcersize == null)
            {
                return;
            }

            var exists = Excersizes.ToList().Where(a => a.ID == newLoggedExcersize.ID).First();

            if(exists != null)
            {
                //exists = newLoggedExcersize;
                int index = Excersizes.IndexOf(exists);
                Excersizes.Remove(exists);
                Excersizes.Insert(index,newLoggedExcersize);

                LoggingWorkout.LoggedExcersizes = Excersizes.ToList();
                SaveLoggedWorkoutProgress();
            }
        }

        public void DeleteExcersize(LoggedExcersize e)
        {
            Excersizes.Remove(e);
        }

        public MvxAsyncCommand SaveWorkout
        {
            get
            {
                return new MvxAsyncCommand(async () =>
                {
                    LoggingWorkout.LoggedExcersizes = Excersizes.ToList();
                    LoggingWorkout.Complete = DateTime.Now;
                    LoggingWorkout.WorkoutComplete = true;
                    LoggingWorkout.WorkoutName = SelectedWorkout.Name;
                    await App.LoggedWorkoutDatabase.SaveItemAsync(LoggingWorkout);

                    var test = await App.LoggedWorkoutDatabase.GetItemsAsync();
                    await _navigationService.Navigate<DashboardViewModel>();
                });
            }
        }

        public MvxAsyncCommand NewExcersize
        {
            get
            {
                return new MvxAsyncCommand(async () =>
                {
                    LoggedExcersize newLoggedExcersize = await _navigationService.Navigate<LogExcersizeViewModel, LoggedExcersize, LoggedExcersize>(new LoggedExcersize());
                    if(newLoggedExcersize != null)
                    {
                        Excersizes.Add(newLoggedExcersize);
                    }
                });
            }
        }

        private void SaveLoggedWorkoutProgress()
        {
            if (LoggingWorkout.ID != null)
            {
                App.LoggedWorkoutDatabase.SaveItemAsync(LoggingWorkout);   
            }

        }

    }
}
