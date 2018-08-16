using System;
using System.Collections.Generic;
using MvvmCross.ViewModels;
using Newtonsoft.Json;
using SQLite;

namespace GymApp.Core.Model
{
    public class Excersize : MvxNotifyPropertyChanged
    {
        public Excersize()
        {}

        public Excersize(LoggedExcersize logged)
        {
            this.ID = Guid.NewGuid().ToString();
            this.Name = logged.Name;
            this.DefaultSets = logged.DefaultSets;
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string LastCompleteExcersizeID { get; set; }

        public string DefaultSetsString { get; set; }

        [Ignore]
        public List<Set> DefaultSets
        {
            get
            {
                return JsonConvert.DeserializeObject<List<Set>>(DefaultSetsString);
            }
            set
            {
                if (value != null)
                {
                    DefaultSetsString = JsonConvert.SerializeObject(value);
                }
            }
        }
    }

    public class Set
    {
        public int SetNumber { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
        public Denomination denomination { get; set; }
    }

    public enum Denomination
    {
        KG,lbs
    }
}
