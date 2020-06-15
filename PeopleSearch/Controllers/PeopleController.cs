using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeopleSearch.Models;

namespace PeopleSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        int milliseconds = 3000;

        private readonly ILogger<PeopleController> _logger;
        private PeopleSearchDbContext Context { get; }

        public PeopleController(ILogger<PeopleController> logger, PeopleSearchDbContext context)
        {
            _logger = logger;
            Context = context;
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<People> Get()
        {
            Thread.Sleep(milliseconds);
            return Context.Peoples.OrderBy(p => p.FirstName).ToList();
        }

        [HttpGet]
        [Route("People/{name}")]
        public IList<People> GetbyName(string name = "")
        {
            Thread.Sleep(milliseconds);

            if (string.IsNullOrEmpty(name))
                return Context.Peoples.OrderBy(p => p.FirstName).ToList();

            return Context.Peoples.Where(p => p.FirstName.Contains(name) || p.LastName.Contains(name)).OrderBy(p => p.FirstName).ToList();
        }
    }
}
