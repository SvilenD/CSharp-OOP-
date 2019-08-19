namespace Skeleton.Tests
{
    using Moq;
    using NUnit.Framework;
    using Skeleton.Interfaces;

    [TestFixture]
    public class HeroTests
    {
        private Mock<IWeapon> fakeWeapon;
        private Hero hero;

        [SetUp]
        public void SetUp()
        {
            this.fakeWeapon = new Mock<IWeapon>();
            fakeWeapon.Setup(w => w.AttackPoints).Returns(10);
            fakeWeapon.Setup(w => w.DurabilityPoints).Returns(10);

            this.hero = new Hero("Pesho", fakeWeapon.Object);
        }

        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDies()
        {
            //Arrange
            var fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(t => t.IsDead()).Returns(true);
            fakeTarget.Setup(t => t.GiveExperience()).Returns(10);

            //Act
            hero.Attack(fakeTarget.Object);

            //Assert
            Assert.AreEqual(10, hero.Experience);
        }

        [Test]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(100)]
        public void Hero_DoesNOT_GainExperienceIfTargetIsAlive(int targetHealth)
        {
            //Arrange
            var fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(t => t.IsDead()).Returns(false);
            fakeTarget.Setup(t => t.GiveExperience()).Returns(10);

            //Act
            hero.Attack(fakeTarget.Object);

            //Assert
            Assert.That(hero.Experience == 0);
        }
    }
}