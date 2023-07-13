using Store.Domain.DtoModels;
using Store.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Repositories
{
    public class CharacteristicRepository : ICharacteristicRepository
    {
        public Task<bool> Create(CharacteristicDto entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> CreateWithList(List<CharacteristicDto> entities)
        {
            throw new NotImplementedException();
        }
    }
}
