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
                "Zari_Intro_0", new()
                {
                    type = NodeType.@event,
                    lookup = [ "zone_first" ],
                    once = true,
                    allPresent = [ AmZari ],
                    bg = "BGRunStartZari",
                    dialogue = 
                    [
                        new(AmCat, "Time to get up, everyone!", flipped: true),
                        new(new Wait{secs = 2}),
                        new(AmCat, "squint", "Seriously, come on. We have places to-", flipped: true),
                        new(new BGAction{action = "flash_weak"}),
                        new(new BGAction{action = "rumble_on"}),
                        new(new Wait{secs = 2}),
                        new(AmCat, "intense", "...Cargo mass limit exceeded?! What...", flipped: true),
                        new(AmZari, "arrogant", "Why hello there."),
                        new(AmCat, "intense", "Who are you?", flipped: true),
                        new(AmZari, "explains", "I am Zari. A dragon of the golden class."),
                        new(AmCat, "squint", "A dragon? How did you end up here?", flipped: true),
                        new(AmZari, "greedycrystal", "Trade secret."),
                        new(AmZari, "pondering", "Regardless, it seems my suspicions were correct."),
                        new(AmZari, "pondering", "This is a time loop, is it not?"),
                        new(AmCat, "Yep!", flipped: true),
                        new(AmZari, "pondering", "I see. Mind if I lend a claw?"),
                        new(AmCat, "Sure!", flipped: true),
                        new(AmCat, "squint", "...after you fix the hull breach your tail just created.", flipped: true),
                        new(AmZari, "pondering", "Hm. Bother."),
                    ]
                }
            },

            {
                "Zari_AfterCrystal_0", new()
                {
                    type = NodeType.@event,
                    lookup = ["after_crystal"],
                    bg = "BGCrystalNebula",
                    allPresent = [ AmZari ],
                    once = true,
                    priority = true,
                    requiredScenes = ["Zari_Intro_0"],
                    dialogue =
                    [
                        new(AmZari, "crystal", "Another time crystal. How exquisite."),
                        new(AmCat, "squint", "Are you collecting those?", flipped: true),
                        new(AmZari, "greedycrystal", "Indeed. Why else would I be here?"),
                        new(AmCat, "squint", "You said you were lending a hand.", flipped: true),
                        new(AmZari, "greedycrystal", "Exactly. Which allows me access to more time crystals."),
                        new(AmZari, "explains", "My hoard will not build itself, you know."),
                        new(AmCat, "squint", "...", flipped: true),
                    ]
                }
            },

            {
                "Zari_BeforeCobalt_0", new()
                {
                    type = NodeType.@event,
                    lookup = ["before_theCobalt"],
                    bg = "BGTheCobalt",
                    allPresent = [ AmZari ],
                    once = true,
                    priority = true,
                    requiredScenes = ["Zari_Intro_0"],
                    dialogue =
                    [
                        new(AmZari, "pondering", "Ah. Is this the end?"),
                        new(AmCat, "Yep!", flipped: true),
                        new(AmZari, "pondering", "Pity. I was hoping there would be more time crystals."),
                        new(AmCat, "grumpy", "Is that all you care about?", flipped: true),
                        new(AmZari, "annoyed", "Had you expected otherwise?"),
                        new(AmZari, "annoyed", "I have no illusions to any sense of morality."),
                        new(AmZari, "explains", "The only thing that matters to me is increasing my wealth."),
                        new(AmCat, "grumpy", "You're terrible.", flipped: true),
                        new(AmZari, "arrogant", "Thank you. Shall we move along?"),
                        new(AmCat, "squint", "...", flipped: true),
                        new(AmCat, "squint", "Fine.", flipped: true),
                        new(AmCat, "transition", "Uploading myself in 3...2...1...", flipped: true),
                    ]
                }
            },



            {
                "ZariMeetsBooks_Intro_0", new()
                {
                    type = NodeType.@event,
                    lookup = [ "zone_first" ],
                    once = true,
                    allPresent = [ AmZari, AmBooks ],
                    bg = "BGRunStartZari",
                    requiredScenes = ["Zari_Intro_0"],
                    dialogue =
                    [
                        new(AmCat, "Time to wake up!", flipped: true),
                        new(AmBooks, "blush", "Yay! Loop time!"),
                        new(AmBooks, "paws", "Who are my teammates today? Peri? Riggs?"),
                        new(AmBooks, "paws", "Maybe Max?"),
                        new(new BGAction{action = "flash_weak"}),
                        new(new Wait{secs = 2}),
                        new(AmBooks, "stoked", "Auntie Zari?!"),
                        new(AmZari, "neutral", "Books! Why hello there!"),
                        new(AmZari, "neutral", "How is my favorite alchemist doing?"),
                        new(AmCat, "You two know each other?", flipped: true),
                        new(AmBooks, "paws", "Yeah! I helped her turn some lead into gold!"),
                        new(AmZari, "explains", "Indeed. Books is quite the little alchemist."),
                        new(AmZari, "neutral", "So what are you up to now, my dear?"),
                        new(AmBooks, "paws", "I'm practicing being a menace!"),
                        new(AmBooks, "blush", "Cat says I'm really good at it!"),
                        new(AmCat, "grumpy", "That was not what I-", flipped: true),
                        new(AmZari, "arrogant", "Excellent! Carry on, my dear. You are doing wonderful."),
                    ]
                }
            },




            {
                "ZariMeetsBooks_Intro_1", new()
                {
                    type = NodeType.@event,
                    lookup = [ "zone_first" ],
                    once = true,
                    allPresent = [ AmZari, AmBooks ],
                    bg = "BGRunStartZari",
                    requiredScenes = ["ZariMeetsBooks_Intro_0"],
                    dialogue =
                    [
                        new(AmBooks, "paws", "Auntie Zari! Auntie Zari!"),
                        new(AmZari, "neutral", "Books? What is it, my dear?", flipped: true),
                        new(AmBooks, "crystal", "Check out my time crystal!"),
                        new(AmZari, "neutral", "That is wonderful, my dear!", flipped: true),
                        new(AmZari, "greedycrystal", "But you see...I have time crystals too!", flipped: true),
                        new(AmBooks, "paws", "Wow!"),
                        new(AmBooks, "intense", "Wait...that's just a plain sapphire."),
                        new(AmZari, "worried", "What?! That cannot be!", flipped: true),
                        new(AmZari, "worried", "I was sure it...", flipped: true),
                        new(AmZari, "resigned", "...oh.", flipped: true),
                        new(AmZari, "resigned", "I mixed the two up. It must be in my assorted sapphires collection.", flipped: true),
                        new(AmBooks, "paws", "Want me to help you find it?"),
                        new(AmZari, "neutral", "...I do not deserve you, Books.", flipped: true),
                        new(AmBooks, "blush", "Of course!"),
                        new(AmBooks, "paws", "Also, you still owe me a thousand rubies for that lead-to-gold recipe."),
                        new(AmZari, "resigned", "...I think I will need an extension on that loan.", flipped: true),
                    ]
                }
            },





            {
                "ZariMeetsDrake_Intro_0", new()
                {
                    type = NodeType.@event,
                    lookup = [ "zone_first" ],
                    once = true,
                    allPresent = [ AmZari, AmDrake ],
                    bg = "BGRunStartZari",
                    requiredScenes = ["Zari_Intro_0"],
                    dialogue =
                    [
                        new(AmDrake, "Sup CAT."),
                        new(AmCat, "Good timing Drake. I was just about to wake everyone up.", flipped: true),
                        new(AmDrake, "sly", "Great. I get dibs on the best seat."),
                        new(new BGAction{action = "flash_weak"}),
                        new(new Wait{secs = 2}),
                        new(AmDrake, "panic", "What-"),
                        new(AmZari, "explains", "Why hello there Eunice.", flipped: true),
                        new(AmDrake, "panic", "Aunt Zari?!"),
                        new(AmCat, "intense", "You two are related?", flipped: true),
                        new(AmZari, "explains", "Correct. Eunice is a niece on the side of my father. Twice removed.", flipped: true),
                        new(AmZari, "arrogant", "Thusly, she contains none of my good traits.", flipped: true),
                        new(AmZari, "arrogant", "Nor wealth, for that matter.", flipped: true),
                        new(AmDrake, "mad", "Cause we didn't inherit a billion dollars, jerk."),
                        new(AmZari, "arrogant", "Consider aquiring more wealth, Eunice.", flipped: true),
                        new(AmZari, "arrogant", "Perhaps then you will have my respect.", flipped: true),
                        new(AmDrake, "mad", "..."),
                        new(AmDrake, "sly", "..."),
                        new(AmDrake, "sly", "So what would happen if I threw this chest of authentic medieval knight signet rings out the airlock?"),
                        new(AmZari, "squint", "Why you little...hand that back! Or else!", flipped: true),
                    ]
                }
            },


            {
                "ZariMeetsDrake_Intro_1", new()
                {
                    type = NodeType.@event,
                    lookup = [ "zone_first" ],
                    once = true,
                    allPresent = [ AmZari, AmDrake ],
                    bg = "BGRunStartZari",
                    requiredScenes = ["ZariMeetsDrake_Intro_0"],
                    dialogue =
                    [
                        new(AmDrake, "neutral", "C'mon, Aunt. Not even ONE silver coin?"),
                        new(AmZari, "arrogant", "No.", flipped: true),
                        new(AmDrake, "squint", "Not even for family, huh."),
                        new(AmZari, "explains", "Tough love, my dear niece.", flipped: true),
                        new(AmZari, "neutral", "I will grant you some advice: pillage some time crystals from the crystalline entity.", flipped: true),
                        new(AmZari, "crystal", "These are worth quite the pretty penny.", flipped: true),
                        new(AmDrake, "squint", "I already knew that."),
                        new(AmDrake, "squint", "That's the reason we're in this situation to begin with."),
                        new(AmZari, "pondering", "Ah. I see.", flipped: true),
                        new(AmZari, "crystal", "Well then, perhaps I have you to thank for this.", flipped: true),
                        new(AmZari, "crystal", "I was looking to expand my time crystal collection.", flipped: true),
                        new(AmDrake, "neutral", "Will you spare a coin or two for me now?"),
                        new(AmZari, "arrogant", "Possibly.", flipped: true),
                    ]
                }
            },











            {
                "ZariMeetsPeri_Intro_0", new()
                {
                    type = NodeType.@event,
                    lookup = [ "zone_first" ],
                    once = true,
                    allPresent = [ AmZari, AmPeri ],
                    bg = "BGRunStartZari",
                    requiredScenes = ["Zari_Intro_0"],
                    dialogue =
                    [
                        new(AmPeri, "squint", "Ugh. Rough wakeup from cryosleep."),
                        new(AmPeri, "squint", "CAT? How much time until-"),
                        new(new BGAction{action = "flash_weak"}),
                        new(new Wait{secs = 2}),
                        new(AmPeri, "panic", "Was that a hull breach?! Status report!"),
                        new(AmCat, "grumpy", "Not a hull breach. That was just...Zari."),
                        new(AmZari, "explains", "My entrance is rather characteristic, is it not?", flipped: true),
                        new(AmPeri, "squint", "A dragon? On MY ship?"),
                        new(AmZari, "explains", "It is more likely than you think.", flipped: true),
                        new(AmPeri, "squint", "...what do you want?"),
                        new(AmPeri, "squint", "Dragons only show interest in things they can exploit."),
                        new(AmZari, "neutral", "You have a sharp wit. Good.", flipped: true),
                        new(AmZari, "crystal", "I am interested in the crystals this time loop provides.", flipped: true),
                        new(AmZari, "greedycrystal", "I am happy to play hero...if you let me salvage some from the crystalline entity.", flipped: true),
                        new(AmPeri, "neutral", "I can work with that."),
                        new(AmZari, "annoyed", "...was that a gun you had pointed on me?", flipped: true),
                        new(AmPeri, "nap", "Just a precaution."),
                    ]
                }
            },





            {
                "ZariMeetsRiggs_Intro_0", new()
                {
                    type = NodeType.@event,
                    lookup = [ "zone_first" ],
                    once = true,
                    allPresent = [ AmZari, AmRiggs ],
                    bg = "BGRunStartZari",
                    requiredScenes = ["Zari_Intro_0"],
                    dialogue =
                    [
                        new(AmCat, "neutral", "Hey, Riggs. You're the first to wake up."),
                        new(AmRiggs, "neutral", "Oh! That means I get my favorite seat!", flipped: true),
                        new(AmRiggs, "neutral", "I love my favorite seat.", flipped: true),
                        new(new BGAction{action = "flash_weak"}),
                        new(new Wait{secs = 2}),
                        new(AmRiggs, "squint", "Why is my favorite seat covered in gold?", flipped: true),
                        new(AmZari, "neutral", "Apologies. That was me."),
                        new(AmRiggs, "squint", "...are you a dragon?", flipped: true),
                        new(AmZari, "explains", "Indeed I am!"),
                        new(AmRiggs, "neutral", "Cool!", flipped: true),
                        new(AmRiggs, "neutral", "Now move your gold from my seat?", flipped: true),
                        new(AmZari, "arrogant", "Must I? It looks rather fetching, piled in the cockpit as it is."),
                        new(AmRiggs, "gun", "...", flipped: true),
                        new(AmRiggs, "gun", "I wasn't asking.", flipped: true),
                    ]
                }
            },




            {
                "ZariMeetsDizzy_Intro_0", new()
                {
                    type = NodeType.@event,
                    lookup = [ "zone_first" ],
                    once = true,
                    allPresent = [ AmZari, AmDizzy ],
                    bg = "BGRunStartZari",
                    requiredScenes = ["Zari_Intro_0"],
                    dialogue =
                    [
                        new(AmCat, "neutral", "Time to get up, everyone!"),
                        new(new BGAction{action = "flash_weak"}),
                        new(new Wait{secs = 2}),
                        new(AmZari, "arrogant", "Hello there.", flipped: true),
                        new(AmCat, "neutral", "Huh. You're getting better at not punching a hole in the ship."),
                        new(AmZari, "explains", "Practice makes perfect.", flipped: true),
                        new(AmDizzy, "squint", "Ugh."),
                        new(AmDizzy, "squint", "Hey CAT? I just got up. Was that bang I heard real or-"),
                        new(AmDizzy, "intense", "-Oh."),
                        new(AmZari, "arrogant", "Why hello.", flipped: true),
                        new(AmDizzy, "neutral", "Wow! Are you a dragon?"),
                        new(AmZari, "explains", "Indeed I am.", flipped: true),
                        new(AmDizzy, "neutral", "Fascinating! And you even have a hoard too!"),
                        new(AmDizzy, "explains", "You know, I thought the whole mountain of gold thing was just an exaggeration."),
                        new(AmDizzy, "neutral", "May I have a look at one of these coins?"),
                        new(AmZari, "squint", "No.", flipped: true),

                    ]
                }
            },




            {
                "ZariMeetsIsaac_Intro_0", new()
                {
                    type = NodeType.@event,
                    lookup = [ "zone_first" ],
                    once = true,
                    allPresent = [ AmZari, AmIsaac ],
                    bg = "BGRunStartZari",
                    requiredScenes = ["Zari_Intro_0"],
                    dialogue =
                    [
                        new(new Wait{secs = 2}),
                        new(new BGAction{action = "flash_weak"}),
                        new(new BGAction{action = "rumble_on"}),
                        new(new Wait{secs = 2}),
                        new(AmZari, "pondering", "Hm. Bother."),
                        new(AmCat, "squint", "You just breached the hull again.", flipped: true),
                        new(AmZari, "pondering", "Yes yes. I will have that fixed in just a moment."),
                        new(new BGAction{action = "rumble_off"}),
                        new(new Wait{secs = 2}),
                        new(AmZari, "neutral", "Better?"),
                        new(AmCat, "neutral", "Yep! Thanks!", flipped: true),
                        new(AmIsaac, "neutral", "Hey CAT? Why did life support go offline for a seco-", flipped: true),
                        new(AmIsaac, "panic", "Wh-what?", flipped: true),
                        new(AmZari, "arrogant", "Why hello there."),
                        new(AmIsaac, "panic", "...Hi?", flipped: true),
                        new(AmZari, "explains", "Do not fret, my dear. I do not bite."),
                        new(AmZari, "neutral", "I am Zari. What is your name?"),
                        new(AmIsaac, "shy", "...Isaac. My name's Isaac.", flipped: true),
                        new(AmZari, "explains", "A wonderful name, to be sure."),
                        new(AmZari, "neutral", "Would you like to enter the cockpit? I may move for you."),
                        new(AmIsaac, "shy", "I...I'll just be in the missile bay for a little bit.", flipped: true),
                    ]
                }
            },




            {
                "ZariMeetsMax_Intro_0", new()
                {
                    type = NodeType.@event,
                    lookup = [ "zone_first" ],
                    once = true,
                    allPresent = [ AmZari, AmMax ],
                    bg = "BGRunStartZari",
                    requiredScenes = ["Zari_Intro_0"],
                    dialogue =
                    [
                        new(AmMax, "squint", "Ugh..."),
                        new(AmCat, "worried", "Max? Are you okay?", flipped: true),
                        new(AmMax, "squint", "Just had a bad sleep."),
                        new(AmMax, "gloves", "A nightmare. Don't usually get those."),
                        new(AmCat, "worried", "I've started the coffee machine in the kitchen.", flipped: true),
                        new(AmCat, "worried", "Double espresso?", flipped: true),
                        new(AmMax, "neutral", "Yeah, that sounds good."),
                        new(AmMax, "smile", "Thanks. I'll go get that."),
                        new(AmCat, "smug", "Of course!", flipped: true),
                        new(new Wait{secs = 3}),
                        new(new BGAction{action = "flash_weak"}),
                        new(new Wait{secs = 2}),
                        new(AmZari, "explains", "Hello there."),
                        new(AmMax, "squint", "CAT?"),
                        new(AmCat, "intense", "...Yes?", flipped: true),
                        new(AmMax, "squint", "I think I'm still dreaming."),
                        new(AmMax, "squint", "There's a dragon in the kitchen."),
                    ]
                }
            },

            {
                "ZariMeetsMax_Intro_1", new()
                {
                    type = NodeType.@event,
                    lookup = [ "zone_first" ],
                    once = true,
                    allPresent = [ AmZari, AmMax ],
                    bg = "BGRunStartZari",
                    requiredScenes = ["ZariMeetsMax_Intro_0"],
                    dialogue =
                    [
                        new(AmMax, "neutral", "Hey there CAT."),
                        new(AmCat, "peace", "Hi Max!", flipped: true),
                        new(AmCat, "neutral", "Up early this loop?", flipped: true),
                        new(AmMax, "gloves", "Yeah. Had a good sleep."),
                        new(AmMax, "neutral", "Had a weird dream, though."),
                        new(AmCat, "worried", "Anything bad?", flipped: true),
                        new(AmMax, "neutral", "Nah. Just weird."),
                        new(AmMax, "neutral", "There was a dragon in the kitchen."),
                        new(AmMax, "squint", "But...the dragon was way bigger than Drake."),
                        new(AmMax, "squint", "I'm not sure how they even fit on the ship."),
                        new(AmCat, "intense", "...Huh. Interesting.", flipped: true),
                        new(AmMax, "neutral", "I'm sure it's nothing, though."),
                        new(AmMax, "neutral", "I'll be at my terminal."),
                        new(new Wait{secs = 2}),
                        new(new BGAction{action = "flash_weak"}),
                        new(new Wait{secs = 2}),
                        new(AmZari, "explains", "Greetings."),
                        new(AmMax, "intense", "..."),
                        new(AmMax, "intense", "That wasn't a dream, was it?"),
                    ]
                }
            },



            {
                "ZariMeetsRatzo_0", new()
                {
                    type = NodeType.@event,
                    lookup = [ "before_knight" ],
                    bg = "BGCastle",
                    once = true,
                    priority = true,
                    allPresent = [ AmZari ],
                    requiredScenes = ["Knight_1"],
                    dialogue =
                    [
                        new(AmRatzo, "Halt thine astral stallion, vile dragon!", flipped: true),
                        new(AmZari, "annoyed", "Excuse me?"),
                        new(AmRatzo, "You heard me!", flipped: true),
                        new(AmRatzo, "I shall slay ye and rescue thine damsel in distress!", flipped: true),
                        new(AmZari, "annoyed", "I have not taken any-"),
                        new(AmRatzo, "Silence!", flipped: true),
                        new(AmRatzo, "Have at thee, beast!", flipped: true),
                    ]
                }
            },

            {
                "ZariMeetsRatzo_1", new()
                {
                    type = NodeType.@event,
                    lookup = [ "before_knight" ],
                    bg = "BGCastle",
                    once = true,
                    priority = true,
                    allPresent = [ AmZari ],
                    requiredScenes = ["ZariMeetsRatzo_0"],
                    dialogue =
                    [
                        new(AmRatzo, "Cruel beast! Give up thy princess, now!", flipped: true),
                        new(AmZari, "annoyed", "Are you done?"),
                        new(AmZari, "annoyed", "There is no damsel."),
                        new(AmZari, "annoyed", "Kidnapping princesses is too old fashioned for my taste."),
                        new(AmZari, "explains", "Personally? I prefer taking the king directly."),
                        new(AmZari, "explains", "The ransom money is quite a bit higher."),
                        new(AmRatzo, "...", flipped: true),
                        new(AmRatzo, "Thou kidnapped true royalty?!", flipped: true),
                        new(AmRatzo, "FOR THINE KING I SHALL OPPOSE YE!", flipped: true),
                    ]
                }
            },

            {
                "ZariMeetsRatzo_2", new()
                {
                    type = NodeType.@event,
                    lookup = [ "before_knight" ],
                    bg = "BGCastle",
                    once = true,
                    priority = true,
                    allPresent = [ AmZari ],
                    requiredScenes = ["ZariMeetsRatzo_1"],
                    dialogue =
                    [
                        new(AmRatzo, "Evil dragon! Where is thy king?!", flipped: true),
                        new(AmZari, "annoyed", "There was no king."),
                        new(AmZari, "annoyed", "I merely stated I preferred kidnapping kings to princesses."),
                        new(AmRatzo, "...", flipped: true),
                        new(AmRatzo, "You knave! I will have your head for this!", flipped: true),
                        new(AmZari, "resigned", "Good grief."),
                    ]
                }
            },

        });
    }
}
