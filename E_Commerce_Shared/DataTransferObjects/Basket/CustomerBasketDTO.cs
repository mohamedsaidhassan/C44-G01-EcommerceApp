using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Shared.DataTransferObjects.Basket
{
    public  class CustomerBasketDTO
    {
        public string Id { get; set; }

        public ICollection<BasketItemDTO> Items { get; set; } = new List<BasketItemDTO>();
    }

    public class BasketItemDTO
    {
#nullable disable
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
    }
}
