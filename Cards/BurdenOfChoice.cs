using System;
using System.Collections.Generic;
using System.Reflection;
using ZariMod.Actions;
using Nanoray.PluginManager;
using Nickel;

namespace ZariMod.Cards;

public class BurdenOfChoice : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "BurdenOfChoice", "name"]).Localize,
            Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/Browse.png")).Sprite,
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
                        cost = 1,
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
                        new ADrawCard
                        {
                            count = 3,
                            timer = 1.5
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
                        new ADrawCard
                        {
                            count = 5,
                            timer = 1.5
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
                        new ADrawCard
                        {
                            count = 3,
                            timer = 1.5
                        },
                        new ADiscardSelect
                        {
                            count = 1
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