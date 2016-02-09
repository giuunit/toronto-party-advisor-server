using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Backend.WebApi.Tests.Webservices
{
    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        public void AddTest()
        {
            var site = ConfigurationManager.AppSettings["site"];
            var accesstoken = "CAAV4JtLrzl8BAKUBHdijYMIFZBgHuN6JZCtrWbIpdP8gdu2SDDBKJAJtBTtkzNg3FDCiiIkpZCXP1or3YpqAMP8qGWrVbbBEcOJYN6ZBhLfZBZBtnZBZAuRlI5cx6BV5VkCpZCTV8g8NpeZCZCWD3lnZBCYY98IrqRdqvAyC84iFfUHhIsXZBSoRCXRzEwH8zkZAV9ay7hojqsTbAdX2vebTpZADyhS8wFLf8HZAk7gZD";

            using (var client = new HttpClient())
            {
                var mock = new 
                {
                    Longitude = -79.39423,
                    Latitude = 43.645549,
                    AccessToken = accesstoken
                };

                var task = client.PostAsJsonAsync(site + "/api/positions/add", mock);

                task.Wait();

                var result = task.Result;

                result.EnsureSuccessStatusCode();

                var taskBis = result.Content.ReadAsStringAsync();

                taskBis.Wait();

                var json = taskBis.Result;


            }
        }
    }
}
