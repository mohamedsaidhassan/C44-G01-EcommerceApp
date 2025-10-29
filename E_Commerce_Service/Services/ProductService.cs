global using AutoMapper;
global using E_Commerce_Domain.Contracts;
global using E_Commerce_service_Abstraction.Service;
global using E_Commerce_Shared.DataTransferObjects.Products;
using E_Commerce_Domain.Entities.Products;
using  E_commerce_Presistance.Repositories;
using E_Commerce_Service.Specifications;
using E_Commerce_Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Service.Services
{
    public class ProductService(IUintofwork uintofwork,IMapper mapper) : IProductService
    {
      

        public async Task<ProductResponse?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await uintofwork.GetRepository<Product,int>().GetByIdAsync(new ProductwithBrandTypeSpec(id), cancellationToken);
            return mapper.Map<ProductResponse>(product);

        }
        public async Task<IEnumerable<BrandResponse>> GetBrandsAsync(CancellationToken cancellationToken)
        {
            var brands = await uintofwork.GetRepository<ProductBrand, int>().GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<BrandResponse>>(brands);
        }

        public async Task<PaginatedResult<ProductResponse>> GetProductsAsync(ProductQueryParameters parameters , CancellationToken cancellationToken)
        {
            var spec = new Specifications.ProductwithBrandTypeSpec(parameters);  
            var products = await uintofwork.GetRepository<Product,int>().GetAllAsync(spec,cancellationToken);
           var products2 =mapper.Map<IEnumerable<ProductResponse>>(products);

            return new(parameters.pageindex, products2.Count(), products2.Count(), products2);
        }

        public async Task<IEnumerable<TypeResponse>> GetTypeAsync(CancellationToken cancellationToken)
        {
            var types = await uintofwork.GetRepository<ProductType, int>().GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<TypeResponse>>(types);
        }


    }
}
