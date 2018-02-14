using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ScheduleApp.Models;

namespace ScheduleApp.Controllers
{
    [Route("api/[controller]")]
    public class Scheduler : Controller
    {

        [Filters.AuthTokenFilter(AllowInQueryString = false)]
        [HttpGet]
        public List<Schedule> Get(string stop)
        {
            
            List<Schedule> schedules = new List<Schedule>();
            List<Schedule> filteredSchedules = new List<Schedule>();
            DateTime currentDateTime = DateTime.Now;

            int _stopInt = 0;

            if(!int.TryParse(stop, out _stopInt)){

                throw new Exception("stop parameter is invalid");

            }
            DataLoader loader = new DataLoader();
            DateTime compareDateTime = currentDateTime.AddMinutes(40);

            schedules = loader.LoadSchedules(currentDateTime).OrderBy(s => s.arrival).ToList();


            for (int i = 1; i <= 3; i++)
            {

                filteredSchedules.AddRange(schedules.Where(v => v.stop == _stopInt && v.route == i && (v.arrival > DateTime.Now && v.arrival <= compareDateTime)).OrderBy(z => z.arrival).Take(2).ToList());
            }

            return filteredSchedules.OrderBy(r => r.route ).ThenBy(t => t.arrival).ToList();
        }
    }
}
