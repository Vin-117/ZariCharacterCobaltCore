using Nickel;
using ZariMod;

namespace ZariMod;


public sealed class ZariAPI_Implementation : IZariApi
{

    public IDeckEntry ZariDeck
        => ModEntry.Instance.ZariDeck;

    public IStatusEntry ZariUndyingStatus
        => ModEntry.Instance.ZariUndyingStatus;

    public IStatusEntry ZariOpportunisticStatus
        => ModEntry.Instance.ZariOpportunisticStatus;

    public IStatusEntry ZariScornStatus
        => ModEntry.Instance.ZariScornStatus;

    public IStatusEntry ZariMinimumStatus
        => ModEntry.Instance.ZariMinimumStatus;
}