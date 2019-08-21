using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("make","model", 10, 20);
        }

        [Test]
        public void Constructor_SetsValues()
        {
            Assert.AreEqual("make", car.Make);
            Assert.AreEqual("model", car.Model);
            Assert.AreEqual(10, car.FuelConsumption);
            Assert.AreEqual(20, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Make_NullOrEmpty_ThrowsException(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "model", 10, 20))
                .Message.Equals("Make cannot be null or empty!");
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Model_NullOrEmpty_ThrowsException(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", model, 10, 20))
                .Message.Equals("Model cannot be null or empty!");
        }

        [Test]
        [TestCase(-5.5)]
        [TestCase(0)]
        public void FuelConsumption_ZeroOrNegative_ThrowsException(double consumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", consumption, 20))
                .Message.Equals("Fuel consumption cannot be zero or negative!");
        }

        [Test]
        [TestCase(-5.5)]
        [TestCase(0)]
        public void FuelCapacity_ZeroOrNegative_ThrowsException(double capacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", 20, capacity))
                .Message.Equals("Fuel capacity cannot be zero or negative!"); ;
        }

        [Test]
        [TestCase(20.1)]
        [TestCase(100)]
        public void Refuel_Method_MakesFuelAmount_EqualToCapacity_IfAddedTooBig_Amount(double amount)
        {
            car.Refuel(amount);

            Assert.AreEqual(car.FuelAmount, car.FuelCapacity);
        }

        //ArgumentException("Fuel capacity cannot be zero or negative!");
        [Test]
        [TestCase(1.2)]
        [TestCase(10)]
        public void Refuel_Method_IncreasesFuelAmount(double amount)
        {
            var newAmount = car.FuelAmount + amount;
            car.Refuel(amount);

            Assert.AreEqual(newAmount, car.FuelAmount);
        }

        [Test]
        [TestCase(-1.2)]
        [TestCase(0)]
        public void Refuel_Method_ThrowsException_IfAmount_ZeroOrNegative(double amount)
        {
            var newAmount = car.FuelAmount + amount;

            Assert.Throws<ArgumentException>(() => car.Refuel(amount))
                .Message.Equals("Fuel amount cannot be zero or negative!");
        }

        [Test]
        [TestCase(10.2)]
        [TestCase(30)]
        public void Drive_Method_Reduces_FuelAmount(double distance)
        {
            car.Refuel(20);
            double fuelNeeded = (distance / 100) * car.FuelConsumption;
            var newAmount = car.FuelAmount - fuelNeeded;
            car.Drive(distance);

            Assert.AreEqual(newAmount, car.FuelAmount);
        }

        [Test]
        [TestCase(10.2)]
        [TestCase(30)]
        public void Drive_Method_ThrowsException_WhenNotEnoughFuel(double distance)
        {
            car.Refuel(1);
            double fuelNeeded = (distance / 100) * car.FuelConsumption;
            var newAmount = car.FuelAmount - fuelNeeded;

            Assert.Throws<InvalidOperationException>(() => car.Drive(distance))
                .Message.Equals("You don't have enough fuel to drive!");
        }
    }
}