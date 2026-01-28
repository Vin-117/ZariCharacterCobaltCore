using System;
using System.Collections.Generic;
using System.Reflection;
using ZariMod.Actions;
using Nanoray.PluginManager;
using Nickel;

namespace ZariMod.Cards;

public class Hoard : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Hoard", "name"]).Localize,
            Art = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Card/placeholder_art.png")).Sprite,
        });
    }

    private int GetShieldAmt(State s)
    {
        int num = 0;
        if (s.route is Combat)
        {
            num = s.ship.Get(Status.shield);
            if (upgrade == Upgrade.A)
            {
                num++;
                if (num > s.ship.GetMaxShield())
                {
                    num = s.ship.GetMaxShield();
                }
            }
        }
        return num;
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
                    };
                }
            case Upgrade.A:
                {
                    return new CardData
                    {
                        cost = 1
                    };
                }
            case Upgrade.B:
                {
                    return new CardData
                    {
                        cost = 1,
                        retain = true
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
                        new AVariableHint
                        {
                            status = Status.shield
                        },
                        new ADrawCard
                        {
                            count = GetShieldAmt(s),
                            xHint = 1
                        }
                    };
                }   
            case Upgrade.A:
                {
                    return new List<CardAction>
                    {

                        new AStatus
                        {
                            status = Status.shield,
                            statusAmount = 1,
                            targetPlayer = true
                        },
                        new AVariableHint
                        {
                            status = Status.shield
                        },
                        new ADrawCard
                        {
                            count = GetShieldAmt(s),
                            xHint = 1
                        }
                    };
                }
            case Upgrade.B:
                {
                    return new List<CardAction>
                    {

                        new AVariableHint
                        {
                            status = Status.shield
                        },
                        new ADrawCard
                        {
                            count = GetShieldAmt(s),
                            xHint = 1
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