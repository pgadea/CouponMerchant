using System.Security.Claims;
using System.Threading.Tasks;
using CouponMerchant.Data;
using CouponMerchant.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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

        private async Task<ApplicationUser> GetUser()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            return await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == claim.Value);
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await GetUser();

            if (user.IsAdmin)
            {
                StatusMessage = "Currenlty only merchant users may add deals.";
                return RedirectToPage("Index");
            }

            Deal = new Deal
            {
                MerchantId = user.MerchantId ?? 1 //TODO: update this to work for admin users
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
            return RedirectToPage("Index");
        }
    }
}