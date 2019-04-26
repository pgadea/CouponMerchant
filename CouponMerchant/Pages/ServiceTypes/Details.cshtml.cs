using System.Threading.Tasks;
using CouponMerchant.Data;
using CouponMerchant.Models;
using CouponMerchant.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CouponMerchant.Pages.ServiceTypes
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ServiceType ServiceType { get; set; }

        public DetailsModel(ApplicationDbContext db)
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
    }
}