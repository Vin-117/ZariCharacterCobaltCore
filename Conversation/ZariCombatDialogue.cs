using FMOD;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using ZariMod.Artifacts;
using ZariMod.External;
using static ZariMod.Conversation.CommonDefinitions;

namespace ZariMod.Conversation;

internal class ZariCombatDialogue : IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            {
                "Zari_Dialogue_AutoDodgeLeft_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    lastTurnEnemyStatuses = [Status.autododgeLeft],
                    oncePerCombatTags = ["Zari_AutoDodge_Tag"],
                    oncePerCombat = true,
                    dialogue = 
                    [ 
                        new(AmZari, "pondering", "I believe the next attack will not land.") 
                    ]
                }
            },

            {
                "Zari_Dialogue_AutoDodgeLeft_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    lastTurnEnemyStatuses = [Status.autododgeLeft],
                    oncePerCombatTags = ["Zari_AutoDodge_Tag"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "pondering", "Their flying ship is primed to evade.")
                    ]
                }
            },

            {
                "Zari_Dialogue_AutoDodgeRight_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    lastTurnEnemyStatuses = [Status.autododgeRight],
                    oncePerCombatTags = ["Zari_AutoDodge_Tag"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "pondering", "Their flying ship is primed to evade.")
                    ]
                }
            },

            {
                "Zari_Dialogue_AutoDodgeRight_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    lastTurnEnemyStatuses = [Status.autododgeRight],
                    oncePerCombatTags = ["Zari_AutoDodge_Tag"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "pondering", "I believe the next attack will not land.")
                    ]
                }
            },

            {
                "Zari_Dialogue_WeMissed_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    playerShotJustMissed = true,
                    oncePerCombatTags = ["Zari_WeMissed_Tag"],
                    doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "pondering", "More difficult to aim than I anticipated.")
                    ]
                }
            },

            {
                "Zari_Dialogue_WeMissed_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    playerShotJustMissed = true,
                    oncePerCombatTags = ["Zari_WeMissed_Tag"],
                    doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "neutral", "Adequate try, I suppose.")
                    ]
                }
            },

            {
                "Zari_Dialogue_WeMissed_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    playerShotJustMissed = true,
                    oncePerCombatTags = ["Zari_WeMissed_Tag"],
                    doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "squint", "We are trying to kill them, are we not?")
                    ]
                }
            },

            {
                "Zari_Dialogue_WeMissed_3", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    playerShotJustMissed = true,
                    oncePerCombatTags = ["Zari_WeMissed_Tag"],
                    doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "pondering", "We will need to realign in order to hit them.")
                    ]
                }
            },

            {
                "Zari_Dialogue_WeMissed_4", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    playerShotJustMissed = true,
                    oncePerCombatTags = ["Zari_WeMissed_Tag"],
                    doesNotHaveArtifacts = ["Recalibrator", "GrazerBeam"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "annoyed", "Why are we wasting shots?")
                    ]
                }
            },

            {
                "Zari_Dialogue_WeGotShotButTookNoDMG_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    oncePerCombatTags = ["Zari_WeGotShotButTookNoDMG_Tag"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "neutral", "Excellent defense, that.")
                    ]
                }
            },

            {
                "Zari_Dialogue_WeGotShotButTookNoDMG_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    oncePerCombatTags = ["Zari_WeGotShotButTookNoDMG_Tag"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "neutral", "Good block.")
                    ]
                }
            },

            {
                "Zari_Dialogue_WeGotShotButTookNoDMG_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    oncePerCombatTags = ["Zari_WeGotShotButTookNoDMG_Tag"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "neutral", "Our scales remain unbroken.")
                    ]
                }
            },

            {
                "Zari_Dialogue_WeGotShotButTookNoDMG_3", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    oncePerCombatTags = ["Zari_WeGotShotButTookNoDMG_Tag"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "arrogant", "Still trying to slay me? I could not tell.")
                    ]
                }
            },

            {
                "Zari_Dialogue_ArmorDeflectedDMG_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyShotJustHit = true,
                    minDamageBlockedByPlayerArmorThisTurn = 1,
                    oncePerCombatTags = ["WowArmorISPrettyCoolHuh"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "neutral", "Tough as a knight's armor, I see.")
                    ]
                }
            },

            {
                "Zari_Dialogue_ArmorDeflectedDMG_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyShotJustHit = true,
                    minDamageBlockedByPlayerArmorThisTurn = 1,
                    oncePerCombatTags = ["WowArmorISPrettyCoolHuh"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "pondering", "Perhaps that armorsmith had a point...")
                    ]
                }
            },

            {
                "Zari_Dialogue_ArmorDeflectedDMG_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyShotJustHit = true,
                    minDamageBlockedByPlayerArmorThisTurn = 1,
                    oncePerCombatTags = ["WowArmorISPrettyCoolHuh"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "arrogant", "Go on. Keep hitting our armor.")
                    ]
                }
            },

            {
                "Zari_Dialogue_ArmorDeflectedDMG_3", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyShotJustHit = true,
                    minDamageBlockedByPlayerArmorThisTurn = 1,
                    oncePerCombatTags = ["WowArmorISPrettyCoolHuh"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "pondering", "I should have hoarded more iron ore. Pity.")
                    ]
                }
            },

            {
                "Zari_Dialogue_NoOverlap_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    priority = true,
                    shipsDontOverlapAtAll = true,
                    nonePresent = [ "crab", "scrap" ],
                    oncePerCombat = true,
                    oncePerCombatTags = [ "NoOverlapBetweenShips" ],
                    dialogue =
                    [
                        new(AmZari, "arrogant", "Leading them on a wild dragon chase? Excellent idea.")
                    ]
                }
            },

            {
                "Zari_Dialogue_NoOverlap_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    priority = true,
                    shipsDontOverlapAtAll = true,
                    nonePresent = [ "crab", "scrap" ],
                    oncePerCombat = true,
                    oncePerCombatTags = [ "NoOverlapBetweenShips" ],
                    dialogue =
                    [
                        new(AmZari, "arrogant", "I do fancy a game of dragon and mouse.")
                    ]
                }
            },

            {
                "Zari_Dialogue_NoOverlap_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    priority = true,
                    shipsDontOverlapAtAll = true,
                    nonePresent = [ "crab", "scrap" ],
                    oncePerCombat = true,
                    oncePerCombatTags = [ "NoOverlapBetweenShips" ],
                    dialogue =
                    [
                        new(AmZari, "nap", "Excellent. Now I can build our defenses in peace.")
                    ]
                }
            },

            {
                "Zari_Dialogue_NoOverlap_3", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    priority = true,
                    shipsDontOverlapAtAll = true,
                    nonePresent = [ "crab", "scrap" ],
                    oncePerCombat = true,
                    oncePerCombatTags = [ "NoOverlapBetweenShips" ],
                    dialogue =
                    [
                        new(AmZari, "neutral", "Keep flying and eventually they will tire.")
                    ]
                }
            },

            {
                "Zari_Dialogue_NoOverlapButSeeker_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    priority = true,
                    shipsDontOverlapAtAll = true,
                    doesNotHaveArtifacts = ["ChaffEmitters"],
                    oncePerCombatTags = [ "NoOverlapBetweenShipsSeeker"],
                    anyDronesHostile = [ "missile_seeker" ],
                    nonePresent = [ "crab" ],
                    dialogue =
                    [
                        new(AmZari, "annoyed", "That bothersome javelin still has us, you know.")
                    ]
                }
            },

            {
                "Zari_Dialogue_NoOverlapButSeeker_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    priority = true,
                    shipsDontOverlapAtAll = true,
                    doesNotHaveArtifacts = ["ChaffEmitters"],
                    oncePerCombatTags = [ "NoOverlapBetweenShipsSeeker"],
                    anyDronesHostile = [ "missile_seeker" ],
                    nonePresent = [ "crab" ],
                    dialogue =
                    [
                        new(AmZari, "annoyed", "A seeking bolt? How irritating.")
                    ]
                }
            },

            {
                "Zari_Dialogue_WeHaveNoWarpPrep_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    oncePerRun = true,
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    oncePerRunTags = [ "ShieldPrepIsGoneYouFool" ],
                    doesNotHaveArtifacts = [ "ShieldPrep", "WarpMastery"],
                    dialogue =
                    [
                        new(AmZari, "pondering", "I feel less prepared. How peculiar.")
                    ]
                }
            },











        });
    }
}
