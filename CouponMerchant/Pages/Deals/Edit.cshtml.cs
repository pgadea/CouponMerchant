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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        public string StatusMessage { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Deal Deal { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var user = await GetUser();
            Deal = await _db.Deal
                .Include(c => c.Merchant).FirstOrDefaultAsync(m => m.Id == id);

            if (!user.IsAdmin)
            {
                if (user.MerchantId != Deal.MerchantId)
                {
                    StatusMessage = "Only Admin users or deal owning merchants may edit a deal.";
                }
            }

            if (Deal == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(Deal).State = EntityState.Modified;

            await _db.SaveChangesAsync();
            StatusMessage = "Deal updated successfully.";
            return RedirectToPage("./Index", new { merchantId = Deal.MerchantId });
        }

        private async Task<ApplicationUser> GetUser()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            return await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == claim.Value);
        }
    }
}