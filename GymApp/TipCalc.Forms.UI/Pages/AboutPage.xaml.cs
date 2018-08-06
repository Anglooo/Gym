using MvvmCross.Forms.Views;
using GymApp.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;

namespace GymApp.Forms.UI.Pages
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Detail, WrapInNavigationPage = true, NoHistory =true)]
    public partial class AboutPage : MvxContentPage<AboutViewModel>
    {
        public AboutPage()
        {
            InitializeComponent();
        }
    }
}