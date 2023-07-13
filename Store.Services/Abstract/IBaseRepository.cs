using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Abstract
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> SelectAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> Delete(Guid id);
    }
}
