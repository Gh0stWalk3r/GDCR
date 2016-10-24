using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    using System.Collections.Generic;

    using ClassLibrary1;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UnderPopulationTest_IsTrue()
        {
            var rules = new Rules();
            var cell = new Cell();
            Assert.IsTrue(rules.UnderPopulation(cell));
        }

        [TestMethod]
        public void UnderPopulationTest_IsFalse()
        {
            var rules = new Rules();
            var cell = new Cell { IsAlive = false };
            Assert.IsFalse(rules.UnderPopulation(cell));
        }

        [TestMethod]
        public void SurvivalTest_IsTrue()
        {
            var rules = new Rules();
            var cell = new Cell();
            cell.Neighbours.AddRange(new[] { new Cell(), new Cell() });
            Assert.IsTrue(rules.Survival(cell));
        }

        [TestMethod]
        public void SurvivalTest_IsFalse()
        {
            var rules = new Rules();
            var cell = new Cell { IsAlive = false };
            cell.Neighbours.AddRange(new[] { new Cell(), new Cell() });
            Assert.IsFalse(rules.Survival(cell));
        }

        [TestMethod]
        public void OvercrowdingTest_IsTrue()
        {
            var rules = new Rules();
            var cell = new Cell();
            cell.Neighbours.AddRange(new[] { new Cell(), new Cell(), new Cell(), new Cell() });
            Assert.IsTrue(rules.Overcrowd(cell));
        }

        [TestMethod]
        public void OvercrowdingTest_IsFalse()
        {
            var rules = new Rules();
            var cell = new Cell { IsAlive = false };
            cell.Neighbours.AddRange(new[] { new Cell(), new Cell(), new Cell(), new Cell() });
            Assert.IsFalse(rules.Overcrowd(cell));
        }
    }
}
