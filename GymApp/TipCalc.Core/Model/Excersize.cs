using System;
using System.Collections.Generic;

namespace GymApp.Core.Model
{
    public class Excersize
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> DefaultRepetitions { get; set; }
        public int DefaultSets { get; set; }
    }
}
