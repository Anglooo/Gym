using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using GymApp.Core;
using GymApp.Forms.UI;
using UIKit;

namespace GymApp.Forms.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : MvxFormsApplicationDelegate<MvxFormsIosSetup<App, FormsApp>, App, FormsApp>
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
