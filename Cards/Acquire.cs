using Nanoray.PluginManager;
using Newtonsoft.Json.Linq;
using Nickel;
using System;
using System.Collections.Generic;
using System.Reflection;
using ZariMod.Actions;

namespace ZariMod.Cards;

public class Acquire : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Acquire", "name"]).Localize,
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
                        exhaust = true,
                        description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Acquire", "desc"]))
                    };
                }
            case Upgrade.A:
                {
                    return new CardData
                    {
                        cost = 0,
                        exhaust = true,
                        description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Acquire", "descA"])),
                    };
                }
            case Upgrade.B:
                {
                    return new CardData
                    {
                        cost = 0,
                        retain = true,
                        exhaust = true,
                        description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "Acquire", "descB"]))
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
                        new ACardSelect
                        {
                            browseAction = new ADiscardTargetSimple(),
                            browseSource = CardBrowse.Source.ExhaustPile,
                            ignoreCardType = "Vintage.ZariMod::Acquire"
                        }
                    };
                }
            case Upgrade.A:
                {
                    return new List<CardAction>
                    {
                        new ACardSelect
                        {
                            browseAction = new ADiscardTargetSimple(),
                            browseSource = CardBrowse.Source.ExhaustPile,
                            ignoreCardType = "Vintage.ZariMod::Acquire"
                        },
                        new ACardSelect
                        {
                            browseAction = new ADiscardTargetSimple(),
                            browseSource = CardBrowse.Source.ExhaustPile,
                            ignoreCardType = "Vintage.ZariMod::Acquire"
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
                            browseSource = CardBrowse.Source.ExhaustPile,
                            ignoreCardType = "Vintage.ZariMod::Acquire"
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