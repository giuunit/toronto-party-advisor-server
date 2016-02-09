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
    public class UserTest
    {
        [TestMethod]
        public void LogInTest()
        {
            var site = ConfigurationManager.AppSettings["site"];

            using (var client = new HttpClient())
            {
                var mock = new
                {
                    first_name = "Test",
                    last_name = "Test",
                    gender = "male",
                    email = "testtttdddtt@gmail.com",
                    access_token = "qfqsdàdddàq,kd!çààè33DFDSNSHSKLZIJ766633SS",
                    id = "49485950595555",
                    timeZone = 2,
                    locale = "fr_FR",
                };

                var task = client.PostAsJsonAsync(site + "/api/users/login", mock);

                task.Wait();

                var result = task.Result;

                result.EnsureSuccessStatusCode();
            }
        }

        [TestMethod]
        public void GetInfoTest()
        {
            var site = ConfigurationManager.AppSettings["site"];

            using (var client = new HttpClient())
            {
                string accessTokenMock = "CAAV4JtLrzl8BAKUBHdijYMIFZBgHuN6JZCtrWbIpdP8gdu2SDDBKJAJtBTtkzNg3FDCiiIkpZCXP1or3YpqAMP8qGWrVbbBEcOJYN6ZBhLfZBZBtnZBZAuRlI5cx6BV5VkCpZCTV8g8NpeZCZCWD3lnZBCYY98IrqRdqvAyC84iFfUHhIsXZBSoRCXRzEwH8zkZAV9ay7hojqsTbAdX2vebTpZADyhS8wFLf8HZAk7gZD";

                var task = client.GetStringAsync(site + "/api/users/getinfo?accesstoken=" + accessTokenMock);

                task.Wait();

                var result = task.Result;
            }
        }
    }
}
