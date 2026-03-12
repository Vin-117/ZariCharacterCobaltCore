using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Reflection;
using ZariMod.Actions;
using static ZariMod.External.IKokoroApi.IV2;

namespace ZariMod.Cards;

public class GoldHoard : Card, IRegisterable
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
                dontOffer = true,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "GoldHoard", "name"]).Localize,
            Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/Hoard.png")).Sprite,
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
                        unplayable = true,
                        temporary = true
                    };
                }
            case Upgrade.A:
                {
                    return new CardData
                    {
                        cost = 0,
                        unplayable = true,
                        temporary = false
                    };
                }
            case Upgrade.B:
                {
                    return new CardData
                    {
                        cost = 0,
                        unplayable = true,
                        temporary = true
                    };
                }
            default:
                {
                    return new CardData { };
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
                            new AExhaustSelf
                            {
                                uuid = this.uuid,
                                timer = 0.0
                            }
                        ).AsCardAction,
                    };
                }
            case Upgrade.A:
                {
                    return new List<CardAction>
                    {
                        ModEntry.Instance.KokoroApi.OnDiscard.MakeAction
                        (
                            new AExhaustSelf
                            {
                                uuid = this.uuid,
                                timer = 0.0,
                            }
                        ).AsCardAction,
                    };
                }
            case Upgrade.B:
                {
                    return new List<CardAction>
                    {
                    };
                }
            default:
                {
                    return new List<CardAction> { };
                }
        }




    }
}