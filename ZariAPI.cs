using Nickel;

namespace ZariMod;

public interface IZariApi 
{
    IDeckEntry ZariDeck { get; }
    IStatusEntry ZariUndyingStatus { get; }
    IStatusEntry ZariOpportunisticStatus { get; }
    IStatusEntry ZariScornStatus { get; }
    IStatusEntry ZariMinimumStatus { get; }

}