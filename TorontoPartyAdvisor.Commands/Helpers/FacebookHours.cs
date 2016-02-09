using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.Helpers
{
    public class FacebookHours
    {
        [JsonProperty(PropertyName = "mon_1_open")]
        public string Mon1Open { get; set; }
        [JsonProperty(PropertyName = "mon_1_close")]
        public string Mon1Close { get; set; }
        [JsonProperty(PropertyName = "mon_2_open")]
        public string Mon2Open { get; set; }
        [JsonProperty(PropertyName = "mon_2_close")]
        public string Mon2Close { get; set; }
        [JsonProperty(PropertyName = "tue_1_open")]
        public string Tue1Open { get; set; }
        [JsonProperty(PropertyName = "tue_1_close")]
        public string Tue1Close { get; set; }
        [JsonProperty(PropertyName = "tue_2_open")]
        public string Tue2Open { get; set; }
        [JsonProperty(PropertyName = "tue_2_close")]
        public string Tue2Close { get; set; }
        [JsonProperty(PropertyName = "wed_1_open")]
        public string Wed1Open { get; set; }
        [JsonProperty(PropertyName = "wed_1_close")]
        public string Wed1Close { get; set; }
        [JsonProperty(PropertyName = "wed_2_open")]
        public string Wed2Open { get; set; }
        [JsonProperty(PropertyName = "wed_2_close")]
        public string Wed2Close { get; set; }
        [JsonProperty(PropertyName = "thu_1_open")]
        public string Thu1Open { get; set; }
        [JsonProperty(PropertyName = "thu_1_close")]
        public string Thu1Close { get; set; }
        [JsonProperty(PropertyName = "thu_2_open")]
        public string Thu2Open { get; set; }
        [JsonProperty(PropertyName = "thu_2_close")]
        public string Thu2Close { get; set; }
        [JsonProperty(PropertyName = "fri_1_open")]
        public string Fri1Open { get; set; }
        [JsonProperty(PropertyName = "fri_1_close")]
        public string Fri1Close { get; set; }
        [JsonProperty(PropertyName = "fri_2_open")]
        public string Fri2Open { get; set; }
        [JsonProperty(PropertyName = "fri_2_close")]
        public string Fri2Close { get; set; }
        [JsonProperty(PropertyName = "sat_1_open")]
        public string Sat1Open { get; set; }
        [JsonProperty(PropertyName = "sat_1_close")]
        public string Sat1Close { get; set; }
        [JsonProperty(PropertyName = "sat_2_open")]
        public string Sat2Open { get; set; }
        [JsonProperty(PropertyName = "sat_2_close")]
        public string Sat2Close { get; set; }
        [JsonProperty(PropertyName = "sun_1_open")]
        public string Sun1Open { get; set; }
        [JsonProperty(PropertyName = "sun_1_close")]
        public string Sun1Close { get; set; }
        [JsonProperty(PropertyName = "sun_2_open")]
        public string Sun2Open { get; set; }
        [JsonProperty(PropertyName = "sun_2_close")]
        public string Sun2Close { get; set; }
    }


    public class FacebookHoursBox
    {
        [JsonProperty(PropertyName="hours")]
        public FacebookHours Hours { get; set; }
    }
}
