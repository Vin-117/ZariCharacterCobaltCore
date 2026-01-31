using HarmonyLib;
using Nanoray.PluginManager;
using Newtonsoft.Json;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ZariMod.Artifacts;
using static ZariMod.External.IKokoroApi.IV2.IStatusLogicApi;
using static ZariMod.External.IKokoroApi.IV2.IStatusLogicApi.IHook;

namespace ZariMod.External;


public class ScornOnDiscardManager : IKokoroApi.IV2.IStatusLogicApi.IHook, IKokoroApi.IV2.IStatusRenderingApi.IHook, IRegisterable
{
	internal static readonly ScornOnDiscardManager Instance = new();

    public ScornOnDiscardManager()
    {
        ModEntry.Instance.KokoroApi.StatusLogic.RegisterHook(this, 0);
        ModEntry.Instance.KokoroApi.StatusRendering.RegisterHook(this, 0);
    }


    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        ModEntry.Instance.Harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(Combat), nameof(Combat.SendCardToDiscard)),
            postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(ZariCombat_SendCardToDiscard_Postfix))
        );

        ModEntry.Instance.Harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(Combat), nameof(Combat.TryPlayCard)),
            prefix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Combat_TryPlayCard_Prefix)),
            finalizer: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Combat_TryPlayCard_Finalizer))
        );
    }

    private static Card? LastCardPlayed;

    private static void Combat_TryPlayCard_Prefix(Card card)
        => LastCardPlayed = card;

    private static void Combat_TryPlayCard_Finalizer()
        => LastCardPlayed = null;

    //TODO: This postfix does not actually work. It's implemented in the temperance artifact and works
    //TODO: there, but it really should be implemented here.
    private static void ZariCombat_SendCardToDiscard_Postfix(Combat __instance, State s, Card card)
    {

        // Do nothing if this is not the player turn, if the status is not greater than 0
        // or if they played a card (which would also cause this script to run)
        if (!__instance.isPlayerTurn) 
        {
            System.Console.WriteLine("Checked if it was the player's turn");
            return;
        }

        if (card == LastCardPlayed) 
        {
            System.Console.WriteLine("Checked if card was less card played");
            return;
        }

        Ship ship = s.ship;

        if (ship.Get(ModEntry.Instance.ZariScornStatus.Status) > 0) 
        {
            __instance.Queue
            (
                new AAttack
                {
                    damage = Card.GetActualDamage(s, ship.Get(ModEntry.Instance.ZariScornStatus.Status), false)
                }
            );
        };

    }

    /*internal static void Setup(IHarmony harmony)
	{

        harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(Combat), nameof(Combat.SendCardToDiscard)),
            postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(ZariCombat_SendCardToDiscard_Postfix))
        );

        harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(Combat), nameof(Combat.TryPlayCard)),
            prefix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Combat_TryPlayCard_Prefix)),
            finalizer: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Combat_TryPlayCard_Finalizer))
        );

    }*/

    public bool HandleStatusTurnAutoStep(IHandleStatusTurnAutoStepArgs args)
    {
        return false;

        /*///
        /// Do nothing if either the hook does not detect the status, 
        /// or its not the start of the turn.
        ///
        if (args.Status != ModEntry.Instance.ZariScornStatus.Status)
        {
            return false;
        }
        if (args.Timing != StatusTurnTriggerTiming.TurnStart)
        {
            return false;
        }
        ///
        /// Will only get here if its the start of the turn and is the correct status,
        /// so add shield equal to status amount
        ///
        if (args.Amount > 0)
        {
            args.Combat.QueueImmediate
            (
                new AAttack()
                {
                    
                }
            );
        }
        return false;*/
    }



}