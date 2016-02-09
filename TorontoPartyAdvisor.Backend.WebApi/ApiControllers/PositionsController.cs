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
    /// <summary>
    /// Service related to positions
    /// </summary>
    public class PositionsController : ApiController
    {
        /// <summary>
        /// Used to push his own position
        /// </summary>
        /// <param name="args"></param>
        /// <returns>This object contains "rewards" as number of points</returns>
        [HttpPost]
        public AddPositionCommandResults Add(AddPositionCommandArgs args)
        {
            //this property has a jsonIgnore attribute
            args.MinutesBetweenMatches = int.Parse(ConfigurationManager.AppSettings["minutesBetweenMatches"]);

            var cmd = new AddPositionCommand()
            {
                Args = args
            };

            Runner.RunCommand(ref cmd);

            return cmd.Results;
        }
    }
}
