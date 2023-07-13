using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository Products { get; }
        ICharacteristicRepository Characteristics { get; }
        Task SaveAsync();

        
    }
}
