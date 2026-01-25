using HarmonyLib;
using Microsoft.Extensions.Logging;
using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using ZariMod.Actions;
//using DemoMod.Artifacts;
using ZariMod.Cards;
using ZariMod.External;
//using DemoMod.Features;

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
        typeof(Backdraft),
        typeof(StretchTheWings),
        typeof(Acquire)
    ];
    private static List<Type> ZariUncommonCardTypes = 
    [
        typeof(Regenerate),
        typeof(Replace),
        typeof(Avarice),
        typeof(Ambition),
        typeof(Seek),
        typeof(Moult)
    ];
    private static List<Type> ZariRareCardTypes = 
    [
        typeof(ShiningScales)
    ];
    private static List<Type> ZariSpecialCardTypes = 
    [
        typeof(DiscardedScales)
    ];
    private static IEnumerable<Type> ZariCardTypes =
        ZariCommonCardTypes
            .Concat(ZariUncommonCardTypes)
            .Concat(ZariRareCardTypes)
            .Concat(ZariSpecialCardTypes);


    
    ///
    /// Define artifact types as static lists
    ///
    private static List<Type> ZariCommonArtifacts = [
    ];
    private static List<Type> ZariBossArtifacts = [
    ];
    private static IEnumerable<Type> ZariArtifactTypes =
        ZariCommonArtifacts
            .Concat(ZariBossArtifacts);

    private static IEnumerable<Type> AllRegisterableTypes =
        ZariCardTypes
            .Concat(ZariArtifactTypes);



    ///
    /// Construct deck
    ///
    internal IDeckEntry ZariDeck;



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
        ZariDeck = helper.Content.Decks.RegisterDeck("Demo", new DeckConfiguration
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
        helper.Content.Characters.V2.RegisterPlayableCharacter("Demo", new PlayableCharacterConfigurationV2
        {
            Deck = ZariDeck.Deck,
            BorderSprite = RegisterSprite(package, "assets/char_frame_zari.png").Sprite,
            Starters = new StarterDeck
            {
                cards =
                [
                    new BurdenOfChoice(),
                    new DiscardedScales(),
                    new Moult()
                    //new ToughScales()
                ],
            },
            Description = AnyLocalizations.Bind(["character", "desc"]).Localize
        });



        ///
        /// Initialize all cards and artifacts defined by static lists
        ///
        foreach (var type in AllRegisterableTypes)
            AccessTools.DeclaredMethod(type, nameof(IRegisterable.Register))?.Invoke(null, [package, helper]);




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
        RegisterAnimation(package, "neutral", "assets/Animation/Neutral/ZariNeutral", 1);
        RegisterAnimation(package, "squint", "assets/Animation/Squint/ZariSquint", 1);
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

