namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class ProductStockTests
    {
        private ProductStock productStock;

        [SetUp]
        public void Setup()
        {
            this.productStock = new ProductStock();
        }

        [Test]
        public void Construct_ShouldInitializeTheArray()
        {
            Assert.AreEqual(0, productStock.Count);
        }

        [Test]
        [TestCase("first")]
        [TestCase("second")]
        public void AddMethod_ShouldAddProductsIfLabelIsUnique(string label)
        {
            var product0 = new Product(label, 1.20m, 1);
            var product1 = new Product("other", 1.20m, 1);

            productStock.Add(product0);
            productStock.Add(product1);

            Assert.AreEqual(product0, productStock[0]);
            Assert.AreEqual(product1, productStock[1]);
            Assert.AreEqual(2, productStock.Count);
        }

        [Test]
        public void AddMethod_ShouldAddProductsIfLabelIsUnique()
        {
            var product = new Product("product", 1.20m, 1);

            productStock.Add(product);
            productStock.Add(product);

            Assert.AreEqual(product.Quantity * 2, productStock[0].Quantity);
            Assert.AreEqual(1, productStock.Count);
        }

        [Test]
        public void AddMethod_ShouldThrowArgumentNullException_IfProducsIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => productStock.Add(null))
                .Message.Equals("Product cannot be null.");
        }

        [Test]
        [TestCase(3)]
        [TestCase(8)]
        [TestCase(22)]
        public void ProductStockArray_ShouldResizeIfProductsMoreThanCurrentSize(int size)
        {
            for (int i = 0; i < size; i++)
            {
                var product = new Product("product" + i, 1.20m, 1);

                productStock.Add(product);
            }

            Assert.AreEqual(size, productStock.Count);
        }

        [Test]
        [TestCase("label")]
        public void ContainsMethodReturnsProductIfExists(string label)
        {
            var product = new Product(label, 1.2m, 1);
            var otherProduct = new Product("other", 2.2m, 2);
            productStock.Add(product);
            productStock.Add(otherProduct);

            Assert.That(productStock.Contains(product));
        }

        [Test]
        public void ContainsMethod_ReturnsFalseIfNotExist()
        {
            var product = new Product("old", 1.2m, 1);
            var otherProduct = new Product("other", 2.2m, 2);
            productStock.Add(product);

            Assert.That(productStock.Contains(otherProduct) == false);
        }

        [Test]
        public void CountMethod_ReturnsCorrectValue()
        {
            Assert.AreEqual(0, productStock.Count);

            productStock.Add(new Product("new", 1, 1));
            Assert.AreEqual(1, productStock.Count);
        }

        [Test]
        public void FindMethod_Returns_ProductOnGivenIndexIfExists()
        {
            productStock.Add(new Product("bb", 1, 1));
            productStock.Add(new Product("bsaads", 2, 1));

            var productIndex0 = productStock.Find(0);
            var productIndex1 = productStock.Find(1);

            Assert.AreEqual(productIndex0, productStock[0]);
            Assert.AreEqual(productIndex1, productStock[1]);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(10)]
        public void FindMethod_Returns_IndexOutOfRangeExceptionIfInvalidIndex(int index)
        {
            productStock.Add(new Product("bb", 1, 1));
            productStock.Add(new Product("bsaads", 2, 1));

            Assert.Throws<IndexOutOfRangeException>(() => productStock.Find(index))
                .Message.Equals("Invalid index!");
        }

        [Test]
        public void FindByLabel_Returns_ProductIfExists()
        {
            productStock.Add(new Product("bb", 1, 1));
            productStock.Add(new Product("bsaads", 2, 1));

            var productIndex0 = productStock.Find(0);
            var productIndex1 = productStock.Find(1);

            Assert.AreEqual(productIndex0, productStock[0]);
            Assert.AreEqual(productIndex1, productStock[1]);
        }

        [Test]
        [TestCase("hhh")]
        [TestCase("afafs")]
        public void FindByLabel_ThrowsException_ProductIfProductNotExist(string label)
        {
            productStock.Add(new Product("1", 1, 1));
            productStock.Add(new Product("2", 2, 1));

            Assert.Throws<NullReferenceException>(() => productStock.FindByLabel(label));
        }

        [Test]
        [TestCase(1.1, 5.5)]
        [TestCase(0.1, 2.5)]
        [TestCase(10, 100)]
        public void FindAllInPriceRange_ReturnsProductsOrEmptyCollection(decimal min, decimal max)
        {
            var productsInRange = new List<IProduct>();

            for (int i = 0; i < 2; i++)
            {
                var product = new Product($"{i}", 1.1m, 1);
                productStock.Add(product);

                if (product.Price >= min && product.Price <= max)
                {
                    productsInRange.Add(product);
                }
            }

            var productsFound = productStock.FindAllInRange(min, max);

            CollectionAssert.AreEqual(productsFound, productsInRange);
        }

        [Test]
        [TestCase(1.1)]
        [TestCase(2.5)]
        public void FindAllByPrice_ReturnsProductsOrEmptyCollection(decimal targetPrice)
        {
            var productsWithPrice = new List<IProduct>();

            for (int i = 0; i < 3; i++)
            {
                var product = new Product($"{i}", 1.1m, 1);
                productStock.Add(product);

                if (product.Price == targetPrice)
                {
                    productsWithPrice.Add(product);
                }
            }

            var productsFound = productStock.FindAllByPrice(targetPrice);

            CollectionAssert.AreEqual(productsFound, productsWithPrice);
        }

        [Test]
        public void FindMostExpensiveProducts_ReturnsProductsWithHighestPrice()
        {
            var price = 1.2m;

            for (int i = 0; i < 3; i++)
            {
                var product = new Product($"{i}", price * (i + 1), 1);
                productStock.Add(product);
            }
            for (int i = 3; i > 0; i--)
            {
                var product = new Product($"{i}m", price * (i + 7), i);
                productStock.Add(product);
            }

            var mostExpensive = productStock.FindMostExpensiveProduct();
            var expected = new Product("3m", 10 * price, 3);

            Assert.AreEqual(expected.Price, mostExpensive.Price);
            Assert.AreEqual(expected.Label, mostExpensive.Label);
            Assert.AreEqual(expected.Quantity, mostExpensive.Quantity);
        }

        [Test]
        [TestCase(12)]
        [TestCase(2)]
        public void FindAllByQuantity_ReturnsProductsOrEmptyCollection(int quantity)
        {
            var productsWithQuantity = new List<IProduct>();

            for (int i = 0; i <= 3; i++)
            {
                var product = new Product($"{i} product", 1.1m, i + 1);
                var product2 = new Product($" product{i}", 2.2m, i + 2);
                productStock.Add(product);
                productStock.Add(product2);

                if (product.Quantity == quantity)
                {
                    productsWithQuantity.Add(product);
                }
                if (product2.Quantity == quantity)
                {
                    productsWithQuantity.Add(product2);
                }
            }

            var productsFound = productStock.FindAllByQuantity(quantity);

            CollectionAssert.AreEqual(productsFound, productsWithQuantity);
        }

        [Test]
        [TestCase("exists")]
        [TestCase("exists3")]
        public void RemoveMethod_RemovesProductIfExists(string label)
        {
            productStock.Add(new Product("exists", 2.2m, 3));
            productStock.Add(new Product("exists2", 12.2m, 23));
            productStock.Add(new Product("exists3", 22.2m, 33));
            productStock.Add(new Product("exists4", 2.2m, 7));

            Assert.That(productStock.Count == 4);
            
            var productToRemove = new Product(label, 2.2m, 3);

            Assert.IsTrue(productStock.Remove(productToRemove));
            Assert.AreEqual(productStock.Count, 3);
        }

        [Test]
        [TestCase("notExists")]
        [TestCase("notExists3")]
        public void RemoveMethod_ReturnsFalseWhenProductNotExists(string label)
        {
            productStock.Add(new Product("exists", 2.2m, 3));
            productStock.Add(new Product("exists2", 12.2m, 23));
            productStock.Add(new Product("exists3", 22.2m, 33));
            productStock.Add(new Product("exists4", 2.2m, 7));

            Assert.That(productStock.Count == 4);

            var productToRemove = new Product(label, 2.2m, 3);

            Assert.IsFalse(productStock.Remove(productToRemove));
            Assert.AreEqual(productStock.Count, 4);
        }

        [Test]
        public void GetEnumerator_ReturnsAllProducts()
        {
            var price = 1.2m;
            var productsAdded = new List<IProduct>();
            for (int i = 0; i < 3; i++)
            {
                var product = new Product($"{i}", price * (i + 1), 1);
                productStock.Add(product);
                productsAdded.Add(product);
            }

            foreach (var product in productStock)
            {
                Assert.That(productsAdded.Contains(product));
            }

            CollectionAssert.AreEqual(productsAdded, productStock);
        }

        [Test]
        public void Indexer_ReturnsItem_IfExists()
        {
            var test = new Product("test", 1, 1);
            productStock[0] = test;

            Assert.That(productStock[0].Label == "test");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(10)]
        public void Indexer_ThrowsException_IfInvalidIndex(int index)
        {
            IProduct test = new Product("test", 1, 1);
            productStock[0] = test;

            Assert.Throws<IndexOutOfRangeException>(() => test = productStock[index]);
        }
    }
}