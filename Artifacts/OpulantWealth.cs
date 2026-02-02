using FMOD;
using HarmonyLib;
using JetBrains.Annotations;
using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using ZariMod.Cards;
using ZariMod.Features;

namespace ZariMod.Artifacts;

public class OpulantWealth : Artifact, IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new ArtifactMeta
            {
                pools = [ArtifactPool.Boss],
                owner = ModEntry.Instance.ZariDeck.Deck,
                unremovable = true
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "OpulantWealth", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "OpulantWealth", "desc"]).Localize,
            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifacts/StackOfCoins.png")).Sprite
        });

    }

    public override void OnReceiveArtifact(State state)
    {
        state.ship.baseDraw += 2;
    }

    public override void OnRemoveArtifact(State state)
    {
        state.ship.baseDraw -= 2;
    }

    public override void OnCombatStart(State state, Combat combat)
    {
        combat.Queue(new AAddCard
        {
            card = new GoldHoard()
            {
                upgrade = Upgrade.None
            },
            artifactPulse = Key(),
            destination = CardDestination.Deck,
            amount = 3
        });
    }

    public override List<Tooltip>? GetExtraTooltips()
    {
        return new List<Tooltip>
        {
            new TTCard
            {
                card = new GoldHoard()
                {
                    upgrade = Upgrade.None
                }
            }
        };
    }


}