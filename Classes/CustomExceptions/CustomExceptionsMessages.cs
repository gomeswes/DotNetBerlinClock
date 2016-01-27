
namespace BerlinClockHcl.Classes.CustomExceptions
{
    public static class CustomExceptionsMessages 
    {
        public const string MoreThanTwentyFourHours = "I can't do it! Sorry but i expect a time between \"00:00:00\" and \"24:59:59\"";
        public const string MissingTimeValueSeparator = "Sorry! Bad time format. Aren't you missing some \":\". I expect something like \"00:00:00\" to \"24:59:59\" (hh:mm:ss)";
        public const string MissingTimeInfo = "Sorry! Missing time information. I expect something like \"00:00:00\" to \"24:59:59\" (hh:mm:ss)";
        public const string Generic = "Oh no! Something went wrong! Please check if the value you are providing is not null";

    }
}
