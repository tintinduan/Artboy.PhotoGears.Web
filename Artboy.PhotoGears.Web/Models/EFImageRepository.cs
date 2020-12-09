using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Web.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Artboy.PhotoGears.Web.Models
{
    public class EFImageRepository : IImageRepository
    {
        private PhotoGearsDbContext context;

        public string Token { get ; set ; }

        public EFImageRepository(PhotoGearsDbContext context)
        {
            this.context = context;
        }
        
        public async Task<GearImage> GetImage(long id)
        {
            return await context.GearImages.FindAsync(id);
        }

        public async Task<IEnumerable<GearImage>> GetImages()
        {
            return await context.GearImages.ToListAsync();
        }

        public async Task UpdateImage(GearImage image)
        {
            context.GearImages.Update(image);
            await context.SaveChangesAsync();
        }
        public async Task CreateImage(GearImage newImage)
        {
            await context.GearImages.AddAsync(newImage);
            await context.SaveChangesAsync();
        }

        public async Task DeleteImage(GearImage image)
        {
            context.GearImages.Remove(image);
            await context.SaveChangesAsync();
            
        }
        public void RejectChanges()
        {
            context.RejectChanges();
        }

        public Task<PageResult<GearImage>> ListImages(int page, int pageSize)
        {
            return context.GearImages.GetPagedAsync(page, pageSize);
        }

        public Task<PageResult<GearImage>> SearchImages(string term, int page)
        {
            throw new NotImplementedException();
        }
    }
}
