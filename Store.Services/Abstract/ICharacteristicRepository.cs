using Store.Domain.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Abstract
{
    public interface ICharacteristicRepository
    {
        Task<bool> CreateAsync(CharacteristicDto entity);
        Task<bool> CreateWithListAsync(List<CharacteristicDto> entities);
    }
}
