using AutoMapper;
using RIIMS.Application.DTOs.ImageDTOs;
using RIIMS.Application.Interfaces;
using RIIMS.Domain.Entities;
using RIIMS.Domain.Interfaces;

namespace RIIMS.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository imageRepository, IFileStorageService fileStorageService, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
        }

        public async Task<ImageDTO> UploadImageAsync(string userId, ImageUploadRequestDTO request)
        {
            if (request.File == null || request.File.Length == 0)
            {
                throw new ArgumentException("File is not valid.");
            }

            var image = _mapper.Map<Image>(request);

            var filePath = await _fileStorageService.SaveFileAsync(request.File, request.FileName);

            image.FilePath = filePath;
            image.FileExtension = Path.GetExtension(request.File.FileName);
            image.FileSizeInBytes = request.File.Length;

            var uploadedImage = await _imageRepository.Upload(userId, image);

            var imageDto = _mapper.Map<ImageDTO>(uploadedImage);
            return imageDto;
        }

        public async Task<ImageDTO?> GetImageByUserIdAsync(string userId)
        {
            var image = await _imageRepository.GetImageByUserId(userId);
            if (image == null)
            {
                return null;
            }

            return _mapper.Map<ImageDTO>(image);
        }

        public async Task<bool> DeleteImageByUserIdAsync(string userId)
        {
            var image = await _imageRepository.GetImageByUserId(userId);
            if (image == null)
            {
                return false;
            }

            var isFileDeleted = await _fileStorageService.DeleteFileAsync(image.FilePath);
            if (!isFileDeleted)
            {
                return false;
            }

            var isDeletedFromDb = await _imageRepository.DeleteImageByUserId(userId);
            if (!isDeletedFromDb)
            {
                return false;
            }

            return true;
        }

    }
}
