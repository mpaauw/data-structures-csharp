using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_CSharp.LinkedList;

namespace Data_Structures_CSharp.Stack
{
    public class Stack<T>
    {
        private Data_Structures_CSharp.LinkedList.LinkedList<T> stack;
        private int size;

        public Stack(T input)
        {
            this.stack = new Data_Structures_CSharp.LinkedList.LinkedList<T>(input);
            this.size++;
        }

        public void push(T input)
        {
            this.stack.insert(input);
        }

        public T pop()
        {
            T head = this.stack.getElementAt(0);
            this.stack.delete(head);
            return head;
        }

    }
}
