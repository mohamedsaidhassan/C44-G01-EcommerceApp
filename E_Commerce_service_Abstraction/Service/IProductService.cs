using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_Shared.DataTransferObjects;
using E_Commerce_Shared.DataTransferObjects.Products;
namespace E_Commerce_service_Abstraction.Service
{
    public interface IProductService
    {
        Task<ProductResponse?> GetByIdAsync(int id,CancellationToken cancellationToken);

        public Task<PaginatedResult<ProductResponse>> GetProductsAsync(ProductQueryParameters parameters, CancellationToken cancellationToken);

        Task<IEnumerable<BrandResponse>> GetBrandsAsync(CancellationToken cancellationToken);

        Task<IEnumerable<TypeResponse>> GetTypeAsync(CancellationToken cancellationToken);
    }
}
