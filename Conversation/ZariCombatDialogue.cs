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



            //Dialogue for when the enemy gains autododge
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



            //Dialogue for when the player misses a shot
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
                "Zari_Dialogue_WeMissedButHaveRecalibrator_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    playerShotJustMissed = true,
                    oncePerCombatTags = ["Zari_WeMissed_Tag"],
                    hasArtifacts = [ "Recalibrator" ],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "pondering", "Missing on purpose? Clever...")
                    ]
                }
            },



            //Dialogue for when the player ship gets hit but takes no damage
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



            //Dialogue for when the players ship takes reduced damage due to armor
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


            //Dialogue for when the enemy and player ship don't overlap
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
                        new(AmZari, "explains", "You cannot hit what is not there.")
                    ]
                }
            },



            //Dialogue for when the player and enemy ship don't overlap, but there is a seeker
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



            //Dialogue for when the player acquires or loses various artifacts
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
            {
                "Zari_Dialogue_WeGainedGlassCannon_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    oncePerRun = true,
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    oncePerRunTags = [ "GlassCannon" ],
                    hasArtifacts = [ "GlassCannon" ],
                    dialogue =
                    [
                        new(AmZari, "pondering", "How does a glass maw make us stronger?")
                    ]
                }
            },
            {
                "Zari_Dialogue_WeGainedSimplicity_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    oncePerRun = true,
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    oncePerRunTags = [ "SimplicityShouts" ],
                    hasArtifacts = [ "Simplicity" ],
                    dialogue =
                    [
                        new(AmZari, "annoyed", "This 'simple' artifact just reduced our hoard!")
                    ]
                }
            },
            {
                "Zari_Dialogue_WeGainedDirtyEngines_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    oncePerRun = true,
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    oncePerRunTags = [ "DirtyEngines" ],
                    hasArtifacts = [ "DirtyEngines" ],
                    dialogue =
                    [
                        new(AmZari, "annoyed", "This new furnace smells dirtier than a muddy peasant.")
                    ]
                }
            },
            {
                "Zari_Dialogue_WeGainedNanofibers_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    oncePerRun = true,
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    hasArtifacts = [ "NanofiberHull" ],
                    doesNotHaveArtifacts = [ "HealBooster" ],
                    dialogue =
                    [
                        new(AmZari, "neutral", "A self regenerating flying ship? How handy!")
                    ]
                }
            },
            {
                "Zari_Dialogue_WeGainedNanofibersANDHealBooster_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    oncePerRun = true,
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    hasArtifacts = [ "NanofiberHull", "HealBooster" ],
                    dialogue =
                    [
                        new(AmZari, "explains", "This heal trinket is handy with self regeneration, is it not?")
                    ]
                }
            },
            {
                "Zari_Dialogue_TookHealableChip_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyShotJustHit = true,
                    hasArtifacts = [ "NanofiberHull" ],
                    oncePerCombatTags = ["ZariNanofiberComment"],
                    oncePerRun = true,
                    minDamageDealtToPlayerThisTurn = 1,
                    maxDamageDealtToPlayerThisTurn = 1,
                    dialogue =
                    [
                        new(AmZari, "explains", "Fret not. Those nanofibers will heal us.")
                    ]
                }
            },
            {
                "Zari_Dialogue_TookBoostedHealableChip_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyShotJustHit = true,
                    hasArtifacts = [ "NanofiberHull", "HealBooster" ],
                    oncePerCombatTags = ["ZariNanofiberComment"],
                    oncePerRun = true,
                    minDamageDealtToPlayerThisTurn = 2,
                    maxDamageDealtToPlayerThisTurn = 2,
                    dialogue =
                    [
                        new(AmZari, "explains", "No fuss. The boosted regeneration will make short work of that.")
                    ]
                }
            },
            {
                "Zari_Dialogue_WeGainedEnergyPrep_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari ],
                    hasArtifacts = [ "EnergyPrep" ],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmZari, "neutral", "These batteries seem rather handy.")
                    ]
                }
            },
            {
                "Zari_Dialogue_WeGainedFractureDetection_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari ],
                    hasArtifacts = [ "FractureDetection" ],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmZari, "pondering", "Where do we believe that brittle spot to be?")
                    ]
                }
            },
            {
                "Zari_Dialogue_WeGainedShieldMemory_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari ],
                    hasArtifacts = [ "ShieldMemory" ],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmZari, "explains", "Finally! Now we may properly hoard our shields!")
                    ]
                }
            },
            {
                "Zari_Dialogue_IonConverterActivated_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari ],
                    hasArtifacts = [ "IonConverter" ],
                    oncePerRunTags = [ "IonConverterTag" ],
                    lookup = [ "IonConverterTrigger" ],
                    priority = true,
                    dialogue =
                    [
                        new(AmZari, "explains", "Waste not, want not.")
                    ]
                }
            },


            //Dialogue related to heat gain, with and without drake
            {
                "Zari_Dialogue_OverheatGeneric_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    goingToOverheat = true,
                    oncePerCombatTags = ["OverheatGeneric"],
                    dialogue =
                    [
                        new(AmZari, "pondering", "Is it a touch warm? I had not noticed.")
                    ]
                }
            },
            {
                "WeJustGainedHeatAndDrakeIsHere_Multi_0", new()
                {
                    edit = 
                    [
                        new(EMod.countFromStart, 1, AmZari, "annoyed", "It is rude to raise the temperature without permission, Eunice."),
                    ]
                }
            }

















        });
    }
}
