using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponMerchant.Models.ViewModel
{
    public class UsersListViewModel
    {
        public List<ApplicationUser> ApplicationUsers { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
