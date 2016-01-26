using System;

namespace BerlinClockHcl.Classes.CustomExceptions
{
    public class MissingTimeValueSeparatorException : Exception
    {
        public MissingTimeValueSeparatorException() 
            : base(CustomExceptionsMessages.MissingTimeValueSeparator) 
        {
            
        }
    }
}
