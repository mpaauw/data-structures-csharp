using Bogus;
using DataStructures.Core.LinkedList.SinglyLinkedList;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DataStructures.Core.LinkedList.Test
{
    public class SinglyLinkedListTestsFixture
    {
        public SinglyLinkedList<string> list { get; private set; }
        private List<string> data;
        private List<DataIndex> dataIndices;

        private readonly Faker faker;

        public SinglyLinkedListTestsFixture()
        {
            list = new SinglyLinkedList<string>();
            data = new List<string>();
            dataIndices = new List<DataIndex>();
            faker = new Faker();
        }

        public SinglyLinkedListTestsFixture WithData(string data = "")
        {
            this.data.Add((data.Equals("") ? this.faker.Random.String() : data));
            return this;
        }

        public SinglyLinkedListTestsFixture WithUniqueData(string data = "")
        {
            while(this.data.Contains(data))
            {
                data = this.faker.Random.String();
            }
            this.data.Add(data);
            return this;
        }

        public SinglyLinkedListTestsFixture WithDataIndex(int index = 0, string data = "")
        {
            this.dataIndices.Add(new DataIndex()
            {
                Data = (data.Equals("")) ? this.faker.Random.String() : data,
                Index = (index == 0) ? this.faker.Random.Int(1, 10) : index
            });
            return this;
        }

        public SinglyLinkedListTestsFixture WithDataPopulation(bool isDataIndex, int count = 0)
        {
            if(count == 0)
            {
                count = this.faker.Random.Int(1, 10);
            }
            for(int i = 0; i < count; i++)
            {
                if(isDataIndex)
                {
                    WithDataIndex();
                }
                else
                {
                    WithData();
                }
            }
            return this;
        }

        public SinglyLinkedListTestsFixture ExecuteInsertHead()
        {
            foreach(var item in this.data)
            {
                this.list.InsertHead(item);
            }
            return this;
        }

        public SinglyLinkedListTestsFixture ExecuteInsertTail()
        {
            foreach(var item in this.data)
            {
                this.list.InsertTail(item);
            }
            return this;
        }

        public SinglyLinkedListTestsFixture ExecuteInsertAt()
        {
            foreach(var item in this.dataIndices)
            {
                this.list.InsertAt(item.Index, item.Data);
            }
            return this;
        }

        public SinglyLinkedListTestsFixture ExecuteDeleteHead()
        {
            this.list.DeleteHead();
            return this;
        }

        public SinglyLinkedListTestsFixture ExecuteDeleteTail()
        {
            this.list.DeleteTail();
            return this;
        }

        public SinglyLinkedListTestsFixture ExecuteDelete(string data = "")
        {
            this.list.Delete(data);
            return this;
        }

        public SinglyLinkedListTestsFixture ExecuteSearch(string data, out int result)
        {
            result = this.list.Search(data);
            return this;
        }

        public SinglyLinkedListTestsFixture AssertDataInsertedAtHeadSuccessfully()
        {
            var isValidOrdering = true;
            var head = this.list.Head;
            for(int i = this.data.Count - 1; i >= 0; i--)
            {
                if(!head.Data.Equals(this.data[i]))
                {
                    isValidOrdering = false;
                }
                head = head.Next;
            }
            Assert.True(isValidOrdering);
            return this;
        }

        public SinglyLinkedListTestsFixture AssertDataInsertedAtTailSuccessfully()
        {
            var isValidOrdering = true;
            var head = this.list.Head;
            for(int i = 0; i < this.data.Count - 1; i++)
            {
                if(!head.Data.Equals(this.data[i]))
                {
                    isValidOrdering = false;
                }
                head = head.Next;
            }
            Assert.True(isValidOrdering);
            return this;
        }

        public SinglyLinkedListTestsFixture AssertDataInsertedAtSuccessfully()
        {
            var isValidOrdering = true;
            var head = this.list.Head;
            var actualOrdering = new List<DataIndex>();
            for(int i = 1; i <= this.list.Size; i++)
            {
                actualOrdering.Add(new DataIndex
                {
                    Data = head.Data,
                    Index = i - 1
                });
                head = head.Next;
            }
            foreach(var item in dataIndices)
            {
                var validItemPresent = actualOrdering.Any(x => x.Data.Equals(item.Data) && x.Index == item.Index);
                if(!validItemPresent)
                {
                    isValidOrdering = false;
                }
            }
            Assert.True(isValidOrdering);
            return this;
        }

        public SinglyLinkedListTestsFixture AssertDataDeletedAtHeadSuccessfully(SinglyLinkedListNode<string> oldHeadNode)
        {
            var isDeleted = true;
            if(oldHeadNode != null && (oldHeadNode.Equals(this.list.Head) || !oldHeadNode.Next.Equals(this.list.Head)))
            {
                isDeleted = false;
            }
            Assert.True(isDeleted);
            return this;
        }

        public SinglyLinkedListTestsFixture AssertDataDeletedAtTailSuccessfully(SinglyLinkedListNode<string> oldTailNode)
        {
            var isDeleted = true;
            if (oldTailNode.Equals(this.list.Tail))
            {
                isDeleted = false;
            }
            Assert.True(isDeleted);
            return this;
        }

        public SinglyLinkedListTestsFixture AssertDataDeletedSuccessfully(SinglyLinkedListNode<string> node, int index)
        {
            var isDeleted = true;
            var current = this.list.Head;
            for(int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            if(current.Equals(node))
            {
                isDeleted = false;
            }
            Assert.True(isDeleted);
            return this;
        }

        public class DataIndex
        {
            public string Data { get; set; }
            public int Index { get; set; }
        }

    }
}
