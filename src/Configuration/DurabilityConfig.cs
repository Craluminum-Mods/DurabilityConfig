using System.Collections.Generic;

namespace DurabilityConfigMod.Configuration
{
    public class DurabilityConfig
    {
        public Dictionary<string, int> DurabilityProperties = new() { };

        public DurabilityConfig() { }
        public DurabilityConfig(DurabilityConfig previousConfig)
        {
            foreach (var item in previousConfig.DurabilityProperties)
            {
                if (DurabilityProperties.ContainsKey(item.Key)) continue;
                DurabilityProperties.Add(item.Key, item.Value);
            }
        }
    }
}
