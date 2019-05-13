using System.Security.Claims;
using System.Threading.Tasks;
using CouponMerchant.Data;
using CouponMerchant.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CouponMerchant.Pages.Deals
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Deal Deal { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet(string userId = null)
        {
            if (userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }

            Deal = new Deal
            {
                UserId = userId
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Deal.Add(Deal);
            await _db.SaveChangesAsync();
            StatusMessage = "Deal has been added successfully.";
            return RedirectToPage("Index", new { userId = Deal.UserId });
        }
    }
}