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
        public async Task<IActionResult> RoundDetail(string roundId)
        {
            var round = await _voteService.GetRoundById(roundId);
            var choiceList = _voteService.GetChoiceListByRoundId(roundId);
            var targetList = _voteService.GetTargetListByRoundId(roundId);
            choiceList.Sort((c1, c2) => { return c1.ChoiceValue.CompareTo(c2.ChoiceValue); });

            ViewData.Add("ROUND", round ?? new RoundModel());
            ViewData.Add("CHOICE_LIST", choiceList ?? new List<ChoiceModel>());
            ViewData.Add("TARGET_LIST", targetList ?? new List<TargetModel>());

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
        public async Task<IActionResult> ModifyRound(string roundId)
        {
            var round = await _voteService.GetRoundById(roundId) ?? new RoundModel();
            var choiceList = _voteService.GetChoiceListByRoundId(roundId);
            var targetList = _voteService.GetTargetListByRoundId(roundId);
            ViewData.Add("ROUND", round);
            ViewData.Add("CHOICE_LIST", choiceList);
            ViewData.Add("TARGET_LIST", targetList);


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
            var round = await _voteService.GetRoundById(roundId);
            if (round == null) return Ok("error");
            Choice.Round = round;
            await _voteService.SaveChioceAsync(Choice);
            return Ok(choice);
        }

        [HttpPost]
        [Route("createvote")]
        public async Task<IActionResult> CreateVote(string roundId)
        {
            var choiceList = _voteService.GetChoiceListByRoundId(roundId);
            var targetList = _voteService.GetTargetListByRoundId(roundId);
            var targetChoiceList = new List<TargetChoiceModel>();
            foreach (var target in targetList)
            {
                foreach (var choice in choiceList)
                {
                    var tc = new TargetChoiceModel
                    {
                        Choice = choice,
                        Target = target,
                        ChoiceId = choice.ChoiceId,
                        TargetId = target.TargetId
                    };
                    targetChoiceList.Add(tc);
                }
            }

            await _voteService.SaveTargetChoiceList(targetChoiceList);

            return View("Index");
        }

        [HttpPost]
        [Route("savevote")]
        public async Task<IActionResult> SaveVote(List<VoteModel> listVote, string roundId, string userName)
        {

            return View("Index");
        }
        /// <summary>
        /// Uploads the targets.
        /// </summary>
        /// <returns>The targets.</returns>
        [Produces("application/json")]
        [Consumes("application/json", "multipart/form-data")]
        [Route("uploadTargets")]
        public async Task<IActionResult> UploadTargets(string roundId)
        {
            // 是否有上传图片
            if (Request.Form.Files.Count <= 0)
            {
                return Ok("ERROR");
            }

            var taragetList = new List<TargetModel>();
            // 当前上传的图片大小不为0
            foreach (var picFile in Request.Form.Files)
            {
                var path = await UploadPic(picFile);
                if (!string.IsNullOrEmpty(path))
                {
                    var target = new TargetModel
                    {
                        TargetContent = path,
                        RoundId = roundId,
                        TargetypeId = "1"
                    };
                    taragetList.Add(target);
                }
            }

            await _voteService.SaveTargetList(taragetList);
            return Ok(taragetList);
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