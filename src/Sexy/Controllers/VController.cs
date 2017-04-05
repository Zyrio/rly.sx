using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sexy.Models.VViewModels;

namespace Sexy.Controllers
{
    public class VController : Controller
    {
        // /

        [Route("/v/{fileName}")]
        [HttpGet]
        public IActionResult Index(string fileName)
        {
            string fileType = null;

            

            IndexViewModel returnViewModel = new IndexViewModel {
                Slug = fileName,
                Type = fileType
            };

            return View(returnViewModel);
        }
    }
}