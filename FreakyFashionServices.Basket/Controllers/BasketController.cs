using FreakyFashionServices.Basket.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashionServices.Basket.Controllers
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

        [HttpPut("{basketId}")]

        public async Task<IActionResult> AddCartContents(string basketId, BasketDto basketDto)
        {
            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);
            options.SlidingExpiration = TimeSpan.FromSeconds(60);

            var serializedData = JsonSerializer.Serialize(basketDto);

            await cache.SetStringAsync(
                basketDto.BasketId,
                serializedData,
                options);

            return Ok();
        }


        // GET /api/basket/{id}

        [HttpGet("{basketId}")]
        public async Task<string> Get(string basketId)
        {
            var cacheKey = basketId;
            var existingBasket = cache.GetString(cacheKey);
            if (!string.IsNullOrEmpty(existingBasket))
            {
                return existingBasket;
            }
            else
            {
                return "Nothing in basket.";
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