using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CouponMerchant.Areas.Identity.Pages.Account
{
    public class VerifyEmailModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        public IActionResult OnGet(string id)
        {
            Email = id;
            return Page();
        }
    }
}