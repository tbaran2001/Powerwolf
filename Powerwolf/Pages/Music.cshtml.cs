using JsonFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Powerwolf.Pages
{
    public class MusicModel : PageModel
    {
        public void OnGet()
        {
            List<Song> songs = DataAccess.GetSongs();

            List<string> albums = new List<string>();

            foreach (Song song in songs)
            {
                if (!albums.Contains(song.Album))
                {
                    albums.Add(song.Album);
                }
            }


            ViewData["Songs"] = songs;
            ViewData["Albums"] = albums;
        }
    }
}
