using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericList;

namespace _2.zadatak
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </ summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // x ?? y => if x is not null , expression returns x. Else it will return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(Item => Item.Id == todoId);
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (Get(todoItem.Id) != null)
            {
                String exceptionMessage = string.Format("duplicate id: {0}", todoItem.Id);
                throw new DuplicateTodoItemException(exceptionMessage);
            }

            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public bool Remove(Guid todoId)
        {
            TodoItem itemToRemove = Get(todoId);
            if (itemToRemove == null)
            {
                return false;
            }
            return _inMemoryTodoDatabase.Remove(itemToRemove);
        }

        public TodoItem Update(TodoItem todoItem)
        {
            Remove(todoItem.Id);
            return Add(todoItem);
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem existingItem = Get(todoId);
            return existingItem.MarkAsCompleted();  
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(i => i.IsCompleted != true).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(i => i.IsCompleted == true).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();
        }
    }
}