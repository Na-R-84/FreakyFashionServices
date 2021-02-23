namespace FreakyFashionServices.Basket.Models.Dto
{
    public class BasketDto
    {
        public int Id { get; set; }
        public string BasketId { get; set; }
        public string ProductTitle { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}

