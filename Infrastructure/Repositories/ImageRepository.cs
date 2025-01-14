using RIIMS.Domain.Interfaces;
using RIIMS.Infrastructure.Data;
using Image = RIIMS.Domain.Entities.Image;

namespace RIIMS.Infrastructure.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly RiimsDbContext _dbContext;

        public ImageRepository(RiimsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Image> Upload(string userId, Image image)
        {
            await _dbContext.Image.AddAsync(image);
            await _dbContext.SaveChangesAsync();

            var user = await _dbContext.Users.FindAsync(userId);
            if (user != null)
            {
                user.ImageId = image.Id;
                await _dbContext.SaveChangesAsync();
            }

            return image;
        }

        public async Task<Image?> GetImageByUserId(string userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user != null && user.ImageId.HasValue)
            {
                return await _dbContext.Image.FindAsync(user.ImageId.Value);
            }

            return null;
        }

        public async Task<bool> DeleteImageByUserId(string userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null || !user.ImageId.HasValue)
            {
                return false;
            }

            var image = await _dbContext.Image.FindAsync(user.ImageId.Value);
            if (image == null)
            {
                return false;
            }

            _dbContext.Image.Remove(image);
            user.ImageId = null;
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
