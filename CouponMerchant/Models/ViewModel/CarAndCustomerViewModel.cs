using System.Collections.Generic;

namespace CouponMerchant.Models.ViewModel
{
    public class CarAndCustomerViewModel
    {
        public ApplicationUser UserObj { get; set; }

        public IEnumerable<Deal> Deals { get; set; }
    }
}
