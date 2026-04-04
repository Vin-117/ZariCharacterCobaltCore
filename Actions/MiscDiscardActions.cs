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
/// Function which discards a given selected card from hand
/// 
public class ADiscardTargetCard : CardAction
{

    public bool DiscardFromDraw = false;

    public override void Begin(G g, State s, Combat c)
    {
        timer = 0.0;

        if (selectedCard is null) { return; }
        
        Card? card = s.FindCard(selectedCard.uuid);

        if (!(DiscardFromDraw))
        {
            if (card != null && c.hand.Contains(card))
            {
                Audio.Play(Event.CardHandling);
                c.hand.Remove(card);
                card.OnDiscard(s, c);
                c.SendCardToDiscard(s, card);
            }
        }
        else 
        {

            if (card != null && s.deck.Contains(card))
            {
                Audio.Play(Event.CardHandling);
                s.deck.Remove(card);
                card.OnDiscard(s, c);
                c.SendCardToDiscard(s, card);
            }

        }
    }
}


public class ADiscardTargetSimple : CardAction
{
    public override void Begin(G g, State s, Combat c)
    {

        timer = 0.0;
        Card? card = selectedCard;
        if (card != null)
        {
            Audio.Play(Event.CardHandling);
            s.RemoveCardFromWhereverItIs(card.uuid);
            card.OnDiscard(s, c);
            c.SendCardToDiscard(s, card);
        }
    }
}





///
/// Function which queues actions for multibrowse
/// 
public class AMultiBrowseListActions : CardAction
{

    public bool fromDraw = false;

    public override void Begin(G g, State s, Combat c)
    {

        if (!(fromDraw))
        {
            if (ModEntry.Instance.KokoroApi.MultiCardBrowse.GetSelectedCards(this) is not { } selectedCards)
            {
                return;
            }

            foreach (var card in selectedCards)
            {
                var action = new ADiscardTargetCard { };
                action.selectedCard = card;
                c.QueueImmediate(action);
            }
        }
        else 
        {

            if (ModEntry.Instance.KokoroApi.MultiCardBrowse.GetSelectedCards(this) is not { } selectedCards)
            {
                return;
            }

            foreach (var card in selectedCards)
            {
                var action = new ADiscardTargetCard { DiscardFromDraw = true };
                action.selectedCard = card;
                c.QueueImmediate(action);
            }

        }
    }
}