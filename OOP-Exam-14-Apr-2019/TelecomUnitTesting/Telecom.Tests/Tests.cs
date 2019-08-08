namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void Setup()
        {
            this.phone = new Phone("LG", "G7");
        }

        [Test]
        public void Constructor_Sets_Make_Model_Count()
        {


            Assert.AreEqual("LG", phone.Make);
            Assert.AreEqual("G7", phone.Model);
            Assert.AreEqual(0, phone.Count);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Make_Throws_ArgumentException_If_MakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Phone(make, "bbb"))
                .Message.Equals($"Invalid Make!");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Model_Throws_ArgumentException_If_ModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Phone("bbb", model))
                .Message.Equals($"Invalid {nameof(phone.Model)}!");
        }


        [Test]
        public void AddMethod_Increase_CountValue()
        {
            phone.AddContact("bbb", "+5484849");

            Assert.That(phone.Count == 1);

            phone.AddContact("bbb2", "+65484849");

            Assert.That(phone.Count == 2);
        }

        [Test]
        public void AddMethod_Throws_InvalidOperationException_If_NameExists()
        {
            phone.AddContact("bbb", "+123");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("bbb", "+6242442"))
                .Message.Equals("Person already exists!");
        }

        [Test]
        public void CallMethod_Throws_InvalidOperationException_If_NameNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => phone.Call("aaa"))
                .Message.Equals("Person doesn't exists!");
        }

        [Test]
        [TestCase("gosho", "-45165546")]
        [TestCase("pesho", "+45664654")]
        public void CallMethod_Returns_StringIfSuccessfullyCalled(string name, string number)
        {
            phone.AddContact(name, number);

            var expected = $"Calling {name} - {number}...";
            var result = phone.Call(name);
            StringAssert.AreEqualIgnoringCase(expected, result);
        }
    }
}