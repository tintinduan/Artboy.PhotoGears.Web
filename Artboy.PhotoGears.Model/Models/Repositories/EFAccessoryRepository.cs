using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Artboy.PhotoGears.Models
{
    public class EFAccessoryRepository : IGenericRepository<Accessory>
    {
        private PhotoGearsDbContext context;

        public string Token { get ; set ; }

        public EFAccessoryRepository(PhotoGearsDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Accessory>> GetAllAsync()
        {
            return await context.Accessories.Include(c=>c.Images)
                        .ToListAsync();
        }

        public async Task<Accessory> GetOneAsync(long id)
        {
            return await context.Accessories.Include(c => c.Images)
                        .FirstOrDefaultAsync(c=>c.Id==id);
        }

 
        public async Task UpdateOneAsync(Accessory accessory)
        {
            context.Accessories.Update(accessory);
            await context.SaveChangesAsync();
        }

        public async Task CreateNewAsync(Accessory newAccessory)
        {
            await context.Accessories.AddAsync(newAccessory);
            await context.SaveChangesAsync();
        }

        public async Task DeleteOneAsync(Accessory accessory)
        {
            context.Accessories.Remove(accessory);
            await context.SaveChangesAsync();
        }
        public void RejectChanges()
        {
            context.RejectChanges();
        }

        public Task<PageResult<Accessory>> SearchAnyAsync(string term, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<PageResult<Accessory>> ListAllAsync(int page, int pageSize)
        {
            return await context.Accessories.GetPagedAsync(page, pageSize);
        }

        public async Task<long> AddNewAsync(Accessory newItem)
        {
            var result = await context.Accessories.AddAsync(newItem);
            await context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
