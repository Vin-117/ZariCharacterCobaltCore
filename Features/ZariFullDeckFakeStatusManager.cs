using HarmonyLib;
using Nanoray.PluginManager;
using Newtonsoft.Json;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ZariMod.Artifacts;
using static ZariMod.External.IKokoroApi.IV2.IStatusLogicApi;
using static ZariMod.External.IKokoroApi.IV2.IStatusLogicApi.IHook;

namespace ZariMod.External;


public class ZariFullDeckFakeStatusManager : IKokoroApi.IV2.IStatusLogicApi.IHook, IKokoroApi.IV2.IStatusRenderingApi.IHook
{
	internal static readonly ZariFullDeckFakeStatusManager Instance = new();

    
    //This status isn't supposed to do anything. It's used only for a tooltip.

}