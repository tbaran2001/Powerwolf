using JsonFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Powerwolf.Pages
{
    public class BandMembersModel : PageModel
    {
        public void OnGet()
        {
            List<BandMember> bandMembers = DataAccess.GetBandMembers();

            ViewData["BandMembers"] = bandMembers;
        }
        public void OnReload()
        {

        }
    }
}
