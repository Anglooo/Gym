using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using GymApp.Core.Services;
using GymApp.Core.Model;
using Xamarin.Forms;
using MvvmCross.Commands;
using System;
using System.Linq;

namespace GymApp.Core.ViewModels
{
    public class NewWorkoutViewModel : MvxViewModel<Workout>
    {
        private readonly IMvxNavigationService _navigationService;

        public NewWorkoutViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare(Workout parameter)
        {
            WorkoutName = parameter.Name;
            WorkoutDescription = parameter.Description;
            WorkoutID = parameter.ID;

            if (parameter.DefaultExcersizesString == null)
            {
                DefaultExcersizes = new MvxObservableCollection<Excersize>();
            }
            else
            {
                DefaultExcersizes = new MvxObservableCollection<Excersize>(parameter.DefaultExcersizes);
            }
        }

        private string _workoutName;
        public string WorkoutName
        {
            get
            {
                return _workoutName;
            }
            set
            {
                _workoutName = value;
                RaisePropertyChanged("WorkoutName");
            }
        }

        private string _workoutDescription;
        public string WorkoutDescription
        {
            get
            {
                return _workoutDescription;
            }
            set
            {
                _workoutDescription = value;
                RaisePropertyChanged("WorkoutDescription");
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

        public MvxObservableCollection<Excersize> _defaultExcersizes;
        public MvxObservableCollection<Excersize> DefaultExcersizes
        {
            get
            {
                return _defaultExcersizes;
            }
            set
            {
                _defaultExcersizes = value;
                RaisePropertyChanged("DefaultExcersizes");
            }
        }

        private string WorkoutID;

        public MvxAsyncCommand NewExcersize
        {
            get
            {
                return new MvxAsyncCommand(async () =>
                {
                    Excersize newDefaultExcersize = await _navigationService.Navigate<AddDefaultExcersizeViewModel, Excersize, Excersize>(new Excersize());
                    if (newDefaultExcersize != null)
                    {
                        DefaultExcersizes.Add(newDefaultExcersize);
                    }
                });
            }
        }

        public MvxAsyncCommand SaveWorkout
        {
            get
            {
                return new MvxAsyncCommand(async () =>
                {
                    if (!string.IsNullOrWhiteSpace(WorkoutName) || !string.IsNullOrWhiteSpace(WorkoutDescription))
                    {
                        Workout toSave = new Workout();
                        if (string.IsNullOrEmpty(WorkoutID))
                        {
                            toSave.ID = Guid.NewGuid().ToString();
                        }
                        else
                        {
                            toSave.ID = WorkoutID;
                        }

                        toSave.Name = WorkoutName;
                        toSave.Description = WorkoutDescription;
                        toSave.DefaultExcersizes = DefaultExcersizes.ToList();

                        await App.WorkoutDatabase.SaveItemAsync(toSave);
                        await _navigationService.Close(this);
                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert("Insufficient Information", "Please fill all fields", "Ok");
                    }
                });
            }
        }

        public Action ClosePageAction
        {
            get
            {
                return new Action(async () =>
                {
                    var result = await Application.Current.MainPage.DisplayAlert(null,
                   "Hey wait now! are you sure " +
                   "you want to go back?",
                   "Yes go back", "Nope");

                    if (result)
                    {
                        await _navigationService.Close(this);
                    }
                });   
            }

        }
    }
}
