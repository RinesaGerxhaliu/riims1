using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace RIIMS.Application.DTOs.ImageDTOs
{
    public class ImageUploadRequestDTO
    {
        public IFormFile File { get; set; }

        public string FileName { get; set; }

        public string? FileDescription { get; set; }

    }
}