namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Astronaut astronaut;
        private Spaceship ship;

        [SetUp]
        public void Setup()
        {
            this.astronaut = new Astronaut("name", 5.5);
            this.ship = new Spaceship("ship", 2);
        }

        [Test]
        public void Astronaut_Ctor()
        {
            Assert.That(astronaut.Name == "name");
            Assert.That(astronaut.OxygenInPercentage == 5.5);
        }

        [Test]
        public void Spaceship_Ctor()
        {
            Assert.That(ship.Name == "ship");
            Assert.That(ship.Capacity == 2);
            Assert.That(ship.Count == 0);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Spaceship_Name_ThrowsException_IfNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(name, 5));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        public void Spaceship_Capacity_ThrowsException_IfNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("name", capacity));
        }

        [Test]
        public void Spaceship_Add_OK()
        {
            this.ship.Add(astronaut);
            Assert.That(ship.Count == 1);
        }

        [Test]
        public void Spaceship_Add_ThrowsException_IfCapacityIsFull()
        {
            this.ship.Add(astronaut);
            this.ship.Add(new Astronaut("new", 6));
            Assert.Throws<InvalidOperationException>(() => this.ship.Add(new Astronaut("new2", 5)));
        }

        [Test]
        public void Spaceship_Add_ThrowsException_IfAstronautExists()
        {
            this.ship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => this.ship.Add(astronaut));
        }

        [Test]
        public void Spaceship_Remove()
        {
            this.ship.Add(astronaut);
            this.ship.Add(new Astronaut("new", 6));

            Assert.That(this.ship.Remove("name") == true);
            Assert.That(this.ship.Remove("notExisting") == false);
            Assert.That(this.ship.Count == 1);
        }
    }
}