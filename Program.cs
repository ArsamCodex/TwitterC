using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Models;
using Tweetinvi.Exceptions;
using Tweetinvi.Models;
using TwitterC;

namespace TwitterAPIDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {


            var client = new TwitterClient("",
            "",
            "",
            "LTP4d");

            var tweetModelDto = new TweetModelDto { Text = "hello" };

            var request = BuildTwitterRequestAction(tweetModelDto, client);

            try
            {
                var result = await client.Execute.AdvanceRequestAsync(request);
                Console.WriteLine("Tweet posted successfully!");
                Console.WriteLine(result.Content);
            }
            catch (TwitterException ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        static Action<ITwitterRequest> BuildTwitterRequestAction(TweetModelDto tweetModelDto, TwitterClient client)
        {
            return (ITwitterRequest request) =>
            {
                var body = client.Json.Serialize(tweetModelDto);
                var content = new StringContent(body, Encoding.UTF8, "application/json");

                request.Query.Url = "https://api.twitter.com/2/tweets";
                request.Query.HttpMethod = Tweetinvi.Models.HttpMethod.POST;
                request.Query.HttpContent = content;
            };
        }
    }
}