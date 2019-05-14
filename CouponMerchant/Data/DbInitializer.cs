using CouponMerchant.Models;
using CouponMerchant.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CouponMerchant.Data
{
    public class DbInitializer : IDbInitializer
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }

            if (_db.Roles.Any(r => r.Name == SD.AdminEndUser)) return;

            _roleManager.CreateAsync(new IdentityRole(SD.AdminEndUser)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.CustomerEndUser)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "pierre.gadea@strategycorps.com",
                Email = "pierre.gadea@strategycorps.com",
                Name = "Pierre Gadea",
                EmailConfirmed = true,
                PhoneNumber = "6153082981"
            }, "Admin123*").GetAwaiter().GetResult();


            _userManager.AddToRoleAsync(_db.Users.FirstOrDefaultAsync(u => u.Email == "pierre.gadea@strategycorps.com")
                .GetAwaiter().GetResult(), SD.AdminEndUser).GetAwaiter().GetResult();

        }
    }
}
