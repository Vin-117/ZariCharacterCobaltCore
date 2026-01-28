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



///
/// Function which checks to make sure selected cards are not null. If they are not, 
/// send them to the final function that acutally does the discarding
/// 
public sealed class ADiscardTargetCardCheck : CardAction
{
    public override void Begin(G g, State s, Combat c)
    {
        base.Begin(g, s, c);
        if (selectedCard is null) { return; }
        c.QueueImmediate([new ADiscardTargetCardFinal { uuid = selectedCard.uuid }]);
    }
}



///
/// Function which discards a given selected card
/// 
public class ADiscardTargetCardFinal : CardAction
{
    public int uuid;
    public const double delayTimer = 0.3;

    public override void Begin(G g, State s, Combat c)
    {
        timer = 0.0;
        Card? card = s.FindCard(uuid);
        if (card != null && c.hand.Contains(card))
        {
            Audio.Play(Event.CardHandling);
            c.hand.Remove(card);
            card.OnDiscard(s, c);
            c.SendCardToDiscard(s, card);
            timer = 0.3;
        }
    }
}


public class ADiscardTargetSimple : CardAction
{
    public override void Begin(G g, State s, Combat c)
    {
        Card? card = selectedCard;
        if (card != null)
        {
            Audio.Play(Event.CardHandling);
            s.RemoveCardFromWhereverItIs(card.uuid);
            card.OnDiscard(s, c);
            c.SendCardToDiscard(s, card);
            timer = 0.3;
        }
    }
}





///
/// Function which queues actions for multibrowse
/// 
public class AMultiBrowseListActions : CardAction
{
    public List<CardAction> actions = new List<CardAction>();

    public override void Begin(G g, State s, Combat c)
    {
        if (ModEntry.Instance.KokoroApi.MultiCardBrowse.GetSelectedCards(this) is not { } selectedCards) 
        {
            return;
        }

        var toQueue = new List<CardAction>();

        foreach (var card in selectedCards)
        {
            foreach (var cardAction in actions)
            {
                var action = Mutil.DeepCopy(cardAction);
                action.selectedCard = card;
                toQueue.Add(action);
            }
        }

        c.QueueImmediate(toQueue);
    }
}