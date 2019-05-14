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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        public string StatusMessage { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Deal Deal { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Deal = await _db.Deal
                .Include(c => c.Merchant).FirstOrDefaultAsync(m => m.Id == id);

            if (Deal == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Deal == null)
            {
                return NotFound();
            }
            var merchantId = Deal.MerchantId;

            _db.Deal.Remove(Deal);
            await _db.SaveChangesAsync();
            StatusMessage = "Deal deleted successfully.";
            return RedirectToPage("./Index", new { merchantId });
        }
    }
}