using FreakyFashionServices.Basket.Extensions;
using FreakyFashionServices.Basket.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashionServices.Basket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IDistributedCache cache;

        public BasketController(IDistributedCache cache)
        {
            this.cache = cache;
        }


        //PUT /api/basket/{id}

        [HttpPut("{id}")]
        public async Task<IActionResult> CreateOrReplaceBasket(string id, [FromBody] BasketDto basket)
        {
            await cache.SetRecordAsync(id, basket);

            return NoContent();  // 204 No Content
        }

        //public async Task<IActionResult> CreateOrReplaceBasket(string id, BasketDto basket)
        //{
        //    var options = new DistributedCacheEntryOptions();

        //    options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);
        //    options.SlidingExpiration = TimeSpan.FromSeconds(60);

        //    var serializedData = JsonSerializer.Serialize(basketDto);

        //    await _cache.SetStringAsync(
        //        basketDto.Id,
        //        serializedData,
        //        options);

        //    return Ok();
        //}



        [HttpPost]
        public async Task<IActionResult> CreateBasket(BasketDto createBasketDto)
        {
            await cache.SetRecordAsync(createBasketDto.Id, createBasketDto);
            return Ok(); //200 ok
        }

        // GET /api/basket/{id}

        //[HttpGet("{Id}")]
        //public async Task<BasketDto> GetBasketById(string id)
        //{
        //    var serializedData = await cache.GetStringAsync(id);
        //    var basket = JsonSerializer.Deserialize<BasketDto>(serializedData);

        //    return basket; // 200 Ok
        //}



        [HttpGet("{Id}")]
        public async Task<string> GetBasket(string Id)
        {
            var cacheKey = Id;
            var Basket = cache.GetString(cacheKey);
            if (!string.IsNullOrEmpty(Basket))
            {
                return Basket;
            }
            else
            {
                return "Nothing in basket.";
            }

        }

        ///////////////////////////////////////////////////////////////
        ///
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