using APITest.Models;
using APITest.Services;
using Microsoft.AspNetCore.Mvc;

namespace APITest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdcutsController : Controller
    {
        private readonly IProductService _service;

        public ProdcutsController(IProductService service)
        {
            _service = service;
        }

        //GET api/Products
        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            var items = _service.GetAllProducts();
            return Ok(items);
        }

        //GET api/Product/4
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductbyId(int id)
        {
            var item = _service.GeProductById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }


        //POST api/Product
        [HttpPost]
        public ActionResult AddProduct([FromBody] Product value)
        {

            var item = _service.AddProduct(value);
            return CreatedAtAction("GetProductbyId", new { id = item.Id }, item);
        }

        //DELETE api/Product/4
        [HttpDelete("{id}")]
        public ActionResult RemoveProduct(int id)
        {
            var item = _service.GeProductById(id);

            if (item == null)
            {
                return NotFound();
            }

            _service.RemoveProduct(id);
            return Ok(item);
        }
    }
}
