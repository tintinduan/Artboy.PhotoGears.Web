using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Web.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Artboy.PhotoGears.Web.Models
{
    public class EFMountRepository : IMountRepository
    {
        private PhotoGearsDbContext context;

        public string Token { get ; set ; }

        public EFMountRepository(PhotoGearsDbContext context)
        {
            this.context = context;
        }
        public async Task<PageResult<Mount>> ListMounts(int page, int pageSize)
        {
            var result = await context.Mounts.GetPagedAsync(page, pageSize);
            return result;
        }
        public async Task<Mount> GetMount(int id)
        {
            return await context.Mounts.FindAsync(id);
        }

        public async Task<IEnumerable<Mount>> GetMounts()
        {
            return await context.Mounts.ToListAsync();
        }
      
        public async Task UpdateMount(Mount mount)
        {
            context.Mounts.Update(mount);
            await context.SaveChangesAsync();
        }
        public async Task CreateMount(Mount newMount)
        {
            await context.Mounts.AddAsync(newMount);
            await context.SaveChangesAsync();
        }

        public async Task DeleteMount(Mount mount)
        {
           context.Mounts.Remove(mount);
           await context.SaveChangesAsync();
        }
        public void RejectChanges()
        {
            context.RejectChanges();
        }

        public async Task<PageResult<Mount>> SearchMounts(string term, int page)
        {
            return await context.Mounts.Where(c => c.Name.Contains(term))
                    .GetPagedAsync(page, 10);
        }
    }
}
