using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.CommandArgs
{
    public class GetFacebookEventsCommandArgs : AbstractCommandArgs
    {
        /// <summary>
        /// facebook page id that created the event
        /// </summary>
        public string FacebookId { get; set; }

        /// <summary>
        /// number of results
        /// </summary>
        public int? Limit { get; set; }

        public string FacebookAccessToken { get; set; }
    }
}
