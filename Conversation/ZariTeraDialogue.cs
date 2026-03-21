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
