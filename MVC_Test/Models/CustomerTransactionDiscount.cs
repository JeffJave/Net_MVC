using System;
using System.Collections.Generic;

namespace MVC_Test.Models;

public partial class CustomerTransactionDiscount
{
    public Guid Id { get; set; }

    public Guid CustomerTransactionId { get; set; }

    public double? Discount { get; set; }

    public double? DiscountRate { get; set; }

    public string DiscountTypeCode { get; set; } = null!;

    public string? CouponSerialNumber { get; set; }

    public virtual ShopDiscountCoupon? CouponSerialNumberNavigation { get; set; }

    public virtual CustomerTransaction CustomerTransaction { get; set; } = null!;
}
