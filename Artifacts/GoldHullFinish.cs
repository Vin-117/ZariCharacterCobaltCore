using FMOD;
using HarmonyLib;
using JetBrains.Annotations;
using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using ZariMod.Cards;
using ZariMod.Features;

namespace ZariMod.Artifacts;

public class GoldHullFinish : Artifact, IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new ArtifactMeta
            {
                pools = [ArtifactPool.Common],
                owner = ModEntry.Instance.ZariDeck.Deck,
                unremovable = true
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "GoldHullFinish", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "GoldHullFinish", "desc"]).Localize,
            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifacts/GoldenArmor.png")).Sprite
        });

    }

    public int goldhullcount;


    public override int? GetDisplayNumber(State s)
    {
        return goldhullcount;
    }


    public override void OnPlayerTakeNormalDamage(State state, Combat combat, int rawAmount, Part? part)
    {

        if (goldhullcount < 4) 
        {
            goldhullcount++;
        }

        if (goldhullcount == 4) 
        {
            goldhullcount = 0;
            Pulse();
            combat.QueueImmediate
            (
                new ADrawCard 
                {
                    count = 1
                }
            );
        }
    }



}