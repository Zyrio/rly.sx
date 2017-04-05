using System;

namespace Sexy.Models
{
    public class File
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public Enums.Filetype Type { get; set; }
        public string OriginalFilename { get; set; }
        public DateTime DateUploaded { get; set; }
        public string Source { get; set; }
    }
}