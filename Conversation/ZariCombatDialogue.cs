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
                        new(AmZari, "pondering", "The next attack may not land.") 
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
                        new(AmZari, "pondering", "The next attack will not land.")
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
            {
                "Zari_Dialogue_ShotHitDrake_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari, AmDrake ],
                    playerShotJustHit = true,
                    oncePerRun = true,
                    minDamageDealtToEnemyThisAction = 4,
                    whoDidThat = Deck.eunice,
                    dialogue =
                    [
                        new(AmZari, "annoyed", "You are a brute, Eunice."),
                        new(AmDrake, "sly", "You're just jealous that you can't hit as hard.")
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
                        new(AmZari, "neutral", "Splendid defense.")
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
                        new(AmZari, "neutral", "Excellent block.")
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
                        new(AmZari, "explains", "No damage, of course.")
                    ]
                }
            },
            {
                "ZariDizzy_Dialogue_WeGotShotButTookNoDMG_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari, AmDizzy ],
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    oncePerCombatTags = ["Zari_WeGotShotButTookNoDMG_Tag"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmDizzy, "explains", "No damage."),
                        new(AmZari, "explains", "Indeed.")
                    ]
                }
            },
            {
                "ZariIsaac_Dialogue_WeGotShotButTookNoDMG_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari, AmIsaac ],
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    oncePerCombatTags = ["Zari_WeGotShotButTookNoDMG_Tag"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmIsaac, "shy", "Huh...we're pretty hard to kill."),
                        new(AmZari, "explains", "After a thousand attempts, you get used to it.")
                    ]
                }
            },
            {
                "ZariDrake_Dialogue_WeGotShotButTookNoDMG_1", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari, AmDrake ],
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    oncePerCombatTags = ["Zari_WeGotShotButTookNoDMG_Tag"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "explains", "No damage, of course."),
                        new(AmDrake, "squint", "You're so boring, you know that?")
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
                        new(AmZari, "arrogant", "Shall we lead them on a wild dragon chase?")
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
                        new(AmZari, "arrogant", "Fancy a game of dragon and mouse?")
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
                        new(AmZari, "annoyed", "There is nothing simple about reducing our hoard.")
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
                        new(AmZari, "annoyed", "This furnace smells dirtier than a muddy peasant.")
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
                        new(AmZari, "neutral", "A regenerating flying ship? Quaint!")
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
                        new(AmZari, "explains", "This heal trinket is handy with regeneration, is it not?")
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
                        new(AmZari, "explains", "Finally! Now I may properly hoard the shields!")
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
            {
                "Zari_Dialogue_WeGainedGenesis_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari ],
                    hasArtifacts = [ "Genesis" ],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmZari, "arrogant", "I do fancy a well packaged gift.")
                    ]
                }
            },
            {
                "Zari_Dialogue_WeGainedCleoGlasses_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari ],
                    hasArtifacts = [ "BrokenGlasses" ],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmZari, "explains", "I had my eye on those glasses for a while, you know.")
                    ]
                }
            },
            {
                "Zari_Dialogue_WeGainedWarpMastery_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari ],
                    hasArtifacts = [ "WarpMastery" ],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmZari, "pondering", "How does one master their warp?")
                    ]
                }
            },
            {
                "Zari_Dialogue_WeGainedExcessiveWealth_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari ],
                    hasArtifactTypes = [typeof(OpulantWealth)],
                    oncePerRunTags = ["ZariWealthComment"],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmZari, "nap", "At long last, a proper hoard.")
                    ]
                }
            },
            {
                "ZariPeri_Dialogue_WeGainedExcessiveWealth_0", new()
                {
                    type = NodeType.combat,
                    priority = true,
                    oncePerRun = true,
                    oncePerRunTags = ["ZariWealthComment"],
                    allPresent = [ AmZari, AmPeri ],
                    hasArtifactTypes = [typeof(OpulantWealth)],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmPeri, "squint", "Zari, I'm going to need you to clear some of this gold."),
                        new(AmZari, "arrogant", "Make me.")
                    ]
                }
            },
            {
                "ZariRiggs_Dialogue_WeGainedExcessiveWealth_0", new()
                {
                    type = NodeType.combat,
                    priority = true,
                    oncePerRunTags = ["ZariWealthComment"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmRiggs ],
                    hasArtifactTypes = [typeof(OpulantWealth)],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmRiggs, "squint", "Where did all this gold come from?"),
                        new(AmZari, "arrogant", "Nowhere.")
                    ]
                }
            },
            {
                "ZariDizzy_Dialogue_WeGainedExcessiveWealth_0", new()
                {
                    type = NodeType.combat,
                    priority = true,
                    oncePerRunTags = ["ZariWealthComment"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmDizzy ],
                    hasArtifactTypes = [typeof(OpulantWealth)],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmDizzy, "intense", "I didn't think you had THAT much wealth..."),
                        new(AmZari, "arrogant", "Impressed?")
                    ]
                }
            },
            {
                "ZariIsaac_Dialogue_WeGainedExcessiveWealth_0", new()
                {
                    type = NodeType.combat,
                    priority = true,
                    oncePerRunTags = ["ZariWealthComment"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmIsaac ],
                    hasArtifactTypes = [typeof(OpulantWealth)],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmIsaac, "shy", "I'm having trouble moving with all this gold in the cockpit.")
                    ]
                }
            },
            {
                "ZariMax_Dialogue_WeGainedExcessiveWealth_0", new()
                {
                    type = NodeType.combat,
                    priority = true,
                    oncePerRunTags = ["ZariWealthComment"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmMax ],
                    hasArtifactTypes = [typeof(OpulantWealth)],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmMax, "squint", "I don't think anyone needs this much money."),
                        new(AmZari, "annoyed", "What are you getting at?")
                    ]
                }
            },
            {
                "ZariDrake_Dialogue_WeGainedExcessiveWealth_0", new()
                {
                    type = NodeType.combat,
                    priority = true,
                    oncePerRunTags = ["ZariWealthComment"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmDrake ],
                    hasArtifactTypes = [typeof(OpulantWealth)],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmDrake, "sly", "Thanks for the donation, Aunt."),
                        new(AmZari, "annoyed", "Why you...give that gold back! Or else!")
                    ]
                }
            },
            {
                "ZariBooks_Dialogue_WeGainedExcessiveWealth_0", new()
                {
                    type = NodeType.combat,
                    priority = true,
                    oncePerRunTags = ["ZariWealthComment"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmBooks ],
                    hasArtifactTypes = [typeof(OpulantWealth)],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmBooks, "paws", "Wow! So much gold!"),
                        new(AmZari, "explains", "I've been putting that lead-to-gold recipe to good use.")
                    ]
                }
            },
            {
                "ZariCat_Dialogue_WeGainedExcessiveWealth_0", new()
                {
                    type = NodeType.combat,
                    priority = true,
                    oncePerRunTags = ["ZariWealthComment"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmCat ],
                    hasArtifactTypes = [typeof(OpulantWealth)],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmCat, "grumpy", "This gold is adding too much weight to the ship."),
                        new(AmZari, "annoyed", "And? We are not throwing it out.")
                    ]
                }
            },


            
            {
                "Zari_Dialogue_WeGainedSimpleBeauty_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari ],
                    hasArtifactTypes = [typeof(Temperance)],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmZari, "resigned", "Oh, how I miss him...")
                    ]
                }
            },
            {
                "Zari_Dialogue_WeGainedChesspiece_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari ],
                    nonePresent = [ AmDizzy, AmMax, AmPeri ],
                    hasArtifactTypes = [typeof(CrownChessPiece)],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmZari, "chess", "Anyone fancy a game of chess?")
                    ]
                }
            },
             {
                "ZariDizzy_Dialogue_WeGainedChesspiece_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari, AmDizzy ],
                    hasArtifactTypes = [typeof(CrownChessPiece)],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmZari, "chess", "Anyone fancy a game of chess?"),
                        new(AmDizzy, "squint", "What kind?")
                    ]
                }
            },
            {
                "Zari_Dialogue_P22_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari, AmDizzy ],
                    hasArtifacts = [ "Prototype22" ],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmZari, "annoyed", "You built a machine to mimic what I do?"),
                        new(AmDizzy, "explains", "Take it as a compliment.")
                    ]
                }
            },
            {
                "Zari_Dialogue_shieldburst_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari, AmDizzy ],
                    hasArtifacts = [ "ShieldBurst" ],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmZari, "pondering", "Shield on top of shield? How does that work?"),
                        new(AmDizzy, "explains", "Overclocking the capacitors at the cusp of the EM field spike. Elementary stuff, really.")
                    ]
                }
            },
            {
                "Zari_Dialogue_quickdraw_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari, AmRiggs ],
                    hasArtifacts = [ "Quickdraw" ],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmRiggs, "Lots of options!"),
                        new(AmZari, "The more the better!")
                    ]
                }
            },
            {
                "Zari_Dialogue_tridimensionalcockpit_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari, AmMax ],
                    hasArtifacts = [ "TridimensionalCockpit" ],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmZari, "explains", "This new cockpit finally gives me room to lounge!"),
                        new(AmMax, "squint", "...How did you even fit in the ship before?")
                    ]
                }
            },
            {
                "Zari_Dialogue_rockcollection_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari, AmBooks ],
                    hasArtifacts = [ "RockCollection" ],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmZari, "neutral", "Fantastic rock collection, my dear."),
                        new(AmBooks, "blush", "Thanks mom!")
                    ]
                }
            },

            //Fighting cleo 
            {
                "ShopKeepBattleInsult", new()
                {
                    edit = 
                    [
                        new("66ea84d6", AmZari, "annoyed", "I have had enough of you sizing up my hoard!"),
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
                        new(AmZari, "neutral", "This ship reminds me of my home.")
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








            //Dialogue for playing certain Zari cards
            {
                "Zari_Dialogue_Scorn_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariScorn" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "squint", "Enough of their insolence. We end this now.")
                    ]
                }
            },
            {
                "Zari_Dialogue_Scorn_1", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariScorn" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "squint", "My patience wears thin. Kill them, if you would.")
                    ]
                }
            },
            {
                "Zari_Dialogue_Scorn_2", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariScorn" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "squint", "I tire of this impudence. Finish them.")
                    ]
                }
            },
            {
                "ZariPeri_Dialogue_Pact_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariPact" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmPeri ],
                    dialogue =
                    [
                        new(AmPeri, "squint", "This is an unfair deal."),
                        new(AmZari, "arrogant", "What else were you expecting?")
                    ]
                }
            },
            {
                "ZariDizzy_Dialogue_Pact_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariPact" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmDizzy ],
                    dialogue =
                    [
                        new(AmDizzy, "intense", "...Wait, what did that fine print say?"),
                        new(AmZari, "arrogant", "Nothing you need to worry about.")
                    ]
                }
            },
            {
                "ZariRiggs_Dialogue_Pact_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariPact" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmRiggs ],
                    dialogue =
                    [
                        new(AmZari, "arrogant", "Thank you for your signature."),
                        new(AmRiggs, "As long as there's free boba!"),
                    ]
                }
            },
            {
                "ZariIsaac_Dialogue_Pact_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariPact" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmIsaac ],
                    dialogue =
                    [
                        new(AmIsaac, "squint", "I don't like what this contract is saying..."),
                        new(AmZari, "arrogant", "It is a perfectly fair deal, I assure you.")
                    ]
                }
            },
            {
                "ZariDrake_Dialogue_Pact_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariPact" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmDrake ],
                    dialogue =
                    [
                        new(AmDrake, "squint", "I'm not stupid enough to sign this."),
                        new(AmZari, "arrogant", "Really? What about this signature you gave me twenty years ago?")
                    ]
                }
            },
            {
                "ZariMax_Dialogue_Pact_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariPact" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmMax ],
                    dialogue =
                    [
                        new(AmZari, "worried", "...Why are you signing without reading?"),
                        new(AmMax, "Reading the terms and conditions takes too long.")
                    ]
                }
            },
            {
                "ZariBooks_Dialogue_Pact_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariPact" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmBooks ],
                    dialogue =
                    [
                        new(AmBooks, "blush", "Silly Auntie, I've already signed this!"),
                        new(AmZari, "pondering", "Ah. I suppose you have.")
                    ]
                }
            },
            {
                "ZariCat_Dialogue_Pact_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariPact" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmCat ],
                    dialogue =
                    [
                        new(AmCat, "squint", "I can't physically sign this."),
                        new(AmZari, "explains", "I do accept e-signatures!")
                    ]
                }
            },

            {
                "Zari_Dialogue_Undying_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariUndying" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "crystal", "What a brilliant diamond...")
                    ]
                }
            },
            {
                "Zari_Dialogue_Undying_1", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariUndying" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "crystal", "Beautiful, is it not?")
                    ]
                }
            },
            {
                "Zari_Dialogue_Undying_2", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariUndying" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "greedycrystal", "A fine addition to my collection.")
                    ]
                }
            },

            {
                "Zari_Dialogue_Unburden_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariUnburden" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "resigned", "I can move my chest of antique silver coins, if you insist.")
                    ]
                }
            },
            {
                "Zari_Dialogue_Unburden_1", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariUnburden" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "pondering", "Good time to toss the scuffed coins, I suppose.")
                    ]
                }
            },
            {
                "Zari_Dialogue_Unburden_2", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariUnburden" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "resigned", "Does no one appreciate my curated gem collection?")
                    ]
                }
            },
            {
                "Zari_Dialogue_Unburden_3", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariUnburden" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "annoyed", "The raw silver can go, but I shalln't part with the polished gold!")
                    ]
                }
            },
            {
                "Zari_Dialogue_Unburden_4", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariUnburden" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "resigned", "Must the platinum ingots be disposed as well?")
                    ]
                }
            },
            {
                "Zari_Dialogue_Avarice_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariAvarice" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "explains", "Why settle for less when you can have more?")
                    ]
                }
            },
            {
                "Zari_Dialogue_Avarice_1", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariAvarice" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "arrogant", "Clever move, was it not?")
                    ]
                }
            },
            {
                "Zari_Dialogue_Avarice_2", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariAvarice" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "explains", "A little ambition can do a lot of good.")
                    ]
                }
            },
            {
                "Zari_Dialogue_Avarice_3", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariAvarice" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "greedy", "I will have my gold and spend it too.")
                    ]
                }
            },
            {
                "Zari_Dialogue_Avarice_4", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariAvarice" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmZari, "arrogant", "Me? Greedy? What gave you the idea?")
                    ]
                }
            },

            //Avarice Dialogue with other characters
            {
                "ZariDrake_Dialogue_Avarice_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariAvarice" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmDrake ],
                    dialogue =
                    [
                        new(AmDrake, "squint", "You think you're so smart, don't you."),
                        new(AmZari, "explains", "Simple wisdom, my dear niece.")
                    ]
                }
            },
            {
                "ZariDizzy_Dialogue_Avarice_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariAvarice" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmDizzy ],
                    dialogue =
                    [
                        new(AmDizzy, "intense", "How did you do that?"),
                        new(AmZari, "explains", "Live a thousand years and you learn some things.")
                    ]
                }
            },
            {
                "ZariBooks_Dialogue_Avarice_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariAvarice" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmBooks ],
                    dialogue =
                    [
                        new(AmBooks, "paws", "Wow! Was that a magic trick?"),
                        new(AmZari, "explains", "Of sorts.")
                    ]
                }
            },
            {
                "ZariIsaac_Dialogue_Avarice_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariAvarice" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmIsaac ],
                    dialogue =
                    [
                        new(AmZari, "pondering", "Some finesse will be required for this..."),
                        new(AmIsaac, "shy", "Are all dragons this crafty?")
                    ]
                }
            },
            {
                "ZariMax_Dialogue_Avarice_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariAvarice" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmMax ],
                    dialogue =
                    [
                        new(AmMax, "Smooth move there."),
                        new(AmZari, "explains", "Why thank you.")
                    ]
                }
            },
            {
                "ZariPeri_Dialogue_Avarice_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariAvarice" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmPeri ],
                    dialogue =
                    [
                        new(AmPeri, "squint", "What other tricks are you hiding?"),
                        new(AmZari, "arrogant", "I would rather show than tell.")
                    ]
                }
            },


            //Dialogue when about to die
            {
                "Zari_AboutToDieAndLoop_Dizzy_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari, AmDizzy ],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    minDamageDealtToPlayerThisTurn = 1,
                    oncePerRunTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue = 
                    [
                        new(AmDizzy, "frown", "This timeline is unsalvageable."),
                        new(AmZari, "resigned", "I fear you are correct.")
                    ]
                }
            },
            {
                "Zari_AboutToDieAndLoop_Peri_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari, AmPeri ],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    minDamageDealtToPlayerThisTurn = 1,
                    oncePerRunTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmZari, "resigned", "They are going to salvage this ship for my hoard."),
                        new(AmPeri, "mad", "Is that all you care about?")
                    ]
                }
            },
            {
                "Zari_AboutToDieAndLoop_Riggs_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari, AmRiggs ],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    minDamageDealtToPlayerThisTurn = 1,
                    oncePerRunTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmRiggs, "I'm okay with the events that are unfolding currently."),
                        new(AmZari, "squint", "We are about to die.")
                    ]
                }
            },
            {
                "Zari_AboutToDieAndLoop_Isaac_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari, AmIsaac ],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    minDamageDealtToPlayerThisTurn = 1,
                    oncePerRunTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmIsaac, "squint", "They're going to destroy the ship and all my drones."),
                        new(AmZari, "resigned", "And my hoard.")
                    ]
                }
            },
            {
                "Zari_AboutToDieAndLoop_Max_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari, AmMax ],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    minDamageDealtToPlayerThisTurn = 1,
                    oncePerRunTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmZari, "annoyed", "I just know they will pillage our ship for valuables."),
                        new(AmMax, "squint", "Like you've been doing with every ship we've destroyed?")
                    ]
                }
            },
            {
                "Zari_AboutToDieAndLoop_Drake_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari, AmDrake ],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    minDamageDealtToPlayerThisTurn = 1,
                    oncePerRunTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmZari, "resigned", "This is our end."),
                        new(AmDrake, "squint", "Don't you know better than to give up? Get a grip."),
                    ]
                }
            },
            {
                "Zari_AboutToDieAndLoop_Books_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari, AmBooks ],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    minDamageDealtToPlayerThisTurn = 1,
                    oncePerRunTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmBooks, "stoked", "Uh oh! Do something, auntie!"),
                        new(AmZari, "resigned", "I am sorry, little one. This may be our end."),
                    ]
                }
            },
            {
                "Zari_AboutToDieAndLoop_Comp_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari, AmCat ],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    minDamageDealtToPlayerThisTurn = 1,
                    oncePerRunTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmZari, "resigned", "I am about to lose everything!"),
                        new(AmCat, "squint", "You'll loop back with it anyway. Why does it matter?"),
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
