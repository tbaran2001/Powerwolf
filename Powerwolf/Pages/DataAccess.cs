using JsonFiles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Powerwolf
{
    public static class DataAccess
    {
        private static List<T> DeserializeJsonFile<T>(string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"jsons/{fileName}.json");

            if (!File.Exists(filePath))
            {
                // Obsługa błędu lub zwracanie pustej listy w przypadku braku pliku
                return new List<T>();
            }

            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonString, JsonFiles.Converter.Settings);
        }

        public static List<BandMember> GetBandMembers()
        {
            return DeserializeJsonFile<BandMember>("BandMembers");
        }

        public static List<Concert> GetConcerts()
        {
            return DeserializeJsonFile<Concert>("Concerts");
        }

        public static List<NewsItem> GetNews()
        {
            return DeserializeJsonFile<NewsItem>("News");
        }

        public static List<Song> GetSongs()
        {
            return DeserializeJsonFile<Song>("Songs");
        }
    }
}
