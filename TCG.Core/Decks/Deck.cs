using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCG.Core.Cards;

namespace TCG.Core.Decks
{
    public class Deck
    {
        private readonly ICollection<Card> _cards;

        public int MaxSize { get; set; }

        public Deck()
        {
            _cards = new List<Card>();
        }

        public ICollection<Card> GetCardsList()
        {
            return new List<Card>(_cards);
        }

        public void AddCard(Card card)
        {
            if (_cards.Count == MaxSize)
            {
                throw new InvalidOperationException("Deck is full.");
            }
            _cards.Add(card);
        }

        public void Remove(Card card)
        {
            if (!_cards.Contains(card))
            {
                throw new InvalidOperationException("That card isn't in the deck");
            }
            _cards.Remove(card);
        }
    }
}
