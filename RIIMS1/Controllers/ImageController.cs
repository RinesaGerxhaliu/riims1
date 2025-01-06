using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.ImageDTOs;
using RIIMS.Application.Interfaces;
using System.Security.Claims;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        private string GetUserIdFromToken()
        {
            var userId = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID is not available in the token.");
            }

            return userId;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImageAsync([FromForm] ImageUploadRequestDTO request)
        {
            var validationErrors = ValidateFileUpload(request);
            if (validationErrors.Any())
            {
                return BadRequest(new { errors = validationErrors });
            }
            string userId;
            try
            {
                userId = GetUserIdFromToken();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }

            try
            {
                var uploadedImage = await _imageService.UploadImageAsync(userId, request);

                return Ok(new { url = uploadedImage.FilePath });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("GetImageByUserId")]
        public async Task<IActionResult> GetImageByUserIdAsync()
        {
            string userId;
            try
            {
                userId = GetUserIdFromToken();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }

            var image = await _imageService.GetImageByUserIdAsync(userId);

            if (image == null)
            {
                return NotFound(new { message = "Image not found." });
            }

            return Ok(new { url = image.FilePath });
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteImageByUserIdAsync()
        {
            string userId;
            try
            {
                userId = GetUserIdFromToken();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }

            try
            {
                var isDeleted = await _imageService.DeleteImageByUserIdAsync(userId);
                if (!isDeleted)
                {
                    return NotFound(new { message = "Image could not be deleted." });
                }

                return Ok(new { message = "Image deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while deleting the image." });
            }
        }


        private List<string> ValidateFileUpload(ImageUploadRequestDTO request)
        {
            var errors = new List<string>();

            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(request.File.FileName)?.ToLower();

            if (fileExtension == null || !allowedExtensions.Contains(fileExtension))
            {
                errors.Add("Unsupported file extension. Please upload a .jpg, .jpeg, or .png file.");
            }

            if (request.File.Length > 10485670) 
            {
                errors.Add("File size exceeds 10MB, please upload a smaller file.");
            }

            return errors;
        }
    }
}
