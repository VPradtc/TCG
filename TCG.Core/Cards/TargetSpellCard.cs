using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCG.Core.Game;

namespace TCG.Core.Cards
{
    public struct TargetSpellCard : Card, ITargetAbility
    {
        private readonly Action<IAttackTarget> _spell;

        public TargetSpellCard(string name, string description, CardRarity rarity, int manacost, Action<IAttackTarget> spell)
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

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public CardRarity Rarity
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Manacost
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
