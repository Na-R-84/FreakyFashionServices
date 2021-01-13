using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Basket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketsController : ControllerBase
    {
        private static readonly List<Basket> Baskets = new List<Basket>
        {
            new  Basket
            {

            }
        };

        private readonly ILogger<BasketsController> _logger;

        public BasketsController(ILogger<BasketsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{name}")]
        public BasketDto Getbasket(string name)
        {
            
        }
    }
}
