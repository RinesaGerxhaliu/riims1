using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Domain.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> Upload(string userId, Image image);
        Task<Image?> GetImageByUserId(string userId);
        Task<bool> DeleteImageByUserId(string userId);
    }
}
