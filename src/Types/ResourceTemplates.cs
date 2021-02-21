using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.Converter.Types
{
    public class ResourceTemplate
    {
        public ResourceTemplate()
        {
            resources = new List<object>();
        }

        [JsonPropertyNameAttribute("$schema")]
        public string Schema { get; } = "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#";
        public string contentVersion { get; } = "1.0.0.0";
        public Dictionary<string, string> parameters { get; } = new Dictionary<string, string> { };
        public Dictionary<string, string> variables { get; } = new Dictionary<string, string> { };
        public List<object> resources { get; set; }
        public Dictionary<string, string> outputs { get; } = new Dictionary<string, string> { };
    }

    public class ResourceTemplateParameters
    {
    }

    public class ResourceTemplateVariables
    {
    }

    public class ResourceTemplateOutputs
    {
    }
}