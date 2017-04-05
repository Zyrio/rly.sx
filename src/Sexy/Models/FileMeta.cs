using System;

namespace Sexy.Models
{
    public class FileMeta
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Credit { get; set; }
        public string Password { get; set; }
        public bool Comments { get; set; }

        public virtual File File { get; set; }
    }
}