using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericList
{
    internal class GenericListEnumerator<T> : IEnumerator<T>
    {
        private readonly GenericList<T> genericList;
        private int currentIndex=-1;

        public T Current => genericList.GetElement(currentIndex);

        public GenericListEnumerator(GenericList<T> genericList)
        {
            this.genericList = genericList;
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if (currentIndex+1 < genericList.Count)
            {
                currentIndex++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        object IEnumerator.Current => Current;
    }
}