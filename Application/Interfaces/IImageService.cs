using RIIMS.Application.DTOs.ImageDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Interfaces
{
    public interface IImageService
    {
        Task<ImageDTO> UploadImageAsync(string userId, ImageUploadRequestDTO request);
        Task<ImageDTO?> GetImageByUserIdAsync(string userId);
        Task<bool> DeleteImageByUserIdAsync(string userId);
    }
}
