﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCG.Core.Cards;
using TCG.Core.Game;
using TCG.Core.Game.Utils;
using System;

namespace TCG.UnitTests
{
    [TestClass]
    public class BattlefieldUtilsTests
    {
        private Battlefield _battlefield;

        private void Init()
        {
            CreatureType dragonType;
            Enum.TryParse("Dragon", false, out dragonType);

            var human = new CreatureCard(
                name: "Human knight",
                description: "",
                rarity: CardRarity.Common,
                cost: 4,
                attack: 4,
                health: 5,
                type: CreatureType.Humanoid);

            var undeadHuman = new CreatureCard(
                name: "Undead knight",
                description: "",
                rarity: CardRarity.Common,
                cost: 4,
                attack: 4,
                health: 5,
                type: CreatureType.Humanoid | CreatureType.Undead);

            var undead = new CreatureCard(
                name: "Ghoul",
                description: "",
                rarity: CardRarity.Common,
                cost: 3,
                attack: 3,
                health: 3,
                type: CreatureType.Undead);

            var player1Creatures = new List<SummonedCreature>
            {
                new SummonedCreature(human),
                new SummonedCreature(undead)
            };
            var player2Creatures = new List<SummonedCreature>
            {
                new SummonedCreature(undeadHuman)
            };
            var player1 = new Player(name: "", health: 100, cards: null, summonedCreatures: player1Creatures);
            var player2 = new Player(name: "", health: 100, cards: null, summonedCreatures: player2Creatures);
            _battlefield = new Battlefield(player1, player2);
        }

        [TestMethod]
        public void GetCreaturesByType_PassORFlags_ReturnsCreaturesWithBothTypes()
        {
            Init();

            var expected = _battlefield.Player2.SummonedCreatures.ToList();
            var actual = _battlefield.GetCreatures(CreatureType.Humanoid | CreatureType.Undead).ToList();

            CollectionAssert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GetCreaturesByType_Pass2Types_ReturnsCreaturesOfAnyType()
        {
            Init();

            var expected = _battlefield.GetCreatures().ToList();
            var actual = _battlefield.GetCreatures(CreatureType.Humanoid, CreatureType.Undead).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
