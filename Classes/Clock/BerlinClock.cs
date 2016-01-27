using BerlinClockHcl.Classes.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BerlinClockHcl.Classes.Clock
{
    public class BerlinClock
    {
        private IList<IRow> rows;
        private readonly TimeSpan aTime;
        public BerlinClock(int hours, int minutes, int seconds)
        {
            if (CheckTimeIsInvalid(hours, minutes, seconds))
                throw new MoreThanTwentyFourHoursTimeException();
            aTime = new TimeSpan(hours, minutes, seconds);
            rows = new List<IRow>();
            rows.Add(new TopRow());
            rows.Add(new FirstRow());
            rows.Add(new SecondRow());
            rows.Add(new ThirdRow());
            rows.Add(new FourthRow());
        }

        private bool CheckTimeIsInvalid(int hours, int minutes, int seconds)
        {
            return hours > 24 || minutes > 59 || seconds > 59;
        }

        public string GetLightsConfiguration()
        {
            StringBuilder lightsRepresentation = new StringBuilder();
            foreach (var row in rows)
            {
                if (row.HasLineBreak)
                {
                    lightsRepresentation.AppendLine(row.GetLightsConfiguration(this.aTime));
                }
                else
                {
                    lightsRepresentation.Append(row.GetLightsConfiguration(this.aTime));
                }
            }

            return lightsRepresentation.ToString();
        }
    }
}
