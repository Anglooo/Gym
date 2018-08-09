using System;
using System.Collections.Generic;
using GymApp.Core;
using GymApp.Core.Model;
using GymApp.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MvvmCross.ViewModels;
using Xamarin.Forms;

namespace GymApp.Forms.UI.Pages
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Detail, WrapInNavigationPage = true, NoHistory = true)]
    public partial class WorkoutHistoryPage : MvxContentPage<WorkoutHistoryViewModel>
    {
        public WorkoutHistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async void Handle_Delete_Clicked(object sender, System.EventArgs e)
        {
            Xamarin.Forms.MenuItem convertedSender = sender as Xamarin.Forms.MenuItem;
            LoggedWorkout workoutToDelete = convertedSender.CommandParameter as LoggedWorkout;
            await App.LoggedWorkoutDatabase.DeleteItemAsync(workoutToDelete);

            WorkoutHistoryViewModel viewModel = this.BindingContext.DataContext as WorkoutHistoryViewModel;
            await viewModel.RefreshPage();
        }
    }
}
