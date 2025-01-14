using Microsoft.AspNetCore.Http;

namespace RIIMS.Domain.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(IFormFile file, string fileName);
        Task<bool> DeleteFileAsync(string filePath);
    }
}
