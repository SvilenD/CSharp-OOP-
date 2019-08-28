namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;

    public class ProductTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Costruct_ShouldSetCorrectValues()
        {
            //Arrange
            string label = "test";
            decimal price = 1.23m;
            int quantity = 1;

            //Act
            IProduct product = new Product(label, price, quantity);

            //Assert
            Assert.AreEqual(product.Label, label);
            Assert.AreEqual(product.Price, price);
            Assert.AreEqual(product.Quantity, quantity);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Costruct_ShouldThrowArgumentException_WhenLabelNullOrEmpty(string label)
        {
            decimal price = 1.23m;
            int quantity = 1;

            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => new Product(label, price, quantity))
                .Message.Equals("Invalid label.");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5.5)]
        public void Costruct_ShouldThrowArgumentException_WhenNegativePrice(decimal price)
        {
            //Arrange
            string label = "test";
            int quantity = 1;

            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(label, price, quantity))
                .Message.Equals("Price should have a positive value");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void Costruct_ShouldThrowArgumentException_WhenNegativeQuantity(int quantity)
        {
            //Arrange
            string label = "test";
            decimal price = 1.23m;

            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(label, price, quantity))
                .Message.Equals("Quantity should be positive.");
        }

        [Test]
        [TestCase("a", "b")]
        [TestCase("A", "a")]
        [TestCase("NGFDSGJS", "njsnoa")]
        public void CompareToMethod_Returns_ProductWithLabelThatHasBiggerASCIIcodeValue(string small, string bigger)
        {
            //Arrange
            IProduct smallerProduct = new Product(small, 1.2m, 1);
            IProduct biggerProduct = new Product(bigger, 1.2m, 1);

            //Act
            int value = biggerProduct.CompareTo(smallerProduct);

            //Assert
            Assert.IsTrue(value == 1);
        }
    }
}