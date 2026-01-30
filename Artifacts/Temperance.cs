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

public class Temperance : Artifact, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Temperance", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "Temperance", "desc"]).Localize,
            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifacts/Temperance.png")).Sprite
        });

        ModEntry.Instance.Harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(Combat), nameof(Combat.SendCardToDiscard)),
            postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(ZariCombat_SendCardToDiscard_Postfix))
        );

        ModEntry.Instance.Harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(Combat), nameof(Combat.TryPlayCard)),
            prefix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Combat_TryPlayCard_Prefix)),
            finalizer: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Combat_TryPlayCard_Finalizer))
        );

    }

    public int DiscardCount = 0;

    public override void OnTurnStart(State state, Combat combat)
    {
        DiscardCount = 0;
    }

    public override void OnTurnEnd(State state, Combat combat)
    {
        DiscardCount = 1;
    }

    public override void OnCombatEnd(State state)
    {
        DiscardCount = 0;
    }


    private static Card? LastCardPlayed;

    private static void Combat_TryPlayCard_Prefix(Card card)
        => LastCardPlayed = card;

    private static void Combat_TryPlayCard_Finalizer()
        => LastCardPlayed = null;

    private static void ZariCombat_SendCardToDiscard_Postfix(Combat __instance, State s, Card card)
    {

        // Do nothing if this is not the player turn, or artifact is not in player possession
        // or if they played a card (which would also cause this script to run)
        if (!__instance.isPlayerTurn)
            return;

        if (card == LastCardPlayed)
            return;

        if (s.EnumerateAllArtifacts().FirstOrDefault(a => a is Temperance) is not { } artifact)
            return;

        var temperance = (Temperance)artifact;

        // If the player has not discarded a card this turn, give them an energy
        if (temperance.DiscardCount == 0)
        {
            __instance.Queue(new AEnergy { changeAmount = 1 });
            temperance.DiscardCount += 1;
            artifact.Pulse();
        }

    }
}