namespace FreakyFashionServices.Models.Domain
{
     public class Product
    {
        public int Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public int Price { get; protected set; }
        public string ArticleNr { get; set; }
        public int AvailableStock { get; protected set; }

        public Product()
        { }
        public Product(int id, string title, string description, int price,string articleNr, int availableStock)
        {
            Id= id;
            Title = title;
            Description = description;
            Price = price;
            ArticleNr = articleNr;
            AvailableStock = availableStock;
            
        }
    }
}