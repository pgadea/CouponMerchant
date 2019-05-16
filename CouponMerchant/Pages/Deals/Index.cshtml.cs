using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CouponMerchant.Data;
using CouponMerchant.Models;
using CouponMerchant.Models.ViewModel;
using CouponMerchant.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CouponMerchant.Pages.Deals
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public DealsViewModel DealsVM { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        private async Task<ApplicationUser> GetUser()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            return await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == claim.Value);
        }

        public async Task<IActionResult> OnGet(int productPage = 1, string searchName = null, string searchStartDate = null, string searchEndDate = null)
        {
            var user = await GetUser();
            DealsVM = new DealsViewModel
            {
                Deals = await _db.Deal.Where(x => x.MerchantId == user.MerchantId || user.IsAdmin).ToListAsync()
            };

            var param = new StringBuilder();
            param.Append("/Merchants?productPage=:");
            param.Append("&searchName=");
            if (searchName != null)
            {
                param.Append(searchName);
            }
            param.Append("&searchCity=");
            if (searchStartDate != null)
            {
                param.Append(searchStartDate);
            }
            param.Append("&searchState=");
            if (searchEndDate != null)
            {
                param.Append(searchEndDate);
            }

            if (searchName != null)
            {
                DealsVM.Deals = await _db.Deal
                    .Where(x => x.Name.ToLower().Contains(searchName.ToLower()) && (user.IsAdmin || x.MerchantId == user.MerchantId)).ToListAsync();
            }
            else
            {
                if (searchStartDate != null)
                {
                    var startDate = DateTime.TryParse(searchStartDate, out var result) ? result : default;
                    DealsVM.Deals = await _db.Deal
                    .Where(x => x.StartDate == startDate && (user.IsAdmin || x.MerchantId == user.MerchantId)).ToListAsync();
                }
                else
                {
                    if (searchEndDate != null)
                    {
                        var endDate = DateTime.TryParse(searchEndDate, out var result) ? result : default;
                        DealsVM.Deals = await _db.Deal
                        .Where(x => x.EndDate == endDate && (user.IsAdmin || x.MerchantId == user.MerchantId)).ToListAsync();
                    }
                }
            }

            var count = DealsVM.Deals.Count;

            DealsVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = SD.PaginationUsersPageSize,
                TotalItems = count,
                UrlParam = param.ToString()
            };

            DealsVM.Deals = DealsVM.Deals.OrderBy(p => p.Name)
                .Skip((productPage - 1) * SD.PaginationUsersPageSize)
                .Take(SD.PaginationUsersPageSize).ToList();

            return Page();
        }
    }
}