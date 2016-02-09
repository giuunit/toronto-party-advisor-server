using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.Commands;
using TorontoPartyAdvisor.Commands.Helpers;

namespace TorontoPartyAdvisor.Commands.Tests.Commands
{
    [TestClass]
    public class GetFacebookEventsCommandTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            var cmd = new GetFacebookEventsCommand()
            {
                Args = new CommandArgs.GetFacebookEventsCommandArgs()
                {
                    FacebookId = "lost577",
                    Limit = 3,
                    FacebookAccessToken = "CAAV4JtLrzl8BAOS6SrV89JV8bwJlaUxXQltYbzz2nRv7M8hn8meSgFynG6KKwzkB3YiW9p3hEXqVFCfDCGeZCby0D06qPo9kZAQSPyfHcGt8jGk5x18pjJdgyG1ZAbW1UYcRymuUcipCfg67gldJS1SFUyy92tfDAk1oDDcKgmgVpRhcHq7VPOZCNdl1cI8ZD"
                }
            };

            cmd.Execute();

            Assert.IsNotNull(cmd.Results);

            Assert.IsNotNull(cmd.Results.Items);

            var list = cmd.Results.Items.ToList();

            Assert.IsNotNull(list[0]);

            var fbEvent = list[0];

            Assert.IsFalse(fbEvent.EndTime == DateTimeOffset.MinValue);

            Assert.IsFalse(fbEvent.StartTime == DateTimeOffset.MinValue);

            Assert.IsNotNull(fbEvent.Picture);

            Assert.IsNotNull(fbEvent.Picture.Data.Url);
        }
    }
}
