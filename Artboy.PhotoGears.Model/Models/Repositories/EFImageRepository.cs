using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Artboy.PhotoGears.Models
{
    public class EFImageRepository : IGenericRepository<GearImage>
    {
        private PhotoGearsDbContext context;

        public string Token { get ; set ; }

        public EFImageRepository(PhotoGearsDbContext context)
        {
            this.context = context;
        }
        
        public async Task<GearImage> GetOneAsync(long id)
        {
            return await context.GearImages.FindAsync(id);
        }

        public async Task<IEnumerable<GearImage>> GetAllAsync()
        {
            return await context.GearImages.ToListAsync();
        }

        public async Task UpdateOneAsync(GearImage image)
        {
            context.GearImages.Update(image);
            await context.SaveChangesAsync();
        }
        public async Task CreateNewAsync(GearImage newImage)
        {
            await context.GearImages.AddAsync(newImage);
            await context.SaveChangesAsync();
        }

        public async Task DeleteOneAsync(GearImage image)
        {
            context.GearImages.Remove(image);
            await context.SaveChangesAsync();
            
        }
        public void RejectChanges()
        {
            context.RejectChanges();
        }

        public async Task<PageResult<GearImage>> ListAllAsync(int page, int pageSize)
        {
            return await context.GearImages.GetPagedAsync(page, pageSize);
        }

        public Task<PageResult<GearImage>> SearchAnyAsync(string term, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<long> AddNewAsync(GearImage newItem)
        {
            var result = await context.GearImages.AddAsync(newItem);
            await context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
