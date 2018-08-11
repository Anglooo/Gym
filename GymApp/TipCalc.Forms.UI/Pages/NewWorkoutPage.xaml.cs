using System;
using System.Collections.Generic;
using GymApp.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using GymApp.Core.CustomControls;
using MvvmCross.ViewModels;

namespace GymApp.Forms.UI.Pages
{
    [MvxViewFor(typeof(NewWorkoutViewModel))]
    public partial class NewWorkoutPage : CustomMvxContentPage
    {
        public NewWorkoutPage()
        {
            InitializeComponent();
            this.EnableBackButtonOverride = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NewWorkoutViewModel model = this.BindingContext.DataContext as NewWorkoutViewModel;
            if(EnableBackButtonOverride)
            {
                this.CustomBackButtonAction = model.ClosePageAction;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
    }
}
