using E_Commerce_service_Abstraction.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_Shared.DataTransferObjects.Basket;

namespace E_Commerce_Presentation.API.Controllers
{
    public class BasketController(IBasketService basketService):APIBaseController
    {
        [HttpPost]
        public async Task<ActionResult<CustomerBasketDTO>> CreateBasket(CustomerBasketDTO basketDTO, CancellationToken cancellationToken = default)
        {
            var basket = await basketService.CreateOrUpdateBasketAsync(basketDTO, cancellationToken);
            return Ok(basket);
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketByID(string id,CancellationToken cancellationToken = default)
        {
            var basket = await basketService.GetBasketByIDAsync(id,cancellationToken);
            return Ok(basket);
        }

        [HttpDelete]

        public async Task<ActionResult> Delete(string id)
        {
            await basketService.DeleteBasketAsync(id);
            return NoContent();
        }

    }
}
