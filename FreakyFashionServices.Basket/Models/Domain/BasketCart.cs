namespace FreakyFashionServices.Basket.Models.Domain
{
    public class BasketCart
    {
        public string Id { get; set; }
        public string ProductTitle { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }

        public BasketCart()
        {
        }
      
        public BasketCart(string id, string productTitle, int unitPrice, int quantity)
        {
            Id = id;
            ProductTitle = productTitle;
            UnitPrice = unitPrice;
            Quantity = quantity;

        }
    }
}
