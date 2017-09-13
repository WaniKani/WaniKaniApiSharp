using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WaniKaniApi.ApiClient
{
    public class WebApiClient : IApiClient
    {
        /// <summary>
        /// Interrogates the API using a web client and returns its response as a string.
        /// </summary>
        /// <param name="uri">URI to interrogate.</param>
        /// <returns>The response of the API as a string.</returns>
        public async Task<string> QueryApiAsync(Uri uri)
        {
            HttpClient client = new HttpClient();
            //string response = await client.DownloadStringTaskAsync(uri);
            string response = await client.GetStringAsync(uri);

            return response;
        }
    }
}
