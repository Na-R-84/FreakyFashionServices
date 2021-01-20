using FreakyFashionServices.Basket.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashionServices.API_Gateway.Basket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IDistributedCache cache;
        public BasketController(IDistributedCache cache)
        {
            this.cache = cache;

        }

        //PUT /api/basket/{id}
        [HttpPut("{id}")]

        public async Task<IActionResult> CreateBasketContents(string id, CartDto cartDto)
        {
            var options = new DistributedCacheEntryOptions();
            var serialized = JsonSerializer.Serialize(cartDto);

            await cache.SetStringAsync(
                cartDto.Id, serialized, options);
            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);
            options.SlidingExpiration = TimeSpan.FromSeconds(60);

            return NoContent();  // 204 No Content
        }



        // GET /api/basket/{id}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasketById(string id)
        {
            var cacheKey = id;
            var existingBasket = cache.GetString(cacheKey);

            if (existingBasket is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(existingBasket); // 200 Ok
            }
        }
        //public async Task<IActionResult> GetBasketById(string id)
        //{
        //    var options = new DistributedCacheEntryOptions();
        //    var serialized = JsonSerializer.Serialize(basketDto);

        //    await cache.SetStringAsync(
        //        basketDto.id, serialized, options);
        //    return Created("", null);  // 201
        //}
    }
}
