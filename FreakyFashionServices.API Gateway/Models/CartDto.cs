using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.API_Gateway.Models
{
    public class CartDto
    {
        public string Id { get; set; }
        public string ProductTitle { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
