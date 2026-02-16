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

internal class ZariEventDialogue : IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {




            //Dialogue related to getting to a repair yard.
            {
                "Zari_Dialogue_Shopkeeper_0", new()
                {
                    type = NodeType.@event,
                    lookup = [ "shopBefore" ],
                    bg = "BGShop",
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmShopkeeper, "Still sitting on all that gold?", true),
                        new(AmZari, "annoyed", "My spending habits are none of your concern."),
                        new(new Jump{key = "NewShop"})
                    ]
                }
            },
            {
                "Zari_Dialogue_Shopkeeper_1", new()
                {
                    type = NodeType.@event,
                    lookup = [ "shopBefore" ],
                    bg = "BGShop",
                    allPresent = [ AmZari ],
                    nonePresent = [ AmDrake ],
                    dialogue =
                    [
                        new(AmShopkeeper, "Not often I see dragons around here.", true),
                        new(AmZari, "arrogant", "Did I fetch your eye?"),
                        new(new Jump{key = "NewShop"})
                    ]
                }
            },
            {
                "Zari_Dialogue_Shopkeeper_2", new()
                {
                    type = NodeType.@event,
                    lookup = [ "shopBefore" ],
                    bg = "BGShop",
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmShopkeeper, "Have any gold or gems you'd be willing to part with?", true),
                        new(AmZari, "greedy", "No."),
                        new(new Jump{key = "NewShop"})
                    ]
                }
            },
            {
                "Zari_Dialogue_Shopkeeper_3", new()
                {
                    type = NodeType.@event,
                    lookup = [ "shopBefore" ],
                    bg = "BGShop",
                    allPresent = [ AmZari ],
                    dialogue =
                    [
                        new(AmShopkeeper, "I could cut a deal if you'd spare me some gems.", true),
                        new(AmZari, "greedyannoyed", "My hoard is not for sale."),
                        new(new Jump{key = "NewShop"})
                    ]
                }
            },

















        });
    }
}
