using E_Commerce_service_Abstraction.Service;
using E_Commerce_Shared.DataTransferObjects;
using E_Commerce_Shared.DataTransferObjects.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace E_Commerce_Presentation.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController(IProductService service) : APIBaseController
    {
        [HttpGet("Products")]
        public async Task<ActionResult<PaginatedResult<ProductResponse>>> GetProducts([FromQuery]ProductQueryParameters parameters, CancellationToken cancellationToken = default)
        {
            var response = await  service.GetProductsAsync(parameters, cancellationToken);

            return  Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> Get(int id,CancellationToken cancellationToken = default)
        {
            var response = await service.GetByIdAsync(id,cancellationToken);

            return Ok(response);
        }

        [HttpGet("Brands")]

        public async Task<ActionResult<IEnumerable<BrandResponse>>> GetBrands(CancellationToken cancellationToken = default)
        {
            var response = await service.GetBrandsAsync(cancellationToken);

            return Ok(response);
        }

        [HttpGet("Types")]
       public  async  Task<ActionResult<TypeResponse>> GetTypeByID(int id,CancellationToken cancelltionToken)
        {
            var response = await service.GetByIdAsync(id,cancelltionToken);
                return Ok(response);
        }

    }
}
