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
    public class GetFacebookPlaceHoursCommandTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            var cmd = new GetFacebookPlaceHoursCommand()
            {
                Args = new CommandArgs.GetFacebookPlaceHoursCommandArgs()
                {
                    AccessToken = "CAACEdEose0cBANQz7icsJutf9V38DildEeBJ92GDLO90yFGVQ469PIGOPEeBCArXyVazeRY5ZAKSmaelslxZAClJQEjuSMPBlWi0qHkmXNMv3O7GWhRwkvsXoOGQE1WQ7Xy5hZBdZBWZC18GtiLV3iNMR6iyMHkrpbgn10jyM0aQMx8wuzVmy6QtBgoP8oBsukbmpKHi6WAZDZD",
                    FacebookId = "lost577"
                }
            };

            cmd.Execute();

            var res = cmd.Results;

        }
    }
}
