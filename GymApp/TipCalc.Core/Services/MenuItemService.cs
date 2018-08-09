using System;
using System.Collections.Generic;
using GymApp.Core.Model;
using GymApp.Core.ViewModels;
using MvvmCross.Navigation;
using Xamarin.Forms;

namespace GymApp.Core.Services
{
    public class MenuItemService : IMenuItemService
    {
        private IMvxNavigationService _navigationService;
        public MenuItemService(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            MenuItemSource = new List<Core.Model.MenuItem>();

            Core.Model.MenuItem item = new Core.Model.MenuItem();
            item.Title = "Dashboard";
            item.MenuImage = "dashboard.png";
            item.NavigateAction = NavigateAction<DashboardViewModel>();
            MenuItemSource.Add(item);

            Core.Model.MenuItem itemLog = new Core.Model.MenuItem();
            itemLog.Title = "Log Workout";
            itemLog.MenuImage = "PlusCircle.png";
            itemLog.NavigateAction = NavigateAction<LogViewModel>();
            MenuItemSource.Add(itemLog);

            Core.Model.MenuItem item3 = new Core.Model.MenuItem();
            item3.Title = "My Workouts";
            item3.MenuImage = "WeightKilo.png"; 
            item3.NavigateAction = NavigateAction<MyWorkoutsViewModel>();
            MenuItemSource.Add(item3);

            Core.Model.MenuItem item4 = new Core.Model.MenuItem();
            item4.Title = "Workout Log";
            item4.MenuImage = "Calendar.png"; 
            item4.NavigateAction = NavigateAction<WorkoutHistoryViewModel>();
            MenuItemSource.Add(item4);

            Core.Model.MenuItem item2 = new Core.Model.MenuItem();
            item2.Title = "About";
            item2.MenuImage = "About.png";
            item2.NavigateAction = NavigateAction<AboutViewModel>();

            MenuItemSource.Add(item2);
        }

        private static List<Core.Model.MenuItem> _menuItemSource;
        public List<GymApp.Core.Model.MenuItem> MenuItemSource
        {
            get
            {
                return _menuItemSource;
            }

            set
            {
                _menuItemSource = value;
            }
        }

        private Action NavigateAction<T>() where T : MvvmCross.ViewModels.MvxViewModel
        {
            
            Action toReturn = new Action(async () =>
            {
                 await _navigationService.Navigate<T>();
                if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
                {
                    masterDetailPage.IsPresented = false;
                }
                else if (Application.Current.MainPage is NavigationPage navigationPage && navigationPage.CurrentPage is MasterDetailPage nestedMasterDetail)
                {
                    nestedMasterDetail.IsPresented = false;
                }
            });

            return toReturn;
        }
    }
}
