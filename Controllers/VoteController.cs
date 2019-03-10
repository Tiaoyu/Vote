using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly VoteService _voteService;
        private readonly IHostingEnvironment he;
        public VoteController(VoteService voteService, IHostingEnvironment IHe)
        {
            _voteService = voteService;
            he = IHe;
        }

        public IActionResult Index()
        {
            var rounds = _voteService.GetRoundList();
            ViewData.Add("ROUND_LIST", rounds ?? new List<RoundModel>());
            return View();
        }

        [HttpGet]
        [Route("round")]
        public IActionResult RoundDetail(string roundId)
        {
            var round = _voteService.GetRoundById(roundId);
            ViewData.Add("ROUND", round ?? new RoundModel());
            return View("round");
        }

        /// <summary>
        /// Create this instance.
        /// </summary>
        /// <returns>The create.</returns>
        [Route("create")]
        public IActionResult CreateVoteRound()
        {
            return View("votecreate");
        }

        /// <summary>
        /// Modifies the round.
        /// </summary>
        /// <returns>The round.</returns>
        /// <param name="roundId">Round identifier.</param>
        [HttpGet]
        [Route("modifyround")]
        public IActionResult ModifyRound(string roundId)
        {
            var round = _voteService.GetRoundById(roundId)??new RoundModel();
            ViewData.Add("ROUND", round);
            return View("votecreate");
        }

        /// <summary>
        /// Creates the round async.
        /// </summary>
        /// <returns>The round async.</returns>
        /// <param name="round">Round.</param>
        [HttpPost]
        [Route("createround")]
        public async Task<IActionResult> CreateRoundAsync(RoundModel round)
        {
            var Round = new RoundModel
            {
                RoundDesc = round.RoundDesc,
                RoundEndTime = round.RoundEndTime,
                RoundBeginTime = round.RoundBeginTime
            };
            if (string.IsNullOrEmpty(round.RoundId))
            {
                Round.RoundId = Utils.GetGuid();
            }
            await _voteService.SaveRoundAsync(Round);
            return Ok(Round);
        }

        /// <summary>
        /// Creates the choice async.
        /// </summary>
        /// <returns>The choice async.</returns>
        /// <param name="choice">Choice.</param>
        /// <param name="roundId">Round identifier.</param>
        [HttpPost]
        [Route("createchoice")]
        public async Task<IActionResult> CreateChoiceAsync(ChoiceModel choice, string roundId)
        {
            var Choice = new ChoiceModel
            {
                ChoiceId = Utils.GetGuid(),
                ChoiceContent = choice.ChoiceContent,
                ChoiceValue = choice.ChoiceValue
            };
            var round = _voteService.GetRoundById(roundId);
            if (round == null) return Ok("error");
            Choice.Round = round;
            await _voteService.SaveChioceAsync(Choice);
            return Ok(choice);
        }

        /// <summary>
        /// Uploads the targets.
        /// </summary>
        /// <returns>The targets.</returns>
        [Produces("application/json")]
        [Consumes("application/json", "multipart/form-data")]
        [Route("uploadTargets")]
        public async Task<IActionResult> UploadTargets()
        {
            // 是否有上传图片
            if (Request.Form.Files.Count <= 0)
            {
                return Ok("ERROR");
            }
            var picList = new List<string>();
            // 当前上传的图片大小不为0
            foreach(var picFile in Request.Form.Files)
            {
                var path = await UploadPic(picFile);
                if (!string.IsNullOrEmpty(path))
                {
                    picList.Add(path);
                }
            }
            return Ok(picList);
        }

        /// <summary>
        /// Uploads the pic.
        /// </summary>
        /// <returns>The pic.</returns>
        /// <param name="formFile">Form file.</param>
        [NonAction]
        public async Task<string> UploadPic(IFormFile formFile)
        {
            if (formFile.Length <= 0)
            {
                return null;
            }
            // 生成图片名
            var picName = Utils.GetGuid() + '.' + formFile.FileName.Split('.').Last();
            // 将图片存入指定文件夹
            var uploadPath = Path.Combine(he.WebRootPath + "/img/", picName);
            using (var stream = new FileStream(uploadPath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }
            return picName;
        }
    }
}