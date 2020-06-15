using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PeopleSearch.Models
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
