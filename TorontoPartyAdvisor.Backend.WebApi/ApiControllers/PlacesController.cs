using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TorontoPartyAdvisor.Commands.CommandArgs;
using TorontoPartyAdvisor.Commands.CommandResults;
using TorontoPartyAdvisor.Commands.Commands;
using TorontoPartyAdvisor.Commands.Helpers;

namespace TorontoPartyAdvisor.Backend.WebApi.ApiControllers
{
    public class PlacesController : ApiController
    {
        [HttpGet]
        public IEnumerable<PlaceViewModel> Get(string accesstoken)
        {
            var cmd = new GetPlacesCommand() {
                Args = new Commands.CommandArgs.GetPlacesCommandArgs()
                {
                    AccessToken = accesstoken
                }
            };

            Runner.RunCommand(ref cmd);

            return cmd.Result;
        }

        [HttpGet]
        public GetGenderStatsCommandResults GenderStats(string accesstoken, int placeId)
        {
            var cmd = new GetGenderStatsCommand()
            {
                Args = new GetGenderStatsCommandArgs()
                {
                    Date = DateTimeOffset.Now,
                    MinutesDifference = Int32.Parse(ConfigurationManager.AppSettings["minutesBetweenMatches"]),
                    AccessToken = accesstoken,
                    PlaceId = placeId
                }
            };

            Runner.RunCommand(ref cmd);

            return cmd.Results;
        }

        [HttpGet]
        public DateTimeOffset Ping()
        {
            var cmd = new GetLatestUpdatedDatePlaceCommand();

            Runner.RunCommand(ref cmd);

            return cmd.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accesstoken"></param>
        /// <param name="facebookId">Facebook id of the page (place) owning the event</param>
        [HttpGet]
        public FacebookEvent GetEvent(string accesstoken, string facebookId)
        {

            var cmd = new GetFacebookEventsCommand()
            {
                Args = new GetFacebookEventsCommandArgs()
                {
                    Limit = 3,
                    FacebookAccessToken = accesstoken,
                    FacebookId = facebookId
                }
            };

            Runner.RunCommand(ref cmd);

            if (cmd.Results != null && cmd.Results.Items != null)
                return cmd.Results.Items.FirstOrDefault();
            else 
                return null;
        }


        /// <summary>
        /// get all the fb events related to the fb pages. Parralel call. like a boss
        /// </summary>
        /// <param name="accesstoken"></param>
        /// <param name="facebookId">Facebook id of the page (place) owning the event</param>
        /// <returns></returns>
        [HttpGet]
        public FacebookHoursFormatted GetHours(string accesstoken, string facebookId)
        {
            var cmd = new GetFacebookPlaceHoursCommand()
            {
                Args = new GetFacebookPlaceHoursCommandArgs()
                {
                    AccessToken = accesstoken,
                    FacebookId = facebookId
                }
            };

            Runner.RunCommand(ref cmd);

            return cmd.Results;
        }

        [HttpGet]
        public IEnumerable<FacebookEventPlace> GetFacebookEvents(string accessToken)
        {
            var cmd = new GetAllFacebookEventsCommand()
            {
                AccessTokenArgs = accessToken
            };

            Runner.RunCommand(ref cmd);

            return cmd.Results;
        }
    }
}
