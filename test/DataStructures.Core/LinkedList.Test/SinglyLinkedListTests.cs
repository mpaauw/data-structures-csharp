using Bogus;
using System;
using Xunit;

namespace DataStructures.Core.LinkedList.Test
{
    public class SinglyLinkedListTests
    {
        private readonly SinglyLinkedListTestsFixture fixture;
        private readonly Faker faker;

        public SinglyLinkedListTests()
        {
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

        [Fact]
        public void Should_Throw_Exception_When_Deleting_Head_Empty()
        {
            Assert.Throws<NullReferenceException>(() => this.fixture
                .ExecuteDeleteHead());
        }

        [Fact]
        public void Should_Delete_Head_Successfully_When_Populated()
        {
            this.fixture
                .WithDataPopulation(false)
                .ExecuteInsertHead();
            var oldHead = this.fixture.list.Head;

            this.fixture
                .ExecuteDeleteHead()
                .AssertDataDeletedAtHeadSuccessfully(oldHead);
        }

        [Fact]
        public void Should_Throw_Exception_When_Deleting_Tail_Empty()
        {
            Assert.Throws<NullReferenceException>(() => this.fixture
                .ExecuteDeleteTail());
        }

        [Fact]
        public void Should_Delete_Tail_Successfully_When_Populated()
        {
            this.fixture
                .WithDataPopulation(false)
                .ExecuteInsertHead();
            var oldTail = this.fixture.list.Tail;

            this.fixture
                .ExecuteDeleteTail()
                .AssertDataDeletedAtTailSuccessfully(oldTail);
        }

        [Fact]
        public void Should_Delete_Data_If_Present()
        {
            this.fixture
                .WithDataPopulation(false, 3)
                .ExecuteInsertHead();

            var node = this.fixture.list.Head.Next;
            this.fixture
                .ExecuteDelete(node.Data)
                .AssertDataDeletedSuccessfully(node, 1);
        }

        [Fact]
        public void Should_Return_Invalid_Index_If_Search_Fails()
        {
            int result = Int32.MaxValue;
            this.fixture
                .WithData("Cat")
                .WithData("Dog")
                .WithData("Fish")
                .ExecuteInsertTail()
                .ExecuteSearch("Bird", out result);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void Should_Return_Proper_Index_If_Search_Passed()
        {
            const string term = "Blue";
            int result = Int32.MaxValue;
            this.fixture
                .WithData("Red")
                .WithData("Green")
                .WithData(term)
                .WithData("Yellow")
                .ExecuteInsertTail()
                .ExecuteSearch(term, out result);
            Assert.Equal(2, result);
        }

    }
}
