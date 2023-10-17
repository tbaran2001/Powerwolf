using JsonFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Powerwolf.Pages
{
    public class SongModel : PageModel
    {
        public Songs SelectedSong { get; set; } = new Songs();

        public void OnGet(string songId)
        {
            List<Songs> songs = DataAccess.GetSongs();

            SelectedSong = songs.First(x => x.Id == songId);

            ViewData["Song"] = SelectedSong;
        }
    }
}
