using NUnit.Framework;
using Service.Models.Parts;
using System;

namespace Tests
{
    public class PartTests
    {
        private LaptopPart laptopPart;
        private LaptopPart laptopPart2;

        [SetUp]
        public void Setup()
        {
            this.laptopPart = new LaptopPart("aaa", 100);
            this.laptopPart2 = new LaptopPart("bbb", 200, true);
        }

        [Test]
        public void LaptopPart_ConstructorTest()
        {
            Assert.AreEqual("aaa", laptopPart.Name);
            Assert.AreEqual("bbb", laptopPart2.Name);
            Assert.AreEqual(150, laptopPart.Cost);
            Assert.AreEqual(300, laptopPart2.Cost);
            Assert.AreEqual(false, laptopPart.IsBroken);
            Assert.AreEqual(true, laptopPart2.IsBroken);
        }

        [Test]
        public void PC_Part_ConstructorTest()
        {
            var pcPart = new PCPart("aaa", 100);
            var pcPart2 = new PCPart("bbb", 200, true);

            Assert.AreEqual("aaa", pcPart.Name);
            Assert.AreEqual("bbb", pcPart2.Name);
            Assert.AreEqual(120, pcPart.Cost);
            Assert.AreEqual(240, pcPart2.Cost);
            Assert.AreEqual(false, pcPart.IsBroken);
            Assert.AreEqual(true, pcPart2.IsBroken);
        }

        [Test]
        public void Phone_Part_ConstructorTest()
        {
            var phonePart = new PhonePart("aaa", 100);
            var phonePart2 = new PhonePart("bbb", 200, true);

            Assert.AreEqual("aaa", phonePart.Name);
            Assert.AreEqual("bbb", phonePart2.Name);
            Assert.AreEqual(130, phonePart.Cost);
            Assert.AreEqual(260, phonePart2.Cost);
            Assert.AreEqual(false, phonePart.IsBroken);
            Assert.AreEqual(true, phonePart2.IsBroken);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void PartConstruct_Exception_IfNameNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() => new LaptopPart(name, 5))
                .Message.Equals("Part name cannot be null or empty!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10.6)]
        public void PartConstruct_Exception_IfPriceZeroOrNegative(decimal price)
        {
            Assert.Throws<ArgumentException>(() => new LaptopPart("name", price))
                .Message.Equals("Part cost cannot be zero or negative!");
        }

        [Test]
        public void Laptop_Part_ReportTest()
        {
            Assert.AreEqual("aaa - 150.00$" + Environment.NewLine +
                $"Broken: False", laptopPart.Report());
            Assert.AreEqual("bbb - 300.00$" + Environment.NewLine +
                $"Broken: True", laptopPart2.Report());
        }

        [Test]
        public void Phone_Part_ReportTest()
        {
            var phonePart = new PhonePart("aaa", 100);
            var phonePart2 = new PhonePart("bbb", 200, true);

            Assert.AreEqual("aaa - 130.00$" + Environment.NewLine +
                $"Broken: False", phonePart.Report());
            Assert.AreEqual("bbb - 260.00$" + Environment.NewLine +
                $"Broken: True", phonePart2.Report());
        }

        [Test]
        public void PC_Part_ReportTest()
        {
            var pcPart = new PCPart("aaa", 100);
            var pcPart2 = new PCPart("bbb", 200, true);

            Assert.AreEqual("aaa - 120.00$" + Environment.NewLine +
                $"Broken: False", pcPart.Report());
            Assert.AreEqual("bbb - 240.00$" + Environment.NewLine +
                $"Broken: True", pcPart2.Report());
        }

        [Test]
        public void Part_RepairMethod()
        {
            var phonePartBroken = new PhonePart("name", 1, true);
            var pcPartBroken = new PhonePart("name2", 1, true);
            var laptopPartBroken = new PhonePart("name3", 1, true);
            var laptopPart = new PhonePart("name3", 1, false);

            Assert.That(laptopPart.IsBroken == false);
            Assert.That(laptopPartBroken.IsBroken == true);
            Assert.That(phonePartBroken.IsBroken == true);
            Assert.That(pcPartBroken.IsBroken == true);

            laptopPart.Repair();
            laptopPartBroken.Repair();
            phonePartBroken.Repair();
            pcPartBroken.Repair();

            Assert.That(laptopPart.IsBroken == false);
            Assert.That(laptopPartBroken.IsBroken == false);
            Assert.That(phonePartBroken.IsBroken == false);
            Assert.That(pcPartBroken.IsBroken == false);
        }
    }
}