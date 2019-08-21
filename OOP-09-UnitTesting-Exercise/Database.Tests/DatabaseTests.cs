using NUnit.Framework;
using System.Linq;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private int[] fiveNumsArray;
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            this.fiveNumsArray = new int[5] { 10, 2, 13, 4, 5 };
            this.database = new Database.Database(fiveNumsArray);
        }

        [Test]
        [TestCase(17)]
        [TestCase(20)]
        public void DatabaseConstructorThrowsExceptionIfArraySizeMoreThan16(int number)
        {
            var array = Enumerable.Range(1, number).ToArray();

            Assert.That(() => new Database.Database(array), Throws.Exception);
        }

        [Test]
        public void DatabaseConstructorSetsCountProperly()
        {
            Assert.AreEqual(5, database.Count);
        }

        [Test]
        public void Database_Fetch_ReturnsArrayCopy()
        {
            //Act
            var result = database.Fetch();

            //Assert
            CollectionAssert.AreEqual(result, fiveNumsArray);
        }

        [Test]
        [TestCase(-5)]
        [TestCase(0)]
        [TestCase(505005)]
        public void Database_Add_MethodAdds(int number)
        {
            //Arrange
            //Act
            database.Add(number);

            //Assert
            Assert.AreEqual(6, database.Count);
        }

        [Test]
        [TestCase(-5)]
        [TestCase(0)]
        public void Database_Add_MethodThrowsExceptionWhenLimitReached(int number)
        {
            //Arrange
            var sixteenNumsArray = new int[16] { 12, 2, 3, 34, 5, 6, 7, 8, 99, 10, 11, 12, 13, 14, 15, 16 };
            var database = new Database.Database(sixteenNumsArray);

            //Act
            //Assert
            Assert.That(() => database.Add(1), Throws.InvalidOperationException
                .With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
            Assert.That(database.Count.Equals(16));
        }

        [Test]
        public void Database_Remove_Method_RemovesLastElement()
        {
            database.Remove();
            Assert.That(database.Count == 4);
            var array = database.Fetch();
            Assert.That(array[3] == 4);
        }

        [Test]
        public void Database_Remove_Method_ThrowsException_WhenEmpty()
        {
            //Arrange
            var data = new Database.Database(new int[1] { 1 });

            //Act
            data.Remove();

            //Assert
            Assert.That(() => data.Remove(), Throws.InvalidOperationException
                .With.Message.EqualTo("The collection is empty!"));
        }
    }
}