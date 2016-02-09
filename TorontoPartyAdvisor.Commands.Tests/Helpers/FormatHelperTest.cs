using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TorontoPartyAdvisor.Commands.Helpers;

namespace TorontoPartyAdvisor.Commands.Tests.Helpers
{
    [TestClass]
    public class FormatHelperTest
    {
        [TestMethod]
        public void FormatFacebookHoursDayTest()
        {
            var mock = new FacebookHoursBox()
            {
                Hours = new FacebookHours()
                {
                    Mon1Open = "02:00",
                    Mon1Close = "04:00",

                    Sat1Open = "01:00",
                    Sat2Close = "03:30"
                }
            };

            var res = TorontoPartyAdvisor.Commands.Helpers.FormatHelper.FormatFacebookHoursDay(mock, DayOfWeek.Monday);

            Assert.IsTrue(res.Day == DayOfWeek.Monday);

            Assert.AreEqual(res.StartTime, mock.Hours.Mon1Open);

            Assert.AreEqual(res.EndTime, mock.Hours.Mon1Close);
        }
    }
}
