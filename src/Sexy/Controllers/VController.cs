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

            switch (fileName.Substring(fileName.LastIndexOf(".") + 1))
            {
                case "bmp":
                case "jpg":
                case "jpeg":
                case "png":
                    fileType = "image";
                    break;
                case "gif":
                    fileType = "gif";
                    break;
                case "mp4":
                case "ogv":
                case "webm":
                    fileType = "video";
                    break;
                case "mp3":
                case "ogg":
                    fileType = "audio";
                    break;
                case "swf":
                    fileType = "flash";
                    break;
                case "jar":
                    ViewBag.JavaClass = fileName.Substring(fileName.Length -3);
                    fileType = "java";
                    break;
                    break;
                case "pdf":
                    fileType = "document";
                    break;
                case "md":
                    fileType = "markdown";
                    break;
                case "html":
                case "htm":
                case "txt":
                    fileType = "frame";
                    break;
                case "avi":
                case "flv":
                case "wmv":
                    fileType = "native";
                    break;
                case "apk":
                    fileType = "android";
                    break;
                case "deb":
                    fileType = "linux-deb";
                    break;
                case "rpm":
                    fileType = "linux-rpm";
                    break;
                case "dmg":
                case "pkg":
                    fileType = "macos";
                    break;
                case "ipa":
                    fileType = "ios";
                    break;
                case "exe":
                case "msi":
                    fileType = "windows";
                    break;
                default:
                    fileType = "other";
                    break;
            }

            IndexViewModel returnViewModel = new IndexViewModel {
                Slug = fileName,
                Type = fileType
            };

            return View(returnViewModel);
        }
    }
}