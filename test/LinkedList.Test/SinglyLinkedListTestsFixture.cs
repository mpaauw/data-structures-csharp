using Bogus;
using LinkedList.SinglyLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LinkedList.Test
{
    public class SinglyLinkedListTestsFixture
    {
        private SinglyLinkedList<string> list;
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

        public SinglyLinkedListTestsFixture WithData()
        {
            this.data.Add(this.faker.Hacker.Noun());
            return this;
        }

        public SinglyLinkedListTestsFixture WithDataIndex(int index = 0, string data = "")
        {
            this.dataIndices.Add(new DataIndex()
            {
                Data = (data.Equals("")) ? this.faker.Hacker.Noun() : data,
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
                    Index = i
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

        public class DataIndex
        {
            public string Data { get; set; }
            public int Index { get; set; }
        }

    }
}
