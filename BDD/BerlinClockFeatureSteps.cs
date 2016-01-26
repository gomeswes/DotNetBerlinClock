using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BerlinClockHcl.BDD;

namespace BerlinClockHcl
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private ITimeConverter berlinClock = new TimeConverter();
        private String theTime;

        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time.CheckAndCastToNull();
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            var theActualBerlinClockOutput = berlinClock.ConvertTime(theTime);
            Assert.AreEqual(theActualBerlinClockOutput.RemoveCarriageReturn(), 
                            theExpectedBerlinClockOutput.RemoveCarriageReturn());
        }

    }
}