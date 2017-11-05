using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.zadatak
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public string Text { get; set; }
        
        public bool IsCompleted => DateCompleted.HasValue;

        public DateTime? DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        public TodoItem(string text)
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.UtcNow;
            Text = text;
        }

        protected bool Equals(TodoItem other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TodoItem) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool MarkAsCompleted()
        {
            if (!IsCompleted)
            {
                DateCompleted = DateTime.Now;
                return true;
            }
            return false;
        }

    }
}