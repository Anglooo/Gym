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
    }
}
