using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.Helpers;

namespace TorontoPartyAdvisor.Commands.Tests.Helpers
{
    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        public void DistanceTest()
        {
            //63 hounslow heath road, Toronto, Canada
            var mock = new TorontoPartyAdvisor.Commands.Helpers.MathPosition(43.673351, -79.4592933);

            var sameTest = mock.Distance(mock);

            Assert.IsTrue(sameTest == 0);

            //rue Jean Schyns 44, La Louviere, Belgique
            var home = new TorontoPartyAdvisor.Commands.Helpers.MathPosition(50.4790720, 4.2203430);

            var res = mock.Distance(home);

            //There are more than 6000 km between Belgium and Canada
            Assert.IsTrue(res > 6000000);

            //test between google map pos and end of facade of the bar 244
            var pos1 = new TorontoPartyAdvisor.Commands.Helpers.MathPosition(43.648232, -79.388948);
            var pos2 = new TorontoPartyAdvisor.Commands.Helpers.MathPosition(43.6480779, -79.3888383);

            var res2 = pos1.Distance(pos2);

            var pixyPos = new TorontoPartyAdvisor.Commands.Helpers.MathPosition(43.6658029, -79.40538643);

            var distance = pixyPos.Distance(new TorontoPartyAdvisor.Commands.Helpers.MathPosition(43.65674, -79.407115));

            var test = distance;

        }

        [TestMethod]
        public void HasPositionInItsRadiusTest()
        {
            //63 hounslow heath road, Toronto, Canada
            var mock = new TorontoPartyAdvisor.Commands.Helpers.MathPosition(43.673351, -79.4592933);

            //rue Jean Schyns 44, La Louviere, Belgique
            var home = new TorontoPartyAdvisor.Commands.Helpers.MathPosition(50.4790720, 4.2203430);

            var res = mock.HasPositionInItsRadius(home, 7000000);

            Assert.IsTrue(res);
        }
    }
}
