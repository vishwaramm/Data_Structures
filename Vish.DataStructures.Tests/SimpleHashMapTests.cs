using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vish.DataStructures.Models;

namespace Vish.DataStructures.Tests
{
    [TestClass]
    public class SimpleHashMapTests
    {
        [TestMethod]
        public void Test_SimpleHM_InsertWithNoSize_Success()
        {
            SimpleHashMap<string, int> hm = new SimpleHashMap<string, int>();

            hm.Insert("Vish", 150);
            hm.Insert("Renessa", 100);
            hm.Insert("Johnny", 30);
            hm.Insert("Albert", 500);
            hm.Insert("Niam", 35);

            Assert.AreEqual(5, hm.Count);
        }

        [TestMethod]
        public void Test_SimpleHM_InsertWithNoSize_ExpandTest()
        {
            SimpleHashMap<string, int> hm = new SimpleHashMap<string, int>();
            //default size = 10, added more than 10 should cause expanding of inner array

            hm.Insert("Vish", 150);
            hm.Insert("Renessa", 100);
            hm.Insert("Johnny", 30);
            hm.Insert("Albert", 500);
            hm.Insert("Niam", 35);
            hm.Insert("Kris", 160);
            hm.Insert("Shiva", 90);
            hm.Insert("Audie", 40);
            hm.Insert("Wilfred", 60);
            hm.Insert("Chuck", 0);

            hm.Insert("Vawn", 130);
            hm.Insert("Rachel", 80);
            hm.Insert("Vanessa", 20);
            hm.Insert("Doug", 340);
            hm.Insert("Jack", 21);
            hm.Insert("Rufin", 340);
            hm.Insert("Conor", 600);
            hm.Insert("David", 70);
            hm.Insert("Mathew", 165);
            hm.Insert("Mark", 23);

            Assert.AreEqual(20, hm.Count);
        }

        [TestMethod]
        public void Test_SimpleHM_InsertWithSize_ExpandTest()
        {
            SimpleHashMap<string, int> hm = new SimpleHashMap<string, int>(5);
            //added more than 5 should cause expanding of inner array

            hm.Insert("Vish", 150);
            hm.Insert("Renessa", 100);
            hm.Insert("Johnny", 30);
            hm.Insert("Albert", 500);
            hm.Insert("Niam", 35);
            hm.Insert("Kris", 160);
            hm.Insert("Shiva", 90);
            hm.Insert("Audie", 40);
            hm.Insert("Wilfred", 60);
            hm.Insert("Chuck", 0);

            hm.Insert("Vawn", 130);
            hm.Insert("Rachel", 80);
            hm.Insert("Vanessa", 20);
            hm.Insert("Doug", 340);
            hm.Insert("Jack", 21);

            Assert.AreEqual(15, hm.Count);
        }

        [TestMethod]
        public void Test_SimpleHM_Get()
        {
            SimpleHashMap<string, int> hm = new SimpleHashMap<string, int>();

            hm.Insert("Vish", 150);
            hm.Insert("Renessa", 100);
            hm.Insert("Johnny", 30);
            hm.Insert("Albert", 500);
            hm.Insert("Niam", 35);

            Assert.AreEqual(150, hm.Get("Vish"));
            Assert.AreEqual(100, hm.Get("Renessa"));
            Assert.AreEqual(30, hm.Get("Johnny"));
            Assert.AreEqual(500, hm.Get("Albert"));
            Assert.AreEqual(35, hm.Get("Niam"));

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                var value = hm.Get("David");
            });
        }

        [TestMethod]
        public void Test_SimpleHM_GetByIndexer()
        {
            SimpleHashMap<string, int> hm = new SimpleHashMap<string, int>();

            hm.Insert("Vish", 150);
            hm.Insert("Renessa", 100);
            hm.Insert("Johnny", 30);
            hm.Insert("Albert", 500);
            hm.Insert("Niam", 35);

            Assert.AreEqual(150, hm["Vish"]);
            Assert.AreEqual(100, hm["Renessa"]);
            Assert.AreEqual(30, hm["Johnny"]);
            Assert.AreEqual(500, hm["Albert"]);
            Assert.AreEqual(35, hm["Niam"]);

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                var value = hm["David"];
            });
        }

        [TestMethod]
        public void Test_SimpleHM_Update()
        {
            SimpleHashMap<string, int> hm = new SimpleHashMap<string, int>();

            hm.Insert("Vish", 150);
            hm.Insert("Renessa", 100);
            hm.Insert("Johnny", 30);
            hm.Insert("Albert", 500);
            hm.Insert("Niam", 35);

            hm.Update("Vish", 200);

            Assert.AreEqual(200, hm["Vish"]);

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                hm.Update("David", 30);
            });
        }

        [TestMethod]
        public void Test_SimpleHM_UpdateByIndexer()
        {
            SimpleHashMap<string, int> hm = new SimpleHashMap<string, int>();

            hm.Insert("Vish", 150);
            hm.Insert("Renessa", 100);
            hm.Insert("Johnny", 30);
            hm.Insert("Albert", 500);
            hm.Insert("Niam", 35);

            hm["Vish"] = 200;

            Assert.AreEqual(200, hm["Vish"]);

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                hm["David"] = 30;
            });
        }

        [TestMethod]
        public void Test_SimpleHM_Delete()
        {
            SimpleHashMap<string, int> hm = new SimpleHashMap<string, int>(5);

            hm.Insert("Vish", 150);
            hm.Insert("Renessa", 100);
            hm.Insert("Johnny", 30);
            hm.Insert("Albert", 500);
            hm.Insert("Niam", 35);

            hm.Delete("Niam");

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                var value = hm["Niam"];
            });

            //exits if key not found
            hm.Delete("David");
        }
    }
}
