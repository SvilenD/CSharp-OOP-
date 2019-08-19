namespace Skeleton.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class AxeTests
    {
        [SetUp] // before every test
        public void Setup()
        {
        }

        [TearDown] //after every test
        public void TearDown()
        {
        }

        [Test]
        public void AxeCtorValuesSetToProperties()
        {
            var axe = CreateAxe(10, 10);

            Assert.AreEqual(10, axe.AttackPoints, "attack points are wrong"); //insert comment on test result
            Assert.That(axe.DurabilityPoints, Is.EqualTo(10));
        }

        [Test] // AAA pattern
        [TestCase(10, 9)]
        [TestCase(20, 19)]
        public void Axe_Attack_DroppingDurabilityPoints(int durability, int result)
        {
            //Arrange
            var axe = CreateAxe(10, durability);
            Dummy dummy = new Dummy(10, durability);

            //Act
            axe.Attack(dummy);

            //Assert
            // asserts 1-2 max 3, when fails first stops and doesn't checks after it

            Assert.AreEqual(result, axe.DurabilityPoints);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void AxeThrowExceptionWhenAttackAndDurabilityIsZeroOrLess(int durability)
        {
            //Arrange
            var axe = CreateAxe(1, durability);
            Dummy dummy = new Dummy(10, durability);

            //Act
            //Assert
            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
        }

        private Axe CreateAxe(int health, int durability)
        {
            return new Axe(health, durability);
        }
    }
}