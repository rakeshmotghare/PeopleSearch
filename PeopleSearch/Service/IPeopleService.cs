using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleSearch.Data;
using PeopleSearch.Models;

namespace PeopleSearch.Service
{
    public interface IPeopleService
    {
        PeopleSearchDbContext Context { get; }

        Task<IList<People>> GetAsync();
        Task<IList<People>> GetbyNameAsync(string name = "");
    }
}