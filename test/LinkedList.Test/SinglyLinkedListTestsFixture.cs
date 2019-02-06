using Bogus;
using LinkedList.SinglyLinkedList;
using System;
using System.Collections.Generic;
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

        public SinglyLinkedListTestsFixture WithDataIndex()
        {
            this.dataIndices.Add(new DataIndex()
            {
                Data = this.faker.Hacker.Noun(),
                Index = this.faker.Random.Int(1, 10)
            });
            return this;
        }

        public SinglyLinkedListTestsFixture WithPopulation()
        {
            for(int i = 0; i < this.faker.Random.Int(1, 10); i++)
            {
                WithData();
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
