using FreakyFashionServices.API_Gateway.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashionServices.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {

        private readonly IHttpClientFactory _clientFactory;

        public GatewayController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // GET api/gateway

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            // GET api/prodoct
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:49413/catalog");

            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var serializedProduct = await response.Content.ReadAsStringAsync();

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var products = JsonSerializer.Deserialize<IEnumerable<ProductDto>>(serializedProduct, serializeOptions);

            var articleNumberList = "";

            foreach (var product in products)
            {
                if (String.IsNullOrEmpty(articleNumberList))
                    articleNumberList += product.ArticleNr;
                else
                    articleNumberList += "," + product.ArticleNr;
            }

            // Get api/productprice
            request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:63992/productprice" + "?products=" + articleNumberList);

            request.Headers.Add("Accept", "application/json");

            response = await client.SendAsync(request);

            var serializedPrice = await response.Content.ReadAsStringAsync();

            var prices = JsonSerializer.Deserialize<IEnumerable<PriceDto>>(serializedPrice, serializeOptions);

            foreach (var item in prices)
            {
                var product = products.FirstOrDefault(x => x.ArticleNr == item.ArticleNr);

                product.Price = item.Price;
            }

            return products;
        }

        // PUT gateway/id
        [HttpPut("{id}")]
        public async Task<IActionResult> AddToBasket(string id, List<ProductDto> items)
        {
            var client = _clientFactory.CreateClient();

            var serialisedBasket = JsonSerializer.Serialize(items);

            var request = new HttpRequestMessage(HttpMethod.Put, "https://localhost:61034/basket/" + id);

            request.Headers.Add("Accept", "application/json");

            request.Content = new StringContent(serialisedBasket, Encoding.UTF8, "application/json");

            await client.SendAsync(request);

            return NoContent();  // 204 No Content                        
        }

        // POST /gateway
        [HttpPost]
        public async Task<IActionResult> CompleteOrder(OrderDto order)
        {
            var client = _clientFactory.CreateClient();

            var serialisedOrder = JsonSerializer.Serialize(order);

            // api/order
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:49410/order/");

            request.Headers.Add("Accept", "application/json");

            request.Content = new StringContent(serialisedOrder, Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);

            var orderId = await response.Content.ReadAsStringAsync();

            return Ok(orderId);
        }

    }
}
