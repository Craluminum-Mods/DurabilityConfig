using System.Collections.Generic;
using Vintagestory.API.Common;

namespace DurabilityConfigMod;

public static class Util
{
    public static CollectibleObject GetCollectible(this ICoreAPI api, KeyValuePair<string, int> key)
    {
        return api.World.GetItem(new AssetLocation(key.Key)) as CollectibleObject ?? api.World.GetBlock(new AssetLocation(key.Key));
    }
}