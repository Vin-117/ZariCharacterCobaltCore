using System;
using System.Collections.Generic;
using System.Reflection;
using ZariMod.Actions;
using Nanoray.PluginManager;
using Nickel;

namespace ZariMod.Cards;

public class Scorn : Card, IRegisterable, IHasCustomCardTraits
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Scorn", "name"]).Localize,
            Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/Scorn.png")).Sprite,
        });
    }

    public IReadOnlySet<ICardTraitEntry> GetInnateTraits(State state)
    {
        switch (this.upgrade)
        {
            case Upgrade.None:
                {
                    return new HashSet<ICardTraitEntry> { };
                }
            case Upgrade.A:
                {
                    return new HashSet<ICardTraitEntry> { };
                }
            case Upgrade.B:
                {
                    return new HashSet<ICardTraitEntry> { };
                }
            default:
                {
                    return new HashSet<ICardTraitEntry> { };
                }
        }

    }

    public override CardData GetData(State state)
    {
        switch (this.upgrade)
        {
            case Upgrade.None:
                {
                    return new CardData
                    {
                        cost = 3,
                        exhaust = true
                    };
                }
            case Upgrade.A:
                {
                    return new CardData
                    {
                        cost = 2,
                        exhaust = true,
                    };
                }
            case Upgrade.B:
                {
                    return new CardData
                    {
                        cost = 4,
                        exhaust = true
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
                            status = ModEntry.Instance.ZariScornStatus.Status,
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
                            status = ModEntry.Instance.ZariScornStatus.Status,
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
                            status = ModEntry.Instance.ZariScornStatus.Status,
                            statusAmount = 2,
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