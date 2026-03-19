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

internal class ZariGarrusDialogue : IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        LocalDB.DumpStoryToLocalLocale("en", "Vintage.VicCharacter", new Dictionary<string, DialogueMachine>()
        {

            {
                "ZariMeetsGarrus_Intro_0", new()
                {
                    type = NodeType.@event,
                    lookup = [ "zone_first" ],
                    once = false,
                    allPresent = [ AmZari, AmGarrus ],
                    bg = "BGRunStartZari",
                    requiredScenes = ["Zari_Intro_0"],
                    dialogue =
                    [
                        new(AmGarrus, "pda", "Missile storage?"),
                        new(AmCat, "Fully loaded."),
                        new(AmGarrus, "pda", "Good. FTL canisters?"),
                        new(AmCat, "Cooled and ready to job."),
                        new(AmGarrus, "pda", "Excellent. That is all for the manifest check."),
                        new(AmGarrus, "pdapressured", "Except...what's this?"),
                        new(AmGarrus, "pdapressured", "Seven tons of gold coins?"),
                        new(new BGAction{action = "flash_weak"}),
                        new(new Wait{secs = 1}),
                        new(AmGarrus, "observe", "What the hell was that? CAT! Status report!)
                        new(AmZari, "arrogant", "No need, little bird."),
                        new(AmZari, "explains", "That bang was a mere announcement of my arrival."),
                        new(AmGarrus, "pressuredneutral", "A dragon? Who are you?"),
                        new(AmZari, "explains", "I am Zari."),
                        new(AmZari, "neutral", "I shall be joining you for your little hero adventure."),
                        new(AmGarrus, "annoyed", "'Hero adventure'?"),
                        new(AmGarrus, "annoyed", "This isn't a game."),
                        new(AmZari, "arrogant", "Both blind and a bird? What a curious little thing you are."),
                        new(AmGarrus, "doubtful", "I can see we're already getting along well.")
                    ]
                }
            },

            {
                "Zari_AboutToDieAndLoop_Garrus_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari, AmGarrus ],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    minDamageDealtToPlayerThisTurn = 1,
                    oncePerRunTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmZari, "resigned", "They are going to destroy my hoard."),
                        new(AmGarrus, "doubtful", "I see you have your priorities in order."),
                    ]
                }
            },

            {
                "Zari_Dialogue_UnburdenGarrus_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariUnburden" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari, AmGarrus ],
                    dialogue =
                    [
                        new(AmZari, "resigned", "Tossing the coins? Must you be so cruel?"),
                        new(AmGarrus, "annoyed", "This ship is not your dumping ground.")
                    ]
                }
            },

            {
                "Zari_Dialogue_Avarice_Garrus", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariAvarice" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmGarrus ],
                    dialogue =
                    [
                        new(AmGarrus, "observe", "Clever move. I'll give you that.")
                        new(AmZari, "arrogant", "Jealous, little bird?")
                    ]
                }
            },

            {
                "ZariGarrus_Dialogue_WeGainedSimplicity_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari, AmZari ],
                    oncePerRun = true,
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    oncePerCombatTags = ["ZariArtifactSpecificDialogueCrewOnce"],
                    hasArtifacts = [ "Simplicity" ],
                    dialogue =
                    [
                        new(AmGarrus, "neutral", "Better to keep things simple."),
                        new(AmZari, "annoyed", "You toss half my hoard and call that 'simplicity'?!")
                    ]
                }
            },

            {
                "ZariGarrus_Dialogue_WeGainedExcessiveWealth_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari, AmGarrus ],
                    hasArtifactTypes = [typeof(OpulantWealth)],
                    oncePerCombatTags = ["ZariArtifactSpecificDialogueCrewOnce"],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmGarrus, "annoyed", "Who's decision was it to let Zari bring more garbage onto the ship?")
                        new(AmZari, "greedycrystal", "Jealous?")
                    ]
                }
            }

        });
    }
}
