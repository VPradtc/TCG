using TCG.Core.Cards;

namespace TCG.Core.Game
{
    public class SummonedCreature : IAttackTarget
    {
        private readonly Battlefield _battlefield;

        public CreatureCard Card { get; private set; }
        public int CurrentHealth { get; private set; }
        public int CurrentAttack { get; private set; }
        public Player Owner { get; private set; }

        public SummonedCreature(CreatureCard card, Battlefield battlefield, Player owner)
        {
            Card = card;
            _battlefield = battlefield;
            CurrentHealth = card.InitialHealth;
            CurrentAttack = card.InitialAttack;
            Owner = owner;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                Decease();
            }
        }

        public void Decease()
        {
            throw new System.NotImplementedException();
        }
    }
}
