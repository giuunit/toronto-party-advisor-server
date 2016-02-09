using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.Helpers
{
    public class FacebookEvents
    {
        [JsonProperty(PropertyName="data")]
        public List<FacebookEvent> Items { get; set; }
    }
}
