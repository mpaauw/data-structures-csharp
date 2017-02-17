using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_CSharp.Shared;

namespace Data_Structures_CSharp.LinkedList
{
    class LinkedListNode<T> : LinkedNode<T>
    {
        public LinkedListNode(T input) : base(input) { }
    }
}
