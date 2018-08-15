using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymApp.Core.CustomControls;
using GymApp.Core.ViewModels;
using MvvmCross.Forms.Views;
using Xamarin.Forms;

namespace GymApp.Forms.UI.Pages
{
    public partial class LogExcersizePage : CustomMvxContentPage
    {
        public LogExcersizePage()
        {
            InitializeComponent();
            EnableBackButtonOverride = true;
        }

        protected override void OnAppearing()
        {
            LogExcersizeViewModel model = this.BindingContext.DataContext as LogExcersizeViewModel;
            if (EnableBackButtonOverride)
            {
                this.CustomBackButtonAction = new Action(async () => { await model.Cancel(); });
            }

            this.OldExcersizePicker.Unfocused += (object sender, FocusEventArgs e) =>
            {
                model.SetOldExcersize();
            };
        }


    }
}
