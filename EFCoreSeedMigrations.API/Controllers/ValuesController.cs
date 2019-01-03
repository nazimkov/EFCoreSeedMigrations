using EFCoreSeedMigrations.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreSeedMigrations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ProductsDbContext _context;

        public ValuesController(ProductsDbContext context)
        {
            _context = context;
            _context.Database.Migrate();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_context.Products.ToArray());
        }
    }
}