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
using static CardBrowse;

namespace ZariMod.Actions;



///
/// Function which prompts the user to select any number of cards to discard from their hand. They may also choose to discard no cards.
///
public class ADiscardFlexSelect : CardAction
{
    //public required int count;
    public static Spr ADiscardFlexSelectSpr;
    public CardDestination destination = CardDestination.Discard;

    public override Route? BeginWithRoute(G g, State s, Combat c)
    {

        CardBrowse cardBrowse = new CardBrowse
        {
            mode = CardBrowse.Mode.Browse,
            browseSource = Source(CardDestination.Hand),
            browseAction = new AMultiBrowseListActions { },
            allowCancel = false
        };
        if (cardBrowse.GetCardList(g).Count == 0)
        {
            //timer = 0.0;
            return null;
        }
        //count = Math.Min(count, cardBrowse.GetCardList(g).Count);

        var multiBrowseRoute = ModEntry.Instance.KokoroApi.MultiCardBrowse.MakeRoute(cardBrowse);
        multiBrowseRoute.MaxSelected = 99;
        multiBrowseRoute.MinSelected = 0;

        timer = 0.0;
        return multiBrowseRoute.AsRoute;
    }



    /// 
    /// Define icon displayed inside the card
    /// 
    public override Icon? GetIcon(State s)
    {
        return new Icon
        {
            path = ADiscardFlexSelectSpr,
            //number = count,
            //color = Colors.textMain
        };
    }



    ///
    /// Define icon and tooltip when hovering over a card with this action 
    ///
    public override List<Tooltip> GetTooltips(State s)
    {
        return
            [
                new GlossaryTooltip(key: "ADiscardFlexSelect")
                {
                    Icon = ADiscardFlexSelectSpr,
                    Title = ModEntry.Instance.Localizations.Localize(["action", "ADiscardFlexSelect", "title"]),
                    TitleColor = Colors.card,
                    Description = ModEntry.Instance.Localizations.Localize(["action", "ADiscardFlexSelect", "desc_single"])
                },
            ];
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