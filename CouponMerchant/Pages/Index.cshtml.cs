using System.Security.Claims;
using CouponMerchant.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CouponMerchant.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            if (User.IsInRole(SD.AdminEndUser))
            {
                return RedirectToPage("/Users/Index");
            }

            return RedirectToPage("/Deals/Index");
        }
    }
}
