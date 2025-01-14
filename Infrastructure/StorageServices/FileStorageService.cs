using Microsoft.AspNetCore.Http;
using RIIMS.Domain.Interfaces;

namespace RIIMS.Infrastructure
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _imageFolderPath;

        public FileStorageService()
        {
            _imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
        }

        public async Task<string> SaveFileAsync(IFormFile file, string fileName)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is empty.");
            }

            if (!Directory.Exists(_imageFolderPath))
            {
                Directory.CreateDirectory(_imageFolderPath);
            }

            var sanitizedFileName = Path.GetFileNameWithoutExtension(fileName);
            var fullFileName = $"{sanitizedFileName}{Path.GetExtension(file.FileName)}"; 

            var filePath = Path.Combine(_imageFolderPath, fullFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }

        public async Task<bool> DeleteFileAsync(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
