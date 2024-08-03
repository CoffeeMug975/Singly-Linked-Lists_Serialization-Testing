using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO2_Assignment3_Group4
{
    public interface ILinkedListADT<T>
    {
        void Prepend(T item);
        void Append(T item);
        void RemoveAtIndex(int index);
        void RemoveAtStart();
        void RemoveAtEnd();
        void Insert(int index, T item);
        void Replace(int index, T item);
        T GetItemAtIndex(int index);
        int GetIndexOfItem(T Item);
        bool CheckListForItem(T Item);
        void ClearList();
        int Count { get; }
        void Reverse();


    }
}
