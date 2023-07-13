using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Data;
using Store.Domain.DbModels;
using Store.Domain.DtoModels;
using Store.Services.Abstract;

namespace Store.Services.Repositories
{
    public class CharacteristicRepository : ICharacteristicRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public CharacteristicRepository(ApplicationDbContext db, ILogger<CharacteristicRepository> logger, IMapper mapper)
        {
            _db = db;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<bool> CreateAsync(CharacteristicDto entity)
        {
            Characteristic? getById = await _db.Characteristics.FirstOrDefaultAsync(c=>c.Id == entity.Id);
            if (getById == null)
            {
                Characteristic product = _mapper.Map<Characteristic>(entity);
                await _db.AddAsync(product);
                _logger.LogInformation("Characteristic added to db");
                return true;
            }

            _logger.LogError("Characteristic not added to db");
            return false;
        }
        public Task<bool> CreateWithListAsync(List<CharacteristicDto> entities)
        {
            throw new NotImplementedException();
        }
    }
}
