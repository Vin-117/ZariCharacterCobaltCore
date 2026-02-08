using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Reflection;
using ZariMod.Actions;
using static ZariMod.External.IKokoroApi.IV2;

namespace ZariMod.Cards;

public class ToughScales : Card, IRegisterable
{   
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard(new CardConfiguration
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new CardMeta
            {
                deck = ModEntry.Instance.ZariDeck.Deck,
                rarity = Rarity.common,
                dontOffer = false,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "ToughScales", "name"]).Localize,
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
                        cost = 1
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
        switch (this.upgrade)
        {
            case Upgrade.None:
                {
                    return new List<CardAction>
                    {
                        new AStatus
                        {
                            status = Status.shield,
                            statusAmount = 1,
                            targetPlayer = true
                        },
                        ModEntry.Instance.KokoroApi.OnDiscard.MakeAction
                        (
                            new AStatus
                            {
                                status = Status.shield,
                                statusAmount = 2,
                                targetPlayer = true
                            }
                        ).AsCardAction
                    };
                }
            case Upgrade.A:
                {
                    return new List<CardAction>
                    {
                        new AStatus
                        {
                            status = Status.shield,
                            statusAmount = 2,
                            targetPlayer = true
                        },
                        ModEntry.Instance.KokoroApi.OnDiscard.MakeAction
                        (
                            new AStatus
                            {
                                status = Status.shield,
                                statusAmount = 3,
                                targetPlayer = true
                            }
                        ).AsCardAction
                    };
                }
            case Upgrade.B:
                {
                    return new List<CardAction>
                    {
                        new AStatus
                        {
                            status = Status.tempShield,
                            statusAmount = 2,
                            targetPlayer = true
                        },
                        ModEntry.Instance.KokoroApi.OnDiscard.MakeAction
                        (
                            new AStatus
                            {
                                status = Status.maxShield,
                                statusAmount = 2,
                                targetPlayer = true
                            }
                        ).AsCardAction
                    };
                }
            default:
                {
                    return new List<CardAction>{};
                }
        }
    }
}