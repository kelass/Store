using Microsoft.AspNetCore.Mvc;
using Store.Domain.DtoModels;
using Store.Services.Abstract;

namespace Store.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacteristicsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CharacteristicsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task Create(CharacteristicDto characteristic)
        {
            await _unitOfWork.Characteristics.CreateAsync(characteristic);
            await _unitOfWork.SaveAsync();
        }
    }
}
