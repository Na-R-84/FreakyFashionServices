using FreakyFashionServices.Order.Models;
using FreakyFashionServices.Order.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FreakyFashionServices.Order.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// Order/{customerId}
        [HttpPost("{customerId}")]
        public async Task<ActionResult> AddCartContents(string customerId, Orders orders)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //HttpResponseMessage response = client.GetAsync("http://localhost:61034/basket/" + customerId).Result;
            //var cartDto = response.Content.ReadAsStringAsync().Result;

            var dto = new Orders
            (
                customerId: orders.CustomerId,
                firstName: orders.FirstName,
                lastName: orders.LastName
            );

            _context.Orders.Add(dto);
            await _context.SaveChangesAsync();

            return Ok(dto.Id);
        }
    }

    //public class OrderController : ControllerBase
    //{

    //    private readonly ApplicationDbContext _context;


    //    public OrderController( ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    // POST: api/order
    //    [HttpPost]
    //    public async Task<ActionResult> OrdersContents(string customerId, Orders order)
    //    {
    //        //new HttpRequestMessage(HttpMethod.Get, "http://localhost:61034/basket/" + customerId);
    //        HttpClient client = new HttpClient();
    //        HttpResponseMessage response = client.GetAsync("http://localhost:61034/basket/" + customerId).Result;

    //        var cart= response.Content.ReadAsStringAsync().Result;
    //        var orders = new Orders(
    //                customerId: order.CustomerId,
    //                firstName: order.FirstName,
    //                lastName: order.LastName
    //                );

    //        _context.Orders.Add(orders);
    //        await _context.SaveChangesAsync();

    //        return Ok(orders.Id);
    //    }


}
