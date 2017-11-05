using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericList
{
    public class GenericList<X> : IGenericList<X>
    {
        public int Count { get; private set; }

        private X[] internalStorage;

        public GenericList()
        {
            internalStorage = new X[4];
        }

        public GenericList(int initialSize)
        {
            if (initialSize < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            internalStorage = new X[initialSize];
        }

        public void Add(X item)
        {
            if (Count >= internalStorage.Length)
            {
                X[] newStorage = new X[internalStorage.Length * 2];

                for (int i = 0; i < Count; i++)
                {
                    newStorage[i] = internalStorage[i];
                }
                internalStorage = newStorage;
            }

            internalStorage[Count] = item;
            Count++;
        }

        public bool Remove(X item) 
        {
            int index = IndexOf(item);

            return RemoveAt(index);
        }

        public bool RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    internalStorage[i] = internalStorage[i + 1];
                }
                Count--;
                return true;
            }

            return false;
        }

        public X GetElement(int index)
        {
            if (index >= 0 && index < Count)
            {
                return internalStorage[index];
            }

            throw new IndexOutOfRangeException();
        }

        public int IndexOf(X item)
        {
            int index = -1;

            for (int i = 0; i < Count; i++)
            {
                if (internalStorage[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
        

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (internalStorage[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
