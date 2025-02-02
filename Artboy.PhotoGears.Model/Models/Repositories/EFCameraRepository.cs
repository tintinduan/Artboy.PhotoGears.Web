﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Models.Helpers;

namespace Artboy.PhotoGears.Models
{
    public class EFCameraRepository : IGenericRepository<Camera>
    {
        private PhotoGearsDbContext context;

        public string Token { get ; set ; }

        public EFCameraRepository(PhotoGearsDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Camera>> GetAllAsync()
        {
            return await context.Cameras.Include(c=>c.Images).Include(c=>c.AssociatedLens)
                        .Include(c=>c.LensMount).ToListAsync();
        }
        public async Task<Camera> GetOneAsync(long id)
        {
            return await context.Cameras.Include(c => c.Images).Include(c => c.AssociatedLens)
                        .Include(c => c.LensMount).FirstOrDefaultAsync(c=>c.Id == id);
        }
        public async Task CreateNewAsync(Camera newCamera)
        {
            await context.Cameras.AddAsync(newCamera);
            await context.SaveChangesAsync();
        }
        public async Task UpdateOneAsync(Camera camera)
        {
            context.Cameras.Update(camera);
            await context.SaveChangesAsync();
        }    

        public async Task DeleteOneAsync(Camera camera)
        {
           context.Cameras.Remove(camera);
           await context.SaveChangesAsync();

        }
        public void RejectChanges()
        {
            context.RejectChanges();
        }
        public async Task<PageResult<Camera>> ListAllAsync(int page, int pageSize)
        {
            return await context.Cameras.GetPagedAsync(page, pageSize);
        }

        public Task<PageResult<Camera>> SearchAnyAsync(string term, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<long> AddNewAsync(Camera newItem)
        {
            var result = await context.Cameras.AddAsync(newItem);
            await context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
