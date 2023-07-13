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
        Task<bool> Create(CharacteristicDto entity);
        Task<bool> CreateWithList(List<CharacteristicDto> entities);
    }
}
