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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Deal = await _db.Deal
                .Include(c => c.ApplicationUser).FirstOrDefaultAsync(m => m.Id == id);

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
            return RedirectToPage("./Index", new { userId = Deal.UserId });
        }
    }
}