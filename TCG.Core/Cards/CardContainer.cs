using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCG.Core.Cards
{
    public class CardContainer
    {
        protected static Dictionary<CardName, Card> _cards;

        public static Card GetCard(CardName cardName)
        {
            if (_cards == null)
            {
                Initialize();
            }

            if (!_cards.ContainsKey(cardName))
            {
                throw new ArgumentException("Card doesn't exist");
            }

            return _cards[cardName];
        }

        private static void Initialize()
        {
            _cards = new Dictionary<CardName, Card>()
            {
                {
                    CardName.HumanKnight,
                    new CreatureCard(
                name: "Human knight",
                description: "",
                rarity: CardRarity.Common,
                cost: 4,
                attack: 4,
                health: 5,
                type: CreatureType.Humanoid)
                },
                {
                    CardName.UndeadKnight,
                    new CreatureCard(
                name: "Undead knight",
                description: "",
                rarity: CardRarity.Common,
                cost: 4,
                attack: 4,
                health: 5,
                type: CreatureType.Humanoid | CreatureType.Undead)
                },
                {
                    CardName.Ghoul,
                    new CreatureCard(
                name: "Ghoul",
                description: "",
                rarity: CardRarity.Common,
                cost: 3,
                attack: 3,
                health: 3,
                type: CreatureType.Undead)
                },
            };
        }

        protected CardContainer()
        {

        }
    }
}
