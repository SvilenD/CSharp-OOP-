using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person[] users;
        private ExtendedDatabase.ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            this.users = new Person[2] { new Person(1, "Pesho"), new Person(2, "Gosho") };
            this.database = new ExtendedDatabase.ExtendedDatabase(users);
        }

        [Test]
        public void ConstructorSetsPersons()
        {
            var users = new Person[1] { new Person(123131, "Pesho") };
            var database = new ExtendedDatabase.ExtendedDatabase(users);

            Assert.AreEqual(1, database.Count);

            var users2 = new Person[2] { new Person(123131, "Pesho2"), new Person(213213, "Gosho2") };
            var database2 = new ExtendedDatabase.ExtendedDatabase(users2);

            Assert.AreEqual(2, database2.Count);
        }

        [Test]
        [TestCase(17)]
        [TestCase(22)]
        public void Constructor_AddRange_ThrowsExceptionIfNotInRange(int count)
        {
            var users = new Person[count];
            for (int i = 0; i < count; i++)
            {
                var user = new Person(20 + count, "gosho{count}");
                users[i] = user;
            }

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(users))
                .Message.Equals("Provided data length should be in range [0..16]!");
        }

        [Test]
        [TestCase("new")]
        [TestCase("new2")]
        public void AddUserMethod_AddsPerson(string name)
        {
            var person = new Person(212112, name);

            database.Add(person);
            Assert.That(database.Count == 3);
        }

        [Test]
        [TestCase("Pesho")]
        [TestCase("Gosho")]
        public void AddUserWith_Name_ThatAlreadyExistThrowsException(string name)
        {
            var person = new Person(212112, name);

            Assert.That(() => database.Add(person), Throws.InvalidOperationException
                .With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void AddUserWith_ID_ThatAlreadyExistThrowsException(int id)
        {
            var person = new Person(id, "NoName");

            Assert.That(() => database.Add(person), Throws.InvalidOperationException
                .With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void AddUser_ThrowsException_IfCapacityIsFull()
        {
            Assert.AreEqual(2, database.Count);

            for (int i = 0; i < 14; i++)
            {
                database.Add(new Person(20 + i, $"gosho{i}"));
            }

            Assert.That(() => database.Add(new Person(17, "17")), Throws.InvalidOperationException
                .With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void RemoveMethod_Works()
        {
            var previousCount = database.Count;
            database.Remove();
            database.Remove();

            Assert.AreEqual(previousCount - 2, database.Count);
        }

        [Test]
        public void RemoveMethod_ThrowsException_IfArrayIsEmpty()
        {
            database.Remove();
            database.Remove();

            Assert.AreEqual(0, database.Count);
            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(5)]
        [TestCase(5555)]
        public void FindById_ThrowsException_IfUserNotExists(int id)
        {
            Assert.That(() => database.FindById(id), Throws.InvalidOperationException
                .With.Message.EqualTo("No user is present by this ID!"));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-5324255)]
        public void FindById_ThrowsException_IfUserIdIsNegative(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id))
                .Message.Equals("Id should be a positive number!");
        }

        [Test]
        [TestCase(1, "Pesho")]
        [TestCase(2, "Gosho")]
        public void FindById_ReturnsUser(int id, string name)
        {
            var user = database.FindById(id);

            Assert.AreEqual(user.Id, id);
            Assert.AreEqual(user.UserName, name);
        }

        [Test]
        [TestCase("baadas")]
        [TestCase("bf")]
        public void FindByUsername_ThrowsException_IfUserNotExists(string username)
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(username))
                .Message.Equals("No user is present by this username!");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindByUsername_ThrowsException_IfUserIsNullOrEmpty(string username)
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username))
                .Message.Equals("Username parameter is null!");
        }

        [Test]
        [TestCase(1, "Pesho")]
        [TestCase(2, "Gosho")]
        public void FindByUsername_ReturnsUser(int id, string name)
        {
            var user = database.FindByUsername(name);

            Assert.AreEqual(user.Id, id);
            Assert.AreEqual(user.UserName, name);
        }
    }
}