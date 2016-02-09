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
    public class LogInUserCommandTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            var cmd = new LogInUserCommand()
            {
                Args = new CommandArgs.LogInUserCommandArgs()
                {
                    FirstName = "Giu",
                    LastName = "Do",
                    Gender = "male",
                    Email = "testtttdtt@gmail.com",
                    FacebookAccessToken = "CAAV4JtLrzl8BAAUuRAQdsdqZBuKoQaVHNEFhthlZBXzhpO3t8YpZC6c7zYj5VlXfi4RIP5wvsFlkczaOOaHGoyfzOzuRlxRDTXxMyQu0j7ZBeZB50uJBM6OWxPkbwkZA3uZAkVffWEZAceUvp1UJCLq4zXX1ByQy5cBpZCYe4Gko9G5aixFMC745pjNb8iqbLZCZBtAxfBipJXsMS3k8h55l42z",
                    FacebookId = "900673009978519",
                    TimeZone = -4,
                    Locale = "fr_FR",
                    
                }
            };

            cmd.Execute();
        }
    }
}
