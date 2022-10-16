using System.Linq;
using Verse;

namespace HealingGun;

public class DamageWorker_Heal : DamageWorker
{
    public override DamageResult Apply(DamageInfo dinfo, Thing victim)
    {
        Pawn pawn;
        if ((pawn = victim as Pawn) == null)
        {
            return new DamageResult();
        }

        //Log.Message($"Starting healing on {pawn.Name.ToStringShort}");
        //Log.Message($"Injury Count: {pawn.health.hediffSet.GetHediffs<Hediff_Injury>().Count()}");
        var totalHeals = 6;
        foreach (var rec in pawn.health.hediffSet.GetInjuredParts())
        {
            if (totalHeals <= 0)
            {
                continue;
            }

            var currentHeals = 2;
            foreach (var item in from injury in pawn.health.hediffSet.hediffs
                     where injury is Hediff_Injury && injury.Part == rec
                     select injury)
            {
                if (currentHeals <= 0)
                {
                    break;
                }

                if (item is Hediff_Injury injury && !injury.CanHealNaturally() || item.IsPermanent())
                {
                    //Log.Message("Scars or old wounds can't be healed");
                    continue;
                }

                //Log.Message($"Healing {item.def.defName} on {item.Part.def.defName}");
                item.Heal((int)item.Severity + 1);
                totalHeals--;
                currentHeals--;
            }
        }

        //Log.Message($"Finished healing on {pawn.Name.ToStringShort}");

        return new DamageResult();
    }
}