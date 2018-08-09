using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SQLite;

namespace GymApp.Core.Model
{
    public class Excersize
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DefaultRepetitionsString { get; set;}
        public int DefaultSets { get; set; }

        [Ignore]
        public List<int> DefaultRepetitions
        {
            get
            {
                return JsonConvert.DeserializeObject<List<int>>(DefaultRepetitionsString);
            }
            set
            {
                if (value != null)
                {
                    DefaultRepetitionsString = JsonConvert.SerializeObject(value);
                }
            }
        }
    }
}
