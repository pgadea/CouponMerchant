using System.Collections.Generic;

namespace CouponMerchant.Models.ViewModel
{
    public class DealsViewModel
    {
        public List<Deal> Deals { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
