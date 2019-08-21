using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Constructor_Creates_NewListOfWarriors()
        {
            var warriors = new List<Warrior>();
            Assert.That(this.arena.Count == 0);
            CollectionAssert.AreEqual(this.arena.Warriors, warriors);
        }

        [Test]
        public void Enroll_Method_AddsWarriors_ToList_IfNameNotExists()
        {
            this.arena.Enroll(new Warrior("name", 30, 30));

            Assert.AreEqual(1, this.arena.Count);
        }

        [Test]
        public void Enroll_Method_ThrowsException_IfWarriorNameExists()
        {
            this.arena.Enroll(new Warrior("name", 30, 30));

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(new Warrior("name", 40, 50)))
                 .Message.Equals("Warrior is already enrolled for the fights!");
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void WarriorsProperty_Returns_ListOfWarriors()
        {
            var warriorsList = new List<Warrior>();
            for (int i = 0; i < 5; i++)
            {
                var warrior = new Warrior($"name{i}", 30 + i, 40 + i);
                this.arena.Enroll(warrior);
                warriorsList.Add(warrior);
            }

            CollectionAssert.AreEqual(this.arena.Warriors, warriorsList);
        }

        [Test]
        [TestCase("notExistingAttacker", "name1")]
        public void FightMethod_ThrowsException_IfWarriorNotExists(string attackerName, string enemyName)
        {
            for (int i = 0; i < 5; i++)
            {
                var warrior = new Warrior($"name{i}", 30 + i, 40 + i);
                this.arena.Enroll(warrior);
            }

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, enemyName))
                .Message.Equals($"There is no fighter with name {attackerName} enrolled for the fights!");
        }

        [Test]
        [TestCase("name2", "notExistingEnemy")]
        public void FightMethod_ThrowsException_IfEnemyNotExists(string attackerName, string enemyName)
        {
            for (int i = 0; i < 5; i++)
            {
                var warrior = new Warrior($"name{i}", 30 + i, 40 + i);
                this.arena.Enroll(warrior);
            }

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, enemyName))
                .Message.Equals($"There is no fighter with name {enemyName} enrolled for the fights!");
        }

        [Test]
        [TestCase("name0", "name1")]
        [TestCase("name2", "name0")]
        public void FightMethod_ReducesEnemyHP(string attackerName, string enemyName)
        {
            for (int i = 0; i < 5; i++)
            {
                var warrior = new Warrior($"name{i}", 30, 40);
                this.arena.Enroll(warrior);
            }
            var enemy = this.arena.Warriors.FirstOrDefault(w => w.Name == enemyName);

            this.arena.Fight(attackerName, enemyName);
            Assert.AreEqual(10, enemy.HP);
        }
    }
}