using System;

namespace TCG.Core.Cards
{
    public class CreatureCard : Card
    {
        public int InitialAttack { get; set; }
        public int InitialHealth { get; set; }
        public CreatureType Type { get; set; }

        public CreatureCard(string name, string description, CardRarity rarity, int cost, int attack, int health, CreatureType type)
            : base(name, description, rarity, cost)
        {
            InitialAttack = attack;
            InitialHealth = health;
            Type = type;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CreatureCard))
            {
                return false;
            }
            var card = obj as CreatureCard;
            return InitialAttack == card.InitialAttack
                   && InitialHealth == card.InitialHealth
                   && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return InitialAttack.GetHashCode() + InitialHealth.GetHashCode()*128 + base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() 
                + String.Format("InitialAttack: {0};\r\n InitialLife: {1};\r\n", InitialAttack, InitialHealth);
        }
    }
}
