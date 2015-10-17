using System;

namespace TCG.Core.Cards
{
    [Flags]
    public enum CreatureType
    {
        None =      0,
        Humanoid =  1,
        Undead =    1 << 1,
        Beast =     1 << 2,
        Dragon =    1 << 3,
    }
}
