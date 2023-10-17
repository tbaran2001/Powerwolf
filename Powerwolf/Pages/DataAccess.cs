using JsonFiles;

namespace Powerwolf;

public static class DataAccess
{
    public static List<BandMembers> GetBandMembers()
    {
        List<BandMembers> output = new List<BandMembers>();

        // Get the path to the BandMembers.json file within the project
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jsons/BandMembers.json");

        string jsonString = File.ReadAllText(filePath);
        output = BandMembers.FromJson(jsonString);

        return output;
    }


    public static List<Concerts> GetConcerts()
    {
        List<Concerts> output = new List<Concerts>();

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jsons/Concerts.json");

        string jsonString = File.ReadAllText(filePath);
        output = Concerts.FromJson(jsonString);

        return output;
    }

    public static List<News> GetNews()
    {
        List<News> output = new List<News>();

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jsons/News.json");

        string jsonString = File.ReadAllText(filePath);
        output = News.FromJson(jsonString);

        return output;
    }

    public static List<Songs> GetSongs()
    {
        List<Songs> output = new List<Songs>();

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jsons/Songs.json");

        string jsonString = File.ReadAllText(filePath);
        output = Songs.FromJson(jsonString);

        return output;
    }
}