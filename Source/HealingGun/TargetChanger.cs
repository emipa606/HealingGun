using System.Reflection;
using HarmonyLib;
using Verse;

namespace HealingGun;

[StaticConstructorOnStartup]
internal static class TargetChanger
{
    static TargetChanger()
    {
        new Harmony("rimworld.erdelf.healing_gun").PatchAll(Assembly.GetExecutingAssembly());
    }
}