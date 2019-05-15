using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponMerchant.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        [Display(Name = "Admin")]
        public bool IsAdmin { get; set; }

        public int? MerchantId { get; set; }

        [ForeignKey("MerchantId")]
        public Merchant Merchant { get; set; }
    }
}
