using Nanoray.PluginManager;
using Nickel;

namespace ZariMod;

internal interface IRegisterable
{
    static abstract void Register(IPluginPackage<IModManifest> package, IModHelper helper);
}