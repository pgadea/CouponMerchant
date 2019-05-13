using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CouponMerchant.Data;
using CouponMerchant.Models;
using CouponMerchant.Models.ViewModel;
using CouponMerchant.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CouponMerchant.Pages.Merchants
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public MerchantsListViewModel MerchantListVM { get; set; }

        public async Task<IActionResult> OnGet(int productPage = 1, string searchName = null, string searchCity = null, string searchState = null)
        {
            MerchantListVM = new MerchantsListViewModel
            {
                Merchants = await _db.Merchant.ToListAsync()
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
                MerchantListVM.Merchants = await _db.Merchant
                    .Where(x => x.Name.ToLower().Contains(searchName.ToLower())).ToListAsync();
            }
            else
            {
                if (searchCity != null)
                {
                    MerchantListVM.Merchants = await _db.Merchant
                    .Where(x => x.Name.ToLower().Contains(searchCity.ToLower())).ToListAsync();
                }
                else
                {
                    if (searchState != null)
                    {
                        MerchantListVM.Merchants = await _db.Merchant
                        .Where(x => x.Name.ToLower().Contains(searchState.ToLower())).ToListAsync();
                    }
                }
            }

            var count = MerchantListVM.Merchants.Count;

            MerchantListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = SD.PaginationUsersPageSize,
                TotalItems = count,
                UrlParam = param.ToString()
            };

            MerchantListVM.Merchants = MerchantListVM.Merchants.OrderBy(p => p.Name)
                .Skip((productPage - 1) * SD.PaginationUsersPageSize)
                .Take(SD.PaginationUsersPageSize).ToList();

            return Page();
        }
    }
}