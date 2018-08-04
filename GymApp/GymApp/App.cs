using MvvmCross.IoC;
using MvvmCross.ViewModels;
using GymApp.ViewModels;

namespace GymApp
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterAppStart<MainViewModel>();
        }
    }
}