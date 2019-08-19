namespace Skeleton.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DummyTests
    {
        private Hero hero;

        [SetUp]
        public void SetUp()
        {
            this.hero = new Hero("Pesho", new Axe(10,10));
        }

        [Test]
        public void Dummy_LosesHealthIfAttacked()
        {
            //Arrange
            var dummy = new Dummy(15, 15);

            //Act
            hero.Attack(dummy);

            //Assert
            Assert.That(dummy.Health == 5);
        }

        [Test]
        public void DeadDummy_ThrowsExceptionIfAttacked()
        {
            //Arrange
            var dummy = new Dummy(0, 15);

            //Act
            //Assert
            Assert.That(() => hero.Attack(dummy), Throws.InvalidOperationException
                     .With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        [TestCase(5, 5)]
        [TestCase(10, 10)]
        public void DeadDummy_CanGiveXP(int experience, int result)
        {
            //Arrange
            var dummy = new Dummy(5, experience);

            //Act
            hero.Attack(dummy);
            //Assert
            Assert.AreEqual(dummy.GiveExperience(), result);
        }

        [Test]
        [TestCase(11)]
        [TestCase(100)]
        public void AliveDummy_CannotGiveXP(int health)
        {
            //Arrange
            var dummy = new Dummy(health, 10);

            //Act
            hero.Attack(dummy);

            //Assert
            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException
                .With.Message.EqualTo("Target is not dead.")); 
        }
    }
}