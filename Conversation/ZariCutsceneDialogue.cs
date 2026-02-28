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

internal class ZariCutsceneDialogue : IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {

            {
                "Zari_Intro_0000000000", new()
                {
                    type = NodeType.@event,
                    lookup = [ "zone_first" ],
                    once = false,
                    allPresent = [ AmZari ],
                    bg = "BGRunStartZari",
                    dialogue = 
                    [
                        new(AmCat, "Testing...", flipped: true),
                        new(new Wait{secs = 1}),
                        //new(new BGAction{action = "rumble_on"}),
                        //new(new BGAction{action = "flash"}),
                        new(new BGAction{action = "bonk"}),
                        new(AmCat, "Did that worK?", flipped: true),
                    ]
                }
            },

        });
    }
}
