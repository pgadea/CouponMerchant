using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CouponMerchant.Data;
using CouponMerchant.Models;

namespace CouponMerchant.Pages.ServiceTypes
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ServiceType ServiceType { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServiceType = await _db.ServiceType.FirstOrDefaultAsync(m => m.Id == id);

            if (ServiceType == null)
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

            var serviceFromDb = await _db.ServiceType.FirstOrDefaultAsync(s => s.Id == ServiceType.Id);
            serviceFromDb.Name = ServiceType.Name;
            serviceFromDb.Price = ServiceType.Price;
            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
