using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponMerchant.Data;
using CouponMerchant.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CouponMerchant.Pages.Services
{
    [Authorize]
    public class HistoryModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public HistoryModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public List<ServiceHeader> ServiceHeader { get; set; }

        public string UserId { get; set; }

        public async Task OnGet(int carId)
        {
            ServiceHeader = await _db.ServiceHeader.Include(s => s.Deal).Include(c => c.Deal.ApplicationUser).Where(c => c.DealId == carId).ToListAsync();

            UserId = _db.Deal.Where(u => u.Id == carId).ToList().FirstOrDefault().UserId;
        }
    }
}