using System.Collections.Generic;

namespace FreakyFashionServices.Basket.Models.Domain
{
    class Basket
    {
        public string BasketId { get; set; }
        public IList<BasketContent> CartContents { get; set; }
    }
}
