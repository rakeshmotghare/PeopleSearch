using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleSearch.Models;

namespace PeopleSearch.Service
{
    public class PeopleService
    {
        public PeopleSearchDbContext Context { get; }

        public PeopleService(PeopleSearchDbContext context)
        {
            Context = context;
        }

        public IList<People> GetPeoples()
        {
            return Context.Peoples.OrderBy(p => p.FirstName).ToList();
        }

        public IList<People> GetPeoples(string name)
        {
            return Context.Peoples.Where(p => name.Contains(p.FirstName) || name.Contains(p.LastName)).ToList();
        }
    }
}
