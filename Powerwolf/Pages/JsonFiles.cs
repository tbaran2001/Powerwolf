using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonFiles
{
    public class BandMember
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Role { get; set; }
        public string DateOfBirth { get; set; }
        public string Description { get; set; }
        public string FacePhoto { get; set; }

        public static List<BandMember> DeserializeFromJson(string json) => JsonConvert.DeserializeObject<List<BandMember>>(json, Converter.Settings);
    }

    public class Concert
    {
        public long Id { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string TicketLink { get; set; }

        public static List<Concert> DeserializeFromJson(string json) => JsonConvert.DeserializeObject<List<Concert>>(json, Converter.Settings);
    }

    public class NewsItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Date { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public static List<NewsItem> DeserializeFromJson(string json) => JsonConvert.DeserializeObject<List<NewsItem>>(json, Converter.Settings);
    }

    public class Song
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Album { get; set; }
        public string ReleaseDate { get; set; }
        public string Lyrics { get; set; }
        public string SpotifyLink { get; set; }
        public string YouTubeLink { get; set; }

        public static List<Song> DeserializeFromJson(string json) => JsonConvert.DeserializeObject<List<Song>>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<BandMember> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<Concert> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<NewsItem> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<Song> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = { new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal } },
        };
    }
}
