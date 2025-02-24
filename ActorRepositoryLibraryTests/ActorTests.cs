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
    public class ActorTests
    {
        [TestMethod()]
        public void NameTest()
        {
            Actor actor = new Actor();
            Assert.ThrowsException<ArgumentNullException>(
                () => actor.Name = null);
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => actor.Name = "123");
        }
        [TestMethod()]
        public void BirthYearTest()
        {
            Actor actor = new Actor();
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => actor.BirthYear = 1820);
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => actor.BirthYear = 10000);
        }
        [TestMethod()]
        public void ToStringTest()
        {
            Actor actor = new Actor();
            actor.Id = 1;
            actor.Name = "ActorName";
            actor.BirthYear = 2000;
            string result = actor.ToString();
            Assert.AreEqual("Id: 1, Name: ActorName, Birth Year: 2000", result);
        }
    }
}