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



            //Dialogue for hitting the enemy
            {
                "Zari_Dialogue_ShotHitGeneric_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    playerShotJustHit = true,
                    oncePerCombatTags = ["Zari_WeHit_Tag"],
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmZari, "neutral", "Splendid shot.")
                    ]
                }
            },
            {
                "Zari_Dialogue_ShotHitGeneric_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    playerShotJustHit = true,
                    oncePerCombatTags = ["Zari_WeHit_Tag"],
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmZari, "neutral", "A fine attack, that was.")
                    ]
                }
            },
            {
                "Zari_Dialogue_ShotHitGeneric_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    playerShotJustHit = true,
                    oncePerCombatTags = ["Zari_WeHit_Tag"],
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmZari, "arrogant", "Stings, does it not?")
                    ]
                }
            },
            {
                "Zari_Dialogue_ShotHitGeneric_3", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    playerShotJustHit = true,
                    oncePerCombatTags = ["Zari_WeHit_Tag"],
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmZari, "neutral", "A firm rebuke.")
                    ]
                }
            },
            {
                "Zari_Dialogue_ShotHitGeneric_4", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    playerShotJustHit = true,
                    oncePerCombatTags = ["Zari_WeHit_Tag"],
                    minDamageDealtToEnemyThisAction = 1,
                    dialogue =
                    [
                        new(AmZari, "arrogant", "Did that hurt?")
                    ]
                }
            },
            {
                "Zari_Dialogue_ShotHitBigDMG_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    playerShotJustHit = true,
                    oncePerCombatTags = ["Zari_WeHitBig_Tag"],
                    minDamageDealtToEnemyThisAction = 5,
                    dialogue =
                    [
                        new(AmZari, "greedy", "Keep shooting. They will be more useful as salvage.")
                    ]
                }
            },
            {
                "Zari_Dialogue_ShotHitBigDMG_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    playerShotJustHit = true,
                    oncePerCombatTags = ["Zari_WeHitBig_Tag"],
                    minDamageDealtToEnemyThisAction = 5,
                    dialogue =
                    [
                        new(AmZari, "explains", "No good deed goes unpunished.")
                    ]
                }
            },
            {
                "Zari_Dialogue_ShotHitBigDMG_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    playerShotJustHit = true,
                    oncePerCombatTags = ["Zari_WeHitBig_Tag"],
                    minDamageDealtToEnemyThisAction = 5,
                    dialogue =
                    [
                        new(AmZari, "arrogant", "Oh my, did that hurt?")
                    ]
                }
            },
            {
                "Zari_Dialogue_ShotHitBigDMG_3", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    playerShotJustHit = true,
                    oncePerCombatTags = ["Zari_WeHitBig_Tag"],
                    minDamageDealtToEnemyThisAction = 5,
                    dialogue =
                    [
                        new(AmZari, "arrogant", "Dear me, we have made quite a mess.")
                    ]
                }
            },
            {
                "Zari_Dialogue_ShotHitBigDMG_4", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    playerShotJustHit = true,
                    oncePerCombatTags = ["Zari_WeHitBig_Tag"],
                    minDamageDealtToEnemyThisAction = 5,
                    dialogue =
                    [
                        new(AmZari, "explains", "A fitting punishment.")
                    ]
                }
            },



            //Dialogue for when the player moves around a lot
            {
                "Zari_Dialogue_MovingLots_0", new()
                {
                    type = NodeType.combat,
                    minMovesThisTurn = 5,
                    oncePerRun = true,
                    allPresent = [ AmZari ],
                    oncePerCombatTags = ["Zari_MoveFast_Tag"],
                    dialogue =
                    [
                        new(AmZari, "neutral", "Goodness, we are moving fast!")
                    ]
                }
            },
            {
                "Zari_Dialogue_MovingLots_1", new()
                {
                    type = NodeType.combat,
                    minMovesThisTurn = 5,
                    oncePerRun = true,
                    allPresent = [ AmZari ],
                    oncePerCombatTags = ["Zari_MoveFast_Tag"],
                    dialogue =
                    [
                        new(AmZari, "annoyed", "Slow it down, please. My coins just spilt.")
                    ]
                }
            },
            {
                "Zari_Dialogue_MovingLots_2", new()
                {
                    type = NodeType.combat,
                    minMovesThisTurn = 5,
                    oncePerRun = true,
                    allPresent = [ AmZari ],
                    oncePerCombatTags = ["Zari_MoveFast_Tag"],
                    dialogue =
                    [
                        new(AmZari, "arrogant", "And here I feared we would be too slow to dodge.")
                    ]
                }
            },



            //Dialogue for when hand is full of garbage or empty
            {
                "Zari_Dialogue_HandofGarbage", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    handFullOfTrash = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "annoyed", "This trash is cluttering my hoard!")
                    ]
                }
            },
            {
                "Zari_Dialogue_HandUnplayable_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    handFullOfUnplayableCards = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "squint", "This lot is worthless.")
                    ]
                }
            },
            {
                "Zari_Dialogue_HandUnplayable_1", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    handFullOfUnplayableCards = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "resigned", "I may be to blame for part of this.")
                    ]
                }
            },
            {
                "Zari_Dialogue_HandEmpty_0", new()
                {
                    type = NodeType.combat,
                    handEmpty = true,
                    minEnergy = 1,
                    oncePerCombatTags = [ "ZariHandEmpty" ],
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "arrogant", "Did I do that?")
                    ]
                }
            },
            {
                "Zari_Dialogue_HandEmpty_1", new()
                {
                    type = NodeType.combat,
                    handEmpty = true,
                    minEnergy = 1,
                    oncePerCombatTags = [ "ZariHandEmpty" ],
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "explains", "Do not fret. We will have plenty more soon.")
                    ]
                }
            },
            {
                "Zari_Dialogue_HandEmpty_2", new()
                {
                    type = NodeType.combat,
                    handEmpty = true,
                    minEnergy = 1,
                    oncePerCombatTags = [ "ZariHandEmpty" ],
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "explains", "Less is more.")
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
                        new(AmZari, "arrogant", "Were they trying to slay me? I could not tell.")
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
                        new(AmZari, "explains", "Tougher than a knight's armor.")
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
                        new(AmZari, "neutral", "These batteries seem rather useful.")
                    ]
                }
            },
            {
                "Zari_Dialogue_WeGainedCrosslink_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    allPresent = [ AmZari ],
                    hasArtifacts = [ "Crosslink" ],
                    dialogue =
                    [
                        new(AmZari, "pondering", "Crosslink? What is that name supposed to mean?")
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


            //Dialogue related to the various ships
            {
                "Zari_Dialogue_Tiderunner_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    allPresent = [ AmZari ],
                    hasArtifacts = [ "TideRunner" ],
                    oncePerRunTags = [ "TideRunner" ],
                    dialogue =
                    [
                        new(AmZari, "pondering", "This ship reminds me of my home.")
                    ]
                }
            },
            {
                "Zari_Dialogue_Gemini_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    allPresent = [ AmZari ],
                    hasArtifacts = [ "GeminiCore" ],
                    oncePerRunTags = [ "GeminiCore" ],
                    dialogue =
                    [
                        new(AmZari, "squint", "Side swapping? I do not understand this ship.")
                    ]
                }
            },
            {
                "Zari_Dialogue_Ares_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    allPresent = [ AmZari ],
                    hasArtifacts = [ "AresCannon" ],
                    oncePerRunTags = [ "AresCannon" ],
                    dialogue =
                    [
                        new(AmZari, "annoyed", "This ship is too small. I can barely fit my tail!")
                    ]
                }
            },
            {
                "Zari_Dialogue_Jupiter_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    allPresent = [ AmZari ],
                    hasArtifacts = [ "JupiterDroneHub" ],
                    oncePerRunTags = [ "JupiterDroneHub" ],
                    dialogue =
                    [
                        new(AmZari, "pondering", "Drone cannons? Intriguing...")
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
            },



            //Dialogue related to taking damage
            {
                "Zari_Dialogue_TookChipDMG_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyShotJustHit = true,
                    doesNotHaveArtifacts = [ "NanofiberHull" ],
                    oncePerCombatTags = ["ZariYappedAboutDMG"],
                    minDamageDealtToPlayerThisTurn = 1,
                    maxDamageDealtToPlayerThisTurn = 2,
                    dialogue =
                    [
                        new(AmZari, "annoyed", "How dare they sully our ship!")
                    ]
                }
            },
            {
                "Zari_Dialogue_TookChipDMG_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyShotJustHit = true,
                    doesNotHaveArtifacts = [ "NanofiberHull" ],
                    oncePerCombatTags = ["ZariYappedAboutDMG"],
                    minDamageDealtToPlayerThisTurn = 1,
                    maxDamageDealtToPlayerThisTurn = 2,
                    dialogue =
                    [
                        new(AmZari, "resigned", "And I was just finished polishing the outer hull...")
                    ]
                }
            },
            {
                "Zari_Dialogue_TookChipDMG_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyShotJustHit = true,
                    doesNotHaveArtifacts = [ "NanofiberHull" ],
                    oncePerCombatTags = ["ZariYappedAboutDMG"],
                    minDamageDealtToPlayerThisTurn = 1,
                    maxDamageDealtToPlayerThisTurn = 2,
                    dialogue =
                    [
                        new(AmZari, "annoyed", "Putting a dent in MY ship?! How dare they!")
                    ]
                }
            },
            {
                "Zari_Dialogue_TookBigDMG_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyShotJustHit = true,
                    doesNotHaveArtifacts = [ "NanofiberHull" ],
                    oncePerCombatTags = ["ZariYappedAboutDMG"],
                    minDamageDealtToPlayerThisTurn = 3,
                    dialogue =
                    [
                        new(AmZari, "resigned", "And I put so much work into shining the outer hull...")
                    ]
                }
            },
            {
                "Zari_Dialogue_TookBigDMG_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyShotJustHit = true,
                    doesNotHaveArtifacts = [ "NanofiberHull" ],
                    oncePerCombatTags = ["ZariYappedAboutDMG"],
                    minDamageDealtToPlayerThisTurn = 3,
                    dialogue =
                    [
                        new(AmZari, "pondering", "I despise saying this, but that damage is irreparable.")
                    ]
                }
            },
            {
                "Zari_Dialogue_TookBigDMG_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyShotJustHit = true,
                    doesNotHaveArtifacts = [ "NanofiberHull" ],
                    oncePerCombatTags = ["ZariYappedAboutDMG"],
                    minDamageDealtToPlayerThisTurn = 3,
                    dialogue =
                    [
                        new(AmZari, "resigned", "Fixing this is going to cost too much of my hoard.")
                    ]
                }
            },



            //Missing dialogue
            {
                "Zari_Dialogue_BooksMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["booksWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingBooks],
                    dialogue =
                    [
                        new(AmZari, "worried", "Books!")
                    ]
                }
            },
            {
                "Zari_Dialogue_CatMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["CatWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingCat],
                    dialogue =
                    [
                        new(AmZari, "pondering", "...Something just happened to our computer.")
                    ]
                }
            },
            {
                "Zari_Dialogue_DizzyMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["dizzyWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingDizzy],
                    dialogue =
                    [
                        new(AmZari, "pondering", "...Pity. That kobold was useful.")
                    ]
                }
            },
            {
                "Zari_Dialogue_DrakeMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["drakeWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingDrake],
                    dialogue =
                    [
                        new(AmZari, "annoyed", "Eunice?! Get back here this instant!")
                    ]
                }
            },
            {
                "Zari_Dialogue_GoatMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["issacWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingIsaac],
                    dialogue =
                    [
                        new(AmZari, "worried", "That darling goat just vanished before my eyes!")
                    ]
                }
            },
            {
                "Zari_Dialogue_MaxMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["maxWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingMax],
                    dialogue =
                    [
                        new(AmZari, "arrogant", "I am sure we can fix these silly little computers without him.")
                    ]
                }
            },
            {
                "Zari_Dialogue_PeriMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["periWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingPeri],
                    dialogue =
                    [
                        new(AmZari, "arrogant", "Peri is gone? What a shame.")
                    ]
                }
            },
            {
                "Zari_Dialogue_RiggsMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["riggsWentMissing"],
                    lastTurnPlayerStatuses = [Status.missingRiggs],
                    dialogue =
                    [
                        new(AmZari, "pondering", "Did our pilot just disappear? Bother.")
                    ]
                }
            },



            //Missing dialogue for when Zari specifically is missing
            {
                "Riggs_Dialogue_ZariMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmRiggs ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["ZariWentMissing"],
                    lastTurnPlayerStatuses = [MissingZari],
                    dialogue =
                    [
                        new(AmRiggs, "squint", "Did our ship just get lighter all of a sudden?")
                    ]
                }
            },
            {
                "Peri_Dialogue_ZariMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmPeri ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["ZariWentMissing"],
                    lastTurnPlayerStatuses = [MissingZari],
                    dialogue =
                    [
                        new(AmPeri, "squint", "...Zari disappeared. Along with all her gold.")
                    ]
                }
            },
            {
                "Dizzy_Dialogue_ZariMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmDizzy ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["ZariWentMissing"],
                    lastTurnPlayerStatuses = [MissingZari],
                    dialogue =
                    [
                        new(AmDizzy, "intense", "Zari?")
                    ]
                }
            },
            {
                "Max_Dialogue_ZariMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmMax ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["ZariWentMissing"],
                    lastTurnPlayerStatuses = [MissingZari],
                    dialogue =
                    [
                        new(AmMax, "squint", "Uh...our 50 ft dragon just disappeared.")
                    ]
                }
            },
            {
                "Books_Dialogue_ZariMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmBooks ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["ZariWentMissing"],
                    lastTurnPlayerStatuses = [MissingZari],
                    dialogue =
                    [
                        new(AmBooks, "paws", "Wow! Mrs Zari did a magic trick!")
                    ]
                }
            },
            {
                "Cat_Dialogue_ZariMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmCat ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["ZariWentMissing"],
                    lastTurnPlayerStatuses = [MissingZari],
                    dialogue =
                    [
                        new(AmCat, "intense", "...at least that reduces the weight of our ship.")
                    ]
                }
            },
            {
                "Drake_Dialogue_ZariMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmDrake ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["ZariWentMissing"],
                    lastTurnPlayerStatuses = [MissingZari],
                    dialogue =
                    [
                        new(AmDrake, "sly", "Looks like dearest old aunt just went missing.")
                    ]
                }
            },
            {
                "Goat_Dialogue_ZariMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmIsaac ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["ZariWentMissing"],
                    lastTurnPlayerStatuses = [MissingZari],
                    dialogue =
                    [
                        new(AmIsaac, "shy", "Umm...did Zari go somewhere?")
                    ]
                }
            },



            //Dialogue related to enemy weakpoints
            {
                "Zari_Dialogue_BrittleComment_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyHasBrittlePart = true,
                    oncePerRunTags = ["yelledAboutBrittle"],
                    dialogue =
                    [
                        new(AmZari, "neutral", "I see a gap in their scales.")
                    ]
                }
            },
            {
                "Zari_Dialogue_WeakComment_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    enemyHasWeakPart = true,
                    oncePerRunTags = ["yelledAboutWeakness"],
                    dialogue =
                    [
                        new(AmZari, "pondering", "Their flying ship contains weakness.")
                    ]
                }
            },



            //Dialogue relating to a fight taking a long time.
            {
                "Zari_Dialogue_Longfight_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    minTurnsThisCombat = 9,
                    oncePerCombatTags = ["manyTurns"],
                    dialogue =
                    [
                        new(AmZari, "explains", "Good things come to those who wait.")
                    ]
                }
            },
            {
                "Zari_Dialogue_Longfight_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    minTurnsThisCombat = 9,
                    oncePerCombatTags = ["manyTurns"],
                    dialogue =
                    [
                        new(AmZari, "pondering", "Seems I will have to delay tea time. Pity.")
                    ]
                }
            },
            {
                "Zari_Dialogue_Longfight_2", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    minTurnsThisCombat = 9,
                    oncePerCombatTags = ["manyTurns"],
                    dialogue =
                    [
                        new(AmZari, "explains", "Patience is a virtue.")
                    ]
                }
            },
            {
                "Zari_Dialogue_Longfight_3", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    minTurnsThisCombat = 9,
                    oncePerCombatTags = ["manyTurns"],
                    dialogue =
                    [
                        new(AmZari, "neutral", "I never lose the long game.")
                    ]
                }
            },
            {
                "Zari_Dialogue_Longfight_4", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari ],
                    minTurnsThisCombat = 9,
                    oncePerCombatTags = ["manyTurns"],
                    dialogue =
                    [
                        new(AmZari, "explains", "After a thousand years, I can outwait anything.")
                    ]
                }
            },



            //Dialogue related to playing many cards
            {
                "Zari_Dialogue_ManyCards_0", new()
                {
                    type = NodeType.combat,
                    oncePerCombatTags = ["ZariManyCardsPlayed"],
                    oncePerCombat = true,
                    minCardsPlayedThisTurn = 12,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "explains", "Simply splendid!")
                    ]
                }
            },
            {
                "Zari_Dialogue_ManyCards_1", new()
                {
                    type = NodeType.combat,
                    oncePerCombatTags = ["ZariManyCardsPlayed"],
                    oncePerCombat = true,
                    minCardsPlayedThisTurn = 12,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "neutral", "Wonderful work!")
                    ]
                }
            },
            {
                "Zari_Dialogue_ManyCards_2", new()
                {
                    type = NodeType.combat,
                    oncePerCombatTags = ["ZariManyCardsPlayed"],
                    oncePerCombat = true,
                    minCardsPlayedThisTurn = 12,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "neutral", "Excellent!")
                    ]
                }
            },






            //Dahlia dialogue
            {
                "BanditThreats_Multi_0", new()
                {
                    edit = 
                    [
                        new(EMod.countFromStart, 1, AmZari, "annoyed", "Excuse me? That is not what I ordered.")
                    ]
                }
            },

            //Crab dialogue
            {
                "CrabFacts1_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmZari, "pondering", "Tell me more about these 'crabs'.")
                    ]
                }
            },
            {
                "CrabFacts2_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 2, AmZari, "pondering", "This sounds like nonsense.")
                    ]
                }
            },
            {
                "CrabFactsAreOverNow_Multi_0", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmZari, "annoyed", "It was mostly drivel, was it not?")
                    ]
                }
            },



            //Dillian dialogue
            {
                "DillianShouts", new()
                {
                    edit =
                    [
                        new(EMod.countFromStart, 1, AmZari, "annoyed", "And who are you, exactly?")
                    ]
                }
            },





        });
    }
}
