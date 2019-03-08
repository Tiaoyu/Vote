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
        private readonly VoteDBContext _voteDBContext;
        private readonly VoteService _voteService;
        private readonly IHostingEnvironment he;
        public VoteController(VoteService voteService, IHostingEnvironment IHe)
        {
            _voteService = voteService;
            he = IHe;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Create this instance.
        /// </summary>
        /// <returns>The create.</returns>
        [Route("create")]
        public IActionResult Create()
        {
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