using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UserLogin.Models;

namespace UserLogin.Pages
{
    public class IndexModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            return RedirectToPage("Create");
        }
    }
}
