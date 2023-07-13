using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Domain.DbModels;
using Store.Domain.DtoModels;
using Store.Services;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
            List<Product> products = await _unitOfWork.Products.Select();
            _unitOfWork.Dispose();
            return products;
        }

        [HttpPost]
        public async Task Create(ProductDto entity)
        {
            await _unitOfWork.Products.Create(entity);
            await _unitOfWork.Save();

        }

        [HttpDelete]
        public async Task Delete(Guid Id)
        {
            await _unitOfWork.Products.Delete(Id);
            await _unitOfWork.Save();
        }
    }
}
