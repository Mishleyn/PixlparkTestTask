using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserLogin.Models;

namespace UserLogin.Pages
{
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
        private readonly IHttpContextAccessor _contextAccessor;

        private ApplicationContext _context;

        [BindProperty]
        public User Person { get; set; } = new();

        Random random = new Random();

        public CreateModel(IHttpContextAccessor contextAccessor, ApplicationContext db)
        {
            _contextAccessor = contextAccessor;
            _context = db;
        }

        public async Task<IActionResult> OnPostAsync()
        {            
            Person.ConfirmationCode = random.Next(1000, 10000);

            _contextAccessor.HttpContext
                .Session.SetString("ConfirmationCode", Person.ConfirmationCode.ToString());

            _context.Users.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("ConfirmRegister", new {email = Person.Email});
        }
    }
}
