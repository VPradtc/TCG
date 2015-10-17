using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCG.Core.Cards
{
    public interface IAttackTarget
    {
        void TakeDamage(int damage);
    }
}
