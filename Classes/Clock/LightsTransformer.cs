namespace BerlinClockHcl.Classes.Clock
{
    internal static class LightsTransformer
    {
        internal static string Transform(short numberOfLightsOn, string onLight)
        {
            var lightsConfiguration = string.Empty;
            while (NumberOfLightsOnAreNotConfigured(lightsConfiguration.Length, numberOfLightsOn))
            {
                lightsConfiguration += onLight;
            }
            return MountLightsOff(BerlinClockConstants.HourRowsTotalLights, lightsConfiguration);
        }

        private static bool NumberOfLightsOnAreNotConfigured(int lightsConfigurationLength, short numberOfLightsOn)
        {
            return lightsConfigurationLength < numberOfLightsOn;
        }

        internal static string TransformSpecialCase(short numberOfTotalLights, short redLightDiviser, short numberOfLightsOn)
        {
            var rowLights = string.Empty;
            while (NumberOfLightsOnAreNotConfigured(rowLights.Length, numberOfLightsOn))
            {
                if (CheckIfIsTimeToUseRed(rowLights.Length, redLightDiviser))
                    rowLights += BerlinClockConstants.RedLight;
                else
                    rowLights += BerlinClockConstants.YellowLight;
            }
            return MountLightsOff(numberOfTotalLights, rowLights);
        }

        private static bool CheckIfIsTimeToUseRed(int rowLightsLength, short redLightDiviser)
        {
            return (rowLightsLength + 1) % redLightDiviser == 0;
        }

        private static string MountLightsOff(short numberOfTotalLights, string rowLights)
        {
            int numberOfLightsOff = CalculateAmountOfLightsOff(numberOfTotalLights, rowLights.Length);
            for (int index = 0; index < numberOfLightsOff; index++)
            {
                rowLights += BerlinClockConstants.OffLight;
            }
            return rowLights;
        }

        private static int CalculateAmountOfLightsOff(short numberOfTotalLights, int rowLightsOnAmount)
        {
            return numberOfTotalLights - rowLightsOnAmount;
        }
    }
}
