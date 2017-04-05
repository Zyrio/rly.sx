using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sexy.Models;

namespace Sexy.Data.Repositories.Interfaces
{
    public interface IFileRepository
    {
        Task<File> AddFile(
            String name,
            String extension,
            Enums.Filetype type,
            string originalFilename,
            DateTime dateUploaded,
            string source);
    }
}