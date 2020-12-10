using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Artboy.PhotoGears.Models
{
    public class EFLensRepository : IGenericRepository<Lens>
    {
        private PhotoGearsDbContext context;

        public string Token { get ; set ; }

        public EFLensRepository(PhotoGearsDbContext context)
        {
            this.context = context;
        }

        public async Task<Lens> GetOneAsync(long id)
        {
            return await context.Lenses.Include(c => c.Images)
                        .Include(c => c.LensMount).FirstOrDefaultAsync(c=>c.Id == id);
        }

        public async Task<IEnumerable<Lens>> GetAllAsync()
        {
            return await context.Lenses.Include(c=>c.Images).Include(c=>c.LensMount)
                        .Where(c=>c.IsAttachedToCamera==false).ToListAsync();
        }

        public async Task UpdateOneAsync(Lens lens)
        {
            context.Lenses.Update(lens);
            await context.SaveChangesAsync();
        }
        public async Task  CreateNewAsync(Lens newLens)
        {
            await context.Lenses.AddAsync(newLens);
            await context.SaveChangesAsync();
        }

        public async Task DeleteOneAsync(Lens lens)
        {
           context.Lenses.Remove(lens);
           await context.SaveChangesAsync();

        }
        public void RejectChanges()
        {
            context.RejectChanges();
        }

        public async Task<PageResult<Lens>> ListAllAsync(int page, int pageSize)
        {
           return await context.Lenses.GetPagedAsync(page, pageSize);
        }

        public async Task<PageResult<Lens>> SearchAnyAsync(string term, int page)
        {
            return await context.Lenses.Where(c => c.Model.Contains(term))
                .GetPagedAsync(page, 10);
        }

        public async Task<long> AddNewAsync(Lens newLens)
        {
            var result = await context.Lenses.AddAsync(newLens);
            await context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
