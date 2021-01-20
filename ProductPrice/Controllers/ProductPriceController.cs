using Microsoft.AspNetCore.Mvc;
using ProductPrice.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductPrice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductPriceController : ControllerBase
    {



        [HttpGet]
        public IEnumerable<Product> Get(string articleNumbers)
        {

            var products = articleNumbers.Split(',').ToList();

            List<Product> articles = new List<Product>();
            Random rnd = new Random();

            foreach (var item in products)
            {
                articles.Add(new Product()
                {
                    ArticleNr = item,
                    Price = rnd.Next(29, 999)
                });
            }
            return articles;

        }
    }
}
