
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventPopper.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Coupon Name")]
        public string CouponCategory { get; set; }
        
        [Display(Name = "Coupon Code")]
        public string CouponName { get; set; }

        public DateTime? Validity { get; set; }

        public int Discount { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
            