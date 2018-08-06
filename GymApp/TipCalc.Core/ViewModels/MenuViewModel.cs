using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using GymApp.Core.Services;
using GymApp.Core.Model;
using System.Collections.Generic;

namespace GymApp.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IMenuItemService _menuItemService;

        public MenuViewModel(IMvxNavigationService navigationService, IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
            _navigationService = navigationService;

        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            MenuItems = _menuItemService.MenuItemSource;
        }

        private List<MenuItem> _menuItems { get; set; }
        public List<MenuItem> MenuItems
        {
            get
            {
                return _menuItems;
            }
            set
            {
                _menuItems = value;
                RaisePropertyChanged("MenuItems");
            }
        }
    }
}
