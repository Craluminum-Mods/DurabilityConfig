using Vintagestory.API.Common;

namespace DurabilityConfigMod.Configuration;

static class ModConfig
{
    private const string jsonConfig = "ConfigureEverything/Durability.json";
    private static DurabilityConfig config;

    public static void ReadConfig(ICoreAPI api)
    {
        try
        {
            config = LoadConfig(api);
            config = api.FillConfig(config);

            if (config == null)
            {
                GenerateConfig(api);
                config = LoadConfig(api);
                config = api.FillConfig(config);
            }
            else
            {
                GenerateConfig(api, config);
                config = api.FillConfig(config);
            }
        }
        catch
        {
            GenerateConfig(api);
            config = LoadConfig(api);
            config = api.FillConfig(config);
        }

        api.ApplyPatches(config);
    }

    private static DurabilityConfig LoadConfig(ICoreAPI api) => api.LoadModConfig<DurabilityConfig>(jsonConfig);
    private static void GenerateConfig(ICoreAPI api) => api.StoreModConfig(new DurabilityConfig(), jsonConfig);
    private static void GenerateConfig(ICoreAPI api, DurabilityConfig previousConfig) => api.StoreModConfig(new DurabilityConfig(previousConfig), jsonConfig);
}