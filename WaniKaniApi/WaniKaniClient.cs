using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WaniKaniApi.ApiClient;
using WaniKaniApi.Converters;
using WaniKaniApi.Models;

namespace WaniKaniApi
{
    /// <summary>
    /// Client allowing communication with the WaniKani API.
    /// </summary>
    public sealed class WaniKaniClient : IWaniKaniClient
    {
        private static readonly Regex ApiKeyRegex = new Regex("^[a-f0-9]{32}$");

        /// <summary>
        /// Defines the max number of levels to request in a single item list request (see <see cref="CutLevelsForListRequest(int[])"/>).
        /// </summary>
        private const int ListRequestSectionMaxLevelCount = 10;

        private string _apiKey;

        private int _maxLevel = 60;

        private readonly IApiClient _apiClient;

        /// <summary>
        /// Gets or sets the base WaniKani API URL as a formatable string containing the API key as a parameter.
        /// </summary>
        public string BaseUrl { get; set; } = "https://www.wanikani.com/api/v1.4/user/{0}/";

        /// <summary>
        /// Gets or sets the API Key used to communicate with the WaniKani API.
        /// </summary>
        public string ApiKey
        {
            get { return _apiKey; }
            set
            {
                if (_apiKey != value)
                {
                    if (!CheckApiKey(value))
                        throw new ArgumentException("The API key must be a 32-characters-long string containing only characters ranging from '0' to '9' and 'a' to 'f'.", nameof(value));
                    _apiKey = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum WaniKani level. The default value is 60.
        /// </summary>
        public int MaxLevel
        {
            get { return _maxLevel; }
            set
            {
                if (_maxLevel != value)
                {
                    if (value < 1)
                        throw new ArgumentException("The max level value cannot be less than 1.");
                    _maxLevel = value;
                }
            }
        }

        /// <summary>
        /// Builds a new WaniKani client initialized with the given WaniKani API key.
        /// </summary>
        /// <param name="apiKey">WaniKani API key used to communicate with the WaniKani API.</param>
        public WaniKaniClient(string apiKey) : this(apiKey, new WebApiClient()) { }

        /// <summary>
        /// Builds a new WaniKani client initialized with the given WaniKani API key and using the given API client.
        /// </summary>
        /// <param name="apiKey">WaniKani API key used to communicate with the WaniKani API.</param>
        /// <param name="apiClient">API client used to communicate with the API.</param>
        public WaniKaniClient(string apiKey, IApiClient apiClient)
        {
            ApiKey = apiKey;
            _apiClient = apiClient;
        }

        #region Queries

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <returns>User information.</returns>
        public WaniKaniUserInformation GetUserInformation()
        {
            return GetUserInformationAsync().Result;
        }

        /// <summary>
        /// Gets the user information asynchronously.
        /// </summary>
        /// <returns>User information.</returns>
        public async Task<WaniKaniUserInformation> GetUserInformationAsync()
        {
            string json = await QueryAsync("user-information");
            var response = Deserialize<WaniKaniResponse>(json);
            return response.UserInformation;
        }

        /// <summary>
        /// Gets the study queue information.
        /// </summary>
        /// <returns>Study queue information.</returns>
        public WaniKaniStudyQueue GetStudyQueue()
        {
            return GetStudyQueueAsync().Result;
        }

        /// <summary>
        /// Gets the study queue information asynchronously.
        /// </summary>
        /// <returns>Study queue information.</returns>
        public async Task<WaniKaniStudyQueue> GetStudyQueueAsync()
        {
            string json = await QueryAsync("study-queue");
            var response = Deserialize<WaniKaniStudyQueueResponse>(json);
            return response.StudyQueue;
        }

        /// <summary>
        /// Gets the level progression information.
        /// </summary>
        /// <returns>Level progression information.</returns>
        public WaniKaniLevelProgression GetLevelProgression()
        {
            return GetLevelProgressionAsync().Result;
        }

        /// <summary>
        /// Gets the level progression information asynchronously.
        /// </summary>
        /// <returns>Level progression information.</returns>
        public async Task<WaniKaniLevelProgression> GetLevelProgressionAsync()
        {
            string json = await QueryAsync("level-progression");
            var response = Deserialize<WaniKaniLevelProgressionResponse>(json);
            return response.LevelProgression;
        }

        /// <summary>
        /// Gets the SRS distribution information.
        /// </summary>
        /// <returns>SRS distribution information.</returns>
        public WaniKaniSrsDistribution GetSrsDistribution()
        {
            return GetSrsDistributionAsync().Result;
        }

        /// <summary>
        /// Gets the SRS distribution information asynchronously.
        /// </summary>
        /// <returns>SRS distribution information.</returns>
        public async Task<WaniKaniSrsDistribution> GetSrsDistributionAsync()
        {
            string json = await QueryAsync("srs-distribution");
            var response = Deserialize<WaniKaniSrsDistributionResponse>(json);
            return response.SrsDistribution;
        }

        /// <summary>
        /// Gets the recently unlocked items.
        /// </summary>
        /// <param name="limit">Maximum number of items to obtain, between 1 and 100 (default is 10).</param>
        /// <returns>Recently unlocked items.</returns>
        public List<WaniKaniRecentUnlock> GetRecentUnlocks(int limit = 10)
        {
            return GetRecentUnlocksAsync(limit).Result;
        }

        /// <summary>
        /// Gets the recently unlocked items asynchronously.
        /// </summary>
        /// <param name="limit">Maximum number of items to obtain, between 1 and 100 (default is 10).</param>
        /// <returns>Recently unlocked items.</returns>
        public async Task<List<WaniKaniRecentUnlock>> GetRecentUnlocksAsync(int limit = 10)
        {
            if (limit < 1 || limit > 100)
                throw new ArgumentOutOfRangeException(nameof(limit), "The limit must be comprised between 1 and 100.");

            string json = await QueryAsync($"recent-unlocks/{limit}");
            var response = Deserialize<WaniKaniRecentUnlocksResponse>(json);
            return response.RecentUnlocks;
        }

        /// <summary>
        /// Gets the items with a review success percentage under the given threshold.
        /// </summary>
        /// <param name="percentageThreshold">Review success percentage threshold, between 0 and 100. Default is 75.</param>
        /// <returns>List of items with a review success percentage under the given threshold.</returns>
        public List<WaniKaniCriticalItem> GetCriticalItems(int percentageThreshold = 75)
        {
            return GetCriticalItemsAsync(percentageThreshold).Result;
        }

        /// <summary>
        /// Gets asynchronously the items with a review success percentage under the given threshold.
        /// </summary>
        /// <param name="percentageThreshold">Review success percentage threshold, between 0 and 100. Default is 75.</param>
        /// <returns>List of items with a review success percentage under the given threshold.</returns>
        public async Task<List<WaniKaniCriticalItem>> GetCriticalItemsAsync(int percentageThreshold = 75)
        {
            if (percentageThreshold < 0 || percentageThreshold > 100)
                throw new ArgumentOutOfRangeException(nameof(percentageThreshold), "The threshold must be comprised between 0 and 100.");

            string json = await QueryAsync($"critical-items/{percentageThreshold}");
            var response = Deserialize<WaniKaniCriticalItemsResponse>(json);
            return response.CriticalItems;
        }

        /// <summary>
        /// Gets the list of radicals for the given levels, or for all accessible levels if nothing is specified.
        /// </summary>
        /// <param name="levels">Target levels. If empty, all accessible levels will be targeted.</param>
        /// <returns>List of radicals for the target levels.</returns>
        public List<WaniKaniRadicalItem> GetRadicals(params int[] levels)
        {
            return GetRadicalsAsync(levels).Result;
        }

        /// <summary>
        /// Gets asynchronously the list of radicals for the given levels, or for all accessible levels if nothing is specified.
        /// </summary>
        /// <param name="levels">Target levels. If empty, all accessible levels will be targeted.</param>
        /// <returns>List of radicals for the target levels.</returns>
        public async Task<List<WaniKaniRadicalItem>> GetRadicalsAsync(params int[] levels)
        {
            List<WaniKaniRadicalListResponse> responses = await QueryItemListAsync<WaniKaniRadicalListResponse>("radicals/{0}", levels);
            return responses.SelectMany(r => r.Radicals).ToList();
        }

        /// <summary>
        /// Gets the list of kanji for the given levels, or for all accessible levels if nothing is specified.
        /// </summary>
        /// <param name="levels">Target levels. If empty, all accessible levels will be targeted.</param>
        /// <returns>List of kanji for the target levels.</returns>
        public List<WaniKaniKanjiItem> GetKanji(params int[] levels)
        {
            return GetKanjiAsync(levels).Result;
        }

        /// <summary>
        /// Gets asynchronously the list of kanji for the given levels, or for all accessible levels if nothing is specified.
        /// </summary>
        /// <param name="levels">Target levels. If empty, all accessible levels will be targeted.</param>
        /// <returns>List of kanji for the target levels.</returns>
        public async Task<List<WaniKaniKanjiItem>> GetKanjiAsync(params int[] levels)
        {
            List<WaniKaniKanjiListResponse> responses = await QueryItemListAsync<WaniKaniKanjiListResponse>("kanji/{0}", levels);
            return responses.SelectMany(r => r.Kanji).ToList();
        }

        /// <summary>
        /// Gets the list of vocabulary items for the given levels, or for all accessible levels if nothing is specified.
        /// </summary>
        /// <param name="levels">Target levels. If empty, all accessible levels will be targeted.</param>
        /// <returns>List of vocabulary items for the target levels.</returns>
        public List<WaniKaniVocabularyItem> GetVocabulary(params int[] levels)
        {
            return GetVocabularyAsync(levels).Result;
        }

        /// <summary>
        /// Gets asynchronously the list of vocabulary items for the given levels, or for all accessible levels if nothing is specified.
        /// </summary>
        /// <param name="levels">Target levels. If empty, all accessible levels will be targeted.</param>
        /// <returns>List of vocabulary items for the target levels.</returns>
        public async Task<List<WaniKaniVocabularyItem>> GetVocabularyAsync(params int[] levels)
        {
            List<WaniKaniVocabularyListResponse> responses = await QueryItemListAsync<WaniKaniVocabularyListResponse>("vocabulary/{0}", levels);
            return responses.SelectMany(r => r.Vocabulary).ToList();
        }

        #endregion

        /// <summary>
        /// Interrogates the WaniKani Api with the given query, and return the answer as a string.
        /// </summary>
        /// <param name="query">API query (e.g. "kanji/1,2,3").</param>
        /// <returns>Result of the query as a Json string.</returns>
        private async Task<string> QueryAsync(string query)
        {
            Uri uri = new Uri(string.Format(BaseUrl, ApiKey) + query, UriKind.Absolute);
            return await _apiClient.QueryApiAsync(uri);
        }

        /// <summary>
        /// Deserializes the given JSON string into a WaniKaniResponse of the correct type.
        /// </summary>
        /// <typeparam name="T">Expected type.</typeparam>
        /// <param name="json">JSON string to deserialize.</param>
        /// <returns>Deserialized item. Cannot be null.</returns>
        private static T Deserialize<T>(string json) where T: WaniKaniResponse
        {
            WaniKaniResponse response;
            try
            {
                response = JsonConvert.DeserializeObject<T>(json);
                if (response == null)
                    throw new Exception($"The result cannot be read as a {typeof(T).Name}.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not deserialize the response: \"{json}\".", ex);
            }

            if (response.Error != null)
                throw new WaniKaniException(response.Error);

            return (T)response;
        }

        /// <summary>
        /// Checks the validity of the given API key.
        /// </summary>
        /// <param name="apiKey">API key to check.</param>
        /// <returns><c>True</c> if the key is valid. <c>False</c> otherwise.</returns>
        private static bool CheckApiKey(string apiKey)
        {
            return ApiKeyRegex.IsMatch(apiKey);
        }

        /// <summary>
        /// Cuts the given list of levels in sections that can be used to request lists of items.
        /// This step is necessary because of a severe performance issue in the WaniKani API affecting large list requests.
        /// The WaniKani development team has issued official answers saying that this issue will not be fixed.
        /// </summary>
        /// <param name="levels">Array of levels to cut. If null or empty, will be considered as starting from level 1 and ending to the maximum level.</param>
        /// <returns>List of sections of levels that can be individually requested.</returns>
        /// <example>[1,2,3,4,5,6,7,8,9,10,11,12] will be cut in [[1,2,3,4,5,6,7,8,9,10],[11,12]] with a max level count of 10.</example>
        private List<List<int>> CutLevelsForListRequest(int[] levels)
        {
            if (levels.Any(l => l > MaxLevel || l < 1))
                throw new ArgumentOutOfRangeException(nameof(levels), "Cannot request on levels below 1 or above the MaxLevel.");

            if (levels == null || levels.Length == 0)
                levels = Enumerable.Range(1, MaxLevel).ToArray();
            else
                levels = levels.Distinct().ToArray();

            List<List<int>> sections = new List<List<int>>();

            int i = 0;
            List<int> current;
            while ((current = levels.Skip(ListRequestSectionMaxLevelCount*i).Take(ListRequestSectionMaxLevelCount).ToList()).Any())
            {
                sections.Add(current);
                i++;
            }

            return sections;
        }

        /// <summary>
        /// Requests the API for a leveled item list and return the responses.
        /// </summary>
        /// <typeparam name="T">Type of responses expected.</typeparam>
        /// <param name="baseRequestUrl">Formattable string containing the request format.</param>
        /// <param name="levels">Target levels.</param>
        /// <returns>List of responses.</returns>
        private async Task<List<T>> QueryItemListAsync<T>(string baseRequestUrl, int[] levels) where T : WaniKaniResponse
        {
            List<List<int>> levelLists = CutLevelsForListRequest(levels);

            List<T> responses = new List<T>();
            foreach (List<int> list in levelLists)
            {
                string query = string.Format(baseRequestUrl, string.Join(",", list));
                //System.Diagnostics.Debug.WriteLine(query);
                string response = await QueryAsync(query);
                //System.Diagnostics.Debug.WriteLine(response);
                responses.Add(Deserialize<T>(response));
            }

            return responses;
        }
    }
}
