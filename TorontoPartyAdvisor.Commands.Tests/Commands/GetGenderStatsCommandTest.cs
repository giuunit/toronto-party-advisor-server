﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.Commands;

namespace TorontoPartyAdvisor.Commands.Tests.Commands
{
    [TestClass]
    public class GetGenderStatsCommandTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            var mockArgs = new CommandArgs.GetGenderStatsCommandArgs()
                {
                    AccessToken = "CAAV4JtLrzl8BAKUBHdijYMIFZBgHuN6JZCtrWbIpdP8gdu2SDDBKJAJtBTtkzNg3FDCiiIkpZCXP1or3YpqAMP8qGWrVbbBEcOJYN6ZBhLfZBZBtnZBZAuRlI5cx6BV5VkCpZCTV8g8NpeZCZCWD3lnZBCYY98IrqRdqvAyC84iFfUHhIsXZBSoRCXRzEwH8zkZAV9ay7hojqsTbAdX2vebTpZADyhS8wFLf8HZAk7gZD",
                    Date = DateTimeOffset.Now,
                    MinutesDifference = 30,
                    PlaceId = 2
                };

            var cmd = new GetGenderStatsCommand()
            {
                Args = mockArgs
            };

            cmd.Execute();

            var res = cmd.Results;

            Assert.AreEqual(mockArgs.MinutesDifference, res.MinutesRequest);
        }
    }
}
