using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Web.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Artboy.PhotoGears.Web.Models
{
    public class EFAccessoryRepository : IAccessoryRepository
    {
        private PhotoGearsDbContext context;

        public string Token { get ; set ; }

        public EFAccessoryRepository(PhotoGearsDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Accessory>> GetAccessories()
        {
            return await context.Accessories.Include(c=>c.Images)
                        .ToListAsync();
        }

        public async Task<Accessory> GetAccessory(long id)
        {
            return await context.Accessories.FindAsync(id);
        }

 
        public async Task UpdateAccessory(Accessory accessory)
        {
            context.Accessories.Update(accessory);
            await context.SaveChangesAsync();
        }

        public async Task CreateAccessory(Accessory newAccessory)
        {
            await context.Accessories.AddAsync(newAccessory);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAccessory(Accessory accessory)
        {
            context.Accessories.Remove(accessory);
            await context.SaveChangesAsync();
        }
        public void RejectChanges()
        {
            context.RejectChanges();
        }

        public Task<PageResult<Accessory>> SearchAccessories(string term, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<PageResult<Accessory>> ListAccessories(int page, int pageSize)
        {
            return await context.Accessories.GetPagedAsync(page, pageSize);
        }
    }
}
