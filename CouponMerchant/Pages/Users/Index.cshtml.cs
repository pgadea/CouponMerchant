using System;
using System.Collections.Generic;
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

namespace CouponMerchant.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public UsersListViewModel UsersListVM { get; set; }

        public async Task<IActionResult> OnGet(int productPage = 1, string searchEmail = null, string searchName = null, string searchPhone = null)
        {
            UsersListVM = new UsersListViewModel
            {
                ApplicationUsers = await _db.ApplicationUser.ToListAsync()
            };

            var param = new StringBuilder();
            param.Append("/Users?productPage=:");
            param.Append("&searchEmail=");
            if (searchEmail != null)
            {
                param.Append(searchEmail);
            }
            param.Append("&searchName=");
            if (searchName != null)
            {
                param.Append(searchName);
            }
            if (searchPhone != null)
            {
                param.Append(searchPhone);
            }

            if (searchEmail != null)
            {
                UsersListVM.ApplicationUsers = await _db.ApplicationUser
                    .Where(u => u.Email.ToLower().Contains(searchEmail.ToLower())).ToListAsync();
            }
            else
            {
                if (searchName != null)
                {
                    UsersListVM.ApplicationUsers = await _db.ApplicationUser
                        .Where(u => u.Name.ToLower().Contains(searchName.ToLower())).ToListAsync();
                }
                else
                {
                    if (searchPhone != null)
                    {
                        UsersListVM.ApplicationUsers = await _db.ApplicationUser
                            .Where(u => u.PhoneNumber.Contains(searchPhone)).ToListAsync();
                    }
                }
            }

            var count = UsersListVM.ApplicationUsers.Count;

            UsersListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = SD.PaginationUsersPageSize,
                TotalItems = count,
                UrlParam = param.ToString()
            };

            UsersListVM.ApplicationUsers = UsersListVM.ApplicationUsers.OrderBy(p => p.Email)
                .Skip((productPage - 1) * SD.PaginationUsersPageSize)
                .Take(SD.PaginationUsersPageSize).ToList();

            return Page();
        }
    }
}