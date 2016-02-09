using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.CommandArgs
{
    public class AddPositionCommandArgs : AbstractCommandArgs
    {
        [JsonProperty(PropertyName = "accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }
        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// the number of minutes required to validate a match or not
        /// in the configs, not in the json
        /// </summary>
        [JsonIgnore]
        public int MinutesBetweenMatches { get; set; }
    }
}
