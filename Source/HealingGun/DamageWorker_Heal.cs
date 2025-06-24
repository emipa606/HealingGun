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
                    continue;
                }

                item.Heal((int)item.Severity + 1);
                totalHeals--;
                currentHeals--;
            }
        }

        return new DamageResult();
    }
}