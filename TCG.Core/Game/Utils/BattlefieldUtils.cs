using System;
using System.Collections.Generic;
using System.Linq;
using TCG.Core.Cards;

namespace TCG.Core.Game.Utils
{
    public static class BattlefieldUtils
    {
        public static ICollection<SummonedCreature> GetCreatures(
            this Battlefield battlefield)
        {
            return battlefield
                .Player1
                .SummonedCreatures
                .Concat(
                        battlefield
                        .Player2
                        .SummonedCreatures)
                .ToList();
        }

        public static ICollection<SummonedCreature> GetCreatures(
            this Battlefield battlefield,
            Predicate<SummonedCreature> condition)
        {
            if (condition == null)
            {
                return battlefield.GetCreatures();
            }
            return battlefield
                .GetCreatures()
                .Where(x => condition(x))
                .ToList();
        }

        public static ICollection<SummonedCreature> GetCreatures(
            this Battlefield battlefield,
            params CreatureType[] creatureTypes)
        {
            return battlefield.GetCreatures(
                x => 
                creatureTypes.Any
                    (creatureType => x.Card.Type.HasFlag(creatureType)));
        }
    }
}
