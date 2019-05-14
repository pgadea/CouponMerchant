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

        //public async Task<IActionResult> OnGet(string merchantId = null)
        //{
        //    if (merchantId == null)
        //    {
        //        return Page();
        //    }

        //    DealsVM = new DealsViewModel
        //    {
        //        Deals = await _db.Deal.Where(c => c.UserId == userId).ToListAsync(),
        //    };

        //    return Page();
        //}

        public async Task<IActionResult> OnGet(int productPage = 1, string searchName = null, string searchCity = null, string searchState = null)
        {
            DealsVM = new DealsViewModel
            {
                Deals = await _db.Deal.ToListAsync()
            };

            var param = new StringBuilder();
            param.Append("/Merchants?productPage=:");
            param.Append("&searchName=");
            if (searchName != null)
            {
                param.Append(searchName);
            }
            param.Append("&searchCity=");
            if (searchCity != null)
            {
                param.Append(searchCity);
            }
            param.Append("&searchState=");
            if (searchState != null)
            {
                param.Append(searchState);
            }

            if (searchName != null)
            {
                DealsVM.Deals = await _db.Deal
                    .Where(x => x.Name.ToLower().Contains(searchName.ToLower())).ToListAsync();
            }
            else
            {
                if (searchCity != null)
                {
                    DealsVM.Deals = await _db.Deal
                    .Where(x => x.Name.ToLower().Contains(searchCity.ToLower())).ToListAsync();
                }
                else
                {
                    if (searchState != null)
                    {
                        DealsVM.Deals = await _db.Deal
                        .Where(x => x.Name.ToLower().Contains(searchState.ToLower())).ToListAsync();
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