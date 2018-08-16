using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using GymApp.Core.Services;
using GymApp.Core.Model;

namespace GymApp.Core.ViewModels
{
    public class DashboardViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public DashboardViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.Navigate<MenuViewModel>();
        }

        public override async Task Initialize()
        {
            LoggedWorkout incompleteLoggedWorkout = await App.LoggedWorkoutDatabase.GetLatestIncompleteWorkoutAsync();
            if(incompleteLoggedWorkout != null)
            {
                ShowIncompleteWorkout = true;
                IncompleteWorkout = incompleteLoggedWorkout;
            }

            await base.Initialize();
        }

        private LoggedWorkout _incompleteWorkout;
        public LoggedWorkout IncompleteWorkout
        {
            get
            {
                return _incompleteWorkout;
            }
            set
            {
                _incompleteWorkout = value;
                RaisePropertyChanged("IncompleteWorkout");
            }
        }

        private bool _showIncompleteWorkout;
        public bool ShowIncompleteWorkout
        {
            get
            {
                return _showIncompleteWorkout;
            }
            set
            {
                _showIncompleteWorkout = value;
                RaisePropertyChanged("ShowIncompleteWorkout");
            }
        }
    }
}
