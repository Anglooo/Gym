using MvvmCross.Forms.Views;
using GymApp.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;

namespace GymApp.Forms.UI.Pages
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Detail, WrapInNavigationPage = false)]
    public partial class MainView : MvxContentPage<MainViewModel>
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}