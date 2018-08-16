using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SQLite;

namespace GymApp.Core.Model
{
    public class Workout
    {
        [PrimaryKey]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime LastLoggedWorkout { get; set; }

        public string DefaultExcersizesString { get; set; }
        [Ignore]
        public List<Excersize> DefaultExcersizes
        {
            get
            {
                return JsonConvert.DeserializeObject<List<Excersize>>(DefaultExcersizesString);
            }
            set
            {
                if (value != null)
                {
                    DefaultExcersizesString = JsonConvert.SerializeObject(value);
                }
            }
        }
        //public List<Excersize> Excersizes { get; set; }
    }
}
