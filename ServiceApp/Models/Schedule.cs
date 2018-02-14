using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApp.Models
{
    public class Schedule
    {

        public int stop { get; set; }

        public int route { get; set; }

        public DateTime arrival{ get; set; }

        public int arrivalMins { get; set; }
    }
}
