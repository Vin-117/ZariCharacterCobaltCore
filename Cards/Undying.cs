using System;
using System.Collections.Generic;
using System.Reflection;
using ZariMod.Actions;
using Nanoray.PluginManager;
using Nickel;

namespace ZariMod.Cards;

public class Undying : Card, IRegisterable
{   
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard(new CardConfiguration
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new CardMeta
            {
                deck = ModEntry.Instance.ZariDeck.Deck,
                rarity = Rarity.rare,
                dontOffer = false,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Undying", "name"]).Localize,
            Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/Endure.png")).Sprite,
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
                        cost = 2,
                        exhaust = true
                    };
                }
            case Upgrade.A:
                {
                    return new CardData
                    {
                        cost = 1,
                        exhaust = true,
                    };
                }
            case Upgrade.B:
                {
                    return new CardData
                    {
                        cost = 2,
                        exhaust = false
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
                            status = ModEntry.Instance.ZariUndyingStatus.Status,
                            statusAmount = 1,
                            targetPlayer = true
                        },
                    };
                }
            case Upgrade.A:
                {
                    return new List<CardAction>
                    {
                        new AStatus
                        {
                            status = ModEntry.Instance.ZariUndyingStatus.Status,
                            statusAmount = 1,
                            targetPlayer = true
                        },
                    };
                }
            case Upgrade.B:
                {
                    return new List<CardAction>
                    {
                        new AStatus
                        {
                            status = ModEntry.Instance.ZariUndyingStatus.Status,
                            statusAmount = 1,
                            targetPlayer = true
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