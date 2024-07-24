using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserLogin.Pages
{
    public class ResultPageModel : PageModel
    {
        public string Message { get; set; } = "";

        public void OnGet(string message)
        {
            Message = $"{message}";
        }
    }
}
