
using Tweetinvi;
using Tweetinvi.Core.Models;
using Tweetinvi.Exceptions;
using Tweetinvi.Models;

namespace TwitterC
{
    public class TwitterService
    {
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private readonly string _accessToken;
        private readonly string _accessTokenSecret;

        public TwitterService(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _accessToken = accessToken;
            _accessTokenSecret = accessTokenSecret;

        }

        public async Task CreateTweet(string message)
        {
            try
            {
                var userClient = new TwitterClient(_consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
                var tweet = await userClient.Tweets.PublishTweetAsync(message);

                if (tweet != null)
                {
                    Console.WriteLine("Tweet sent successfully!");
                    Console.WriteLine("Tweet ID: " + tweet.Id);
                }
                else
                {
                    Console.WriteLine("Failed to send tweet. Tweet is null.");
                }
            }
            catch (TwitterException ex)
            {
                Console.WriteLine($"Error occurred while sending the tweet: {ex.Message}");

                if (ex.TwitterDescription != null)
                {
                    Console.WriteLine($"Twitter error description: {ex.TwitterDescription}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }


        private async Task<ITweet> TweetAsync(string message)
        {
            var userClient = new TwitterClient(_consumerKey, _consumerSecret, _accessToken, _accessTokenSecret);
            var publishedTweet = await userClient.Tweets.PublishTweetAsync(message);
            return publishedTweet;
        }


    }

}