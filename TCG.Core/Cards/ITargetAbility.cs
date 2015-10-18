using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCG.Core.Game;

namespace TCG.Core.Cards
{
    public interface ITargetAbility : IPlayable
    {
        void Cast(IAttackTarget target);
    }
}
