using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2.zadatak;

namespace TodoTests
{
    /// <summary>
    /// Summary description for TodoItemTests
    /// </summary>
    [TestClass]
    public class TodoItemTests
    {
        #region Additional test attributes

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion

        [TestMethod]
        public void TestMarkAsCompleted()
        {
            TodoItem item = new TodoItem("Todo Item");
            item.MarkAsCompleted();
            Assert.IsTrue(item.IsCompleted);
        }

        [TestMethod]
        public void TestMarkAsCompletedOnCompletedItem()
        {
            TodoItem item = new TodoItem("Todo Item");
            item.MarkAsCompleted();
            Assert.IsFalse(item.MarkAsCompleted());
        }

        [TestMethod]
        public void TestEqualsForReferenceEquality()
        {
            TodoItem originalItem = new TodoItem("Original item");
            TodoItem otherItem = originalItem;
            Assert.IsTrue(originalItem.Equals(otherItem));
        }

        [TestMethod]
        public void TestEqualsForComparationWithNull()
        {
            TodoItem orignaItem = new TodoItem("Item");
            TodoItem otherItem = null;
            Assert.IsFalse(orignaItem.Equals(otherItem));
        }

        [TestMethod]
        public void TestEqualsForIncompatibleTypes()
        {
            TodoItem orignaItem = new TodoItem("Item");
            object objectToCompare = "this";
            Assert.IsFalse(orignaItem.Equals(objectToCompare));
        }
        
    }
}