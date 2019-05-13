using System.Collections.Generic;

namespace CouponMerchant.Models.ViewModel
{
    public class CarServiceViewModel
    {
        public Deal Deal { get; set; }
        public ServiceHeader ServiceHeader { get; set; }
        public ServiceDetails ServiceDetails { get; set; }

        public List<ServiceType> ServiceTypesList { get; set; }
        public List<ServiceShoppingCart> ServiceShoppingCart { get; set; }
    }
}
