using Microsoft.EntityFrameworkCore;
using PeopleSearch.Models;

namespace PeopleSearch.Data
{
    public class PeopleSearchDbContext : DbContext
    {
        public PeopleSearchDbContext(DbContextOptions<PeopleSearchDbContext> options) : base(options)
        {
        }

        public DbSet<People> Peoples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>().ToTable("People");
        }
    }
}
