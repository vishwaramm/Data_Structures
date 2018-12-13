using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vish.DataStructures.Models;

namespace Vish.DataStructures.Tests
{
    [TestClass]
    public class TrieTests
    {
        [TestMethod]
        public void Test_Trie_Insert()
        {
            Trie trie = new Trie();

            trie.Insert("Apple");
            trie.Insert("Oranges");
            trie.Insert("Apply");
            trie.Insert("Cookies");
            trie.Insert("Orange");

            Assert.IsTrue(trie.Search("Apple"));
            Assert.IsTrue(trie.Search("Oranges"));
            Assert.IsTrue(trie.Search("Apply"));
            Assert.IsTrue(trie.Search("Cookies"));
            Assert.IsTrue(trie.Search("Orange"));
            Assert.IsFalse(trie.Search("App"));
        }

        [TestMethod]
        public void Test_Trie_InsertDuplicate()
        {
            Trie trie = new Trie();

            trie.Insert("Apple");
            trie.Insert("Oranges");
            trie.Insert("Apply");
            trie.Insert("Cookies");
            trie.Insert("Orange");

            trie.Insert("Apple");//duplicate

            Assert.AreEqual(5, trie.EntryCount);
        }

        [TestMethod]
        public void Test_Trie_Prefix()
        {
            Trie trie = new Trie();

            trie.Insert("Apple");
            trie.Insert("Oranges");
            trie.Insert("Apply");
            trie.Insert("Cookies");
            trie.Insert("Orange");

            var node = trie.Prefix("App");
            Assert.IsNotNull(node);

            node = trie.Prefix("Boots");

            Assert.IsNotNull(node);
            Assert.AreEqual('^', node.Value);
        }

        [TestMethod]
        public void Test_Trie_Delete()
        {
            Trie trie = new Trie();

            trie.Insert("Apple");
            trie.Insert("Oranges");
            trie.Insert("Apply");
            trie.Insert("Cookies");
            trie.Insert("Orange");

            trie.Delete("Apple");

            Assert.IsFalse(trie.Search("Apple"));
        }

        [TestMethod]
        public void Test_Trie_DeleteNonExistentWord()
        {
            Trie trie = new Trie();

            trie.Insert("Apple");
            trie.Insert("Oranges");
            trie.Insert("Apply");
            trie.Insert("Cookies");
            trie.Insert("Orange");

            trie.Delete("Boots");

            Assert.AreEqual(5, trie.EntryCount);
        }

        [TestMethod]
        public void Test_Trie_StartsWith_Success()
        {
            Trie trie = new Trie();

            trie.Insert("Apple");
            trie.Insert("Oranges");
            trie.Insert("Apply");
            trie.Insert("App");
            trie.Insert("Appointment");
            trie.Insert("Applepie");
            trie.Insert("Apprentice");
            trie.Insert("Appropriate");
            trie.Insert("Boots");
            trie.Insert("Ball");
            trie.Insert("Balls");

            var list = trie.StartsWith("App");

            Assert.AreEqual(7, list.Count);

            Assert.IsTrue(list.Contains("Apple"));
            Assert.IsTrue(list.Contains("Apply"));
            Assert.IsTrue(list.Contains("App"));
            Assert.IsTrue(list.Contains("Appointment"));
            Assert.IsTrue(list.Contains("Applepie"));
            Assert.IsTrue(list.Contains("Apprentice"));
            Assert.IsTrue(list.Contains("Appropriate"));
        }

        [TestMethod]
        public void Test_Trie_StartsWith_NoResults()
        {
            Trie trie = new Trie();

            trie.Insert("Apple");
            trie.Insert("Oranges");
            trie.Insert("Apply");
            trie.Insert("App");
            trie.Insert("Appointment");
            trie.Insert("Applepie");
            trie.Insert("Apprentice");
            trie.Insert("Appropriate");
            trie.Insert("Boots");
            trie.Insert("Ball");
            trie.Insert("Balls");

            var list = trie.StartsWith("Sh");

            Assert.AreEqual(0, list.Count);
        }
    }
}
