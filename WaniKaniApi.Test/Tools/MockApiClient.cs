using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WaniKaniApi.ApiClient;

namespace WaniKaniApi.Test.Tools
{
    /// <summary>
    /// Mocked IApiClient that returns whatever is in its ReturnValue property.
    /// </summary>
    public class MockApiClient : IApiClient
    {
        /// <summary>
        /// Gets or sets the value returned by the call.
        /// </summary>
        public string ReturnValue { get; set; }

        /// <summary>
        /// Gets the list of URIs queried by the mocked client.
        /// </summary>
        public List<string> Requests { get; } = new List<string>();

        public async Task<string> QueryApiAsync(Uri uri)
        {
            Requests.Add(uri.AbsolutePath);
            return ReturnValue;
        }
    }
}
