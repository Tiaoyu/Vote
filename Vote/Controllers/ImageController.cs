using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyVote.Models;

namespace MyVote.Controllers
{
    [Controller]
    [Route("/image")]
    public class ImageController : Controller
    {
        [HttpPost]
        [Route("upload")]
        [Produces("application/json")]
        [Consumes("application/json", "multipart/form-data")]
        public IActionResult Upload()
        {
            return View(); 
        }
    }
}