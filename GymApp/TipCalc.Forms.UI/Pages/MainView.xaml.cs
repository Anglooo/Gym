﻿using MvvmCross.Forms.Views;
using GymApp.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms;

namespace GymApp.Forms.UI.Pages
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Detail, WrapInNavigationPage = true, NoHistory = true)]
    public partial class MainView : MvxContentPage<MainViewModel>
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}