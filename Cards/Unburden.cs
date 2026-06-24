using System;
using System.Collections.Generic;
using System.Reflection;
using ZariMod.Actions;
using Nanoray.PluginManager;
using Nickel;

namespace ZariMod.Cards;

public class Unburden : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Unburden", "name"]).Localize,
            Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/Unburden.png")).Sprite,
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
                        cost = 1,
                        retain = true
                    };
                }
            case Upgrade.B:
                {
                    return new CardData
                    {
                        unplayable = true,
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
                        new ADiscardSelect
                        {
                            count = 1,
                            dialogueSelector = ".ZariUnburden"
                        },
                        ModEntry.Instance.KokoroApi.OnDiscard.MakeAction
                        (
                            new AStatus
                            {
                                status = Status.evade,
                                statusAmount = 1,
                                targetPlayer = true,
                                dialogueSelector = ".ZariUnburden"
                            }
                        ).AsCardAction
                    };
                }
            case Upgrade.A:
                {
                    return new List<CardAction>
                    {
                        new ADiscardSelect
                        {
                            count = 1,
                            dialogueSelector = ".ZariUnburden"
                        },
                        ModEntry.Instance.KokoroApi.OnDiscard.MakeAction
                        (
                            new AStatus
                            {
                                status = Status.evade,
                                statusAmount = 1,
                                targetPlayer = true,
                                dialogueSelector = ".ZariUnburden"
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
                            new ADiscardFlexSelect
                            {
                            }
                        ).AsCardAction,
                        ModEntry.Instance.KokoroApi.OnDiscard.MakeAction
                        (
                            new AStatus
                            {
                                status = Status.evade,
                                statusAmount = 1,
                                targetPlayer = true,
                                dialogueSelector = ".ZariUnburden"
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