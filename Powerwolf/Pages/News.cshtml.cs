using JsonFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Powerwolf.Pages
{
    public class NewsModel : PageModel
    {
        public void OnGet()
        {
            List<NewsItem> news = DataAccess.GetNews();

            ViewData["News"] = news;
        }
    }
}
