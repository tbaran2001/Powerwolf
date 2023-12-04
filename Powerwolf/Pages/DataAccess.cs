using JsonFiles;

namespace Powerwolf;

public static class DataAccess
{
    public static List<BandMember> GetBandMembers()
    {
        List<BandMember> output = new List<BandMember>();

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jsons/BandMembers.json");

        string jsonString = File.ReadAllText(filePath);
        output = BandMember.FromJson(jsonString);

        return output;
    }


    public static List<Concert> GetConcerts()
    {
        List<Concert> output = new List<Concert>();

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jsons/Concerts.json");

        string jsonString = File.ReadAllText(filePath);
        output = Concert.FromJson(jsonString);

        return output;
    }

    public static List<NewsItem> GetNews()
    {
        List<NewsItem> output = new List<NewsItem>();

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jsons/News.json");

        string jsonString = File.ReadAllText(filePath);
        output = NewsItem.FromJson(jsonString);

        return output;
    }

    public static List<Song> GetSongs()
    {
        List<Song> output = new List<Song>();

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jsons/Songs.json");

        string jsonString = File.ReadAllText(filePath);
        output = Song.FromJson(jsonString);

        return output;
    }
}