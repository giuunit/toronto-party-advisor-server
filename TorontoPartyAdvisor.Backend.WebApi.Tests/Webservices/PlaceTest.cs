using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Backend.WebApi.Tests.Webservices
{
    [TestClass]
    public class PlaceTest
    {
        [TestMethod]
        public void Get()
        {
            var site = ConfigurationManager.AppSettings["site"];
            var accesstoken = "CAAV4JtLrzl8BAAUuRAQdsdqZBuKoQaVHNEFhthlZBXzhpO3t8YpZC6c7zYj5VlXfi4RIP5wvsFlkczaOOaHGoyfzOzuRlxRDTXxMyQu0j7ZBeZB50uJBM6OWxPkbwkZA3uZAkVffWEZAceUvp1UJCLq4zXX1ByQy5cBpZCYe4Gko9G5aixFMC745pjNb8iqbLZCZBtAxfBipJXsMS3k8h55l42z";

            using (var client = new HttpClient())
            {
                var task = client.GetStringAsync(site + "/api/places/get?accesstoken=" + accesstoken);

                task.Wait();

                var result = task.Result;
            }
        }

        [TestMethod]
        public void GenderStats()
        {
            var site = ConfigurationManager.AppSettings["site"];
            var accesstoken = "CAAV4JtLrzl8BAKUBHdijYMIFZBgHuN6JZCtrWbIpdP8gdu2SDDBKJAJtBTtkzNg3FDCiiIkpZCXP1or3YpqAMP8qGWrVbbBEcOJYN6ZBhLfZBZBtnZBZAuRlI5cx6BV5VkCpZCTV8g8NpeZCZCWD3lnZBCYY98IrqRdqvAyC84iFfUHhIsXZBSoRCXRzEwH8zkZAV9ay7hojqsTbAdX2vebTpZADyhS8wFLf8HZAk7gZD";
            int placeId = 2;

            using (var client = new HttpClient())
            {
                var task = client.GetStringAsync(site + "/api/places/genderstats?accesstoken=" + accesstoken + "&placeId=" + placeId);

                task.Wait();

                var result = task.Result;
            }
        }

        [TestMethod]
        public void GetPing()
        {
            var site = ConfigurationManager.AppSettings["site"];

            using (var client = new HttpClient())
            {
                var task = client.GetStringAsync(site + "/api/places/ping");

                task.Wait();

                var result = task.Result;

                var date = JsonConvert.DeserializeObject<DateTimeOffset>(result);
                
            }
        }

        [TestMethod]
        public void GetEvent()
        {
            var site = ConfigurationManager.AppSettings["site"];

            var accesstoken = "CAAV4JtLrzl8BAOS6SrV89JV8bwJlaUxXQltYbzz2nRv7M8hn8meSgFynG6KKwzkB3YiW9p3hEXqVFCfDCGeZCby0D06qPo9kZAQSPyfHcGt8jGk5x18pjJdgyG1ZAbW1UYcRymuUcipCfg67gldJS1SFUyy92tfDAk1oDDcKgmgVpRhcHq7VPOZCNdl1cI8ZD";
            var facebookId = "lost577";

            using (var client = new HttpClient())
            {
                var task = client.GetStringAsync(site + "/api/places/getevent?accesstoken=" + accesstoken + "&facebookId=" + facebookId);

                task.Wait();

                var result = task.Result;

            }
        }

        [TestMethod]
        public void GetHours()
        {
            var site = ConfigurationManager.AppSettings["site"];

            var accesstoken = "CAAV4JtLrzl8BAOS6SrV89JV8bwJlaUxXQltYbzz2nRv7M8hn8meSgFynG6KKwzkB3YiW9p3hEXqVFCfDCGeZCby0D06qPo9kZAQSPyfHcGt8jGk5x18pjJdgyG1ZAbW1UYcRymuUcipCfg67gldJS1SFUyy92tfDAk1oDDcKgmgVpRhcHq7VPOZCNdl1cI8ZD";
            var facebookId = "lost577";

            using (var client = new HttpClient())
            {
                var task = client.GetStringAsync(site + "/api/places/gethours?accesstoken=" + accesstoken + "&facebookId=" + facebookId);

                task.Wait();

                var result = task.Result;

            }
        }

        [TestMethod]
        public void GetFacebookEvents()
        {
            var site = ConfigurationManager.AppSettings["site"];

            var accessTokenArgs = "CAAV4JtLrzl8BAOS6SrV89JV8bwJlaUxXQltYbzz2nRv7M8hn8meSgFynG6KKwzkB3YiW9p3hEXqVFCfDCGeZCby0D06qPo9kZAQSPyfHcGt8jGk5x18pjJdgyG1ZAbW1UYcRymuUcipCfg67gldJS1SFUyy92tfDAk1oDDcKgmgVpRhcHq7VPOZCNdl1cI8ZD";

            using (var client = new HttpClient())
            {
                var task = client.GetStringAsync(site + "/api/places/getfacebookevents?accessToken=" + accessTokenArgs);

                task.Wait();

                var result = task.Result;

            }
        }
    }
}
