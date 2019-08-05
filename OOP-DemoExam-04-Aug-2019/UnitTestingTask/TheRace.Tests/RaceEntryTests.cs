using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitMotorcycle unitMotorcycle;
        private UnitRider unitRider;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
            this.unitMotorcycle = new UnitMotorcycle("model", 10, 50.5);
            this.unitRider = new UnitRider("name", this.unitMotorcycle);
        }

        [Test]
        public void Constructor_UnitMotorcycle()
        {
            Assert.That(this.unitMotorcycle.Model == "model");
            Assert.That(this.unitMotorcycle.HorsePower == 10);
            Assert.That(this.unitMotorcycle.CubicCentimeters == 50.5);
        }

        [Test]
        public void Constructor_UnitRider()
        {
            Assert.That(this.unitRider.Name == "name");
            Assert.That(this.unitRider.Motorcycle == this.unitMotorcycle);
        }

        [Test]
        public void UnitRider_Name_If_Null_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitRider(null, this.unitMotorcycle))
                .Message.Equals("Name cannot be null!");
        }

        [Test]
        public void RaceEntry_Constructor_InitiatesDictionary()
        {
            Assert.That(this.raceEntry.Counter == 0);
        }

        [Test]
        public void RaceEntry_AddMethod()
        {
            var result = raceEntry.AddRider(unitRider);

            Assert.AreEqual($"Rider {this.unitRider.Name} added in race.", result);
            Assert.AreEqual(1, this.raceEntry.Counter);
        }


        [Test]
        public void RaceEntry_AddMethod_ThrowsException_If_RiderNameExists()
        {
            this.raceEntry.AddRider(unitRider);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(unitRider))
                .Message.Equals($"Rider {this.unitRider.Name} is already added.");
        }

        [Test]
        public void RaceEntry_AddMethod_ThrowsException_If_RiderIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(null))
                .Message.Equals("Rider cannot be null.");
        }

        [Test]
        public void RaceEntry_CalculateAverageHorsePower()
        {
            var motorcycle1 = new UnitMotorcycle("1", 10, 5.5);
            var motorcycle2 = new UnitMotorcycle("2", 20, 54.5);

            var racer1 = new UnitRider("name1", motorcycle1);
            var racer2 = new UnitRider("name2", motorcycle2);

            this.raceEntry.AddRider(racer1);
            this.raceEntry.AddRider(racer2);

            Assert.AreEqual(15, raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void RaceEntry_CalculateAverageHorsePower_ThrowsException_IfRiders_Less_Than_MinParticipants()
        {
            int MinParticipants = 2;

            this.raceEntry.AddRider(this.unitRider);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower())
                .Message.Equals($"The race cannot start with less than {MinParticipants} participants.");
        }
    }
}