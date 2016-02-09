using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.Helpers
{
    public class FacebookEventPictureData
    {
        [JsonProperty(PropertyName = "is_silhouette")]
        public bool IsSilhouette { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }

    public class FacebookEventPicture
    {
        [JsonProperty(PropertyName = "data")]
        public FacebookEventPictureData Data { get; set; }
    }
}
