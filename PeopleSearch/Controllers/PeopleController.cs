using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeopleSearch.Data;
using PeopleSearch.Service;

namespace PeopleSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        int milliseconds = 1000;

        private readonly ILogger<PeopleController> _logger;
        private PeopleSearchDbContext Context { get; }
        public IPeopleService PeopleService { get; }

        public PeopleController(ILogger<PeopleController> logger, PeopleSearchDbContext context, IPeopleService peopleService)
        {
            _logger = logger;
            Context = context;
            PeopleService = peopleService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            Thread.Sleep(milliseconds);
            var result = await PeopleService.GetAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("People/{name}")]
        public async Task<IActionResult> GetbyName(string name = "")
        {
            Thread.Sleep(milliseconds);
            var result = await PeopleService.GetbyNameAsync(name);
            return Ok(result);
        }
    }
}
