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

        [TestMethod]
        public void TestConstructor()
        {
            TodoItem item = new TodoItem("Todo Item");
            Assert.AreEqual(item.Text, "Todo Item");
        }


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

        [TestMethod]
        public void TestHashCode()
        {
            TodoItem firstItem = new TodoItem("Todo Item");
            TodoItem secondItem = new TodoItem("Other item");
            secondItem.Id = firstItem.Id;

            Assert.AreEqual(firstItem.GetHashCode(), secondItem.GetHashCode());
        }

    }
}