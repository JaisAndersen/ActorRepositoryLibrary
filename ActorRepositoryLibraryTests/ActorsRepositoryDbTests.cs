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
            Assert.Fail();
        }
    }
}