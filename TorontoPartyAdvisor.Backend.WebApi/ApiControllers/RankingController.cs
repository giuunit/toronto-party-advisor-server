using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TorontoPartyAdvisor.Commands.CommandArgs;
using TorontoPartyAdvisor.Commands.Commands;
using TorontoPartyAdvisor.Commands.Helpers;

namespace TorontoPartyAdvisor.Backend.WebApi.ApiControllers
{
    public class RankingController : ApiController
    {
        public IEnumerable<RankingUserViewModel> Get(string accesstoken)
        {
            var cmd = new GetRankingCommand()
            {
                Args = new GetRankingCommandArgs()
                {
                    AccessToken = accesstoken,
                    NumberResults = Int32.Parse(ConfigurationManager.AppSettings["rankingResultsNbr"])
                }
            };

            cmd.Execute();

            Runner.RunCommand(ref cmd);

            return cmd.Results;
        }
    }
}
