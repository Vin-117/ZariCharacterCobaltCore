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
                        new(AmGarrus, "pda", "Missiles storage check...")
                    ]
                }
            },


        });
    }
}
