using Microsoft.AspNetCore.Mvc;
using Store.Domain.DbModels;
using Store.Domain.DtoModels;
using Store.Services.Abstract;

namespace Store.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Select()
        {
            List<Product> products = await _unitOfWork.Products.SelectAsync();
            _unitOfWork.Dispose();
            return products;
        }

        [HttpPost]
        public async Task Create(ProductDto entity)
        {
            await _unitOfWork.Products.CreateAsync(entity);
            await _unitOfWork.SaveAsync();

        }

        [HttpDelete]
        public async Task Delete(Guid Id)
        {
            await _unitOfWork.Products.Delete(Id);
            await _unitOfWork.SaveAsync();
        }
    }
}
