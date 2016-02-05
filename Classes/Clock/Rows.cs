using System;

namespace BerlinClockHcl.Classes.Clock
{
    public interface IRow
    {
        string GetLightsConfiguration(TimeSpan aTimeValue);
        bool HasLineBreak { get; }
    }

    public class TopRow : IRow
    {
        public string GetLightsConfiguration(TimeSpan aTime)
        {

            return (aTime.Seconds % 2 == 0 ? BerlinClockConstants.YellowLight : BerlinClockConstants.OffLight) + "\n";
        }
        public bool HasLineBreak
        {
            get { return true; }
        }
    }

    public class FirstRow : IRow
    {
        public string GetLightsConfiguration(TimeSpan aTime)
        {
            short numberOfLightsOn = Convert.ToInt16(Math.Floor(aTime.TotalHours / BerlinClockConstants.Diviser));
            return LightsTransformer.Transform(numberOfLightsOn, BerlinClockConstants.RedLight, HasLineBreak);
        }
        public bool HasLineBreak
        {
            get { return true; }
        }
    }

    public class SecondRow : IRow
    {
        public string GetLightsConfiguration(TimeSpan aTime)
        {
            short numberOfTotalLightsOn = Convert.ToInt16(Math.Floor(aTime.TotalHours % BerlinClockConstants.Diviser));
            return LightsTransformer.Transform(numberOfTotalLightsOn, BerlinClockConstants.RedLight, HasLineBreak);
        }
        public bool HasLineBreak
        {
            get { return true; }
        }
    }

    public class ThirdRow : IRow
    {
        public string GetLightsConfiguration(TimeSpan aTime)
        {
            short redLightDiviser = 3;
            short numberOfLightsOn = Convert.ToInt16(aTime.Minutes / BerlinClockConstants.Diviser);
            return LightsTransformer.TransformSpecialCase(BerlinClockConstants.LargerMinutesTotalLights, redLightDiviser, numberOfLightsOn, HasLineBreak);
        }
        public bool HasLineBreak
        {
            get { return true; }
        }
    }

    public class FourthRow : IRow
    {
        public string GetLightsConfiguration(TimeSpan aTime)
        {
            short numberOfLightsOn = Convert.ToInt16(aTime.Minutes % BerlinClockConstants.Diviser);
            return LightsTransformer.Transform(numberOfLightsOn, BerlinClockConstants.YellowLight, HasLineBreak);
        }
        public bool HasLineBreak
        {
            get { return false; }
        }
    }
}