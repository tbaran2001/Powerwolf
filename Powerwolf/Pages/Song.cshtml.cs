using JsonFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Powerwolf.Pages
{
    public class SongModel : PageModel
    {
        public Song SelectedSong { get; set; } = new Song();

        public void OnGet(string songId)
        {
            List<Song> songs = DataAccess.GetSongs();

            // Use LINQ to find the song with the specified ID
            SelectedSong = songs.First(x => x.Id == songId);

            ViewData["Song"] = SelectedSong;
        }
    }
}
