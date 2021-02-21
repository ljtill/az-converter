using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.Azure.Converter.Types;

namespace Microsoft.Azure.Converter.Resources
{
    class Template
    {
        /// <summary>
        /// Export
        /// </summary>
        public static void Export(PolicyDefinition definition, string outputDirectory, string fileName)
        {

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.Never,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            ResourceTemplate template = new ResourceTemplate();

            template.resources.Add(definition);

            string data = JsonSerializer.Serialize(template, options);
            File.WriteAllText((outputDirectory + fileName), data);
        }
    }
}