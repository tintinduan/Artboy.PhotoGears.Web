using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Artboy.PhotoGears.Models
{
    public class EFMountRepository : IGenericRepository<Mount>
    {
        private PhotoGearsDbContext context;

        public string Token { get ; set ; }

        public EFMountRepository(PhotoGearsDbContext context)
        {
            this.context = context;
        }
        public async Task<PageResult<Mount>> ListAllAsync(int page, int pageSize)
        {
            var result = await context.Mounts.GetPagedAsync(page, pageSize);
            return result;
        }
        public async Task<Mount> GetOneAsync(long id)
        {
            return await context.Mounts.FindAsync(id);
        }

        public async Task<IEnumerable<Mount>> GetAllAsync()
        {
            return await context.Mounts.ToListAsync();
        }
      
        public async Task UpdateOneAsync(Mount mount)
        {
            context.Mounts.Update(mount);
            await context.SaveChangesAsync();
        }
        public async Task CreateNewAsync(Mount newMount)
        {
            await context.Mounts.AddAsync(newMount);
            await context.SaveChangesAsync();
        }

        public async Task DeleteOneAsync(Mount mount)
        {
           context.Mounts.Remove(mount);
           await context.SaveChangesAsync();
        }
        public void RejectChanges()
        {
            context.RejectChanges();
        }

        public async Task<PageResult<Mount>> SearchAnyAsync(string term, int page)
        {
            return await context.Mounts.Where(c => c.Name.Contains(term))
                    .GetPagedAsync(page, 10);
        }
        public async Task<long> AddNewAsync(Mount newItem)
        {
            var result = await context.Mounts.AddAsync(newItem);
            await context.SaveChangesAsync();
            return result.Entity.MountId;
        }
    }
}
