using AutoMapper;
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
        private readonly IMapper _mapper;

        private IProductRepository _productRepository;
        private ICharacteristicRepository _characteristicRepository;

        private ILogger<ProductRepository> _loggerProduct;
        private ILogger<CharacteristicRepository> _loggerCharacteristic;

        public UnitOfWork(ApplicationDbContext db,
            ILogger<ProductRepository> loggerProduct,
            ILogger<CharacteristicRepository> loggerCharacteristic,
            IMapper mapper)
        {
            _db = db;
            _loggerProduct = loggerProduct;
            _loggerCharacteristic = loggerCharacteristic;
            _mapper = mapper;
        }

        public IProductRepository Products
        {
            get
            {
                return _productRepository = _productRepository ?? new ProductRepository(_db, _loggerProduct, _mapper);
            }

        }
        public ICharacteristicRepository Characteristics
        {
            get
            {
                return _characteristicRepository = _characteristicRepository ?? new CharacteristicRepository(_db, _loggerCharacteristic, _mapper);
            }

        }

        public void Dispose()
        {
            _db.ChangeTracker.Clear();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
