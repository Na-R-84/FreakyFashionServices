namespace ProductPrice.Models.Domain
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string articleNr, int price)
        {
            ArticleNr = articleNr;
            Price = price;
        }

        public int Price { get; set; }
        public string ArticleNr { get; set; }

    }



}
