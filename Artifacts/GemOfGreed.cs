using FMOD;
using HarmonyLib;
using JetBrains.Annotations;
using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using ZariMod.Features;

namespace ZariMod.Artifacts;

public class GemOfGreed : Artifact, IRegisterable
{

    private static Spr DisabledSpr;

    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {

        DisabledSpr = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifacts/GemsOfGreedUsed.png")).Sprite;

        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new ArtifactMeta
            {
                pools = [ArtifactPool.Boss],
                owner = ModEntry.Instance.ZariDeck.Deck,
                unremovable = true
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "GemOfGreed", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "GemOfGreed", "desc"]).Localize,
            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifacts/GemsOfGreed.png")).Sprite
        });

    }

    public override int? GetDisplayNumber(State s)
    {
        return deckSizeCount;
    }

    public int deckSizeCount;
    public bool effectEnabled;

    public override void OnTurnStart(State state, Combat combat)
    {
        int exhaustedCardCount = 0;
        int handCount = 0;
        int discardCount = 0;
        int drawCount = 0;

        foreach (var thisCard in combat.exhausted)
        {
            if (thisCard.GetDataWithOverrides(state).temporary)
            {
                continue;
            }
            else 
            {
                exhaustedCardCount++;
            }
        }

        foreach (var thisCard in combat.hand)
        {
            if (thisCard.GetDataWithOverrides(state).temporary)
            {
                continue;
            }
            else
            {
                handCount++;
            }
        }

        foreach (var thisCard in combat.discard)
        {
            if (thisCard.GetDataWithOverrides(state).temporary)
            {
                continue;
            }
            else
            {
                discardCount++;
            }
        }

        foreach (var thisCard in state.deck)
        {
            if (thisCard.GetDataWithOverrides(state).temporary)
            {
                continue;
            }
            else
            {
                drawCount++;
            }
        }

        deckSizeCount = exhaustedCardCount + handCount + discardCount + drawCount;

        if (deckSizeCount > 24)
        {
            Pulse();
            combat.QueueImmediate(new ADrawCard
            {
                count = 1
            });
            combat.QueueImmediate(new AEnergy
            {
                changeAmount = 1
            });
            effectEnabled = true;
        }
    }

    public override Spr GetSprite()
    {
        if (effectEnabled)
        {
            return base.GetSprite();
        }
        else
        {
            return DisabledSpr;
        }
    }

}