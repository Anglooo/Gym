using System;
using GymApp.Core.ViewModels;
using MvvmCross.Forms.Views;
using MvvmCross.ViewModels;
using Xamarin.Forms;

namespace GymApp.Core.CustomControls
{
    [MvxViewFor(typeof(NewWorkoutViewModel))]
    public class CustomMvxContentPage : MvxContentPage<MvxViewModel>
    {
        /// <summary>
        /// Gets or Sets the Back button click overriden custom action
        /// </summary>
        public Action CustomBackButtonAction { get; set; }

        public static readonly BindableProperty EnableBackButtonOverrideProperty =
               BindableProperty.Create(
               nameof(EnableBackButtonOverride),
               typeof(bool),
                typeof(CustomMvxContentPage),
               false);

        /// <summary>
        /// Gets or Sets Custom Back button overriding state
        /// </summary>
        public bool EnableBackButtonOverride
        {
            get
            {
                return (bool)GetValue(EnableBackButtonOverrideProperty);
            }
            set
            {
                SetValue(EnableBackButtonOverrideProperty, value);
            }
        }
    }
}
