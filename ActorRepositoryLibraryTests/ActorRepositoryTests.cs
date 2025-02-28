using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActorRepositoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorRepositoryLibrary.Tests
{
    [TestClass()]   
    public class ActorRepositoryTests
    {
        ActorsRepositoryList repo;
        Actor actor;

        [TestInitialize]
        public void Initialize()
        {
            repo = new ActorsRepositoryList();
            repo.Add(new Actor() { Name = "testActor1", BirthYear = 1984 });
            repo.Add(new Actor() { Name = "testActor2", BirthYear = 1985 });
            repo.Add(new Actor() { Name = "testActor3", BirthYear = 1986 });
            repo.Add(new Actor() { Name = "testActor4", BirthYear = 1987 });
        }
        [TestMethod()]
        public void AddActorTest()
        {
            Actor a = new Actor() { Name = "testActor5", BirthYear = 1999 };
            repo.Add(a);
            Assert.AreEqual(5, repo.GetActors().Count());
            Assert.ThrowsException<ArgumentNullException>(() => repo.Add(null));
        }
        [TestMethod()]
        public void GetActorByIdTest()
        {
            Assert.IsNotNull(repo.GetActorById(1));
            Assert.IsNull(repo.GetActorById(999));
        }
        [TestMethod()]
        public void GetActorsTest()
        {
            IEnumerable<Actor> actors = repo.GetActors();
            Assert.AreEqual(4, actors.Count());
            Assert.AreEqual(actors.First().Name, "testActor1");

            IEnumerable<Actor> filteredActors = repo.GetActors(birthYearBefore: 1985);
            Assert.AreEqual(1, filteredActors.Count());

            IEnumerable<Actor> filteredActors2 = repo.GetActors(birthYearAfter: 1985);
            Assert.AreEqual(2, filteredActors2.Count());

            IEnumerable<Actor> filteredActors3 = repo.GetActors(nameIncludes: "Actor2");
            Assert.AreEqual(1, filteredActors3.Count());
            
            IEnumerable<Actor> sortedActors = repo.GetActors(sortBy: "name");
            Assert.AreEqual(sortedActors.First().Name, "testActor1");

            IEnumerable<Actor> sortedActors2 = repo.GetActors(sortBy: "birthyear");
            Assert.AreEqual(sortedActors2.First().Name, "testActor1");
        }
        [TestMethod()]
        public void RemoveTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => repo.Delete(100));
            Assert.AreEqual(1, repo.Delete(1)?.Id);
            Assert.ThrowsException<ArgumentNullException>(() => repo.Delete(1));
            Assert.AreEqual(3, repo.GetActors().Count());
        }
        [TestMethod()]
        public void UpdateTest()
        {
            Assert.AreEqual(4, repo.GetActors().Count());
            Actor m = new() { Name = "Test", BirthYear = 2021 };
            Assert.ThrowsException<ArgumentNullException>(() => repo.Update(100, m));
            Assert.AreEqual(1, repo.Update(1, m)?.Id);
            Assert.AreEqual(4, repo.GetActors().Count());
        }   
    }
}