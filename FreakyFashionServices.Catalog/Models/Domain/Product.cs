namespace FreakyFashionServices.Models.Domain
{
     class Product
    {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public int Price { get; }
        public int AvailableStock { get; }

        public Product(int id, string title, string description, int price, int availableStock)
        {
            Id= id;
            Title = title;
            Description = description;
            Price = price;
            AvailableStock = availableStock;
        }
    }
}