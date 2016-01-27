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
                TimeParts timePartsConverted = ExtractTimeParts(aTime);
                var berlinClock = new BerlinClock(timePartsConverted.Hours, timePartsConverted.Minutes, timePartsConverted.Seconds);
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

        private TimeParts ExtractTimeParts(string aTime)
        {
            char timeValueSeparator = ':';
            if (CheckForInvalidTimeValueSeparator(timeValueSeparator,aTime))
                throw new MissingTimeValueSeparatorException();

            var timeArray = aTime.Split(timeValueSeparator).Select(item => Convert.ToInt32(item)).ToArray();
            TimeParts timeParts;
            timeParts.Hours = timeArray[0];
            timeParts.Minutes = timeArray[1];
            timeParts.Seconds = timeArray[2];
            return timeParts;
        }

        private bool CheckForInvalidTimeValueSeparator(char timeValueSeparator, string aTime)
        {
            return aTime.Count(letter => letter.Equals(timeValueSeparator)) != 2;
        }

        private struct TimeParts
        {
            public int Hours;
            public int Minutes;
            public int Seconds;
        }
    }
}