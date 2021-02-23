namespace FreakyFashionServices.Basket.Models.Domain
{
    public class BasketContent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
