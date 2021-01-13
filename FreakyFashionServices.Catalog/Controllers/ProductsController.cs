using FreakyFashionServices.Models.Domain;
using FreakyFashionServices.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Catalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Items = new List<Product>
        {
           new Product(
                id: 1,
                title: "Black T-Shirt",
                description: "Lorem ipsum dolor",
                price: 299,
                availableStock: 12)
        };

        // GET /catalogs/item
        [HttpGet("{item}")]
        public ActionResult <ProductDto> GetItem(string title)
        {
            var foundItem = Items
                .FirstOrDefault(x => x.Title == title);

            if(foundItem is null)
            {
                return NotFound(); // 404 Error
            }
            var dto = new ProductDto
            {
                Id = foundItem.Id,
                Title = foundItem.Title,
                Description = foundItem.Description,
                Price = foundItem.Price,
                AvailableStock = foundItem.AvailableStock
            };
            return dto;

        }
    }
}
