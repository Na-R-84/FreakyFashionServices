namespace FreakyFashionServices.Order.Models
{
    public class Orders
    {
  
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Orders(string customerId, string firstName, string lastName)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
        }
        public Orders()
        {
        }
    }
}
