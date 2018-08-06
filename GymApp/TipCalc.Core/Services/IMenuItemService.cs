using System;
using System.Collections.Generic;
using GymApp.Core.Model;

namespace GymApp.Core.Services
{
    public interface IMenuItemService
    {
        List<MenuItem> MenuItemSource { get; set; }
    }
}
