using Android.App;
using Android.Runtime;
using GymApp.Core;
using GymApp.Forms.UI;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Forms.Platforms.Android.Core;
using System;

[Application]
public class MainApplication : MvxFormsAndroidSetup<App, FormsApp>
{
    public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base()
    {
    }
}