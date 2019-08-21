using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("name", 20, 20);
        }

        [Test]
        public void Constructor_Sets_PropertiesValues()
        {

            Assert.AreEqual("name", warrior.Name);
            Assert.AreEqual(20, warrior.Damage);
            Assert.AreEqual(20, warrior.HP);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void NameProperty_ThrowsException_IfEmptyOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 20, 20))
                .Message.Equals("Name should not be empty or whitespace!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void DamageProperty_ThrowsException_IfZeroOrNegativeValue(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("name", damage, 20))
                .Message.Equals("Damage value should be positive!");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        public void HP_Property_ThrowsException_IfNegativeValue(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("name", 20, hp))
                .Message.Equals("HP should not be negative!");
        }

        [Test]
        [TestCase(10)]
        [TestCase(29)]
        public void AttackMethod_ThrowsException_IfHpLessThanMinAttackHp(int hp)
        {
            int MIN_ATTACK_HP = 30;
            var warrior = new Warrior("name", 20, hp);
            var enemy = new Warrior("target", 20, 50);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy))
                .Message.Equals("Your HP is too low in order to attack other warriors!");
        }

        [Test]
        [TestCase(10)]
        [TestCase(29)]
        public void AttackMethod_ThrowsException_If_Enemy_HpLessThanMinAttackHp(int hp)
        {
            int MIN_ATTACK_HP = 30;
            var warrior = new Warrior("name", 20, 50);
            var enemy = new Warrior("target", 20, hp);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy))
                .Message.Equals($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }

        [Test]
        [TestCase(30, 31)]
        [TestCase(50, 51)]
        public void AttackMethod_ThrowsException_If_AttackerHP_Less_Than_EnemyDamage(int hp, int enemyDamage)
        {
            var warrior = new Warrior("name", 20, hp);
            var enemy = new Warrior("target", enemyDamage, 30);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy))
                .Message.Equals($"You are trying to attack too strong enemy");
        }

        [Test]
        [TestCase(50, 40)]
        [TestCase(60, 50)]
        public void AttackMethod_Reduces_AttackerHP_With_EnemyDamage(int hp, int enemyDamage)
        {
            var warrior = new Warrior("name", 40, hp);
            var enemy = new Warrior("target", enemyDamage, 40);

            warrior.Attack(enemy);
            Assert.AreEqual(10, warrior.HP);
        }

        [Test]
        [TestCase(41, 40)]
        [TestCase(60, 50)]
        public void AttackMethod_Sets_EnemyHP_ToZero_IfAttackerDamageMore_ThanEnemyHP(int attackerDamage, int enemyHP)
        {
            var warrior = new Warrior("name", attackerDamage, 50);
            var enemy = new Warrior("target", 30, enemyHP);

            warrior.Attack(enemy);
            Assert.AreEqual(0, enemy.HP);
        }

        [Test]
        [TestCase(50, 100)]
        [TestCase(40, 50)]
        public void AttackMethod_Reduces_EnemyHP_With_AttackerDamage(int attackerDamage, int enemyHP)
        {
            var warrior = new Warrior("name", attackerDamage, 50);
            var enemy = new Warrior("target", 30, enemyHP);

            warrior.Attack(enemy);
            Assert.AreEqual(enemyHP - attackerDamage, enemy.HP);
        }

        [Test]
        public void Test_Attack_First_Exception()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 30);
            Warrior warrior2 = new Warrior("Name2", 10, 10);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void Test_Attack_Second_Exception()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 40);
            Warrior warrior2 = new Warrior("Name2", 10, 10);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void Test_Attack_Third_Exception()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 40);
            Warrior warrior2 = new Warrior("Name2", 50, 40);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }
    }
}