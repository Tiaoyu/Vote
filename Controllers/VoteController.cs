using System;
using Microsoft.AspNetCore.Mvc;
using MyVote.Models;
using MyVote.Services;
using MyVote.Tools;

namespace MyVote.Controllers
{
    [Controller]
    [Route("/vote")]
    public class VoteController : Controller
    {
        private VoteDBContext _voteDBContext { get; set; }
        private VoteService _voteService { get; set; }

        public VoteController(VoteService voteService)
        {
            _voteService = voteService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("create")]
        public IActionResult Create()
        {
            return View("votecreate");
        }

        [HttpPost]
        [Route("createround")]
        public async System.Threading.Tasks.Task<IActionResult> CreateRoundAsync(RoundModel round)
        {
            Console.Write(round.RoundDesc);
            var Round = new RoundModel
            {
                RoundId = Utils.GetGuid(),
                RoundDesc = round.RoundDesc,
                RoundEndTime = round.RoundEndTime,
                RoundBeginTime = round.RoundBeginTime
            };
            await _voteService.SaveRoundAsync(Round);
            return Ok(Round);
        }
    }

}