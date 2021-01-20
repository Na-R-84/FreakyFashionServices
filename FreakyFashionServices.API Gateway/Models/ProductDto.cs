namespace FreakyFashionServices.API_Gateway.Models
{
    public class ProductDto
    {
        public int Id { get;  set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public int Price { get;  set; }
        public string ArticleNr { get; set; }
        public int AvailableStock { get;  set; }

    }
}
