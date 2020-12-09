using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Web.Helpers;

namespace Artboy.PhotoGears.Web.Models
{
    public interface IMountRepository
    {
        Task<PageResult<Mount>> ListMounts(int page, int pageSize);
        Task<IEnumerable<Mount>> GetMounts();
        Task<Mount> GetMount(int id);
        Task CreateMount(Mount newMount);
        Task UpdateMount(Mount mount);
        Task DeleteMount(Mount mount);
        Task<PageResult<Mount>> SearchMounts(string term, int page);
        string Token { get; set; }
        void RejectChanges();

    }
}
