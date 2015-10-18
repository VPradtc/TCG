using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCG.Core.Cards;

namespace TCG.Core.Game
{
    public class Player
    {
        private readonly ICollection<Card> _cards;
        private readonly ICollection<SummonedCreature> _summonedCreatures;

        public string Name { get; set; }
        public int Health { get; set; }

        public ICollection<Card> Cards
        {
            get { return _cards; }
        }

        public ICollection<SummonedCreature> SummonedCreatures
        {
            get { return _summonedCreatures; }
        }

        public Player(ICollection<Card> cards, ICollection<SummonedCreature> summonedCreatures)
        {
            _cards = cards;
            _summonedCreatures = summonedCreatures;
        }
    }
}
