using System;
using System.Collections.Generic;
using GymApp.Core.Model;
using GymApp.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;

namespace GymApp.Forms.UI.Pages
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Detail, WrapInNavigationPage = true, NoHistory = true)]
    public partial class LogWorkoutPage : MvxContentPage<LogViewModel>
    {
        LogViewModel viewModel;

        public LogWorkoutPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel = this.BindingContext.DataContext as LogViewModel;

            this.WorkoutPicker.Unfocused += (object sender, FocusEventArgs e) =>
            {
                viewModel.UpdateExcersizeListUI();
            };
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var listView = sender as ListView;
            LoggedExcersize selectedLogged = listView.SelectedItem as LoggedExcersize;
            //listView.SelectedItem = null;

            viewModel.LoggedExcersizeSelected(selectedLogged);
            //selectedExcercise
        }

        void Handle_Delete_Clicked(object sender, System.EventArgs e)
        {
            Xamarin.Forms.MenuItem convertedSender = sender as Xamarin.Forms.MenuItem;
            LoggedExcersize excersizeToDelete = convertedSender.CommandParameter as LoggedExcersize;

            viewModel.DeleteExcersize(excersizeToDelete);
        }
    }
}
