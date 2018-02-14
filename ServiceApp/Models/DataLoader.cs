using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApp.Models
{
    public class DataLoader
    {
        static int _timeIncrement = 15;
        static int _routeDiff = 2;
        static int _stopDiff = 2;
        static DateTime _arrival = new DateTime();
        static DateTime _currentDate = DateTime.Now;

        public List<Schedule> LoadSchedules(DateTime currentDateTime)
        {
            List<Schedule> schedules = new List<Schedule>();

            Schedule s = new Schedule();

            for (int i = 1; i <= 10; i++)
            {               
                for (int x = 0; x < 24; x++)
                {
                    for (int t = 0; t <= 45; t += _timeIncrement)
                    {
                        _arrival = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, x, t, 0);

                        for (int j = 1; j <= 3; j++)
                        {
                            s = new Schedule();
                            s.route = j;
                            s.stop = i;

                            s.arrival = _arrival.AddMinutes((j-1)*_routeDiff).AddMinutes((i - 1) * _stopDiff);
                            TimeSpan timeDiff = s.arrival - currentDateTime;
                            s.arrivalMins = (int)timeDiff.TotalMinutes;

                            schedules.Add(s);
                        }
                    }
                }

            }

            return schedules;

        }
    }
}
