using System;
using System.Collections.Generic;
using SQLite;

namespace GymApp.Core.Model
{
    public class Workout
    {
        [PrimaryKey]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public List<Excersize> Excersizes { get; set; }
    }
}
