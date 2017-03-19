using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Task4

{
    class Serialization
    {
        public static void Run(EatThis[] eaten)
        {
            var meal = eaten[0];

            // serialize all items
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            Console.WriteLine(JsonConvert.SerializeObject(eaten , settings));
            
            // store json string to file "eaten.json" on your Desktop
            var text = JsonConvert.SerializeObject(eaten, settings);
            // gets current working directory as directory to write file in
            var currentDirecoty = Directory.GetCurrentDirectory(); 
            var filename = Path.Combine(currentDirecoty, "eaten.json");
            File.WriteAllText(filename, text);
            
            // deserialize items from "eaten.json"
            // and print using LunchPrint()
            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<EatThis[]>(textFromFile, settings);
            for (int i = 0; i <= (eaten.Length - 1); i++)
            {
                eaten[i].LunchPrint();
            }
        }
    }
}