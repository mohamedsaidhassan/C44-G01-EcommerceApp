using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_Domain.Entities.Products;

namespace E_Commerce_Service.MappingFiles
{
    internal class Productprofile:Profile
    {
        public Productprofile() 
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(d => d.PBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.Type, o => o.MapFrom(s => s.ProductType.Name));

            CreateMap<ProductBrand, BrandResponse>();
            CreateMap<ProductType,TypeResponse>();
                
        }
    }
}
