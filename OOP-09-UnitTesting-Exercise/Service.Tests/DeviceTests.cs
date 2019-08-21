using NUnit.Framework;
using Service.Models.Devices;
using Service.Models.Parts;
using System;
using System.Collections.Generic;

namespace Service.Tests
{
    public class DeviceTests
    {
        private LaptopPart laptopPart;
        private PhonePart phonePart;
        private PCPart pcPart;

        [SetUp]
        public void Setup()
        {
            this.laptopPart = new LaptopPart("laptopPart", 1, true);
            this.phonePart = new PhonePart("phonePart", 1, true);
            this.pcPart = new PCPart("pcPart", 1, true);
        }

        [Test]
        public void Laptop_ConstructorTest()
        {
            var laptop = new Laptop("HP");

            Assert.AreEqual("HP", laptop.Make);
            Assert.AreEqual(0, laptop.Parts.Count);
        }

        [Test]
        public void PC_ConstructorTest()
        {
            var pc = new PC("HP");

            Assert.AreEqual("HP", pc.Make);
            Assert.AreEqual(0, pc.Parts.Count);
        }

        [Test]
        public void Phone_ConstructorTest()
        {
            var phone = new Phone("HP");

            Assert.AreEqual("HP", phone.Make);
            Assert.AreEqual(0, phone.Parts.Count);
        }

        [Test]
        public void Laptop_AddPartTest()
        {
            var laptop = new Laptop("HP");

            laptop.AddPart(laptopPart);

            Assert.AreEqual(1, laptop.Parts.Count);
        }

        [Test]
        public void Laptop_AddPartThrowsException_PartExists()
        {
            var laptop = new Laptop("HP");

            laptop.AddPart(laptopPart);

            Assert.Throws<InvalidOperationException>(() => laptop.AddPart(laptopPart))
                .Message.Equals("This part already exists!");
        }

        [Test]
        [TestCase("Laptop")]
        [TestCase("PC")]
        [TestCase("Phone")]
        public void Devices_AddPartThrowsException_WhenPartNotCompatible(string type)
        {
            switch (type)
            {
                case "Laptop":
                    var laptop = new Laptop("make");

                    Assert.Throws<InvalidOperationException>(() => laptop.AddPart(phonePart))
                    .Message.Equals($"You cannot add {phonePart.GetType().Name} to {this.GetType().Name}!");

                    Assert.Throws<InvalidOperationException>(() => laptop.AddPart(pcPart))
                         .Message.Equals($"You cannot add {pcPart.GetType().Name} to {this.GetType().Name}!");
                    break;

                case "PC":
                    var pc = new PC("make");

                    Assert.Throws<InvalidOperationException>(() => pc.AddPart(laptopPart))
                    .Message.Equals($"You cannot add {laptopPart.GetType().Name} to {this.GetType().Name}!");

                    Assert.Throws<InvalidOperationException>(() => pc.AddPart(phonePart))
                         .Message.Equals($"You cannot add {phonePart.GetType().Name} to {this.GetType().Name}!");
                    break;

                case "Phone":
                    var phone = new Phone("make");

                    Assert.Throws<InvalidOperationException>(() => phone.AddPart(pcPart))
                    .Message.Equals($"You cannot add {pcPart.GetType().Name} to {this.GetType().Name}!");

                    Assert.Throws<InvalidOperationException>(() => phone.AddPart(laptopPart))
                         .Message.Equals($"You cannot add {laptopPart.GetType().Name} to {this.GetType().Name}!");
                    break;
            }
        }

        [Test]
        public void Laptop_PartsGetter()
        {
            var laptop = new Laptop("HP");
            var part = new LaptopPart("part", 2);

            var parts = new List<LaptopPart>() { part };
            laptop.AddPart(part);

            CollectionAssert.AreEqual(parts, laptop.Parts);
        }

        [Test]
        public void Laptop_RemovePartTest()
        {
            var laptop = new Laptop("HP");
            var part = new LaptopPart("part", 2);

            laptop.AddPart(part);
            Assert.AreEqual(1, laptop.Parts.Count);
            laptop.RemovePart(part.Name);
            Assert.AreEqual(0, laptop.Parts.Count);
        }

        [Test]
        public void Laptop_RemovePart_ThrowsExceptions()
        {
            var laptop = new Laptop("HP");
            var part = new LaptopPart("part", 2);

            laptop.AddPart(part);
            Assert.Throws<ArgumentException>(() => laptop.RemovePart(null))
                .Message.Equals("Part name cannot be null or empty!");
            Assert.Throws<ArgumentException>(() => laptop.RemovePart(""))
                .Message.Equals("Part name cannot be null or empty!");
            Assert.Throws<InvalidOperationException>(() => laptop.RemovePart("notExisting"))
                .Message.Equals("You cannot remove part which does not exist!");
        }

        [Test]
        public void DeviceRepairMethod_Test()
        {
            var pc = new PC("pc");
            var phone = new Phone("phone");
            var laptop = new Laptop("laptop");
            pc.AddPart(pcPart);
            phone.AddPart(phonePart);
            laptop.AddPart(laptopPart);

            pc.RepairPart("pcPart");
            phone.RepairPart("phonePart");
            laptop.RepairPart("laptopPart");

            Assert.That(pcPart.IsBroken == false);
            Assert.That(laptopPart.IsBroken == false);
            Assert.That(phonePart.IsBroken == false);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void DeviceRepairMethod_ArgumentException(string name)
        {
            var laptop = new Laptop("laptop");

            Assert.Throws<ArgumentException>(() => laptop.RepairPart(name))
                .Message.Equals("Part name cannot be null or empty!");
        }

        [Test]
        [TestCase("notExisting", "You cannot repair part which does not exist!")]
        [TestCase("laptopPart", "You cannot repair part which is not broken!")]
        public void DeviceRepairMethod_InvalidOperationExceptions(string partName, string message)
        {
            var laptop = new Laptop("laptop");
            laptop.AddPart(new LaptopPart("laptopPart", 1.5m, false));

            Assert.Throws<InvalidOperationException>(() => laptop.RepairPart(partName))
                .Message.Equals(message);
        }
    }
}