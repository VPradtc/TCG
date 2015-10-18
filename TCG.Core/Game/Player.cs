using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCG.Core.Cards;

namespace TCG.Core.Game
{
    public class Player : IAttackTarget
    {
        private readonly ICollection<Card> _cards;
        private readonly ICollection<SummonedCreature> _summonedCreatures;
        private readonly string _name;

        public string Name
        {
            get { return _name; }
        }

        public int Health { get; private set; }

        public ICollection<Card> Cards
        {
            get { return _cards; }
        }

        public ICollection<SummonedCreature> SummonedCreatures
        {
            get { return _summonedCreatures; }
        }

        public Player(string name, int health, ICollection<Card> cards, ICollection<SummonedCreature> summonedCreatures)
        {
            _cards = cards;
            _summonedCreatures = summonedCreatures;
            _name = name;
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health >= 0 && Deceased != null) { Deceased.Invoke(this, new EventArgs()); }
        }

        public event EventHandler Deceased;
    }
}
