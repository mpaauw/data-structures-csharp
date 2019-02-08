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
        public void Should_Insert_Head_Successfully_When_Empty()
        {
            this.fixture
                .WithData()
                .ExecuteInsertHead()
                .AssertDataInsertedAtHeadSuccessfully();
        }

        [Fact]
        public void Should_Insert_Head_Successfully_When_Populated()
        {
            this.fixture
                .WithDataPopulation(false)
                .ExecuteInsertHead()
                .AssertDataInsertedAtHeadSuccessfully();
        }

        [Fact]
        public void Should_Insert_Tail_Successfully_When_Empty()
        {
            this.fixture
                .WithData()
                .ExecuteInsertTail()
                .AssertDataInsertedAtTailSuccessfully();
        }

        [Fact]
        public void Should_Throw_Exception_When_Inserting_At_Empty()
        {
            Assert.Throws<IndexOutOfRangeException>(() => this.fixture
               .WithDataIndex()
               .ExecuteInsertAt());
        }

        [Fact]
        public void Should_Throw_Exception_When_Inserting_At_Out_Of_Range()
        {
            Assert.Throws<IndexOutOfRangeException>(() => this.fixture
                .WithDataPopulation(false, 5)
                .ExecuteInsertHead()
                .WithDataIndex(10)
                .ExecuteInsertAt());
        }

        [Fact]
        public void Should_Insert_At_Successfully_When_In_Range()
        {
            this.fixture
                .WithDataPopulation(false, 10)
                .ExecuteInsertHead()
                .WithDataIndex(5)
                .ExecuteInsertAt()
                .AssertDataInsertedAtSuccessfully();
        }

    }
}
