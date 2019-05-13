using Microsoft.AspNetCore.Identity;

namespace CouponMerchant.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
