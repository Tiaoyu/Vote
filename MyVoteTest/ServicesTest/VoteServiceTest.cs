using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MyVote;
using MyVote.Controllers;
using MyVote.Models;
using MyVote.Services;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
namespace MyVoteTest.ServicesTest
{
    public class VoteServiceTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public VoteServiceTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task CreateRoundTest()
        {
            var content = new StringContent(JsonConvert.SerializeObject(new RoundModel
            {
                RoundDesc = "testRound",
                RoundBeginTime = DateTime.Now,
                RoundEndTime = DateTime.Now
            }));

            var res = await _client.GetAsync("/");// ("/vote/createround", content);
            Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        }
    }
}
