using Microsoft.AspNetCore.Mvc;
using ProductPrice.Models.Domain;
using ProductPrice.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductPrice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductPriceController : ControllerBase
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new Product(articleNr: "ABC123"),
            new Product(articleNr: "BCA123"),
            new Product(articleNr: "AAA123"),
            new Product(articleNr: "BBB123"),
            new Product(articleNr: "CCC123")
        };

        //GET /api/productprice?products=ABC123,BCA321,AAA123,BBB123
        [HttpGet("{articleNr}")]
        public ActionResult<ProductDto> Get(string articleNr)
        {
            var founfProduct = Products.FirstOrDefault(x => x.ArticleNr == articleNr);

            if (founfProduct is null)
            {
                return NotFound();

            }

            foreach (var product in Products)
            {
                var item = new Random();
                product.RandomPrice = item.Next();
            };

            var dto = new ProductDto
            {
                ArticleNr = founfProduct.ArticleNr,
                RandomPrice = founfProduct.RandomPrice
            };


        }



    }
}
