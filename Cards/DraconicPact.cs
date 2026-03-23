using System;
using System.Collections.Generic;
using System.Reflection;
using ZariMod.Actions;
using Nanoray.PluginManager;
using Nickel;

namespace ZariMod.Cards;

public class DraconicPact : Card, IRegisterable, IHasCustomCardTraits
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "DraconicPact", "name"]).Localize,
            Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/Draconic Pact.png")).Sprite,
        });
    }

    public IReadOnlySet<ICardTraitEntry> GetInnateTraits(State state)
        => new HashSet<ICardTraitEntry> { ModEntry.Instance.KokoroApi.Fleeting.Trait };

    public override CardData GetData(State state)
    {
        switch (this.upgrade)
        {
            case Upgrade.None:
                {
                    return new CardData
                    {
                        cost = 1,
                        exhaust = true
                    };
                }
            case Upgrade.A:
                {
                    return new CardData
                    {
                        cost = 1,
                        exhaust = true
                    };
                }
            case Upgrade.B:
                {
                    return new CardData
                    {
                        cost = 0,
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
                        new AHurt
                        {
                            targetPlayer = true,
                            hurtAmount = 1
                        },
                        new AShieldMax
                        {
                            amount = 1,
                            targetPlayer = true
                        },
                        new AStatus
                        {
                            targetPlayer = true,
                            statusAmount = 1,
                            status = Status.shield,
                            dialogueSelector = ".ZariPact"
                        }
                    };
                }
            case Upgrade.A:
                {
                    return new List<CardAction>
                    {
                        new AHurt
                        {
                            targetPlayer = true,
                            hurtAmount = 1
                        },
                        new AShieldMax
                        {
                            amount = 1,
                            targetPlayer = true
                        },
                        new AStatus
                        {
                            targetPlayer = true,
                            statusAmount = 3,
                            status = Status.shield,
                            dialogueSelector = ".ZariPact"
                        },
                    };
                }
            case Upgrade.B:
                {
                    return new List<CardAction>
                    {
                        new AHurt
                        {
                            targetPlayer = true,
                            hurtAmount = 1
                        },
                        new AShieldMax
                        {
                            amount = 1,
                            targetPlayer = true
                        },
                        new ADrawCard
                        {
                            count = 1,
                            dialogueSelector = ".ZariPact"
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
