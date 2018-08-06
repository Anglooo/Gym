using System;
using System.Collections.Generic;
using GymApp.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;

namespace GymApp.Forms.UI.Pages
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Master, WrapInNavigationPage = false)]
    public partial class MenuPage : MvxContentPage<MenuViewModel>
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as GymApp.Core.Model.MenuItem;
            if(item.NavigateAction != null)
            {
                item.NavigateAction.Invoke();
            }
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var item = e.Item as GymApp.Core.Model.MenuItem;
            if (item.NavigateAction != null)
            {
                item.NavigateAction.Invoke();
            }

            (sender as ListView).SelectedItem = null;
        }
    }
}
