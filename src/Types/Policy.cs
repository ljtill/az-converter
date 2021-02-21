using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.Converter.Types
{
    public class PolicyDefinition
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string ApiVersion { get; set; }
        public PolicyDefinitionProperties Properties { get; set; }
    }

    public class PolicyDefinitionProperties
    {
        public string description { get; set; }
        public string displayName { get; set; }
        public string mode { get; set; }

        public object parameters { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> PolicyRule { get; set; }
    }
}
