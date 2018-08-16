using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymApp.Core.CustomControls;
using GymApp.Core.ViewModels;
using MvvmCross.Forms.Views;
using Xamarin.Forms;

namespace GymApp.Forms.UI.Pages
{
    public partial class AddDefaultExcersizePage : CustomMvxContentPage
    {
        public AddDefaultExcersizePage()
        {
            InitializeComponent();
            EnableBackButtonOverride = true;
        }

        protected override void OnAppearing()
        {
            AddDefaultExcersizeViewModel model = this.BindingContext.DataContext as AddDefaultExcersizeViewModel;
            if (EnableBackButtonOverride)
            {
                this.CustomBackButtonAction = new Action(async () => { await model.Cancel(); });
            }
        }


    }
}
