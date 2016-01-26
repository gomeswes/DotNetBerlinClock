using BerlinClockHcl.Classes.Clock;
using BerlinClockHcl.Classes.CustomExceptions;
using System;
using System.Linq;

namespace BerlinClockHcl
{
    public class TimeConverter : ITimeConverter
    {
        public string ConvertTime(string aTime)
        {
            try
            {
                TimeSpan aTimeConverted = TransformToTimeSpan(aTime);
                var berlinClock = new BerlinClock(aTimeConverted);
                return berlinClock.GetLightsConfiguration();
            }
            catch(MoreThanTwentyFourHoursTimeException moreThanTwentyFourHoursTimeException)
            {
                return moreThanTwentyFourHoursTimeException.Message;
            }
            catch(MissingTimeValueSeparatorException timeValueSeparatorException)
            {
                return timeValueSeparatorException.Message;
            }
            catch (FormatException)
            {
                return CustomExceptionsMessages.MissingTimeInfo;
            }
            catch (Exception)
            {
                return CustomExceptionsMessages.Generic;
            }
            
        }

        private TimeSpan TransformToTimeSpan(string aTime)
        {
            char timeValueSeparator = ':';
            if (CheckForInvalidTimeValueSeparator(timeValueSeparator,aTime))
                throw new MissingTimeValueSeparatorException();

            var timeArray = aTime.Split(timeValueSeparator).Select(item => Convert.ToInt32(item)).ToArray();
            return new TimeSpan(timeArray[0], timeArray[1], timeArray[2]);
        }

        private bool CheckForInvalidTimeValueSeparator(char timeValueSeparator, string aTime)
        {
            return aTime.Count(letter => letter.Equals(timeValueSeparator)) != 2;
        }
    }
}