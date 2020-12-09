using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Web.Helpers;

namespace Artboy.PhotoGears.Web.Models
{
    public interface ICameraRepository
    {
        Task<PageResult<Camera>> ListCameras(int page, int pageSize);
        Task<IEnumerable<Camera>> GetCameras();
        Task<Camera> GetCamera(long id);
        Task CreateCamera(Camera newCamera);
        Task UpdateCamera(Camera camera);
        Task DeleteCamera(Camera camera);
        Task<PageResult<Camera>> SearchCameras(string term, int page);
        string Token { get; set; }
        void RejectChanges();
    }
}
