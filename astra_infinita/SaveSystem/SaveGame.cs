using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;

namespace astra_infinita
{
    namespace SaveSystem
    {
        class SaveGame
        {
            public static string savePath;
            public static void Save(Player player)
            {
                if(savePath!="")
                    savePath =Path.Combine(Program.executingPath, "Save");
                if (!Directory.Exists(savePath)) {
                    Directory.CreateDirectory(savePath);
                }
                try {
                    WriteToJsonFile<Player>(Path.Combine(savePath, "Player.json"), player, false);
                }
                catch(Exception e) {
                    Console.WriteLine(e);
                }
            }

            public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
            {
                TextWriter writer = null;
                try
                {
                    JsonSerializerSettings serializer = new JsonSerializerSettings();
                    serializer.Formatting = Formatting.Indented;
                    serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    serializer.NullValueHandling = NullValueHandling.Include;
                    serializer.TypeNameHandling = TypeNameHandling.Auto;
                    var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite,serializer);
                    writer = new StreamWriter(filePath, append);
                    writer.Write(contentsToWriteToFile);
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                }
            }

            public static T ReadFromJsonFile<T>(string filePath) where T : new()
            {
                TextReader reader = null;
                try
                {
                    JsonSerializerSettings serializer = new JsonSerializerSettings();
                    serializer.Formatting = Formatting.Indented;
                    serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    serializer.NullValueHandling = NullValueHandling.Include;
                    serializer.TypeNameHandling = TypeNameHandling.Auto;
                    reader = new StreamReader(filePath);
                    var fileContents = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(fileContents,serializer);
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }


        }
    }
}
