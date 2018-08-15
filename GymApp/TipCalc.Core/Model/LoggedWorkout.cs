using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQLite;

namespace GymApp.Core.Model
{
    public class LoggedWorkout
    {
        [PrimaryKey]
        public string ID { get; set; }
        public string WorkoutName { get; set; }
        public string LoggedExcersizesString { get; set; }

        [Ignore]
        public List<LoggedExcersize> LoggedExcersizes
        {
            get
            {
                return JsonConvert.DeserializeObject<List<LoggedExcersize>>(LoggedExcersizesString);
            }
            set
            {
                if(value != null)
                {
                    LoggedExcersizesString = JsonConvert.SerializeObject(value);
                }
            }
        }

        public bool WorkoutComplete { get; set; }
        public DateTime Started { get; set; }
        public DateTime Complete { get; set; }
    }

    public class ExcersizeLogs
    {
        public List<ExcersizeLog> Logs { get; set;}
    }

    public class ExcersizeLog
    {
        public LoggedExcersize LoggedExcersize { get; set; }
        public int LoggedSets { get; set; }
        public List<int> LoggedReps { get; set; }
        public List<string> LoggedWeight { get; set; }
    }
}
