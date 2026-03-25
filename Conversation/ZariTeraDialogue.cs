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

internal class ZariTeraDialogue : IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        LocalDB.DumpStoryToLocalLocale("en", "TeraTheTaxCollector", new Dictionary<string, DialogueMachine>()
        {

            {
                "ZariMeetsTera_Intro_0", new()
                {
                    type = NodeType.@event,
                    lookup = [ "zone_first" ],
                    once = true,
                    allPresent = [ AmZari, AmTera ],
                    bg = "BGRunStartZari",
                    requiredScenes = ["Zari_Intro_0"],
                    dialogue =
                    [

                        new(AmTera, "Hey CAT."),
                        new(AmCat, "peace", "Hey Tera!", flipped: true),
                        new(AmCat, "Up early today?", flipped: true),
                        new(AmTera, "Yeah."),
                        new(AmTera, "taxes", "Just wanted to get some things filed before we started."),
                        new(AmTera, "taxes", "Even a time loop doesn't stop tax season."),
                        new(AmCat, "Sounds good. Just be ready, we'll be starting soon.", flipped: true),
                        new(new Wait{secs = 1.5}),
                        new(new BGAction{action = "flash_weak"}),
                        new(new Wait{secs = 1}),
                        new(AmTera, "scared", "W-what?"),
                        new(AmTera, "scared", "Why is the ship flooded with gold?"),
                        new(AmZari, "pondering", "Hmm.", flipped: true),
                        new(AmZari, "pondering", "CAT? It seems the coins spilled out again.", flipped: true),
                        new(AmZari, "annoyed", "Bother. I knew that chest was overfilled.", flipped: true),
                        new(AmTera, "scared", "A d-dragon? You're a dragon?!"),
                        new(AmTera, "lookawaynervous", "Did you steal all this gold?"),
                        new(AmZari, "annoyed", "Steal?", flipped: true),
                        new(AmZari, "annoyed", "Word of advice, little bird.", flipped: true),
                        new(AmZari, "annoyed", "If you want to keep those feathers of yours, question not the legitimacy of my wealth.", flipped: true),
                        new(AmTera, "sad", "Aaah! Don't hurt me!"),
                        new(AmTera, "sad", "I don't want to be set on fire!"),
                        new(AmZari, "arrogant", "Burn you to death? How old fashioned.", flipped: true),
                        new(AmZari, "arrogant", "Sending things out the airlock is in style now, is it not?", flipped: true),
                        new(AmTera, "lookawaynervous", "I..."),
                        new(new Wait{secs = 2}),
                        new(AmZari, "pondering", "Goodness me, you truly WERE terrified, were you not?", flipped: true),
                        new(AmZari, "explains", "I was only half joking.", flipped: true),
                        new(AmTera, "lookawaynervous", "Only ‘half’ joking? You sound just like Drake."),
                        new(AmZari, "Ah! Have you met my niece?", flipped: true),
                        new(AmZari, "She keeps insisting on that silly little nickname. Her proper name is Eunice.", flipped: true),
                        new(AmTera, "squint", "You're her aunt?"),
                        new(AmZari, "explains", "Indeed.", flipped: true),
                        new(AmTera, "squint", "...Tell me more.")

                    ]
                }
            },

            {
                "ZariTera_Dialogue_Pact_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariPact" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmTera ],
                    dialogue =
                    [
                        new(AmZari, "explains", "Thank you for agreeing to my pact."),
                        new(AmTera, "scared", "W-wait, THAT'S what I signed?"),
                    ]
                }
            },

            {
                "Zari_AboutToDieAndLoop_Tera_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari, AmTera ],
                    enemyShotJustHit = true,
                    maxHull = 2,
                    minDamageDealtToPlayerThisTurn = 1,
                    oncePerRunTags = ["aboutToDie"],
                    oncePerRun = true,
                    dialogue =
                    [
                        new(AmZari, "resigned", "All my wealth and assets, to be destroyed..."),
                        new(AmTera, "squint", "Can you get your tail out of my face so I can CONCENTRATE?"),
                    ]
                }
            },

            {
                "ZariTera_Dialogue_WeGotShotButTookNoDMG_0", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmZari, AmTera ],
                    enemyShotJustHit = true,
                    maxDamageDealtToPlayerThisTurn = 0,
                    oncePerCombatTags = ["Zari_WeGotShotButTookNoDMG_Tag"],
                    oncePerCombat = true,
                    dialogue =
                    [
                        new(AmZari, "explains", "The noble dragon protects the motley crew from harm."),
                        new(AmTera, "squint", "Yeah yeah, can it, grandma.")
                    ]
                }
            },

            {
                "Zari_Dialogue_UnburdenTera_0", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariUnburden" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerCombat = true,
                    allPresent = [ AmZari, AmTera ],
                    dialogue =
                    [
                        new(AmZari, "resigned", "Why must we throw away? It is all so valuable..."),
                        new(AmTera, "happy", "Less stuff means less taxable assets!")
                    ]
                }
            },

            {
                "Zari_Dialogue_Avarice_Tera", new()
                {
                    type = NodeType.combat,
                    lookup = [ "ZariAvarice" ],
                    oncePerCombatTags = ["ZariCardSpecificDialogueCrewOnce"],
                    oncePerRun = true,
                    allPresent = [ AmZari, AmTera ],
                    dialogue =
                    [
                        new(AmTera, "lookaway", "How did you...do that?"),
                        new(AmZari, "arrogant", "Curious, little bird?")
                    ]
                }
            },

            {
                "ZariTera_Dialogue_WeGainedExcessiveWealth_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [ AmZari, AmTera ],
                    hasArtifactTypes = [typeof(OpulantWealth)],
                    oncePerCombatTags = ["ZariArtifactSpecificDialogueCrewOnce"],
                    turnStart = true,
                    maxTurnsThisCombat = 1,
                    dialogue =
                    [
                        new(AmZari, "nap", "Finally, a proper bed of gold to lie on."),
                        new(AmTera, "squint", "Are you gonna pay taxes on that?")
                    ]
                }
            },

            {
                "Tera_Dialogue_ZariMissing", new()
                {
                    type = NodeType.combat,
                    allPresent = [ AmTera ],
                    priority = true,
                    oncePerRun = true,
                    oncePerCombatTags = ["ZariWentMissing"],
                    lastTurnPlayerStatuses = [MissingZari],
                    dialogue =
                    [
                        new(AmTera, "lookaway", "...Holy heck I can see now.")
                    ]
                }
            }

        });
    }
}
