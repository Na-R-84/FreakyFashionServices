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

        private readonly IHttpClientFactory _clientFactory;
        private readonly ApplicationDbContext _context;

        public OrderController(IHttpClientFactory clientFactory, ApplicationDbContext context)
        {
            _clientFactory = clientFactory;
            _context = context;
        }

        // POST: api/order
        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrders(Orders order)
        {
            new HttpRequestMessage(HttpMethod.Get, "http://localhost:44316/api/basket/" + order.CustomerIdentifier);

            var orders = new Orders(
                    customerIdentifier: order.CustomerIdentifier,
                    firstName: order.FirstName,
                    lastName: order.LastName
                    );

            _context.orders.Add(orders);
            await _context.SaveChangesAsync();

            return Ok(orders.Id);
        }

    }
}
