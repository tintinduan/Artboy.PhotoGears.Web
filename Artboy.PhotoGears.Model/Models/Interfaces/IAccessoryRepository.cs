using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Models.Helpers;

namespace Artboy.PhotoGears.Models
{
    public interface IAccessoryRepository
    {
        Task<PageResult<Accessory>> ListAccessories(int page, int pageSize);
        Task<IEnumerable<Accessory>> GetAccessories();
        Task<Accessory> GetAccessory(long id);
        Task CreateAccessory(Accessory newAccessory);
        Task UpdateAccessory(Accessory accessory);
        Task DeleteAccessory(Accessory accessory);
        Task<PageResult<Accessory>> SearchAccessories(string term, int page);
        string Token { get; set; }
        void RejectChanges();
    }
}
