using Android.Support.Design.Widget;
using GymApp.Core;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Reflection;

public class Setup : MvxAppCompatSetup<App>
{
    protected override IMvxApplication CreateApp()
    {
        return new App();
    }
}