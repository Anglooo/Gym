using System;
using Xamarin.Forms;

namespace GymApp.Core.Model
{
    public class MenuItem
    {
        public string Title { get; set; }
        public Action NavigateAction { get; set; }
        public Image MenuImage { get; set; }
        public bool ItemSelected { get; set;}
    }
}
