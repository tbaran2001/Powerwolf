using JsonFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Powerwolf.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //Retrieves data and prepares the model for the Index page
        public void OnGet()
        {
            List<NewsItem> newsItems = DataAccess.GetNews();
            List<BandMember> bandMembers = DataAccess.GetBandMembers();
            List<Concert> concerts = DataAccess.GetConcerts();
            List<Song> songs = DataAccess.GetSongs();

            Random random = new Random();
            int index = random.Next(songs.Count);
            Song randomSong = songs[index];

            ViewData["NewsItems"] = newsItems;
            ViewData["BandMembers"] = bandMembers;
            ViewData["Concerts"] = concerts;
            ViewData["RandomSong"] = randomSong;
        }
    }
}