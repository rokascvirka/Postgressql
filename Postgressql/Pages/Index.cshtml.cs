using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Postgressql.Interfaces;
using Postgressql.Models;

namespace Postgressql.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ISessionService _sessionService;

        [BindProperty]

        public int SessionId { get; set; }

        [BindProperty]
        public string ReturnUrl { get; set; }

        [BindProperty]
        public string Token { get; set; }

        public Session RetrievedSession { get; set; }
        public IndexModel(ISessionService session)
        {
            _sessionService = session;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostDeleteSessionAsync()
        {
            await _sessionService.DeleteSessionByIdAsync(SessionId);
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostUpdateReturnUrlAsync()
        {
            await _sessionService.UpdateSessionByIdAsync(SessionId, ReturnUrl);
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostGetBySessionTokenAsync()
        {
            RetrievedSession = await _sessionService.GetBySessionTokenAsync(Token);
            return Page();
        }
    }
}