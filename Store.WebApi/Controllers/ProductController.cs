using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Domain.DbModels;
using Store.Domain.DtoModels;
using Store.Services;
using System.Reflection.Metadata.Ecma335;

namespace Store.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public ProductController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> Select()
        {
          List<Product> products = await _unitOfWork.Products.Select();
            _unitOfWork.Dispose();
            return products;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> Create(ProductDto entity)
        {
            try
            {
                bool product = await _unitOfWork.Products.Create(entity);
                if (product == true)
                {
                    await _unitOfWork.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(Guid Id)
        {
            try
            {
                bool product = await _unitOfWork.Products.Delete(Id);
                if (product == true)
                {
                    await _unitOfWork.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }
    }
}
