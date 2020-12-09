using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Models.Helpers;

namespace Artboy.PhotoGears.Models
{
    public interface ILensRepository
    {
        Task<PageResult<Lens>> ListLenses(int page,int pageSize);
        Task<IEnumerable<Lens>> GetLenses();
        Task<Lens> GetLens(long id);
        Task<long> AddLens(Lens newLens);
        Task CreateLens(Lens newLens);
        Task UpdateLens(Lens lens);
        Task DeleteLens(Lens lens);
        Task<PageResult<Lens>> SearchLenses(string term, int page);
        string Token { get; set; }
        void RejectChanges();
    }
}
