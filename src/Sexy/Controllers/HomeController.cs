using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sexy.Data;
using Sexy.Data.Repositories.Interfaces;
using Sexy.Models.HomeViewModels;
using Sexy.Utilities;

namespace Sexy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFileRepository _fileRepository;

        public HomeController(
            ApplicationDbContext dbContext,
            IFileRepository fileRepository
        ) {
            _dbContext = dbContext;
            _fileRepository = fileRepository;
        }

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
            var uploads = Sexy.Data.Constants.AppSettingsConstant.UploadStoragePath;
            var filenameLength = Convert.ToInt32(Sexy.Data.Constants.AppSettingsConstant.FilenameLength);
            var maxFilesize = Convert.ToInt32(Sexy.Data.Constants.AppSettingsConstant.MaxFilesize);

            var randomString = GenerationUtilities.GenerateRandomString(filenameLength, false);

            string newFile = null;

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    if(file.Length < maxFilesize) {
                        try {
                            newFile = randomString + Path.GetExtension(file.FileName);
                        } catch {
                            newFile = randomString + "bin";
                        }

                        using (var fileStream = new FileStream(
                            Path.Combine(uploads, newFile), FileMode.Create)
                        )
                        {
                            await file.CopyToAsync(fileStream);
                        }

                        var fileNamePieces = newFile.Split(new[] { '.' }, 2);
                        var fileType = FiletypeUtilities.GetFiletypeEnum(fileNamePieces[1]);

                        await _fileRepository.AddFile(
                            fileNamePieces[0],
                            fileNamePieces[1],
                            fileType,
                            file.FileName,
                            DateTime.UtcNow,
                            "rly.sx"
                        );
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
    }
}
