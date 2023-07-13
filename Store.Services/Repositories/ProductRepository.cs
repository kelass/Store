using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Store.Data;
using Store.Domain.DbModels;
using Store.Domain.DtoModels;
using Store.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, ILogger<ProductRepository> logger, IMapper mapper)
        {
            _db = db;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<bool> CreateAsync(ProductDto entity)
        {
            var getById = await _db.Products.FirstOrDefaultAsync(pr => pr.Id == entity.Id);

            if (getById == null)
            {
                Product product = _mapper.Map<Product>(entity);
                await _db.AddAsync(product);
                _logger.LogInformation("Product added to db");
                return true;
            }
            _logger.LogError("Product not added to db");
            return false;

        }

        public async Task<bool> Delete(Guid id)
        {
            Product product = await _db.Products.FirstOrDefaultAsync(pr => pr.Id == id);

            if (product != null)
            {
                _db.Products.Remove(product);
                _logger.LogInformation("Product deleted from db");
                return true;
            }
            _logger.LogError("Product not deleted from db");
            return false;


        }
        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _db.Products.FirstOrDefaultAsync(pr => pr.Id == id);
        }

        public async Task<List<Product>> SelectAsync()
        {
            return await _db.Products.Include(p => p.Characteristics).ToListAsync();
        }
    }
}
