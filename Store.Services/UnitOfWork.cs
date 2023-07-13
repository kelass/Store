using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Store.Data;
using Store.Services.Abstract;
using Store.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private IProductRepository _productRepository;
        private ILogger<ProductRepository> _loggerProduct;

        public UnitOfWork(ApplicationDbContext db, ILogger<ProductRepository> loggerProduct)
        {
            _db = db;
            _loggerProduct = loggerProduct;
        }
        public IProductRepository Products
        {
            get
            {
                return _productRepository = _productRepository ?? new ProductRepository(_db, _loggerProduct);
            }

        }

        public void Dispose()
        {
            _db.ChangeTracker.Clear();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
