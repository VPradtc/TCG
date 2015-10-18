using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCG.Core.Cards;

namespace TCG.Core.Game.Utils
{
    public static class BattlefieldUtils
    {
        public static ICollection<SummonedCreature> GetAllCreatures(
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
                return battlefield.GetAllCreatures();
            }
            return battlefield
                .GetAllCreatures()
                .Where(x => condition(x))
                .ToList();
        }

        public static ICollection<SummonedCreature> GetCreaturesByType(
            this Battlefield battlefield,
            CreatureType creatureType)
        {
            return battlefield.GetCreatures(x => x.Card.Type == creatureType);
        }
    }
}
