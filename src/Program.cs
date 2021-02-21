using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.Azure.Converter.Types;
using Microsoft.Azure.Converter.FileSystem;

namespace Microsoft.Azure.Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDirectory = "data/";
            string outputDirectory = "output/";
            FileInfo[] files = Files.FindFiles(inputDirectory);

            foreach (FileInfo file in files)
            {
                string fileName = file.Name;
                PolicyDefinition definition = GetPolicyDefinition(file.FullName);
                Console.WriteLine($"Type: {definition.Type}");
                Console.WriteLine($"Name: {definition.Name}");
                Console.WriteLine($"Version: {definition.ApiVersion}");

                ExportResourceTemplate(definition, outputDirectory, fileName);
            }

        }

        /// <summary>
        /// GetPolicyDefinition
        /// </summary>
        private static PolicyDefinition GetPolicyDefinition(string path)
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

        /// <summary>
        /// ExportResourceTemplate
        /// </summary>
        private static void ExportResourceTemplate(PolicyDefinition definition, string outputDirectory, string fileName)
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
