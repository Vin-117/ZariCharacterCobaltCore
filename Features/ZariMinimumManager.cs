using HarmonyLib;
using JetBrains.Annotations;
using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using ZariMod;
using ZariMod.Actions;
using ZariMod.External;
using static ZariMod.External.IKokoroApi.IV2;
using static ZariMod.External.IKokoroApi.IV2.IStatusLogicApi;
using static ZariMod.External.IKokoroApi.IV2.IStatusLogicApi.IHook;

namespace ZariMod.Features;



///
/// Status which makes the player draw and then discard every turn
/// 
public class ZariMinimumStatusManager : IKokoroApi.IV2.IStatusLogicApi.IHook, IKokoroApi.IV2.IStatusRenderingApi.IHook
{



    /// 
    /// Register hooks
    /// 
    public ZariMinimumStatusManager() 
    {
        ModEntry.Instance.KokoroApi.StatusLogic.RegisterHook(this, 0);
        ModEntry.Instance.KokoroApi.StatusRendering.RegisterHook(this, 0);
    }



    ///
    /// Define status behaviour
    /// 
    public bool HandleStatusTurnAutoStep(IHandleStatusTurnAutoStepArgs args)
    {


        ///
        /// Do nothing if either the hook does not detect the status, 
        /// or its not the start of the turn.
        ///
        if (args.Status != ModEntry.Instance.ZariMinimumStatus.Status) 
        {
            return false;
        }
        if (args.Timing != StatusTurnTriggerTiming.TurnStart) 
        {
            return false;
        }
        ///
        /// Will only get here if its the start of the turn and is the correct status,
        /// so then perform a flex discard
        ///
        if (args.Amount > 0)
        {

            args.Combat.QueueImmediate
            (
                new ADelay 
                {
                    time = 0.15
                }
            );
            args.Combat.Queue
            (
                new ADiscardFlexSelect()
                {
                }
            );
        }
        return false;
    }
}

   


    
