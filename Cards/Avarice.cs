using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Reflection;
using ZariMod.Actions;
using static ZariMod.External.IKokoroApi.IV2;

namespace ZariMod.Cards;

public class Avarice : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Avarice", "name"]).Localize,
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
                        cost = 0,
                        unplayable = true
                    };
                }
            case Upgrade.A:
                {
                    return new CardData
                    {
                        cost = 0,
                        unplayable = true
                    };
                }
            case Upgrade.B:
                {
                    return new CardData
                    {
                        cost = 0
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
                        ModEntry.Instance.KokoroApi.OnDiscard.MakeAction
                        (
                            new ADrawCard
                            {
                                count = 2
                            }
                        ).AsCardAction
                    };
                }
            case Upgrade.A:
                {
                    return new List<CardAction>
                    {
                        ModEntry.Instance.KokoroApi.OnDiscard.MakeAction
                        (
                            new ADrawCard
                            {
                                count = 3
                            }
                        ).AsCardAction
                    };
                }
            case Upgrade.B:
                {
                    return new List<CardAction>
                    {
                        new ADrawCard
                        {
                            count = 1
                        },
                        ModEntry.Instance.KokoroApi.OnDiscard.MakeAction
                        (
                            new ADrawCard
                            {
                                count = 2
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