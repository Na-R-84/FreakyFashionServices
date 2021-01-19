using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Order.Models
{
    public class Orders
    {
        public Orders()
        {
        }
        public Orders(string customerIdentifier, string firstName, string lastName)
        {
            CustomerIdentifier = customerIdentifier;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; set; }
        public string CustomerIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
