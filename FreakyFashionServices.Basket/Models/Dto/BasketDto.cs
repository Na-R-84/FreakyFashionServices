using System.Collections.Generic;

namespace FreakyFashionServices.Basket.Models.Dto
{
    public class BasketDto
    {
        public string Id { get; set; }

        public IList<BasketContent> Items { get; set; }

    }
}

