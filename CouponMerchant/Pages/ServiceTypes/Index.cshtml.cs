using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponMerchant.Data;
using CouponMerchant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CouponMerchant.Pages.ServiceTypes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IList<ServiceType> ServiceType { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet()
        {
            ServiceType = await _db.ServiceType.ToListAsync();
            return Page();
        }
    }
}