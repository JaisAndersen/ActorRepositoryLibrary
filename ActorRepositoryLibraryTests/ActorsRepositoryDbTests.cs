using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActorRepositoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ActorRepositoryLibrary.Tests
{
    [TestClass()]
    public class ActorsRepositoryDbTests
    {
        private const bool useDatabase = true;
        private static IActorsRepository repo;

        [ClassInitialize]
        public static void InitOnce(TestContext context)
        {
            if (useDatabase)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ActorsDbContext>();
                optionsBuilder.UseSqlServer(Db.LocalConnectionString);
                ActorsDbContext dbContext = new(optionsBuilder.Options);    
                dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.Actors");

                repo = new ActorsRepositoryDb(dbContext);
            }
            else
            {
                repo = new ActorsRepositoryList();
            }
        }
        [TestMethod()]
        public void AddTest()
        {
            repo.Add(new Actor { Name = "Brad", BirthYear = 1821 });
            Actor bradPitt = repo.Add(new Actor { Name = "BradPitt", BirthYear = 1974 });
            Assert.IsTrue(bradPitt.Id >= 0);
            IEnumerable<Actor> all = repo.GetActors();
            Assert.AreEqual(2, all.Count());

            Assert.ThrowsException<ArgumentNullException>(
                () => repo.Add(new Actor { Name = null, BirthYear = 1821 }));
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => repo.Add(new Actor { Name = "A", BirthYear = 1821 }));
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => repo.Add(new Actor { Name = "Brad", BirthYear = 1820 }));
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => repo.Add(new Actor { Name = "Brad", BirthYear = 10000}));
        }
    }
}