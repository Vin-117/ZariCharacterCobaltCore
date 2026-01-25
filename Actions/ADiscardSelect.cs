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
/// Function which prompts the user to select a set number of cards from their hand to discard. Discarding is not optional.
///
public class ADiscardSelect : CardAction
{
    public required int count;
    public static Spr ADiscardSelectSpr;
    public CardDestination destination = CardDestination.Discard;
    public List<CardAction> actions = [];

    public override Route? BeginWithRoute(G g, State s, Combat c)
    {

        CardAction selectedAction = new ADiscardTargetCardCheck { };
        actions.Insert(0, selectedAction);

        CardBrowse cardBrowse = new CardBrowse
        {
            mode = CardBrowse.Mode.Browse,
            browseSource = Source(CardDestination.Hand),
            browseAction = new AMultiBrowseListActions { actions = actions },
            allowCancel = false
        };
        if (cardBrowse.GetCardList(g).Count == 0)
        {
            timer = 0.0;
            return null;
        }
        count = Math.Min(count, cardBrowse.GetCardList(g).Count);

        var multiBrowseRoute = ModEntry.Instance.KokoroApi.MultiCardBrowse.MakeRoute(cardBrowse);
        multiBrowseRoute.MaxSelected = count;
        multiBrowseRoute.MinSelected = count;

        return multiBrowseRoute.AsRoute;
    }



    /// 
    /// Define icon displayed inside the card
    /// 
    public override Icon? GetIcon(State s)
    {
        return new Icon
        {
            path = ADiscardSelectSpr,
            number = count,
            color = Colors.textMain
        };
    }



    ///
    /// Define icon and tooltip when hovering over a card with this action 
    ///
    public override List<Tooltip> GetTooltips(State s)
    {

        if (count == 1)
        {
            return
            [
                new GlossaryTooltip(key: "ADiscardSelect")
                {
                    Icon = ADiscardSelectSpr,
                    Title = ModEntry.Instance.Localizations.Localize(["action", "ADiscardSelect", "title"]),
                    TitleColor = Colors.card,
                    Description = ModEntry.Instance.Localizations.Localize(["action", "ADiscardSelect", "desc_single"])
                },
            ];
        }
        else 
        {
            return
            [
                new GlossaryTooltip(key: "ADiscardSelect")
                {
                    Icon = ADiscardSelectSpr,
                    Title = ModEntry.Instance.Localizations.Localize(["action", "ADiscardSelect", "title"]),
                    TitleColor = Colors.card,
                    Description = ModEntry.Instance.Localizations.Localize(["action", "ADiscardSelect", "desc"], new { cnt = count })
                },
            ];
        }
    }



    ///
    /// Function which is used to compress a switch statement
    /// 
    public static CardBrowse.Source Source(CardDestination mode)
    {
        return mode switch
        {
            CardDestination.Discard => CardBrowse.Source.DiscardPile,
            CardDestination.Exhaust => CardBrowse.Source.ExhaustPile,
            CardDestination.Hand => CardBrowse.Source.Hand,
            CardDestination.Deck => CardBrowse.Source.DrawPile,
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
        };
    }
}