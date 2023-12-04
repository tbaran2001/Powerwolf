namespace JsonFiles
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BandMember
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Nickname")]
        public string Nickname { get; set; }

        [JsonProperty("Role")]
        public string Role { get; set; }

        [JsonProperty("DateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("Description")]
        public String Description { get; set; }

        [JsonProperty("FacePhoto")]
        public string FacePhoto { get; set; }
    }

    public partial class Concert
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("TicketLink")]
        public string TicketLink { get; set; }
    }

    public partial class NewsItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("ShortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("LongDescription")]
        public string LongDescription { get; set; }
    }

    public partial class Song
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Album")]
        public string Album { get; set; }

        [JsonProperty("RelaseDate")]
        public string RelaseDate { get; set; }

        [JsonProperty("Lyrics")]
        public string Lyrics { get; set; }

        [JsonProperty("SpotifyLink")]
        public string SpotifyLink { get; set; }

        [JsonProperty("YouTubeLink")]
        public string YouTubeLink { get; set; }
    }

    // Class definition for BandMember
    public partial class BandMember
    {
        // Static method to deserialize BandMember from JSON
        public static List<BandMember> FromJson(string json) => JsonConvert.DeserializeObject<List<BandMember>>(json, JsonFiles.Converter.Settings);
    }

    // Legal: Class definition for Concert (partial)
    public partial class Concert
    {
        // Legal: Static method to deserialize Concert from JSON
        public static List<Concert> FromJson(string json) => JsonConvert.DeserializeObject<List<Concert>>(json, JsonFiles.Converter.Settings);
    }

    // Legal: Class definition for NewsItem (partial)
    public partial class NewsItem
    {
        // Legal: Static method to deserialize NewsItem from JSON
        public static List<NewsItem> FromJson(string json) => JsonConvert.DeserializeObject<List<NewsItem>>(json, JsonFiles.Converter.Settings);
    }

    // Legal: Class definition for Song (partial)
    public partial class Song
    {
        // Legal: Static method to deserialize Song from JSON
        public static List<Song> FromJson(string json) => JsonConvert.DeserializeObject<List<Song>>(json, JsonFiles.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<BandMember> self) => JsonConvert.SerializeObject(self, JsonFiles.Converter.Settings);
        public static string ToJson(this List<Concert> self) => JsonConvert.SerializeObject(self, JsonFiles.Converter.Settings);
        public static string ToJson(this List<NewsItem> self) => JsonConvert.SerializeObject(self, JsonFiles.Converter.Settings);
        public static string ToJson(this List<Song> self) => JsonConvert.SerializeObject(self, JsonFiles.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
