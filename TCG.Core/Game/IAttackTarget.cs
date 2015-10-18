using System;

namespace TCG.Core.Game
{
    public interface IAttackTarget
    {
        void TakeDamage(int damage);

        event EventHandler Deceased;
    }
}
