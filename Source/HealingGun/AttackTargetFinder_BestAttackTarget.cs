using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace HealingGun;

[HarmonyPatch(typeof(AttackTargetFinder), "BestAttackTarget")]
public static class AttackTargetFinder_BestAttackTarget
{
    public static void Postfix(ref IAttackTarget __result, IAttackTargetSearcher searcher, float maxDist)
    {
        var pawn = searcher as Pawn;
        if (!(pawn?.equipment?.Primary?.def?.Equals(ThingDef.Named("Healing_Gun")) ?? false))
        {
            return;
        }

        IEnumerable<Pawn> enumerable = pawn.Map.mapPawns.AllPawnsSpawned.Where(p =>
            !p.Dead && !p.Faction.HostileTo(pawn.Faction) && p != pawn &&
            GenSight.LineOfSight(pawn.Position, p.Position, pawn.Map) && p.health.hediffSet
                .GetHediffs<Hediff_Injury>().Any(h => h.CanHealNaturally() && !h.IsPermanent())).ToArray();
        var thing =
            GenClosest.ClosestThing_Global(pawn.Position,
                enumerable.Where(p => p.RaceProps.Humanlike && p.Faction == pawn.Faction), maxDist) ??
            GenClosest.ClosestThing_Global(pawn.Position, enumerable.Where(p => p.Faction == pawn.Faction),
                maxDist);
        if (thing == null)
        {
            thing = GenClosest.ClosestThing_Global(pawn.Position, enumerable.Where(p => p.RaceProps.Humanlike),
                maxDist);
        }

        if (thing == null)
        {
            thing = GenClosest.ClosestThing_Global(pawn.Position, enumerable, maxDist);
        }

        __result = (IAttackTarget)thing;
    }
}