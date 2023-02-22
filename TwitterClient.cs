using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_API2_Stream_Test
{
    public class TwitterClient
    {
        //Bearer token from the config settings
        public static string bearerToken { get; set; } = Settings1.Default.Bearer_Token;
        //Gets total tweets asynchronously from the twitter stream.
        //****Note: The endpoint which gets the sample tweets from the stream needs an elevated access. Currently, this bearer token doesn't have an elevated access.
        public static async Task<int> GetTotalTweetsAsync()
        {
            string endpoint = Settings1.Default.Total_Stream_Endpoint;
            int totalTweets = 0;
            try
            {
                //Get HTTP client
                var client = GetWebClient();

                // Get response stream
                Stream? responseStream = await GetHttpResponseStreamAsync(endpoint, client);

                // Parse response stream to count number of tweets received
                
                if (responseStream != null)
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        if (reader != null)
                        {
                            while (!reader.EndOfStream)
                            {
                                string? line = await reader.ReadLineAsync();
                                if (!string.IsNullOrWhiteSpace(line))
                                {
                                    JObject twtObject = JObject.Parse(line);
                                    if (twtObject.ContainsKey("data"))
                                    {
                                        //Increments the counter when the data is found
                                        totalTweets++;
                                    }
                                }
                            }
                        }
                        return totalTweets;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.LogError(ex.GetBaseException().ToString());
            }
            return -1;

        }
        //This method gets the recent tweets from the TwitterDev account asynchronously.
        public static async Task<List<string>> GetRecentDevTweetsAsync()
        {
            List<string> lstRecentTweets = new List<string>();
            try
            {
                var endpoint = Settings1.Default.Recent_Tweets_Endpoint;
                //Get Http Client
                var client = GetWebClient();

                //Add query parameters to endpoint to get recent tweets from TwitterDev
                string queryParameters = "?query=from:TwitterDev";

                //Get http response asynchronously
                dynamic? tweetData = await GetHttpResponseAsync(endpoint + queryParameters, client);
               
                var data = tweetData is null ? "" : tweetData["data"];
                //Loop through the data node and add the tweet text to the list.
                foreach (var tweet in data)
                {
                    lstRecentTweets.Add(Convert.ToString(tweet.text));                    
                }
            }
            catch (Exception ex)
            {
                Log.LogError(ex.GetBaseException().ToString());
            }
            return lstRecentTweets;
        }
        //Method to get top 10 hashtags aynchronously
        public static async Task<Dictionary<string, int>> GetTop10HashTagsAsync()
        {
            //Endpoint to get top 10 hashtags for max results of 100
            var endpoint = Settings1.Default.Top10HashTags_Endpoint;
            var sortedHashtags = new Dictionary<string, int>();
            var topTenHashtags = new Dictionary<string, int>();
            try
            {
                //Get http client
                var client = GetWebClient();

                //Get Http async response 
                dynamic? tweetData = await GetHttpResponseAsync(endpoint, client);

                var data = tweetData is null ? "" : tweetData["data"];
                // Create a dictionary to store the hashtag count
                var hashtags = new Dictionary<string, int>();
                foreach (var tweet in data)
                {
                    // Split the tweet text into words
                    var words = tweet.text;
                    words = Convert.ToString(words).Split(' ');

                    // Loop through each word and check if it starts with '#'
                    foreach (var word in words)
                    {
                        if (word.StartsWith("#"))
                        {
                            // Increment the count of this hashtag
                            if (hashtags.ContainsKey(word))
                                hashtags[word]++;
                            else
                                hashtags[word] = 1;
                        }
                    }                    
                }
                // Sort the hashtags by count in descending order
                sortedHashtags = hashtags.OrderByDescending(h => h.Value).ToDictionary(z => z.Key, y => y.Value);
                int i = 0;
                foreach (var hashtag in sortedHashtags)
                {
                    topTenHashtags.Add(hashtag.Key, hashtag.Value);
                    i++;
                    if (i == 10)
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.LogError(ex.GetBaseException().ToString());
            }
            return topTenHashtags;
        }
        //Method to setup HTTP Client
        public static HttpClient GetWebClient()
        {
            //Initialize HTTP client
            HttpClient client = new HttpClient();
            //Add Authorization with bearer token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            return client;
        }
        //Method to get HTTP response
        public static async Task<dynamic?> GetHttpResponseAsync(string endpoint, HttpClient client)
        {
            dynamic tweetData;
            try
            {
                // Send request to Twitter API
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    // Get response stream
                    var content = await response.Content.ReadAsStringAsync();
                    tweetData = JsonConvert.DeserializeObject<dynamic>(content);
                    return tweetData;
                }
                else
                {
                    //Log status code if response is not successful
                    Log.LogError("GetHTTPResponse return code: " + response.StatusCode.ToString() + " Endpoint: " + endpoint);
                }
            }
            catch { throw; }
            return null;
        }
        public static async Task<Stream?> GetHttpResponseStreamAsync(string endpoint, HttpClient client)
        {
            try
            {
                // Send request to Twitter Streaming API
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    // Get response stream
                    Stream responseStream = await response.Content.ReadAsStreamAsync();
                    return responseStream;
                }
                else
                {
                    //Log status code if response is not successful
                    Log.LogError("GetHTTPResponse return code: " + response.StatusCode.ToString() + " Endpoint: " + endpoint);
                }
            }
            catch { throw; }
            return null;

        }

    }
}
