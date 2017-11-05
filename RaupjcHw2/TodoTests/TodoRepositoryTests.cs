using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2.zadatak;

namespace TodoTests
{
    [TestClass]
    public class TodoRepositoryTests
    {
        [TestMethod]
        public void TestAddToEmptyRepo()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem item = new TodoItem("a");
            repository.Add(item);
            Assert.AreEqual(repository.GetAll().Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void TestAddDuplicate()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem item = new TodoItem("a");
            repository.Add(item);
            repository.Add(item);
        }

        [TestMethod]
        public void TestGet()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem item = new TodoItem("a");
            repository.Add(item);
            Assert.IsTrue(item.Equals(repository.Get(item.Id)));
        }

        [TestMethod]
        public void TestGetForNotExistingItem()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem firstItem = new TodoItem("a");
            TodoItem secondItem = new TodoItem("b");

            repository.Add(firstItem);
            TodoItem retrievedItem = repository.Get(secondItem.Id);

            Assert.AreEqual(null, retrievedItem);
            
        }

        [TestMethod]
        public void TestRemoveOnExistingItem()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem item = new TodoItem("a");
            repository.Add(item);
            repository.Remove(item.Id);
            Assert.AreEqual(0, repository.GetAll().Count);
        }

        [TestMethod]
        public void TestRemoveOnNonExistingItem()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem firstItem = new TodoItem("a");
            TodoItem secondItem = new TodoItem("b");

            repository.Add(firstItem);
            Assert.IsFalse(repository.Remove(secondItem.Id));
        }

        [TestMethod]
        public void TestUpdate()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem firstItem = new TodoItem("a");
            TodoItem secondItem = new TodoItem("b");

            repository.Add(firstItem);
            secondItem.Id = firstItem.Id;
            repository.Update(secondItem);

            TodoItem changedItem = repository.GetAll().FirstOrDefault();
            Assert.AreEqual("b", changedItem.Text);
        }

        [TestMethod]
        public void TestUpdateForNewItem()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem item = new TodoItem("a");
            repository.Update(item);

            Assert.AreEqual(1, repository.GetAll().Count);

        }

        [TestMethod]
        public void TestMarkAsCompleted()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem item = new TodoItem("a");
            repository.Add(item);
            repository.MarkAsCompleted(item.Id);

            bool isCompleted = repository.GetAll().FirstOrDefault().IsCompleted;
            Assert.IsTrue(isCompleted);
        }

        [TestMethod]
        public void TestMarkAsCompletedForCompletedItem()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem item = new TodoItem("a");
            item.MarkAsCompleted();
            repository.Add(item);

            Assert.IsFalse(repository.MarkAsCompleted(item.Id));
        }

        [TestMethod]
        public void TestGetAll()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem firstItem = new TodoItem("a");
            TodoItem secondItem = new TodoItem("b");
            TodoItem thirdItem = new TodoItem("c");
            firstItem.DateCreated = DateTime.MinValue;
            thirdItem.DateCreated = DateTime.MaxValue;
            repository.Add(firstItem);
            repository.Add(secondItem);
            repository.Add(thirdItem);

            List<TodoItem> list = repository.GetAll();
            TodoItem firstRetrievedItem = list[2];
            Assert.AreEqual(firstRetrievedItem.Text, "a");

        }

        [TestMethod]
        public void TestGetActive()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem firstItem = new TodoItem("a");
            TodoItem secondItem = new TodoItem("b");
            TodoItem thirdItem = new TodoItem("c");
            firstItem.MarkAsCompleted();
            secondItem.MarkAsCompleted();

            repository.Add(firstItem);
            repository.Add(secondItem);
            repository.Add(thirdItem);

            List<TodoItem> list = repository.GetActive();
            TodoItem retrievedItem = list.FirstOrDefault();
            Assert.AreEqual(retrievedItem.Id, thirdItem.Id);

        }

        [TestMethod]
        public void TestGetCompleted()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem firstItem = new TodoItem("a");
            TodoItem secondItem = new TodoItem("b");
            TodoItem thirdItem = new TodoItem("c");
            thirdItem.MarkAsCompleted();

            repository.Add(firstItem);
            repository.Add(secondItem);
            repository.Add(thirdItem);

            List<TodoItem> list = repository.GetCompleted();
            TodoItem retrievedItem = list.FirstOrDefault();
            Assert.AreEqual(retrievedItem.Id, thirdItem.Id);
        }

        [TestMethod]
        public void TestGetFiltered()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem firstItem = new TodoItem("a");
            TodoItem secondItem = new TodoItem("b");
            TodoItem thirdItem = new TodoItem("c");

            repository.Add(firstItem);
            repository.Add(secondItem);
            repository.Add(thirdItem);

            Func<TodoItem, bool> filter = item => item.Text == "b";

            List<TodoItem> list = repository.GetFiltered(filter);
            TodoItem retrievedItem = list.FirstOrDefault();
            Assert.AreEqual(retrievedItem.Id, secondItem.Id);

        }

    }
}
