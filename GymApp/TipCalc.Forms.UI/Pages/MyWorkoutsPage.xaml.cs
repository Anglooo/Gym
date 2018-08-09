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
    public partial class MyWorkoutsPage : MvxContentPage<MyWorkoutsViewModel>
    {
        private MyWorkoutsViewModel viewModel;

        public MyWorkoutsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel = this.BindingContext.DataContext as MyWorkoutsViewModel;

            ToolbarItem addWorkout = new ToolbarItem();
            addWorkout.Icon = "PlusCircle.png";
            addWorkout.Command = (this.BindingContext.DataContext as MyWorkoutsViewModel).NewWorkout;

            if(ToolbarItems.Count == 0)
            {
                ToolbarItems.Add(addWorkout);
            }
        }

        async void Handle_Delete_Clicked(object sender, System.EventArgs e)
        {
            Xamarin.Forms.MenuItem convertedSender = sender as Xamarin.Forms.MenuItem;
            Workout workoutToDelete = convertedSender.CommandParameter as Workout;
            await App.WorkoutDatabase.DeleteItemAsync(workoutToDelete);

            await viewModel.RefreshPage();
        }

        async void Handle_Edit_Clicked(object sender, System.EventArgs e)
        {
            Xamarin.Forms.MenuItem convertedSender = sender as Xamarin.Forms.MenuItem;
            Workout workoutToEdit = convertedSender.CommandParameter as Workout;
            viewModel.EditWorkout(workoutToEdit);
        }
    }
}
