using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponMerchant.Models
{
    public class Deal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public decimal DollarValue { get; set; }

        public string Url { get; set; }

        public int MerchantId { get; set; }

        [ForeignKey("MerchantId")]
        public virtual Merchant Merchant { get; set; }
    }
}
