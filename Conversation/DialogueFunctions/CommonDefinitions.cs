using System.Linq;
using Microsoft.Extensions.Logging;
using Nickel;

namespace ZariMod.Conversation;

/// <summary>
/// For if a dialogue needs to be registered AFTER mods have been loaded
/// </summary>
internal interface IDialogueRegisterable
{
    static abstract void LateRegister();
}

static class CommonDefinitions
{
    internal static ModEntry Instance => ModEntry.Instance;

    internal static string AmZari => Instance.ZariDeck.UniqueName;
    internal static Deck AmZariDeck => Instance.ZariDeck.Deck;

    internal const string AmCat = "comp";

    internal const string AmJumbo = "miner";
    internal const string AmStardog = "wolf";
    internal const string AmSmiff = "batboy";
    internal static string AmDizzy => Deck.dizzy.Key();
    internal static string AmPeri => Deck.peri.Key();
    internal static string AmRiggs => Deck.riggs.Key();
    internal static string AmDrake => Deck.eunice.Key();
    internal static string AmIsaac => Deck.goat.Key();
    internal static string AmBooks => Deck.shard.Key();
    internal static string AmMax => Deck.hacker.Key();
    internal const string AmVoid = "void";
    internal const string AmShopkeeper = "nerd";
    internal const string AmBrimford = "walrus";

    internal readonly static string AmJohnson = "Shockah.Johnson::Johnson";
    internal readonly static string JohnsonDeck = "Shockah.Johnson.JohnsonDeck";
    internal readonly static string JohnsonFrugal = "Shockah.Johnson::Frugality";

    internal readonly static string AmNibbs = "TheJazMaster.Nibbs::Nibbs";

    internal static Status MissingVic => ModEntry.ZariPlayableCharacter.MissingStatus.Status;

}