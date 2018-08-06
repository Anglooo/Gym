using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using GymApp.Core.Services;
using GymApp.Core.ViewModels;

namespace GymApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterSingleton<IMenuItemService>(new MenuItemService(Mvx.Resolve<IMvxNavigationService>()));

            RegisterAppStart<RootViewModel>();
        }
    }
}
