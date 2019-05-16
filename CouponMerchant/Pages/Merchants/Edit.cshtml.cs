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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Merchant Merchant { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Merchant = await _db.Merchant.FirstOrDefaultAsync(m => m.Id == id);

            if (Merchant == null)
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
            else
            {
                var merchant = await _db.Merchant.SingleOrDefaultAsync(u => u.Id == Merchant.Id);
                if (merchant == null)
                {
                    return NotFound();
                }
                else
                {
                    merchant.Name = Merchant.Name;
                    merchant.Email = Merchant.Email;
                    merchant.PhoneNumber = Merchant.PhoneNumber;
                    merchant.Address = Merchant.Address;
                    merchant.City = Merchant.City;
                    merchant.State = Merchant.State;
                    merchant.PostalCode = Merchant.PostalCode;

                    await _db.SaveChangesAsync();
                    return RedirectToPage("Index");
                }
            }
        }
    }
}