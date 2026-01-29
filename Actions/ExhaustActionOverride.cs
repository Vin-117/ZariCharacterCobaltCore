using FSPRO;
using HarmonyLib;
using JetBrains.Annotations;
using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using ZariMod.External;

namespace ZariMod.Actions;



/// <summary>
/// Action which causes the card its on to exhaust. Normally unneccessary, since
/// you can use the exhaust trait on cards, but useful for on discard actions
/// Note this code was taken from Two's Company
/// </summary>
public class AExhaustSelf : CardAction
{
    public int uuid;
    public override void Begin(G g, State s, Combat c)
    {

        // thanks to shockah for this snippet
        if (s.FindCard(uuid) is not { } card)
            return;

        s.RemoveCardFromWhereverItIs(uuid);
        c.SendCardToExhaust(s, card);
        Audio.Play(Event.CardHandling);
    }
    public override Icon? GetIcon(State s) => new Icon?(new Icon(StableSpr.icons_exhaust, new int?(), Colors.textMain));
    public override List<Tooltip> GetTooltips(State s) => new List<Tooltip>() { new TTGlossary("cardtrait.exhaust") };
}