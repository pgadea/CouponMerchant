using System.Collections.Generic;

namespace CouponMerchant.Models.ViewModel
{
    public class UsersListViewModel
    {
        public List<ApplicationUser> ApplicationUsers { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
