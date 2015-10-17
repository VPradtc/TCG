namespace TCG.Core.Cards
{
    public abstract class Card : IPlayable
    {
        private readonly string _name;
        private readonly string _description;
        private readonly CardRarity _rarity;
        private readonly int _manacost;

        public string Name { get { return _name; } }
        public string Description { get { return _description; } }
        public CardRarity Rarity { get { return _rarity; } }
        public int Manacost { get { return _manacost; } }

        protected Card(string name, string description, int manacost)
            :this(name, description, CardRarity.Common, manacost)
        {
        }

        protected Card(string name, string description, CardRarity rarity, int manacost)
        {
            _name = name;
            _description = description;
            _rarity = rarity;
            _manacost = manacost;
        }
    }
}
