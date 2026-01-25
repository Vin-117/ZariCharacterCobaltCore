using System;
using System.Collections.Generic;
using System.Reflection;
using ZariMod.Actions;
using Nanoray.PluginManager;
using Nickel;

namespace ZariMod.Cards;

public class Moult : Card, IRegisterable
{   
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard(new CardConfiguration
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new CardMeta
            {
                deck = ModEntry.Instance.ZariDeck.Deck,
                rarity = Rarity.uncommon,
                dontOffer = false,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Moult", "name"]).Localize,
            Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/placeholder_art.png")).Sprite,
        });
    }

    public override CardData GetData(State state)
    {
        switch (this.upgrade)
        {
            case Upgrade.None:
                {
                    return new CardData
                    {
                        cost = 1
                    };
                }
            case Upgrade.A:
                {
                    return new CardData
                    {
                        cost = 0
                    };
                }
            case Upgrade.B:
                {
                    return new CardData
                    {
                        cost = 1
                    };
                }
            default:
                {
                    return new CardData{};
                }
        }
    }

    public override List<CardAction> GetActions(State s, Combat c)
    {

        int GetMoultTotal(State s)
        {
            int num = 0;
            if (s.route is Combat combat)
            {
                num = combat.hand.Count - 1;
            }
            return num;
        }

        switch (this.upgrade)
        {
            case Upgrade.None:
                {
                    return new List<CardAction>
                    {

                        new AVariableHint
                        {
                            hand = true,
                            handAmount = GetMoultTotal(s)
                        },
                        new ADiscard(),
                        new AAddCard()
                        {
                            card = new DiscardedScales()
                            {
                            },
                            destination = CardDestination.Hand,
                            xHint = 1,
                            amount = GetMoultTotal(s),
                        },
                    };
                }
            case Upgrade.A:
                {
                    return new List<CardAction>
                    {

                        new AVariableHint
                        {
                            hand = true,
                            handAmount = GetMoultTotal(s)
                        },
                        new ADiscard(),
                        new AAddCard()
                        {
                            card = new DiscardedScales()
                            {
                            },
                            destination = CardDestination.Hand,
                            xHint = 1,
                            amount = GetMoultTotal(s),
                        },
                    };
                }
            case Upgrade.B:
                {
                    return new List<CardAction>
                    {

                        new AVariableHint
                        {
                            hand = true,
                            handAmount = GetMoultTotal(s)
                        },
                        new ADiscard(),
                        new AAddCard()
                        {
                            card = new DiscardedScales()
                            {
                                upgrade = Upgrade.B
                            },
                            destination = CardDestination.Hand,
                            xHint = 1,
                            amount = GetMoultTotal(s),
                        },
                    };
                }
            default:
                {
                    return new List<CardAction>{};
                }
        }
    }
}