using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace RIIMS.Application.DTOs
{
    public class ImageUploadRequestDto
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        public string FileName { get; set; }

        public string? FileDescription { get; set; }

       // [Required] // Ensure the UserId is required to link the image to a user
       // public string UserId { get; set; }
    }
}