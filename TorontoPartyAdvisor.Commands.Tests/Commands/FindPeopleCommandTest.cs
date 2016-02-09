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
    public class FindPeopleCommandTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            var cmd = new FindPeopleCommand()
            {
                Args = new CommandArgs.FindPeopleCommandArgs()
                {
                    //one day
                    Minutes = 3600,
                    PlaceId = 2
                }
            };

            cmd.Execute();

            var res = cmd.Results;

            Assert.IsNotNull(res);
        }
    }
}
