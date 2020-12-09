using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Models.Helpers;

namespace Artboy.PhotoGears.Models
{
    public interface IImageRepository
    {
        Task<PageResult<GearImage>> ListImages(int page, int pageSize);
        Task<IEnumerable<GearImage>> GetImages();
        Task<GearImage> GetImage(long id);
        Task CreateImage(GearImage newImage);
        Task UpdateImage(GearImage image);
        
        Task DeleteImage(GearImage image);
        Task<PageResult<GearImage>> SearchImages(string term, int page);
        string Token { get; set; }
        void RejectChanges();
    }
}
