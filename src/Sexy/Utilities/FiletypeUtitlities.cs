using System;
using Sexy.Models;

namespace Sexy.Utilities
{
    public class FiletypeUtilities
    {
        public static Enums.Filetype GetFiletypeEnum(string extension)
        {
            switch (extension.ToLower())
            {
                case "bmp":
                case "jpg":
                case "jpeg":
                case "png":
                    return Enums.Filetype.Image;
                case "gif":
                    return Enums.Filetype.Gif;
                case "mp4":
                case "ogv":
                case "webm":
                    return Enums.Filetype.Video;
                case "mp3":
                case "ogg":
                    return Enums.Filetype.Audio;
                case "swf":
                    return Enums.Filetype.Flash;
                case "jar":
                    //ViewBag.JavaClass = fileName.Substring(fileName.Length -3);
                    return Enums.Filetype.Java;
                case "pdf":
                    return Enums.Filetype.Document;
                case "md":
                    return Enums.Filetype.Markdown;
                case "htm":
                case "html":
                case "text":
                case "txt":
                    return Enums.Filetype.Plain;
                case "avi":
                case "flv":
                case "wmv":
                    return Enums.Filetype.Native;
                case "apk":
                    return Enums.Filetype.Android;
                case "deb":
                    return Enums.Filetype.Linux_Deb;
                case "rpm":
                    return Enums.Filetype.Linux_RPM;
                case "dmg":
                case "pkg":
                    return Enums.Filetype.MacOS;
                case "ipa":
                    return Enums.Filetype.iOS;
                case "exe":
                case "msi":
                    return Enums.Filetype.Windows;
                default:
                    return Enums.Filetype.Other;
            }
        }
    }
}