using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCG.Core.Cards
{
    public abstract class Card
    {
        private readonly string _name;
        private readonly string _description;
        private readonly CardRarity _rarity;
        private readonly int _cost;

        public string Name { get { return _name; } }
        public string Description { get { return _description; } }
        public CardRarity Rarity { get { return _rarity; } }

        public int Cost
        {
            get { return _cost; }
        }

        protected Card(string name, string description, CardRarity rarity, int cost)
        {
            _name = name;
            _description = description;
            _rarity = rarity;
            _cost = cost;
        }
    }
}
