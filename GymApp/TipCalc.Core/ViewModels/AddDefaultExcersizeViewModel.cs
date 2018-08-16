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
    public class AddDefaultExcersizeViewModel : MvxViewModel<Excersize, Excersize>
    {
        private IMvxNavigationService _navigationService;
        private Excersize baseWorkout;

        public AddDefaultExcersizeViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare(Excersize parameter)
        {
            baseWorkout = parameter;
            DefaultSets = new MvxObservableCollection<Set>();

            if (baseWorkout.ID == null)
            {
                baseWorkout.DefaultSets = new List<Set>();
            }
        }

        private MvxObservableCollection<Set> _defaultSets;
        public MvxObservableCollection<Set> DefaultSets
        {
            get
            {
                return _defaultSets;
            }
            set
            {
                _defaultSets = value;
                RaisePropertyChanged("DefaultSets");
            }
        }


        public override async Task Initialize()
        {
            DefaultExcersize = baseWorkout;
        }



        public async Task Cancel()
        {
            var x = await Application.Current.MainPage.DisplayAlert("Cancel or Save?", "Would you like to exit this excerisze without saving or to save it to complete later?", "Save", "Exit");
            if (x)
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
            if (string.IsNullOrWhiteSpace(DefaultExcersize.Name) || DefaultSets.Count == 0)
            {
                Application.Current.MainPage.DisplayAlert("Not Enough Info", "Not Enough info", "Ok");
            }
            else
            {
                DefaultExcersize.ID = Guid.NewGuid().ToString();
                DefaultExcersize.DefaultSets = DefaultSets.ToList();

                await App.ExcersizeDatabase.SaveItemAsync(DefaultExcersize);

                await _navigationService.Close(this, DefaultExcersize);
            }

        }

        private void AddNewSet()
        {
            Set newSet = new Set();
            newSet.SetNumber = DefaultSets.Count + 1;

            DefaultSets.Add(newSet);
        }

        private Excersize _defaultExcersize;
        public Excersize DefaultExcersize
        {
            get
            {
                return _defaultExcersize;
            }
            set
            {
                _defaultExcersize = value;
                RaisePropertyChanged("DefaultExcersize");
            }
        }

        public MvxAsyncCommand LogExcersizeCommand
        {
            get
            {
                return new MvxAsyncCommand(async () =>
                {
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

