using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearch.Data;
using PeopleSearch.Models;
using PeopleSearch.Service;

namespace PeopleSearch.Test
{
    [TestClass]
    public class PeopleSearchTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var options = new DbContextOptionsBuilder<PeopleSearchDbContext>()
            .UseInMemoryDatabase(databaseName: "PeopleListDatabase")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new PeopleSearchDbContext(options))
            {
                context.Peoples.Add(new People{ FirstName="Jone", LastName="Sams", Age=22, Address="TestAddress1", Interest= "TestInterest1" });
                context.Peoples.Add(new People{ FirstName="Laura", LastName="John", Age=32, Address="TestAddress2", Interest= "TestInterest2" });
                context.Peoples.Add(new People{ FirstName="Sam", LastName="Kite", Age=23, Address="TestAddress3", Interest= "TestInterest3" });
                context.SaveChanges();
            }

            using (var context = new PeopleSearchDbContext(options))
            {
                PeopleService peopleService = new PeopleService(context);
                var peopleList = peopleService.GetAsync().Result;
                Assert.AreEqual(3, peopleList.Count);

                peopleList = peopleService.GetbyNameAsync("Jo").Result;
                Assert.AreEqual(2, peopleList.Count);
            }
        }
    }
}
