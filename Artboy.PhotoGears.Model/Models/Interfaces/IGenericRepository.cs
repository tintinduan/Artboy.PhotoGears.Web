using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artboy.PhotoGears.Models.Helpers;
namespace Artboy.PhotoGears.Models
{
    public interface IGenericRepository<T> where T:class
    {
        Task<PageResult<T>> ListAllAsync(int page, int pageSize);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetOneAsync(long id);
        Task CreateNewAsync(T newItem);
        Task<long> AddNewAsync(T newItem);
        Task UpdateOneAsync(T item);
        Task DeleteOneAsync(T item);
        Task<PageResult<T>> SearchAnyAsync(string term, int page);
        string Token { get; set; }
        void RejectChanges();
    }
}
