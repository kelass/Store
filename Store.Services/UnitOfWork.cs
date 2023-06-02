using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        private bool _disposed = false;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }
        public IProductRepository Products
        {
            get
            {
                return _productRepository = _productRepository ?? new ProductRepository(_db);
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
