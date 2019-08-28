using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using INStock.Contracts;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private const int INITIAL_Size = 4;
        private IProduct[] products;
        private int index;

        public ProductStock()
        {
            this.products = new IProduct[INITIAL_Size];
            this.index = 0;
        }

        public IProduct this[int index]
        {
            get
            {
                return products[index];
            }
            set
            {
                if (index < 0 || index > this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                this.products[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return this.products.Count(p => p != null);
            }
        }

        public void Add(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product cannot be null.");
            }
            if (index == products.Length)
            {
                IncreaseArraySize();
            }
            if (this.Contains(product))
            {
                ReplaceOldProduct(product);
            }
            else
            {
                this.products[index] = product;
                index++;
            }
        }


        public bool Contains(IProduct product)
        {
            return this.products.Where(p => p != null).Any(p => p.Label == product.Label);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException("Invalid index!");
            }

            return this.products[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return this.products.Where(p => p != null).Where(p => p.Price == price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return this.products.Where(p => p != null)
                .Where(p => p.Quantity == quantity);
        }

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
        {
            return products.Where(p => p != null)
                .Where(p => p.Price >= lo && p.Price <= hi)
                .OrderByDescending(p => p.Price);
        }

        public IProduct FindByLabel(string label)
        {
            return this.products.FirstOrDefault(p => p.Label == label);
        }

        public IProduct FindMostExpensiveProduct()
        {
            return this.products.Where(p => p != null).OrderByDescending(p => p.Price).FirstOrDefault();
        }

        public bool Remove(IProduct product)
        {
            var productToFind = this.FindByLabel(product.Label);

            if (productToFind == null)
            {
                return false;
            }
            var index = Array.IndexOf(this.products, productToFind);

            this.products[index] = null;

            return true;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] != null)
                {
                    yield return products[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void IncreaseArraySize()
        {
            var newLength = this.products.Length * 2;
            var newProductsArray = new IProduct[newLength];
            Array.Copy(this.products, newProductsArray, this.products.Length);

            this.products = newProductsArray;
        }
        private void ReplaceOldProduct(IProduct product)
        {
            var oldProduct = this.FindByLabel(product.Label);
            var combinedQuantity = oldProduct.Quantity + product.Quantity;
            var newProduct = new Product(oldProduct.Label, oldProduct.Price, combinedQuantity);

            var oldProductIndex = Array.IndexOf(products, oldProduct);
            this.products[oldProductIndex] = newProduct;
        }
    }
}