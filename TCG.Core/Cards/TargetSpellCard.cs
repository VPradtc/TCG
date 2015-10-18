using System;
using TCG.Core.Game;

namespace TCG.Core.Cards
{
    public class TargetSpellCard : Card, ITargetAbility
    {
        private readonly Action<IAttackTarget> _spell;

        public TargetSpellCard(string name, string description, CardRarity rarity, int manacost, Action<IAttackTarget> spell)
            : base(name, description, rarity, manacost)
        {
            _spell = spell;
        }

        public void Cast(IAttackTarget target)
        {
            if (_spell != null)
            {
                _spell.Invoke(target);
            }
        }
    }
}
