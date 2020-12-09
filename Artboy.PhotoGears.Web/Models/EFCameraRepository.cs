using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Web.Helpers;

namespace Artboy.PhotoGears.Web.Models
{
    public class EFCameraRepository : ICameraRepository
    {
        private PhotoGearsDbContext context;

        public string Token { get ; set ; }

        public EFCameraRepository(PhotoGearsDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Camera>> GetCameras()
        {
            return await context.Cameras.Include(c=>c.Images)
                        .ToListAsync();
        }
        public async Task<Camera> GetCamera(long id)
        {
            return await context.Cameras.FindAsync(id);
        }
        public async Task CreateCamera(Camera newCamera)
        {
            await context.Cameras.AddAsync(newCamera);
            await context.SaveChangesAsync();
        }
        public async Task UpdateCamera(Camera camera)
        {
            context.Cameras.Update(camera);
            await context.SaveChangesAsync();
        }    

        public async Task DeleteCamera(Camera camera)
        {
           context.Cameras.Remove(camera);
           await context.SaveChangesAsync();

        }
        public void RejectChanges()
        {
            context.RejectChanges();
        }

        public async Task<PageResult<Camera>> ListCameras(int page, int pageSize)
        {
            return await context.Cameras.GetPagedAsync(page, pageSize);
        }

        public Task<PageResult<Camera>> SearchCameras(string term, int page)
        {
            throw new NotImplementedException();
        }
    }
}
