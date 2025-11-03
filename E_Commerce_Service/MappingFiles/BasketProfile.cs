using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_Domain.Entities.Basket;
using E_Commerce_Shared.DataTransferObjects.Basket;

namespace E_Commerce_Service.MappingFiles
{
    public class BasketProfile : Profile
    {
       public BasketProfile() 
        {
            CreateMap<BasketItem, BasketItemDTO>()
                .ReverseMap();

            CreateMap<CustomerBasketDTO, CustomerBasketDTO>()
                .ReverseMap();
        }

    }
}
