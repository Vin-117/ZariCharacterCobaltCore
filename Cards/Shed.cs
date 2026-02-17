using System;
using System.Collections.Generic;
using System.Reflection;
using ZariMod.Actions;
using Nanoray.PluginManager;
using Nickel;

namespace ZariMod.Cards;

public class Shed : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Shed", "name"]).Localize,
            Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/Moult.png")).Sprite,
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
                        exhaust = false,
                        //description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "TheFavorite", "desc"]))
                    };
                }
            case Upgrade.A:
                {
                    return new CardData
                    {
                        cost = 0,
                        exhaust = false,
                        //description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "TheFavorite", "desc"]))
                    };
                }
            case Upgrade.B:
                {
                    return new CardData
                    {
                        cost = 1,
                        //description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "TheFavorite", "desc"]))
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
                            status = Status.maxShield,
                            statusAmount = -1,
                            targetPlayer = true
                        },
                        new AStatus
                        {
                            status = Status.drawNextTurn,
                            statusAmount = 3,
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
                            status = Status.maxShield,
                            statusAmount = -1,
                            targetPlayer = true
                        },
                        new AStatus
                        {
                            status = Status.shield,
                            statusAmount = 1,
                            targetPlayer = true
                        },
                        new AStatus
                        {
                            status = Status.drawNextTurn,
                            statusAmount = 3,
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
                            status = Status.maxShield,
                            statusAmount = -1,
                            targetPlayer = true
                        },
                        new ADrawCard
                        {
                            count = 3
                        },
                        new AStatus
                        {
                            status = Status.drawNextTurn,
                            statusAmount = 3,
                            targetPlayer = true
                        }
                    };
                }
            default:
                {
                    return new List<CardAction>{};
                }
        }
    }
}