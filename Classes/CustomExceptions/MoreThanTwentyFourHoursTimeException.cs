using System;

namespace BerlinClockHcl.Classes.CustomExceptions
{
    public class MoreThanTwentyFourHoursTimeException : Exception
    {
        public MoreThanTwentyFourHoursTimeException() :
            base(CustomExceptionsMessages.MoreThanTwentyFourHours)
        {

        }
    }
}
