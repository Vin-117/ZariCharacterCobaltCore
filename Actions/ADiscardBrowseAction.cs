using FSPRO;
using HarmonyLib;
using JetBrains.Annotations;
using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ZariMod.Actions;



/// 
/// Function which prompts the player to select a card from their hand to discard it
/// 
public class ADiscardSelect : CardAction
{
    //public required int discardAmount;
    public bool allowCancel = false;
    public bool allowCloseOverride = false;
    private CardBrowse.Source browseSource = CardBrowse.Source.Hand;
    private CardAction browseAction = new ADiscardCardBrowseAction { };
    public static Spr ADiscardSelectSpr;

    public override bool CanSkipTimerIfLastEvent()
    {
        return false;
    }

    public override Route? BeginWithRoute(G g, State s, Combat c)
    {
        CardBrowse cardBrowse = new CardBrowse
        {
            mode = CardBrowse.Mode.Browse,
            browseSource = browseSource,
            browseAction = browseAction,
            allowCancel = allowCancel,
            allowCloseOverride = allowCloseOverride
        };
        c.Queue(new ADelay
        {
            time = 0.0,
            timer = 0.0
        });
        if (cardBrowse.GetCardList(g).Count == 0)
        {
            timer = 0.0;
            return null;
        }

        return cardBrowse;
    }

    public override List<Tooltip> GetTooltips(State s)
    {
        return
        [
            new GlossaryTooltip(key: "ADiscardSelect")
            {
                Icon = ADiscardSelectSpr,
                Title = ModEntry.Instance.Localizations.Localize(["action", "ADiscardSelect", "title"]),
                TitleColor = Colors.card,
                Description = ModEntry.Instance.Localizations.Localize(["action", "ADiscardSelect", "desc"], this)
            },
        ];
    }


    public override Icon? GetIcon(State s)
    {
        return new Icon
        {
            path = ADiscardSelectSpr
        };
    }

}



public sealed class ADiscardCardBrowseAction : CardAction
{
    public override void Begin(G g, State s, Combat c)
    {
        base.Begin(g, s, c);
        if (selectedCard is null)
        {
            return;
        }

        c.QueueImmediate([new ADiscardCardAction { uuid = selectedCard.uuid }]);
    }
}



public class ADiscardCardAction : CardAction
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






