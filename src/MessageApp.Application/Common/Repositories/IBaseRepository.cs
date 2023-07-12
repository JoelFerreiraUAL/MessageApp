using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Application.Common.Repositories
{
    public interface IBaseRepository<T,Tkey> where T : class
    {
      Task<List<T>> GetAllAsync();
       Task AddAsync(T entity);
       Task<T> GetByIdAsync(Tkey id);
        Task UpdateAsync(T entity);
       Task DeleteAsync(T entity);


    }
}
