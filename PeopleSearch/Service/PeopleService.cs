using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeopleSearch.Data;
using PeopleSearch.Models;

namespace PeopleSearch.Service
{
    public class PeopleService : IPeopleService
    {
        public PeopleSearchDbContext Context { get; }

        public PeopleService(PeopleSearchDbContext context)
        {
            Context = context;
        }

        public async Task<IList<People>> GetAsync()
        {
            return await Context.Peoples.OrderBy(p => p.FirstName).ToListAsync();
        }

        public async Task<IList<People>> GetbyNameAsync(string name = "")
        {
            if (string.IsNullOrEmpty(name))
                return await GetAsync();

            return await Context.Peoples.Where(p => p.FirstName.Contains(name) || p.LastName.Contains(name)).OrderBy(p => p.FirstName).ToListAsync();
        }
    }
}
