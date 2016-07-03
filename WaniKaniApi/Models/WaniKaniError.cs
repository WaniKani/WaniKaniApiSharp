using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WaniKaniApi.Models
{
    /// <summary>
    /// Represents an error the WaniKani API may return.
    /// </summary>
    public class WaniKaniError
    {
        // Note: Error types cannot be represented by an enum because the API documentation does not detail the different possible errors.

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <example>user_not_found</example>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the user-friendly message accompanying the error.
        /// </summary>
        /// <example>User does not exist.</example>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}
