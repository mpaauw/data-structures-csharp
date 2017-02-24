using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_CSharp.LinkedList;

namespace Data_Structures_CSharp.Stack
{
    /// <summary>
    /// Represents a Stack data structure utilizing a Linked-List.
    /// </summary>
    /// <typeparam name="T">Underlying data type represented within the class object.</typeparam>
    public class Stack<T>
    {
        private Data_Structures_CSharp.LinkedList.LinkedList<T> stack;
        public int size { get; set; }

        /// <summary>
        /// Default constructor.
        /// Assigns initial value of stack to an input parameter, increments the size of the stack by 1.
        /// </summary>
        /// <param name="input"></param>
        public Stack(T input)
        {
            this.stack = new Data_Structures_CSharp.LinkedList.LinkedList<T>(input);
            this.size++;
        }

        /// <summary>
        /// Inserts a new element to the top of the stack.
        /// </summary>
        /// <param name="input">Item to be passed and added to the stack.</param>
        public void push(T input)
        {
            this.stack.insert(input);
        }

        /// <summary>
        /// Returns the top element of the stack and deletes it from the structure.
        /// </summary>
        /// <returns>Returns an element of underlying data type T representing the element at the top of the stack.</returns>
        public T pop()
        {
            T head = this.stack.getElementAt(0);
            this.stack.delete(head);
            return head;
        }

        /// <summary>
        /// Determines whether or not the stack is empty.
        /// </summary>
        /// <returns>Returns true if the stack is empty, false if otherwise.</returns>
        public bool isEmpty()
        {
            if(this.size < 1)
            {
                return true;
            }
            return false;
        }

    }
}
