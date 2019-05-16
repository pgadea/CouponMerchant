using System.Threading.Tasks;
using CouponMerchant.Data;
using CouponMerchant.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CouponMerchant.Pages.Merchants
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Merchant Merchant { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Merchant = await _db.Merchant.FirstOrDefaultAsync(x => x.Id == id);

            if (Merchant == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var merchant = await _db.Merchant.SingleOrDefaultAsync(x => x.Id == Merchant.Id);

            _db.Merchant.Remove(merchant);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}