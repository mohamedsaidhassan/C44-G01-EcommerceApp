using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_Domain.Entities.Products;

namespace E_Commerce_Service.Specifications
{
    public class ProductwithBrandTypeSpec : BaseSpecifications<Product>
    {
        public ProductwithBrandTypeSpec(ProductQueryParameters parameters) :
            base(p=>(!parameters.BrandId.HasValue || p.BrandId == parameters.BrandId)
                 && (!parameters.TypeId.HasValue|| p.TypeId == parameters.TypeId.Value)
                 && (string.IsNullOrWhiteSpace(parameters.Search) || p.Name.Contains(parameters.Search))
            )
                 
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
            ApplyPagination(parameters.Pagesize, parameters.pageindex);

            SortedDictionary(parameters);
        }

        public void SortedDictionary(ProductQueryParameters parameters)
        {
            switch (parameters.sort)
            {
                case ProductSortoptions.NameAscending:
                    AddorderBy(p=>p.Name);
                    break;
                case ProductSortoptions.NameDescending:
                    AddorderByDesc(p => p.Name);
                    break;
                case ProductSortoptions.PriceAscending:
                    AddorderBy(p => p.Price);
                    break;
                case ProductSortoptions.PriceDescending:
                    AddorderByDesc(p => p.Price);
                    break;

                default:
                    AddorderBy(p => p.Name);
                    break;
            }
        }



        public ProductwithBrandTypeSpec(int id) : base(p=>p.Id==id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}
