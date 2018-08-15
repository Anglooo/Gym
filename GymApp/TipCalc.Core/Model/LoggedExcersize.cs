using System;
using System.Collections.Generic;
using MvvmCross.ViewModels;

namespace GymApp.Core.Model
{
    public class LoggedExcersize : Excersize
    {
        public LoggedExcersize()
        {}

        public LoggedExcersize(Excersize excersize)
        {
            this.ID = Guid.NewGuid().ToString();
            this.Name = excersize.Name;
            this.Description = excersize.Description;
            this.LoggedSets = new MvxObservableCollection<Set>(excersize.DefaultSets);
        }

        public bool Complete { get; set; }
        private bool _dropDownShown { get; set; }
        public bool DropDownShown
        { 
            get
            {
                return _dropDownShown;
            }
            set
            {
                _dropDownShown = value;
                RaisePropertyChanged("DropDownShown");
            }
        }

        private MvxObservableCollection<Set> _loggedSets { get; set; }
        public MvxObservableCollection<Set> LoggedSets
        {
            get
            {
                return _loggedSets;
            }
            set
            {
                _loggedSets = value;
                RaisePropertyChanged("LoggedSets");
            }
        }

    }
}
