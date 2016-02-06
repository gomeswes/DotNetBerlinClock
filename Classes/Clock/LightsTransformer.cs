using System;
using System.Linq;

namespace BerlinClockHcl.Classes.Clock
{
    internal static class LightsTransformer
    {
        internal static string Transform(IRow theRow, short numberOfLightsOn, char onLight)
        {
            var lightsOn = new String('\0', numberOfLightsOn);
            lightsOn = String.Join("", lightsOn.Select(light => onLight));
            return AppendLightsOffAndLineBreak(theRow.NumberOfLights, lightsOn, theRow.HasLineBreak);
        }

        internal static string TransformSpecialCase(IRow theRow, short redLightDiviser, short numberOfLightsOn)
        {
            var lightsOn = new String('\0', numberOfLightsOn);
            lightsOn = String.Join("", lightsOn.Select((light, index) => 
                    CheckIfIsTimeToUseRed(index, redLightDiviser) 
                        ? BerlinClockConstants.RedLight : BerlinClockConstants.YellowLight));

            return AppendLightsOffAndLineBreak(theRow.NumberOfLights, lightsOn, theRow.HasLineBreak);
        }

        private static string AppendLightsOffAndLineBreak(short totalLightsNumber, string lightsOn, bool hasBreakLine)
        {
            var offLightsNumber = CalculateAmountOfLightsOff(totalLightsNumber, lightsOn.Length);
            var lightsOff = new String(BerlinClockConstants.OffLight, offLightsNumber);
            
            var rowLights = String.Concat(lightsOn, lightsOff);

            if (hasBreakLine)
            {
                return rowLights + "\n";
            }
            return rowLights;
        }

        private static bool CheckIfIsTimeToUseRed(int rowLightsLength, short redLightDiviser)
        {
            return (rowLightsLength + 1) % redLightDiviser == 0;
        }

        private static int CalculateAmountOfLightsOff(short numberOfTotalLights, int rowLightsOnAmount)
        {
            return numberOfTotalLights - rowLightsOnAmount;
        }
    }
}