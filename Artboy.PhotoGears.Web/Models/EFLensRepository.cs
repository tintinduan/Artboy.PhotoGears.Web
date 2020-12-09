using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Web.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Artboy.PhotoGears.Web.Models
{
    public class EFLensRepository : ILensRepository
    {
        private PhotoGearsDbContext context;

        public string Token { get ; set ; }

        public EFLensRepository(PhotoGearsDbContext context)
        {
            this.context = context;
        }

        public async Task<Lens> GetLens(long id)
        {
            return await context.Lenses.FindAsync(id);
        }

        public async Task<IEnumerable<Lens>> GetLenses()
        {
            return await context.Lenses.Include(c=>c.Images)
                        .ToListAsync();
        }

        public async Task UpdateLens(Lens lens)
        {
            context.Lenses.Update(lens);
            await context.SaveChangesAsync();
        }
        public async Task  CreateLens(Lens newLens)
        {
            await context.Lenses.AddAsync(newLens);
            await context.SaveChangesAsync();
        }

        public async Task DeleteLens(Lens lens)
        {
           context.Lenses.Remove(lens);
           await context.SaveChangesAsync();

        }
        public void RejectChanges()
        {
            context.RejectChanges();
        }

        public async Task<PageResult<Lens>> ListLenses(int page, int pageSize)
        {
           return await context.Lenses.GetPagedAsync(page, pageSize);
        }

        public async Task<PageResult<Lens>> SearchLenses(string term, int page)
        {
            return await context.Lenses.Where(c => c.Model.Contains(term))
                .GetPagedAsync(page, 10);
        }

        public async Task<long> AddLens(Lens newLens)
        {
            var result = await context.Lenses.AddAsync(newLens);
            await context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
