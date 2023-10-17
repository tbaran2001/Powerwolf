namespace JsonFiles
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BandMembers
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

    public partial class Concerts
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

    public partial class News
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

    public partial class Songs
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

    public partial class BandMembers
    {
        public static List<BandMembers> FromJson(string json) => JsonConvert.DeserializeObject<List<BandMembers>>(json, JsonFiles.Converter.Settings);
    }

    public partial class Concerts
    {
        public static List<Concerts> FromJson(string json) => JsonConvert.DeserializeObject<List<Concerts>>(json, JsonFiles.Converter.Settings);
    }

    public partial class News
    {
        public static List<News> FromJson(string json) => JsonConvert.DeserializeObject<List<News>>(json, JsonFiles.Converter.Settings);
    }

    public partial class Songs
    {
        public static List<Songs> FromJson(string json) => JsonConvert.DeserializeObject<List<Songs>>(json, JsonFiles.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<BandMembers> self) => JsonConvert.SerializeObject(self, JsonFiles.Converter.Settings);
        public static string ToJson(this List<Concerts> self) => JsonConvert.SerializeObject(self, JsonFiles.Converter.Settings);
        public static string ToJson(this List<News> self) => JsonConvert.SerializeObject(self, JsonFiles.Converter.Settings);
        public static string ToJson(this List<Songs> self) => JsonConvert.SerializeObject(self, JsonFiles.Converter.Settings);
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
