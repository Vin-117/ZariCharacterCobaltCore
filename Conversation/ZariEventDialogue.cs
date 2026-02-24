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




            //Dialogue for the ephermeral events
            {
                $"ChoiceCardRewardOfYourColorChoice_{AmZari}", new()
                {
                    type = NodeType.@event,
                    oncePerRun = true,
                    allPresent = [ AmZari ],
                    bg = "BGBootSequence",
                    dialogue = 
                    [
                        new(AmVoid, "You do not belong here."),
                        new(AmZari, "squint", "I was well aware.")
                    ]
                }
            },
            {
                "ForeignCardOffering_After", new()
                {
                    edit = 
                    [
                        new(EMod.countFromStart, 1, AmZari, "pondering", "I suppose we can accept this...")
                    ]
                }
            },
            {
                "ForeignCardOffering_Refuse", new()
                {
                    edit = 
                    [
                        new(EMod.countFromStart, 1, AmZari, "squint", "I know an offer with strings when I see one.")
                    ]
                }
            },
            {
                "EphemeralCardGift", new()
                {
                    edit = 
                    [
                        new(EMod.countFromStart, 1, AmZari, "squint", "My mind is not yours to read!")
                    ]
                }
            },



            //Dialogue for picking Zari from the crystal pilot event
            {
                $"CrystallizedFriendEvent_{AmZari}", new()
                {
                    type = NodeType.@event,
                    oncePerRun = true,
                    allPresent = [ AmZari ],
                    bg = "BGCrystalizedFriend",
                    dialogue = 
                    [
                        new(new Wait{secs = 1.5}),
                        new(AmZari, "arrogant", "I see you have exquisite taste.")
                    ]
                }
            },



            //Dialogue for the forced card remove event
            {
                "LoseCharacterCard", new()
                {
                    edit = 
                    [
                        new(EMod.countFromStart, 1, AmZari, "annoyed", "Is it not your job to prevent this from happening?")
                    ]
                }
            },
            {
                $"LoseCharacterCard_{AmZari}", new()
                {
                    type = NodeType.@event,
                    allPresent = [ AmZari ],
                    oncePerRun = true,
                    bg = "BGSupernova",
                    dialogue = 
                    [
                        new(AmZari, "resigned", "If I must part with something...very well.")
                    ]
                }
            },

            //Dialogue for dracula
            {
                "DraculaTime", new()
                {
                    edit = 
                    [
                        new(EMod.countFromStart, 1, AmZari, "neutral", "Pleased to make your acquaintance, Dracula.")
                    ]
                }
            },

            //Dialogue for repairing the ship
            {
                "AbandonedShipyard_Repaired", new()
                {
                    edit = 
                    [
                        new(EMod.countFromStart, 1, AmZari, "neutral", "Ah, good. I was meaning to polish the outer hull.")
                    ]
                }
            },

            //Grandma dialogue
            {
                "GrandmaShop", new()
                {
                    edit = 
                    [
                        new(EMod.countFromStart, 1, AmZari, "arrogant", "One roast pig, if you'd please.")
                    ]
                }
            },

            //Soggins.
            {
                "SogginsEscape_1", new()
                {
                    edit = 
                    [
                        new(EMod.countFromStart, 1, AmZari, "annoyed", "Excuse me?")
                    ]
                }
            },
            {
                "Soggins_Infinite", new()
                {
                    edit = 
                    [
                        new(EMod.countFromStart, 1, AmZari, "arrogant", "It would be a shame if we decided to just leave right now, would it not?")
                    ]
                }
            }
        });
    }
}
