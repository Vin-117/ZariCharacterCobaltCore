using Nanoray.PluginManager;
using Newtonsoft.Json.Linq;
using Nickel;
using System;
using System.Collections.Generic;
using System.Reflection;
using ZariMod.Actions;

namespace ZariMod.Cards;

public class Peruse : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Peruse", "name"]).Localize,
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
                        cost = 1,
                        description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Peruse", "desc"]))
                    };
                }
            case Upgrade.A:
                {
                    return new CardData
                    {
                        cost = 1,
                        description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Peruse", "descA"])),
                    };
                }
            case Upgrade.B:
                {
                    return new CardData
                    {
                        cost = 0,
                        buoyant = true,
                        description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Peruse", "descB"]))
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
                            statusAmount = 2,
                            targetPlayer = true
                        },
                        new ACardSelect
                        {
                            browseAction = new ADiscardTargetSimple(),
                            browseSource = CardBrowse.Source.DrawPile,
                            filterUUID = uuid
                        },
                        new ACardSelect
                        {
                            browseAction = new ADiscardTargetSimple(),
                            browseSource = CardBrowse.Source.DrawPile,
                            filterUUID = uuid
                        }
                    };
                }
            case Upgrade.A:
                {
                    return new List<CardAction>
                    {

                        new AStatus
                        {
                            status = Status.tempShield,
                            statusAmount = 2,
                            targetPlayer = true
                        },
                        new ACardSelect
                        {
                            browseAction = new ADiscardTargetSimple(),
                            browseSource = CardBrowse.Source.DrawPile,
                            filterUUID = uuid
                        }

                    };
                }
            case Upgrade.B:
                {
                    return new List<CardAction>
                    {
                        new ACardSelect
                        {
                            browseAction = new ADiscardTargetSimple(),
                            browseSource = CardBrowse.Source.DrawPile,
                            filterUUID = uuid
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