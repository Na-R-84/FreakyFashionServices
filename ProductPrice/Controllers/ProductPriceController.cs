using Microsoft.AspNetCore.Mvc;
using ProductPrice.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductPrice.Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    public class ProductPriceController : ControllerBase
    {


        //GET /api/productprice?products=ABC123,BCA321,AAA123,BBB123
        [HttpGet("{articleNr}")]
        public IEnumerable<Product> Get(string products)
        {
            var productList = products.Split(',').ToList();

            List<Product> response = new List<Product>();
            Random itme = new Random();

            foreach (var item in productList)
            {
                response.Add(new Product() { ArticleNr = item, Price = itme.Next(29, 999) });
            }

            return response;
        }



    }
}
