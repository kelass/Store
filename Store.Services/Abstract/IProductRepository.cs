using Store.Domain.DbModels;
using Store.Domain.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Abstract
{
    public interface IProductRepository:IBaseRepository<Product>
    {
        Task<bool> Create(ProductDto entity);
    }
}
