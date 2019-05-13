using System.Threading.Tasks;
using CouponMerchant.Data;
using CouponMerchant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CouponMerchant.Pages.Merchants
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Merchant Merchant { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Merchant.Add(Merchant);
            await _db.SaveChangesAsync();
            StatusMessage = "Merhant has been added successfully.";
            return RedirectToPage("Index", new { userId = Merchant.Id });
        }
    }
}