using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TorontoPartyAdvisor.Backend.WebApi.Tests.Webservices
{
    [TestClass]
    public class RankingTest
    {
        [TestMethod]
        public void Get()
        {
            var site = ConfigurationManager.AppSettings["site"];
            var accessTokenMock = "CAAV4JtLrzl8BAKUBHdijYMIFZBgHuN6JZCtrWbIpdP8gdu2SDDBKJAJtBTtkzNg3FDCiiIkpZCXP1or3YpqAMP8qGWrVbbBEcOJYN6ZBhLfZBZBtnZBZAuRlI5cx6BV5VkCpZCTV8g8NpeZCZCWD3lnZBCYY98IrqRdqvAyC84iFfUHhIsXZBSoRCXRzEwH8zkZAV9ay7hojqsTbAdX2vebTpZADyhS8wFLf8HZAk7gZD";

            using (var client = new HttpClient())
            {
                var mock = new
                {
                    NumberResults = 7,
                };

                var task = client.GetStringAsync(site + "/api/ranking/get?accesstoken=" + accessTokenMock);

                task.Wait();

                var result = task.Result;
            }
        }
    }
}
