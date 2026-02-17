using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Reflection;
using ZariMod.Actions;
using static ZariMod.External.IKokoroApi.IV2;

namespace ZariMod.Cards;

public class Ambition : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Ambition", "name"]).Localize,
            Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/Ambition.png")).Sprite,
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
                        cost = 0,
                        unplayable = true
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
                            new AEnergy
                            {
                                changeAmount = 1
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
                            new AEnergy
                            {
                                changeAmount = 2
                            }
                        ).AsCardAction
                    };
                }
            case Upgrade.B:
                {
                    return new List<CardAction>
                    {
                        ModEntry.Instance.KokoroApi.OnDiscard.MakeAction
                        (
                            new AStatus
                            {
                                statusAmount = 3,
                                status = Status.energyNextTurn,
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