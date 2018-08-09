using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using GymApp.Core.Services;
using GymApp.Core.Model;

namespace GymApp.Core.ViewModels
{
    public class LogViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public LogViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public MvxObservableCollection<Excersize> Excersizes
        {
            get
            {
                //TODO: FIX
                return null;
            }
        }
    }
}
