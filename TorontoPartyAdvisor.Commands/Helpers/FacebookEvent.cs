﻿using Newtonsoft.Json;
using System;

namespace TorontoPartyAdvisor.Commands.Helpers
{
    public class FacebookEvent
    {
        [JsonProperty(PropertyName="name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "start_time")]
        public DateTimeOffset StartTime { get; set; }

        [JsonProperty(PropertyName = "end_time")]
        public DateTimeOffset EndTime { get; set; }

        [JsonProperty(PropertyName="description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "picture")]
        public FacebookEventPicture Picture { get; set; }

        [JsonProperty(PropertyName = "maybe_count")]
        public int MaybeCount { get; set; }

        [JsonProperty(PropertyName = "attending_count")]
        public int AttendingCount { get; set; }
    }
}
