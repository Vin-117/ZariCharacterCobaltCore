using HarmonyLib;
using Microsoft.Extensions.Logging;
using Nanoray.PluginManager;
using Nickel;
using Nickel.Common;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using ZariMod.Actions;
using ZariMod.Artifacts;
using ZariMod.Cards;
using ZariMod.Conversation;
using ZariMod.External;
using ZariMod.Features;
using static System.Formats.Asn1.AsnWriter;

namespace ZariMod;



///
/// Set up ModEntry class
///
internal class ModEntry : SimpleMod
{



    ///
    /// Construct ModEntry, Harmony, and Kokoro instances
    ///
    internal static ModEntry Instance { get; private set; } = null!;
    internal Harmony Harmony;
    internal IKokoroApi.IV2 KokoroApi;




    ///
    /// This is for missing status registration
    ///
    internal static IPlayableCharacterEntryV2 ZariPlayableCharacter { get; private set; } = null!;



    ///
    /// Construct deck
    ///
    internal IDeckEntry ZariDeck;






    ///
    /// Construct status variables
    ///
    internal IStatusEntry ZariUndyingStatus;
    internal IStatusEntry ZariOpportunisticStatus;
    internal IStatusEntry ZariScornStatus;







    ///
    /// This is required for dialogue machine registration
    ///
    public LocalDB localDB { get; set; } = null!;



    ///
    /// Construct localization
    ///
    internal ILocalizationProvider<IReadOnlyList<string>> AnyLocalizations { get; }
    internal ILocaleBoundNonNullLocalizationProvider<IReadOnlyList<string>> Localizations { get; }







    ///
    /// Define card types as static lists
    ///
    private static List<Type> ZariCommonCardTypes = 
    [
        typeof(BurdenOfChoice),
        typeof(ToughScales),
        typeof(Unburden),
        typeof(Endure),
        typeof(Covet),
        typeof(Amass),
        typeof(Rapacity),
        typeof(StretchTheWings),
        typeof(Browse)
    ];
    private static List<Type> ZariUncommonCardTypes = 
    [
        typeof(Regenerate),
        typeof(Avarice),
        typeof(Ambition),
        typeof(Moult),
        typeof(Shed),
        typeof(Peruse),
        typeof(Seek)
    ];
    private static List<Type> ZariRareCardTypes = 
    [
        typeof(ShiningScales),
        typeof(Undying),
        typeof(Opportunistic),
        typeof(Replace),
        typeof(Scorn)
    ];
    private static List<Type> ZariSpecialCardTypes = 
    [
        typeof(GoldHoard)
    ];
    private static List<Type> ZariEXECardTypes =
    [
        typeof(ZariCatEXE)
    ];
    private static IEnumerable<Type> ZariCardTypes =
        ZariCommonCardTypes
            .Concat(ZariUncommonCardTypes)
            .Concat(ZariRareCardTypes)
            .Concat(ZariSpecialCardTypes)
            .Concat(ZariEXECardTypes);


    


    ///
    /// Define artifact types as static lists
    ///
    private static List<Type> ZariCommonArtifacts = 
    [
        typeof(CrownChessPiece),
        typeof(ShinyShield),
        typeof(GoldHullFinish)
    ];
    private static List<Type> ZariBossArtifacts = 
    [
        typeof(Temperance),
        typeof(OpulantWealth)
    ];
    private static IEnumerable<Type> ZariArtifactTypes =
        ZariCommonArtifacts
            .Concat(ZariBossArtifacts);



    ///
    /// Define dialogue types as static lists
    ///
    private static List<Type> ZariModDialogueTypes =
    [
        typeof(ZariCombatDialogue),
        typeof(ZariEventDialogue)
    ];




    /// <summary>
    /// Collect all registerable types into one master list
    /// </summary>
    private static IEnumerable<Type> AllRegisterableTypes =
        ZariCardTypes
            .Concat(ZariArtifactTypes)
            .Concat(ZariModDialogueTypes);



    ///
    /// Set up ModEntry helper
    ///
    public ModEntry(IPluginPackage<IModManifest> package, IModHelper helper, ILogger logger) : base(package, helper, logger)
    {
        ///
        /// Define instance, as well as Harmony and KokoroAPI fields
        ///
        Instance = this;
        Harmony = new Harmony("Vintage.ZariMod");
        KokoroApi = helper.ModRegistry.GetApi<IKokoroApi>("Shockah.Kokoro")!.V2;


        ///
        /// Define localization lists
        ///
        AnyLocalizations = new JsonLocalizationProvider
        (
            tokenExtractor: new SimpleLocalizationTokenExtractor(),
            localeStreamFunction: locale => package.PackageRoot.GetRelativeFile($"i18n/{locale}.json").OpenRead()
        );
        Localizations = new MissingPlaceholderLocalizationProvider<IReadOnlyList<string>>
        (
            new CurrentLocaleOrEnglishLocalizationProvider<IReadOnlyList<string>>(AnyLocalizations)
        );




        



        ///
        /// Define deck metadata
        ///
        ZariDeck = helper.Content.Decks.RegisterDeck("ZariTheDragon", new DeckConfiguration
        {
            Definition = new DeckDef
            {
                color = new Color("e8df5f"),
                titleColor = new Color("000000")
            },
            DefaultCardArt = StableSpr.cards_colorless,
            BorderSprite = RegisterSprite(package, "assets/card_frame_zari.png").Sprite,
            Name = AnyLocalizations.Bind(["character", "name"]).Localize
        });
        ZariPlayableCharacter = helper.Content.Characters.V2.RegisterPlayableCharacter("ZariTheDragon", new PlayableCharacterConfigurationV2
        {
            Deck = ZariDeck.Deck,
            BorderSprite = RegisterSprite(package, "assets/char_frame_zari.png").Sprite,
            Starters = new StarterDeck
            {
                cards =
                [
                    new Covet(),
                    new ToughScales()
                ],
            },
            SoloStarters = new StarterDeck
            {
                cards = [
                    new BurdenOfChoice(),
                    new ToughScales(),
                    new Covet(),
                    new StretchTheWings(),
                    new CannonColorless(),
                    new DodgeColorless()
                ]
            },
            ExeCardType = typeof(ZariCatEXE),
            Description = AnyLocalizations.Bind(["character", "desc"]).Localize
        });





        ///
        /// Define alternate starting cards for the more difficulties mod
        /// as well as starters for custom run option duos
        ///
        helper.ModRegistry.AwaitApi<IMoreDifficultiesApi>(
            "TheJazMaster.MoreDifficulties",
            new SemanticVersion(1, 3, 0),
            api => api.RegisterAltStarters
            (
                deck: ZariDeck.Deck,
                starterDeck: new StarterDeck
                {
                    cards = 
                    [
                        new BurdenOfChoice(),
                        new StretchTheWings(),
                    ]
                }

            )
        );
        helper.ModRegistry.AwaitApi<ICustomRunOptionsApi>("Shockah.CustomRunOptions", cro =>
        {
            cro.RegisterPartialDuoDeck(ZariDeck.Deck, new StarterDeck
            {
                cards = 
                [
                    new BurdenOfChoice(),
                    new ToughScales(),
                    new Covet()
                ]
            });
        });


        ///
        /// Define status metadata and manager
        ///
        ZariUndyingStatus = helper.Content.Statuses.RegisterStatus("ZariUndyingStatus", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                affectedByTimestop = false,
                color = new Color("9fd0ff"),
                icon = RegisterSprite(package, "assets/Status/undying.png").Sprite
            },
            Name = AnyLocalizations.Bind(["status", "ZariUndyingStatus", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "ZariUndyingStatus", "desc"]).Localize
        });
        _ = new ZariUndyingStatusManager();

        ZariOpportunisticStatus = helper.Content.Statuses.RegisterStatus("ZariOpportunisticStatus", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                affectedByTimestop = false,
                color = new Color("3FBFFF"),
                icon = RegisterSprite(package, "assets/Status/Opportunistic.png").Sprite
            },
            Name = AnyLocalizations.Bind(["status", "ZariOpportunisticStatus", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "ZariOpportunisticStatus", "desc"]).Localize
        });
        _ = new ZariOpportunisticStatusManager();

        ZariScornStatus = helper.Content.Statuses.RegisterStatus("ZariScornStatus", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                affectedByTimestop = false,
                color = new Color("e8df5f"),
                icon = RegisterSprite(package, "assets/Status/Scorn.png").Sprite
            },
            Name = AnyLocalizations.Bind(["status", "ZariScornStatus", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "ZariScornStatus", "desc"]).Localize
        });
        _ = new ScornOnDiscardManager();



        ADiscardSelect.ADiscardSelectSpr = RegisterSprite(package, "assets/Actions/chooseDiscard.png").Sprite;
        ADiscardFlexSelect.ADiscardFlexSelectSpr = RegisterSprite(package, "assets/Actions/chooseFlexDiscard.png").Sprite;



        ///
        /// Define gameover and mini sprites, which require slightly different implementations
        ///
        Instance.Helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2
        {
            CharacterType = ZariDeck.Deck.Key(),
            LoopTag = "gameover",
            Frames = [
                RegisterSprite(package, "assets/Animation/GameOver/ZariGameOver.png").Sprite,
            ]
        });
        Instance.Helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2
        {
            CharacterType = ZariDeck.Deck.Key(),
            LoopTag = "mini",
            Frames = [
                RegisterSprite(package, "assets/Animation/ZariMini.png").Sprite,
            ]
        });



        ///
        /// Define all other sprites
        ///
        RegisterAnimation(package, "neutral", "assets/Animation/Neutral/ZariNeutral", 5);
        RegisterAnimation(package, "squint", "assets/Animation/Squint/ZariSquint", 5);
        RegisterAnimation(package, "resigned", "assets/Animation/Resigned/ZariResigned", 5);
        RegisterAnimation(package, "arrogant", "assets/Animation/Arrogant/ZariArrogant", 5);
        RegisterAnimation(package, "annoyed", "assets/Animation/Annoyed/ZariAnnoyed", 5);
        RegisterAnimation(package, "explains", "assets/Animation/Explains/ZariExplains", 5);
        RegisterAnimation(package, "crystal", "assets/Animation/Crystal/ZariCrystal", 5);
        RegisterAnimation(package, "greedy", "assets/Animation/Greedy/ZariGreedy", 5);
        RegisterAnimation(package, "greedyannoyed", "assets/Animation/GreedyAnnoyed/ZariGreedyAnnoyed", 5);
        RegisterAnimation(package, "pondering", "assets/Animation/Pondering/ZariPondering", 5);
        RegisterAnimation(package, "nap", "assets/Animation/Nap/ZariNap", 5);
        RegisterAnimation(package, "accusing", "assets/Animation/Accusing/ZariAccusing", 5);
        RegisterAnimation(package, "rebuke", "assets/Animation/Rebuke/ZariRebuke", 5);
        RegisterAnimation(package, "worried", "assets/Animation/Worried/ZariWorried", 5);





        ///
        /// Initialize all cards and artifacts defined by static lists
        /// THIS MUST BE DONE LAST
        ///
        foreach (var type in AllRegisterableTypes)
            AccessTools.DeclaredMethod(type, nameof(IRegisterable.Register))?.Invoke(null, [package, helper]);




        ///
        /// Setup dialogue machine localdB
        ///
        helper.Events.OnModLoadPhaseFinished += (_, phase) =>
        {
            if (phase == ModLoadPhase.AfterDbInit)
            {
                localDB = new(helper, package);
            }
        };
        helper.Events.OnLoadStringsForLocale += (_, thing) =>
        {
            foreach (KeyValuePair<string, string> entry in localDB.GetLocalizationResults(thing.Locale))
            {
                thing.Localizations[entry.Key] = entry.Value;
            }
        };




    }



    ///
    /// Define method for easier sprite registration
    ///
    public static ISpriteEntry RegisterSprite(IPluginPackage<IModManifest> package, string dir)
    {
        return Instance.Helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile(dir));
    }



    ///
    /// Define method for easier animation registration
    ///
    public static void RegisterAnimation(IPluginPackage<IModManifest> package, string tag, string dir, int frames)
    {
        Instance.Helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2
        {
            CharacterType = Instance.ZariDeck.Deck.Key(),
            LoopTag = tag,
            Frames = Enumerable.Range(0, frames)
                .Select(i => RegisterSprite(package, dir + i + ".png").Sprite)
                .ToImmutableList()
        });
    }
}

