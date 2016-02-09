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
    public class GetLatestUpdatedDatePlaceCommandTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            var cmd = new GetLatestUpdatedDatePlaceCommand();

            cmd.Execute();
        }
    }
}
