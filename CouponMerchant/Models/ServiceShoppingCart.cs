using System.ComponentModel.DataAnnotations.Schema;

namespace CouponMerchant.Models
{
    public class ServiceShoppingCart
    {
        public int Id { get; set; }

        public int DealId { get; set; }

        public int ServiceTypeId { get; set; }

        [ForeignKey("DealId")]
        public virtual Deal Deal { get; set; }

        [ForeignKey("ServiceTypeId")]
        public virtual ServiceType ServiceType { get; set; }
    }
}
