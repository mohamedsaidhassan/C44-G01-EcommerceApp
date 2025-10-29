using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Shared.DataTransferObjects.Products
{
    public class ProductQueryParameters
    {
        private const int maxPageSize = 10;
        private const int defaultPageSize = 5;
        public int? BrandId {get; set;}
        public int? TypeId { get; set; }

        public string? Search { get; set;}

        public ProductSortoptions sort { get; set; }

        public int pagesize;
        public int Pagesize
        {
            get { return pagesize; }
            set { pagesize = (value > maxPageSize) ? maxPageSize : (value<defaultPageSize)? defaultPageSize:value; }
        }
        public int pageindex { get; set; } = 1;

    }

    public enum ProductSortoptions
    {
        NameAscending=1,
        NameDescending=2,
        PriceAscending=3,
        PriceDescending=4,
           
    }
}
