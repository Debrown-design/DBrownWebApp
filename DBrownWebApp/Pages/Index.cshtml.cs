using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBrownWebApp.Pages
{
    public class IndexModel : PageModel
    {

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
