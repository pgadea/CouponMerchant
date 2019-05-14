using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CouponMerchant.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        [Display(Name = "Admin")]
        public bool IsAdmin { get; set; }
    }
}
