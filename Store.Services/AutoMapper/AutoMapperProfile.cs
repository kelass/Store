using AutoMapper;
using Store.Domain.DbModels;
using Store.Domain.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.AutoMapper
{
    internal class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CharacteristicDto, Characteristic>();
            CreateMap<ProductDto, Product>();
        }
    }
}
