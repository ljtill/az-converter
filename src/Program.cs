using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.Azure.Converter.Types;
using Microsoft.Azure.Converter.Resources;
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

                PolicyDefinition definition = Policy.GetPolicyDefinition(file.FullName);

                Console.WriteLine($"Type: {definition.Type}");
                Console.WriteLine($"Name: {definition.Name}");
                Console.WriteLine($"Version: {definition.ApiVersion}");

                Template.Export(definition, outputDirectory, fileName);
            }
        }
    }
}
