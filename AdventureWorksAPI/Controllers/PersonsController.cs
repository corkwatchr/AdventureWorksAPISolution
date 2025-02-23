using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdventureWorksAPI.Data;
using AdventureWorksAPI.Models;
using System.Threading.Tasks;

namespace AdventureWorksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class PersonsController : ControllerBase
    {
                private readonly AdventureWorksContext _context;

                public PersonsController(AdventureWorksContext context)
        {
                        _context = context;
        }

        [HttpGet]
                public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
                        return await _context.Persons.ToListAsync();
        }
    }
}
