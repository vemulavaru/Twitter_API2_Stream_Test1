using System;
using Twitter_API2_Stream_Test;
using Xunit;

namespace TwitterAPI_UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public async void InvalidURI()
        {
            //Get http client
            var client = TwitterClient.GetWebClient();
            try
            {
                //Get Http async response 
                dynamic? tweetData = await TwitterClient.GetHttpResponseAsync("xxxx", client);
            }
            catch (Exception ex)
            {
                Assert.Contains("invalid request uri", ex.Message.ToLower());
            }

        }
        [Fact]
        public async void InvalidEndpoint()
        {
            //Get http client
            var client = TwitterClient.GetWebClient();
            
            dynamic? tweetData = await TwitterClient.GetHttpResponseAsync("https://api.twitter.com/2/tweets/recent/stream", client);
            Assert.Equal(tweetData, null);            

        }
        [Fact]
        public async void VerifyTopTenHashTagsCount()
        {
            var hashTags = await TwitterClient.GetTop10HashTagsAsync();
            if (hashTags != null)
            {
                Assert.Equal(10,hashTags.Count);
            }

        }
        [Fact]
        public async void VerifyRecentTweets()
        {
            var tweets = await TwitterClient.GetRecentDevTweetsAsync();
            Assert.NotNull(tweets);           

        }
    }
}
