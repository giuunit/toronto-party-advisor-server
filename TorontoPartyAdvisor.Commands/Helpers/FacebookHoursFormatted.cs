using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.Helpers
{
    public class FacebookHoursFormatted
    {
        [JsonProperty(PropertyName = "day")]
        public DayOfWeek Day { get; set; }
        [JsonProperty(PropertyName="start_time")]
        public string StartTime { get; set; }
        [JsonProperty(PropertyName = "end_time")]
        public string EndTime { get; set; }
    }
}
