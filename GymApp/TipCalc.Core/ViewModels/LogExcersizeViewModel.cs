using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GymApp.Core.Model;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Xamarin.Forms;

namespace GymApp.Core.ViewModels
{
    public class LogExcersizeViewModel : MvxViewModel<LoggedExcersize, LoggedExcersize>
    {
        private IMvxNavigationService _navigationService;
        private LoggedExcersize baseWorkout;

        public LogExcersizeViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare(LoggedExcersize parameter)
        {
            baseWorkout = parameter;

            if(baseWorkout.ID == null)
            {
                IsNewExcersize = true;
                baseWorkout.LoggedSets = new MvxObservableCollection<Set>();
            }
        }

        private MvxObservableCollection<Excersize> _oldExcersizes;
        public MvxObservableCollection<Excersize> OldExcersizes
        {
            get
            {
                return _oldExcersizes;
            }
            set
            {
                _oldExcersizes = value;
                RaisePropertyChanged("OldExcersizes");
            }
        }

        private Excersize _oldExcersizeSelected;
        public Excersize OldExcersizeSelected
        {
            get
            {
                return _oldExcersizeSelected;
            }
            set
            {
                _oldExcersizeSelected = value;
                RaisePropertyChanged("OldExcersizeSelected");
            }
        }

        public void SetOldExcersize()
        {
            LoggingExcersize = new LoggedExcersize(OldExcersizeSelected);
            IsNewExcersize = false;
        }

        private bool _isNewExcersize;
        public bool IsNewExcersize
        {
            get
            {
                return _isNewExcersize;
            }
            set
            {
                _isNewExcersize = value;
                RaisePropertyChanged("IsNewExcersize");
            }
        }

        public override async Task Initialize()
        {
            LoggingExcersize = baseWorkout;

            List<Excersize> excersize;
            try
            {
                excersize = await App.ExcersizeDatabase.GetItemsAsync();
                OldExcersizes = new MvxObservableCollection<Excersize>();
                foreach (var item in excersize)
                {
                    OldExcersizes.Add(item);
                }
            }
            catch(Exception e)
            {
                int i = 0;
            }
        }

        public async Task Cancel()
        {
            var x = await Application.Current.MainPage.DisplayAlert("Cancel or Save?", "Would you like to exit this excerisze without saving or to save it to complete later?", "Save", "Exit");
            if(x)
            {
                Finish();
            }
            else
            {
                await _navigationService.Close(this, null);
            }
        }

        public async Task Finish()
        {
            if(string.IsNullOrWhiteSpace(LoggingExcersize.Name)|| LoggingExcersize.LoggedSets == null || LoggingExcersize?.LoggedSets?.Count == 0)
            {
                Application.Current.MainPage.DisplayAlert("Not Enough Info", "Not Enough info", "Ok");
            }
            else
            {
                if(IsNewExcersize)
                {
                    LoggingExcersize.ID = Guid.NewGuid().ToString();
                    LoggingExcersize.DefaultSets = LoggingExcersize.LoggedSets.ToList();

                    await App.ExcersizeDatabase.SaveLoggedAsExcersizeAsync(LoggingExcersize);
                }

                await _navigationService.Close(this, LoggingExcersize);
            }

        }

        private void AddNewSet()
        {
            Set newSet = new Set();
            newSet.SetNumber = LoggingExcersize.LoggedSets.Count + 1;

            LoggingExcersize.LoggedSets.Add(newSet);
        }

        private LoggedExcersize _loggingExcersize;
        public LoggedExcersize LoggingExcersize
        {
            get
            {
                return _loggingExcersize;
            }
            set
            {
                _loggingExcersize = value;
                RaisePropertyChanged("LoggingExcersize");
            }
        }

        public MvxAsyncCommand LogExcersizeCommand
        {
            get
            {
                return new MvxAsyncCommand(async () =>
                {
                    LoggingExcersize.Complete = true;
                    await Finish();
                });
            }
        }

        public MvxAsyncCommand NewSetCommand
        {
            get
            {
                return new MvxAsyncCommand(async () =>
                {
                    AddNewSet();
                });
            }
        }

    }
}

