using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.Commands;

namespace TorontoPartyAdvisor.Commands.Tests.Commands
{
    [TestClass]
    public class AddPositionCommandTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            var mock = new AddPositionCommand()
            {
                //positions of the bar 244
                //User 1 Access token
                Args = new CommandArgs.AddPositionCommandArgs()
                {
                    Latitude = 43.6658029,
                    Longitude = -79.40538643,
                    AccessToken = "CAAV4JtLrzl8BAAUuRAQdsdqZBuKoQaVHNEFhthlZBXzhpO3t8YpZC6c7zYj5VlXfi4RIP5wvsFlkczaOOaHGoyfzOzuRlxRDTXxMyQu0j7ZBeZB50uJBM6OWxPkbwkZA3uZAkVffWEZAceUvp1UJCLq4zXX1ByQy5cBpZCYe4Gko9G5aixFMC745pjNb8iqbLZCZBtAxfBipJXsMS3k8h55l42z",
                    MinutesBetweenMatches = 1
                }
            };

            mock.Execute();

            Assert.IsNotNull(mock.Results);
        }
    }
}
