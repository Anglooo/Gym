using System;
using System.Collections.Generic;
using SQLite;

namespace GymApp.Core.Model
{
    public class LoggedWorkout
    {
        [PrimaryKey]
        public string ID { get; set; }
        public string WorkoutID { get; set; }
        //public List<Excersize> Excersizes { get; set; }
        public bool WorkoutComplete { get; set; }
        public DateTime Started { get; set; }
        public DateTime Complete { get; set; }

    }
}
