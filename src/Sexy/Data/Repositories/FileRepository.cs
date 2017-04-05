using System;
using System.Threading.Tasks;
using Sexy.Data.Repositories.Interfaces;
using Sexy.Models;

namespace Sexy.Data.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<File> AddFile(
            String name,
            String extension,
            Enums.Filetype type,
            string originalFilename,
            DateTime dateUploaded,
            string source
        )
        {
            File file = new File {
                Name = name,
                Extension = extension,
                Type = type,
                OriginalFilename = originalFilename,
                DateUploaded = dateUploaded,
                Source = source
            };

            var newFile = _dbContext
                .Files
                .Add(file)
                .Entity;

            await _dbContext.SaveChangesAsync();

            return newFile;
        }
    }
}