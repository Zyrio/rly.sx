using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sexy.Models.HomeViewModels;

namespace Sexy.Controllers
{
    public class HomeController : Controller
    {
        // /

        [HttpGet]
        public IActionResult Index()
        {
            IndexViewModel returnViewModel = new IndexViewModel {
                Filename = ""
            };

            return View(returnViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ICollection<IFormFile> files)
        {
            var uploads = Sexy.Data.Constants.AppSettings.UploadStoragePath;
            var filenameLength = Convert.ToInt32(Sexy.Data.Constants.AppSettings.FilenameLength);
            var maxFilesize = Convert.ToInt32(Sexy.Data.Constants.AppSettings.MaxFilesize);

            var randomString = CreateFilename(filenameLength);

            string newFile = null;

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    if(file.Length < maxFilesize) {
                        newFile = randomString + Path.GetExtension(file.FileName);

                        using (var fileStream = new FileStream(
                            Path.Combine(uploads, newFile), FileMode.Create)
                        )
                        {
                            await file.CopyToAsync(fileStream);
                        }
                    }
                }
            }

            IndexViewModel returnViewModel = new IndexViewModel {
                Filename = newFile
            };

            return View(returnViewModel);
        }

        // /error

        public IActionResult Error()
        {
            return View();
        }

        //

        public string CreateFilename(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyz1234567890";
            System.Text.StringBuilder randomString = new System.Text.StringBuilder();
            Random random = new Random();

            while (0 < length--)
            {
                randomString.Append(valid[random.Next(valid.Length)]);
            }

            return randomString.ToString();
        }
    }
}
