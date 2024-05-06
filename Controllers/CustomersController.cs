using Microsoft.AspNetCore.Mvc;
using Middleware.Data;

namespace Middleware.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly Context _context;

        public CustomersController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(_context.Customers.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult UpdateCustomer([FromRoute(Name = "id")] int id)
        {
            throw new Exception();
        }
    }
}