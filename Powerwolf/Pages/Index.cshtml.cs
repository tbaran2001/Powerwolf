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

        readonly HttpClient client = new HttpClient();
        public void OnGet()
        {
            List<News> news = DataAccess.GetNews();
            List<BandMembers> bandMembers = DataAccess.GetBandMembers();
            List<Concerts> concerts = DataAccess.GetConcerts();
            List<Songs> songs = DataAccess.GetSongs();

            Random random = new Random();

            int index = random.Next(songs.Count);
            Songs randomSong = songs[index];

            ViewData["News"] = news;
            ViewData["BandMembers"] = bandMembers;
            ViewData["Concerts"] = concerts;
            ViewData["Song"] = randomSong;
        }
    }
}