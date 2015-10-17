using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCG.Core.Cards
{
    public class CreatureCard : Card
    {
        public int AttackValue { get; set; }
        public int LifeValue { get; set; }

        public CreatureCard(string name, string description, CardRarity rarity)
            : base(name, description, rarity)
        {
        }
    }
}
