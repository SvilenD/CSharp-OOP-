namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private Car car;
        private SoftPark parking;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("make", "regNum");
            this.parking = new SoftPark();
        }

        [Test]
        public void Constructor_CreatesNewCarWithGivenParameters()
        {
            Assert.That(car.Make == "make");
            Assert.That(car.RegistrationNumber == "regNum");
        }

        [Test]
        public void Construct_CreatesNewParking()
        {
            Assert.That(parking.Parking.Count == 12);
        }

        [Test]
        public void ParkCarMethod_ParksCarIsNotParkedAndPlaceIsFree()
        {
            var result = parking.ParkCar("A1", car);

            StringAssert.AreEqualIgnoringCase(result, $"Car:{car.RegistrationNumber} parked successfully!");
        }

        [Test]
        public void ParkCarMethod_ThrowException_WhenCarIfCarIsAlreadyParked()
        {
            parking.ParkCar("A1", car);
            var result =

            Assert.Throws<InvalidOperationException>(() => parking.ParkCar("A2", car))
            .Message.Equals("Car is already parked!");
        }

        [Test]
        [TestCase("w2")]
        [TestCase("d20")]
        public void ParkCarMethod_ThrowException_IfParkingSpotDoesnotExist(string spot)
        {
            Assert.Throws<ArgumentException>(() => parking.ParkCar(spot, car))
            .Message.Equals("Parking spot doesn't exists!");
        }

        [Test]
        [TestCase("A1")]
        [TestCase("A2")]
        public void ParkCarMethod_ThrowException_IfParkingIsAlreadyTaken(string spot)
        {
            parking.ParkCar("A1", new Car("car", "number"));
            parking.ParkCar("A2", new Car("car2", "number2"));

            Assert.Throws<ArgumentException>(() => parking.ParkCar(spot, car))
            .Message.Equals("Parking spot is already taken!");
        }

        [Test]
        [TestCase("W1")]
        [TestCase("A20")]
        public void RemoveCarMethod_ThrowException_IfParkingSpotNotExists(string spot)
        {
            Assert.Throws<ArgumentException>(() => parking.RemoveCar(spot, car))
            .Message.Equals("Parking spot doesn't exists!");
        }

        [Test]
        [TestCase("D1")]
        [TestCase("A2")]
        public void RemoveCarMethod_ThrowException_IfCarIsNotOnGivenSpot(string spot)
        {
            parking.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(() => parking.RemoveCar(spot, car))
            .Message.Equals("Car for that spot doesn't exists!");
        }

        [Test]
        [TestCase("C1")]
        [TestCase("A2")]
        public void RemoveCarMethod_RemovesCarFromParkingSuccessfully(string spot)
        {
            parking.ParkCar(spot, car);

            Assert.That(parking
                .RemoveCar(spot, car) == $"Remove car:{car.RegistrationNumber} successfully!");
        }
    }
}
