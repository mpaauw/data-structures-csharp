using Bogus;
using LinkedList.SinglyLinkedList;
using System;
using Xunit;

namespace LinkedList.Test
{
    public class SinglyLinkedListTests
    {
        private readonly SinglyLinkedList<string> list;
        private readonly SinglyLinkedListTestsFixture fixture;
        private readonly Faker faker;

        public SinglyLinkedListTests()
        {
            this.list = new SinglyLinkedList<string>();
            this.fixture = new SinglyLinkedListTestsFixture();
            faker = new Faker();
        }

        [Fact]
        public void List_Should_Insert_Head_Successfully_When_Empty()
        {
            fixture
                .WithData()
                .ExecuteInsertHead()
                .AssertDataInsertedAtHeadSuccessfully();
        }

        [Fact]
        public void List_Should_Insert_Head_Successfully_When_Populated()
        {
            fixture
                .WithPopulation()
                .ExecuteInsertHead()
                .AssertDataInsertedAtHeadSuccessfully();
        }

        [Fact]
        public void List_Should_Insert_Tail_Successfully_When_Empty()
        {
            fixture
                .WithData()
                .ExecuteInsertTail()
                .AssertDataInsertedAtTailSuccessfully();
        }

        [Fact]
        public void List_Should_Throw_Exception_When_Inserting_At_Empty()
        {
            Assert.Throws<IndexOutOfRangeException>(() => fixture
               .WithDataIndex()
               .ExecuteInsertAt());
        }

    }
}
