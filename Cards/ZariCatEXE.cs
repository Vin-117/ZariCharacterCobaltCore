using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using ZariMod.Actions;

namespace ZariMod.Cards;


public class ZariCatEXE : Card, IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard(new CardConfiguration
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new CardMeta
            {
                deck = Deck.colorless,
                rarity = Rarity.uncommon,
                dontOffer = false,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "ZariCatEXE", "name"]).Localize,
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
                        exhaust = true,
                        description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "ZariCatEXE", "desc"]))
                    };
                }
            case Upgrade.A:
                {
                    return new CardData
                    {
                        cost = 0,
                        exhaust = true,
                        description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "ZariCatEXE", "descA"]))
                    };
                }
            case Upgrade.B:
                {
                    return new CardData
                    {
                        cost = 1,
                        exhaust = true,
                        description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "ZariCatEXE", "descB"]))
                    };
                }
            default:
                {
                    return new CardData
                    {
                        cost = 1,
                        exhaust = true,
                        description = string.Format(ModEntry.Instance.Localizations.Localize(["card", "ZariCatEXE", "desc"]))
                    };
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
                        new ACardOffering
                        {
                            amount = 3,
                            limitDeck = ModEntry.Instance.ZariDeck.Deck,
                            makeAllCardsTemporary = true,
                            overrideUpgradeChances = false,
                            canSkip = false,
                            inCombat = true,
                            discount = -1,
                            //dialogueSelector = ".summonGarrus"
                        },
                        new ADiscardSelect
                        {
                            count = 1
                        }
                    };
                }
            case Upgrade.A:
                {
                    return new List<CardAction>
                    {
                        new ACardOffering
                        {
                            amount = 3,
                            limitDeck = ModEntry.Instance.ZariDeck.Deck,
                            makeAllCardsTemporary = true,
                            overrideUpgradeChances = false,
                            canSkip = false,
                            inCombat = true,
                            discount = -1,
                            //dialogueSelector = ".summonGarrus"
                        },
                        new ADiscardSelect
                        {
                            count = 1
                        }
                    };
                }
            case Upgrade.B:
                {
                    return new List<CardAction>
                    {
                        new ACardOffering
                        {
                            amount = 5,
                            limitDeck = ModEntry.Instance.ZariDeck.Deck,
                            makeAllCardsTemporary = true,
                            overrideUpgradeChances = false,
                            canSkip = false,
                            inCombat = true,
                            discount = -1,
                            //dialogueSelector = ".summonGarrus"
                        },
                        new ADiscardSelect
                        {
                            count = 1
                        }
                    };
                }
            default:
                {
                    return new List<CardAction>
                    {
                    };
                }
        }
    }
}