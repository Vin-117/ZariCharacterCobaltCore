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


        });
    }
}
