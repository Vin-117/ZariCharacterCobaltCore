using System;
using System.Collections.Generic;
using System.Reflection;
using ZariMod.Actions;
using Nanoray.PluginManager;
using Nickel;

namespace ZariMod.Cards;

public class ShedScales : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "ShedScales", "name"]).Localize,
            Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/ShedScales.png")).Sprite,
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
                        cost = 1,
                        infinite = true
                    };
                }
            case Upgrade.A:
                {
                    return new CardData
                    {
                        cost = 1,
                        infinite = true
                    };
                }
            case Upgrade.B:
                {
                    return new CardData
                    {
                        cost = 0,
                        infinite = true
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

        switch (this.upgrade)
        {
            case Upgrade.None:
                {
                    return new List<CardAction>
                    {
                        new AStatus
                        {
                            status = Status.tempShield,
                            targetPlayer = true,
                            statusAmount = 2
                        },
                        new ADiscardSelect
                        {
                            count = 1
                        },
                    };
                }
            case Upgrade.A:
                {
                    return new List<CardAction>
                    {
                        new AStatus
                        {
                            status = Status.tempShield,
                            targetPlayer = true,
                            statusAmount = 2
                        },
                        new AStatus
                        {
                            status = Status.drawNextTurn,
                            targetPlayer = true,
                            statusAmount = 1
                        },
                        new ADiscardSelect
                        {
                            count = 1
                        },
                    };
                }
            case Upgrade.B:
                {
                    return new List<CardAction>
                    {

                        new AStatus
                        {
                            status = Status.shield,
                            targetPlayer = true,
                            statusAmount = 1
                        },
                        new ADiscardSelect
                        {
                            count = 2
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