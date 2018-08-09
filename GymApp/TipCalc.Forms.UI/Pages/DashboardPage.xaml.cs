using System;
using System.Collections.Generic;
using GymApp.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;

namespace GymApp.Forms.UI.Pages
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Detail, WrapInNavigationPage = true, NoHistory = true)]
    public partial class DashboardPage : MvxContentPage<DashboardViewModel>
    {
        public DashboardPage()
        {
            InitializeComponent();
        }
    }
}
