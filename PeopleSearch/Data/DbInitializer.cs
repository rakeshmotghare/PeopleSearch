using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleSearch.Models;

namespace PeopleSearch.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PeopleSearchDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            if (dbContext.Peoples.Any())
                return;

            var peoples = new People[]
            {
                new People{ FirstName="James", LastName="Butt", Age=20, Address="6649 N Blue Gum St	New Orleans	Orleans	LA	70116", Interest="Interest1", ImageUrl="assets/images/doraemon1.png" },
                new People{ FirstName="Josephine", LastName="Darakjy", Age=33, Address="4 B Blue Ridge Blvd	Brighton	Livingston	MI	48116", Interest="Interest2", ImageUrl="assets/images/picture-thumb.png" },
                new People{ FirstName="Art", LastName="Venere", Age=50, Address="8 W Cerritos Ave #54	Bridgeport	Gloucester	NJ	8014", Interest="Interest2", ImageUrl="assets/images/pokemon.png" },
                new People{ FirstName="John", LastName="Doe", Age=23, Address="120 jefferson st.,Riverside, NJ, 08075", Interest="Interest2", ImageUrl="assets/images/pokemon1.png" },
                new People{ FirstName="Jack", LastName="McGinnis", Age=30, Address="220 hobo Av.,Phila, PA,09119", Interest="Interest22", ImageUrl="assets/images/doraemon1.png" },
                new People{ FirstName="John", LastName="Da Man", Age=30, Address="Repici,120 Jefferson St.,Riverside, NJ,08075", Interest="Interest23", ImageUrl="assets/images/sonic.png" },
                new People{ FirstName="Stephen", LastName="", Age=40, Address="Blankman,,SomeTown, SD, 00298", Interest="Interest12", ImageUrl="assets/images/sinbacartoon.png" }
            };

            dbContext.Peoples.AddRange(peoples);
            dbContext.SaveChanges();
        }
    }
}
