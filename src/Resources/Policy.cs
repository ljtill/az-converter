using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.Azure.Converter.Types;

namespace Microsoft.Azure.Converter.Resources
{
    class Policy
    {
        /// <summary>
        /// GetPolicyDefinition
        /// </summary>
        public static PolicyDefinition GetPolicyDefinition(string path)
        {
            System.Console.WriteLine("Testing path");
            if (!File.Exists(path))
            {
                throw new Exception("Unable to locate file.");
            }

            System.Console.WriteLine("Reading file");
            string data = File.ReadAllText(path);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.Never,
                PropertyNameCaseInsensitive = true,
            };

            System.Console.WriteLine("Deseralizing file");
            PolicyDefinition definition = null;
            try
            {
                definition = JsonSerializer.Deserialize<PolicyDefinition>(data, options);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("The process failed: {0}", e.ToString());
                Environment.Exit(1);
            }

            return definition;
        }
    }
}
