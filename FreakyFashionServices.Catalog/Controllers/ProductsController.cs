using FreakyFashionServices.Catalog.Models;
using FreakyFashionServices.Models.Domain;
using FreakyFashionServices.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreakyFashionServices.Catalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public ApplicationDbContext _context { get; }
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET /api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProductItems()
        {
            return _context.Products;
        }


        // GET /api/products/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            //var foundProducts = _context.Products.FirstOrDefault(x => x.Id == id);
            var foundProducts = await _context.Products.FindAsync(id);

            if (foundProducts is null)
            {
                return NotFound();
            }

            var dto = new ProductDto
            {
                Id = foundProducts.Id,
                Title = foundProducts.Title,
                Description = foundProducts.Description,
                Price = foundProducts.Price,
                AvailableStock = foundProducts.AvailableStock,
                ArticleNr= foundProducts.ArticleNr
            };
            return Ok(dto); // 200
        }


    }
}
