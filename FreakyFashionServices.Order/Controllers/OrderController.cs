using FreakyFashionServices.Order.Models;
using FreakyFashionServices.Order.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace FreakyFashionServices.Order.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OrderController : ControllerBase
    {

        private readonly ApplicationDbContext _context;


        public OrderController( ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/order
        [HttpPost]
        public async Task<ActionResult<Orders>> OrdersContents(Orders order)
        {
            new HttpRequestMessage(HttpMethod.Get, "http://localhost:61034/basket/" + order.CustomerId);

            var orders = new Orders(
                    customerId: order.CustomerId,
                    firstName: order.FirstName,
                    lastName: order.LastName
                    );

            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();

            return Ok(orders.Id);
        }

    }
}
