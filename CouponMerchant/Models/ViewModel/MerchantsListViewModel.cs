using System.Collections.Generic;

namespace CouponMerchant.Models.ViewModel
{
    public class MerchantsListViewModel
    {
        public List<Merchant> Merchants { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
