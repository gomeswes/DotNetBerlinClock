using System;

namespace BerlinClockHcl.Classes.Clock
{
    public interface IRow
    {
        string GetLightsConfiguration(TimeSpan aTimeValue);
        short NumberOfLights { get; }
        bool HasLineBreak { get; }
    }

    public class TopRow : IRow
    {
        public string GetLightsConfiguration(TimeSpan aTime)
        {

            return (aTime.Seconds % 2 == 0 ? BerlinClockConstants.YellowLight.ToString() : BerlinClockConstants.OffLight.ToString()) + "\n";
        }
        
        public short NumberOfLights
        {
            get { return 1; }
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
            return LightsTransformer.Transform(this, numberOfLightsOn, BerlinClockConstants.RedLight);
        }

        public short NumberOfLights
        {
            get { return 4; }
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
            return LightsTransformer.Transform(this, numberOfTotalLightsOn, BerlinClockConstants.RedLight);
        }

        public short NumberOfLights
        {
            get { return 4; }
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
            return LightsTransformer.TransformSpecialCase(this, redLightDiviser, numberOfLightsOn);
        }

        public short NumberOfLights
        {
            get { return 11; }
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
            return LightsTransformer.Transform(this, numberOfLightsOn, BerlinClockConstants.YellowLight);
        }

        public short NumberOfLights
        {
            get { return 4; }
        }

        public bool HasLineBreak
        {
            get { return false; }
        }
    }
}