using Vintagestory.API.Common;
using DurabilityConfigMod.Configuration;

namespace DurabilityConfigMod;

public static class Patches
{
    public static void ApplyPatches(this ICoreAPI api, DurabilityConfig config)
    {
        if (config.DurabilityProperties?.Count == 0) return;

        foreach (var durabilityProps in config.DurabilityProperties)
        {
            var obj = api.GetCollectible(durabilityProps);
            if (obj == null) continue;
            if (obj.Code == null) continue;

            obj.Durability = durabilityProps.Value;
        }
    }

    public static DurabilityConfig FillConfig(this ICoreAPI api, DurabilityConfig config)
    {
        if (config.DurabilityProperties == null) return config;

        foreach (var obj in api.World.Collectibles)
        {
            if (obj?.Code == null) continue;
            var code = obj?.Code?.ToString();
            if (obj.Durability == 0 || obj.Durability == 1) continue;
            if (config.DurabilityProperties.ContainsKey(code)) continue;

            config.DurabilityProperties.Add(code, obj.Durability);
        }

        return config;
    }
}