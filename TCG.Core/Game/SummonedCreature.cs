using System;
using TCG.Core.Cards;

namespace TCG.Core.Game
{
    public class SummonedCreature : IAttackTarget
    {
        public CreatureCard Card { get; private set; }
        public int CurrentHealth { get; private set; }
        public int CurrentAttack { get; private set; }

        public SummonedCreature(CreatureCard card)
        {
            Card = card;
            CurrentHealth = card.InitialHealth;
            CurrentAttack = card.InitialAttack;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                if (Deceased != null) Deceased.Invoke(this, new EventArgs());
            }
        }

        public event EventHandler Deceased;
    }
}
