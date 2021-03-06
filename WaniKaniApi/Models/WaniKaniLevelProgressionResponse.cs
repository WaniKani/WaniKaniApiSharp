﻿using Newtonsoft.Json;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// WaniKani response for the level progression query.
    /// </summary>
    internal class WaniKaniLevelProgressionResponse : WaniKaniResponse
    {
        /// <summary>
        /// Gets or sets the level progression information.
        /// </summary>
        [JsonProperty(PropertyName = "requested_information")]
        public WaniKaniLevelProgression LevelProgression { get; set; }
    }
}
